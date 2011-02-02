using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Threading;
using System.Management;
using System.Runtime.InteropServices;

namespace TweakTool
{
    public partial class MainForm : Form
    {
        // DIFx framework binding
        [DllImport("DIFxAPI.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern Int32 DriverPackageUninstall([MarshalAs(UnmanagedType.LPTStr)] string DriverPackageInfPath, Int32 Flags, IntPtr pInstallerInfo, out bool pNeedReboot);

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public struct INSTALLERINFO
        {
            [MarshalAs(UnmanagedType.LPTStr)]
            public string pApplicationId;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string pDisplayName;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string pProductName;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string pMfgName;
        }

        const Int32 DRIVER_PACKAGE_REPAIR = 0x00000001;
        const Int32 DRIVER_PACKAGE_SILENT = 0x00000002;
        const Int32 DRIVER_PACKAGE_FORCE = 0x00000004;
        const Int32 DRIVER_PACKAGE_ONLY_IF_DEVICE_PRESENT = 0x00000008;
        const Int32 DRIVER_PACKAGE_LEGACY_MODE = 0x00000010;
        const Int32 DRIVER_PACKAGE_DELETE_FILES = 0x00000020;

        const Int32 ERROR_SUCCESS = 0;
        const Int32 ERROR_FILE_NOT_FOUND = 2;
        const Int32 ERROR_ACCESS_DENIED = 5;
        const Int32 ERROR_CANT_ACCESS_FILE = 1920;
        // A lot of error codes are missing here ... to map more of them see: http://msdn.microsoft.com/en-us/library/ms681381(v=VS.85).aspx?appId=Dev10IDEF1&l=EN-US&k=k

        public MainForm()
        {
            InitializeComponent();
        }
        
        private bool GetDrivers()
        {
            // *) Remove old entries from list
            listDrivers.Items.Clear();

            // *) Hourglass cursor
            Cursor.Current = Cursors.WaitCursor;

            // *) Query WMI interface for signed drivers (For all properties see: http://msdn.microsoft.com/en-us/library/aa394354(v=VS.85).aspx)
            System.Management.SelectQuery oQuery                 = new System.Management.SelectQuery("Win32_PnPSignedDriver");
            System.Management.ManagementObjectSearcher oSearcher = new System.Management.ManagementObjectSearcher(oQuery);

            // *) Loop through query results
            foreach (System.Management.ManagementObject oManageObject in oSearcher.Get())
            {
                // -) Check for valid result
                String szInfName = oManageObject["InfName"] != null ? oManageObject["InfName"].ToString() : "";
                if (!szInfName.StartsWith("oem") || !szInfName.EndsWith(".inf"))
                // => No third party driver
                    continue;

                // -) Convert driver date
                String szDriverDate = oManageObject["DriverDate"] != null ? 
                    System.Management.ManagementDateTimeConverter.ToDateTime(oManageObject["DriverDate"].ToString()).ToString("dd.MM.yyyy") :
                    "n/a";
                
                // -) Add items to our list
                //
                // => Create main item
                ListViewItem oListItem1 = new ListViewItem(oManageObject["DeviceName"] != null ? oManageObject["DeviceName"].ToString() : "n/a");

                // => Subitem collection for additional columns
                ListViewItem.ListViewSubItemCollection oListCollection = new ListViewItem.ListViewSubItemCollection(oListItem1);

                ListViewItem.ListViewSubItem oListItem2 = new ListViewItem.ListViewSubItem(oListItem1, szDriverDate);
                ListViewItem.ListViewSubItem oListItem3 = new ListViewItem.ListViewSubItem(oListItem1, oManageObject["DriverVersion"] != null ? oManageObject["DriverVersion"].ToString() : "n/a");
                ListViewItem.ListViewSubItem oListItem4 = new ListViewItem.ListViewSubItem(oListItem1, oManageObject["Manufacturer"] != null ? oManageObject["Manufacturer"].ToString() : "n/a");
                ListViewItem.ListViewSubItem oListItem5 = new ListViewItem.ListViewSubItem(oListItem1, szInfName);

                // => Add subitem collection
                oListCollection.Add(oListItem2);
                oListCollection.Add(oListItem3);
                oListCollection.Add(oListItem4);
                oListCollection.Add(oListItem5);

                // => Add new row to driver list
                listDrivers.Items.Add(oListItem1);
            }

            // *) Return to normal cursor
            Cursor.Current = Cursors.Default;

            return true;
        }

        // Calls DriverPackageUninstall() from DIFx framework (See: http://msdn.microsoft.com/en-us/library/ff544822(v=VS.85).aspx)
        private Int32 UninstallDriver(string szInfFile, ref bool bNeedReboot)
        {
            Int32 nFlags = DRIVER_PACKAGE_SILENT | DRIVER_PACKAGE_DELETE_FILES;

            return DriverPackageUninstall(szInfFile, nFlags, IntPtr.Zero, out bNeedReboot);
        }

        private void buttonRemoveSelectedDrivers_Click(object sender, EventArgs e)
        {
            if (listDrivers.CheckedItems.Count == 0)
                return;

            // *) Hourglass cursor
            Cursor.Current = Cursors.WaitCursor;

            // *) Get Windows inf path
            string szInfPath = Environment.GetEnvironmentVariable("SystemRoot") + @"\inf";

            // *) Loop trough list items
            string[] szErrorInfs  = new string[listDrivers.Items.Count];
            bool bRebootNeeded    = false;

            int nErrors      = 0,
                nUninstalled = 0;

            foreach (ListViewItem oListItem in listDrivers.CheckedItems)
            {
                if (!oListItem.Checked)
                // => not checked
                    continue;

                // -) Fetch inf filename from subitems
                ListViewItem.ListViewSubItem oListItem5 = oListItem.SubItems[4];

                string szInfFile = oListItem5.Text;

                // -) Uninstall driver
                bool bNeedReboot = false;

                Int32 nResult = UninstallDriver(szInfPath+@"\"+szInfFile, ref bNeedReboot);
                if (nResult != ERROR_SUCCESS)
                // => This part of the code could use definitely a better error processing!
                    szErrorInfs[nErrors++] = szInfFile + " (" + nResult.ToString() + ")";
                else
                {
                    nUninstalled++;

                    if (bNeedReboot)
                        bRebootNeeded = true;
                }
            }

            // *) Return to normal cursor
            Cursor.Current = Cursors.Default;

            // *) Show error messages
            if (nErrors > 0)
            {
                // -) Implode erroneous inf files to one string
                string szErrors = "";

                foreach (string szError in szErrorInfs)
                {
                    if (szErrors != "")
                        szErrors += " ";

                    szErrors += szError;
                }

                // -) Show awful messagebox
                MessageBox.Show("Could not uninstall following drivers: "+szErrors,"Error",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
            else
            if (nUninstalled > 0)
                MessageBox.Show(nUninstalled.ToString()+" drivers successfully removed from the driver store!","Notice",MessageBoxButtons.OK,MessageBoxIcon.Information);

            // *) Reboot notice
            if (bRebootNeeded)
            {
                if (MessageBox.Show("You should reboot now to see any changes! Save your data and continue ...", "Notice", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start("ShutDown", "/r");
                    return;
                }
            }

            // *) Reload drivers
            if (!GetDrivers())
                MessageBox.Show("Could not reload drivers!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            if (!GetDrivers())
                MessageBox.Show("Could not load drivers!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void linkLabelOC_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.overclockers.at");
        }
    }
}
