namespace TweakTool
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageDrivers = new System.Windows.Forms.TabPage();
            this.listDrivers = new System.Windows.Forms.ListView();
            this.columnDeviceName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnDriverDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnDriverVersion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnManufacturer = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnInfName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.labelDrivers = new System.Windows.Forms.Label();
            this.buttonRemoveSelectedDrivers = new System.Windows.Forms.Button();
            this.tabPageInfo = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.linkLabelOC = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabControl1.SuspendLayout();
            this.tabPageDrivers.SuspendLayout();
            this.tabPageInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageDrivers);
            this.tabControl1.Controls.Add(this.tabPageInfo);
            this.tabControl1.Location = new System.Drawing.Point(-3, -1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(644, 377);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPageDrivers
            // 
            this.tabPageDrivers.Controls.Add(this.listDrivers);
            this.tabPageDrivers.Controls.Add(this.labelDrivers);
            this.tabPageDrivers.Controls.Add(this.buttonRemoveSelectedDrivers);
            this.tabPageDrivers.Location = new System.Drawing.Point(4, 22);
            this.tabPageDrivers.Name = "tabPageDrivers";
            this.tabPageDrivers.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDrivers.Size = new System.Drawing.Size(636, 351);
            this.tabPageDrivers.TabIndex = 0;
            this.tabPageDrivers.Text = "Drivers";
            this.tabPageDrivers.UseVisualStyleBackColor = true;
            // 
            // listDrivers
            // 
            this.listDrivers.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.listDrivers.AllowColumnReorder = true;
            this.listDrivers.CheckBoxes = true;
            this.listDrivers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnDeviceName,
            this.columnDriverDate,
            this.columnDriverVersion,
            this.columnManufacturer,
            this.columnInfName});
            this.listDrivers.FullRowSelect = true;
            this.listDrivers.Location = new System.Drawing.Point(11, 23);
            this.listDrivers.Name = "listDrivers";
            this.listDrivers.Size = new System.Drawing.Size(614, 291);
            this.listDrivers.TabIndex = 2;
            this.listDrivers.UseCompatibleStateImageBehavior = false;
            this.listDrivers.View = System.Windows.Forms.View.Details;
            // 
            // columnDeviceName
            // 
            this.columnDeviceName.Text = "Device";
            this.columnDeviceName.Width = 250;
            // 
            // columnDriverDate
            // 
            this.columnDriverDate.Text = "Driver Date";
            this.columnDriverDate.Width = 70;
            // 
            // columnDriverVersion
            // 
            this.columnDriverVersion.Text = "Version";
            this.columnDriverVersion.Width = 100;
            // 
            // columnManufacturer
            // 
            this.columnManufacturer.Text = "Manufacturer";
            this.columnManufacturer.Width = 120;
            // 
            // columnInfName
            // 
            this.columnInfName.Text = "Inf File";
            // 
            // labelDrivers
            // 
            this.labelDrivers.AutoSize = true;
            this.labelDrivers.Location = new System.Drawing.Point(5, 7);
            this.labelDrivers.Name = "labelDrivers";
            this.labelDrivers.Size = new System.Drawing.Size(43, 13);
            this.labelDrivers.TabIndex = 4;
            this.labelDrivers.Text = "Drivers:";
            // 
            // buttonRemoveSelectedDrivers
            // 
            this.buttonRemoveSelectedDrivers.Location = new System.Drawing.Point(242, 320);
            this.buttonRemoveSelectedDrivers.Name = "buttonRemoveSelectedDrivers";
            this.buttonRemoveSelectedDrivers.Size = new System.Drawing.Size(153, 23);
            this.buttonRemoveSelectedDrivers.TabIndex = 3;
            this.buttonRemoveSelectedDrivers.Text = "Remove selected drivers";
            this.buttonRemoveSelectedDrivers.UseVisualStyleBackColor = true;
            this.buttonRemoveSelectedDrivers.Click += new System.EventHandler(this.buttonRemoveSelectedDrivers_Click);
            // 
            // tabPageInfo
            // 
            this.tabPageInfo.Controls.Add(this.label2);
            this.tabPageInfo.Controls.Add(this.linkLabelOC);
            this.tabPageInfo.Controls.Add(this.label1);
            this.tabPageInfo.Controls.Add(this.pictureBox1);
            this.tabPageInfo.Location = new System.Drawing.Point(4, 22);
            this.tabPageInfo.Name = "tabPageInfo";
            this.tabPageInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageInfo.Size = new System.Drawing.Size(636, 351);
            this.tabPageInfo.TabIndex = 1;
            this.tabPageInfo.Text = "Info";
            this.tabPageInfo.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(23, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(566, 58);
            this.label2.TabIndex = 3;
            this.label2.Text = "This tool can destroy your system configuration.\r\nMake backups and use it at your" +
                " own risk!";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // linkLabelOC
            // 
            this.linkLabelOC.AutoSize = true;
            this.linkLabelOC.Location = new System.Drawing.Point(249, 309);
            this.linkLabelOC.Name = "linkLabelOC";
            this.linkLabelOC.Size = new System.Drawing.Size(138, 13);
            this.linkLabelOC.TabIndex = 2;
            this.linkLabelOC.TabStop = true;
            this.linkLabelOC.Text = "http://www.overclockers.at";
            this.linkLabelOC.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelOC_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 131);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(198, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "A project by the community of:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::TweakTool.Properties.Resources.oc_logo;
            this.pictureBox1.Location = new System.Drawing.Point(11, 162);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(592, 144);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 372);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "MainForm";
            this.Text = "overclockers.at TweakTool";
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.tabControl1.ResumeLayout(false);
            this.tabPageDrivers.ResumeLayout(false);
            this.tabPageDrivers.PerformLayout();
            this.tabPageInfo.ResumeLayout(false);
            this.tabPageInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageDrivers;
        private System.Windows.Forms.TabPage tabPageInfo;
        private System.Windows.Forms.Label labelDrivers;
        private System.Windows.Forms.Button buttonRemoveSelectedDrivers;
        private System.Windows.Forms.ListView listDrivers;
        private System.Windows.Forms.ColumnHeader columnDeviceName;
        private System.Windows.Forms.ColumnHeader columnDriverDate;
        private System.Windows.Forms.ColumnHeader columnDriverVersion;
        private System.Windows.Forms.ColumnHeader columnManufacturer;
        private System.Windows.Forms.ColumnHeader columnInfName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel linkLabelOC;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;

    }
}

