namespace PickerTool
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.Button_Delay = new System.Windows.Forms.ToolStripDropDownButton();
            this.MenuItemDelay0 = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemDelay1 = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemDelay2 = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemDelay3 = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemDelay4 = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemDelay5 = new System.Windows.Forms.ToolStripMenuItem();
            this.Button_Cancel = new System.Windows.Forms.ToolStripButton();
            this.Button_Pick = new System.Windows.Forms.ToolStripButton();
            this.PanelResults = new PickerTool.ucGradientPanel();
            this.LabelInfo = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            this.PanelResults.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Button_Pick,
            this.Button_Delay,
            this.Button_Cancel});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(317, 40);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // Button_Delay
            // 
            this.Button_Delay.AutoSize = false;
            this.Button_Delay.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemDelay0,
            this.MenuItemDelay1,
            this.MenuItemDelay2,
            this.MenuItemDelay3,
            this.MenuItemDelay4,
            this.MenuItemDelay5});
            this.Button_Delay.Image = global::PickerTool.Properties.Resources.delay;
            this.Button_Delay.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.Button_Delay.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Button_Delay.Name = "Button_Delay";
            this.Button_Delay.Size = new System.Drawing.Size(84, 37);
            this.Button_Delay.Text = "&Delay";
            this.Button_Delay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Button_Delay.ToolTipText = "Delay pick selection";
            // 
            // MenuItemDelay0
            // 
            this.MenuItemDelay0.Checked = true;
            this.MenuItemDelay0.CheckOnClick = true;
            this.MenuItemDelay0.CheckState = System.Windows.Forms.CheckState.Checked;
            this.MenuItemDelay0.Name = "MenuItemDelay0";
            this.MenuItemDelay0.Size = new System.Drawing.Size(80, 22);
            this.MenuItemDelay0.Text = "0";
            this.MenuItemDelay0.Click += new System.EventHandler(this.MenuItemDelay0_Click);
            // 
            // MenuItemDelay1
            // 
            this.MenuItemDelay1.CheckOnClick = true;
            this.MenuItemDelay1.Name = "MenuItemDelay1";
            this.MenuItemDelay1.Size = new System.Drawing.Size(80, 22);
            this.MenuItemDelay1.Text = "1";
            this.MenuItemDelay1.Click += new System.EventHandler(this.MenuItemDelay1_Click);
            // 
            // MenuItemDelay2
            // 
            this.MenuItemDelay2.CheckOnClick = true;
            this.MenuItemDelay2.Name = "MenuItemDelay2";
            this.MenuItemDelay2.Size = new System.Drawing.Size(80, 22);
            this.MenuItemDelay2.Text = "2";
            this.MenuItemDelay2.Click += new System.EventHandler(this.MenuItemDelay2_Click);
            // 
            // MenuItemDelay3
            // 
            this.MenuItemDelay3.CheckOnClick = true;
            this.MenuItemDelay3.Name = "MenuItemDelay3";
            this.MenuItemDelay3.Size = new System.Drawing.Size(80, 22);
            this.MenuItemDelay3.Text = "3";
            this.MenuItemDelay3.Click += new System.EventHandler(this.MenuItemDelay3_Click);
            // 
            // MenuItemDelay4
            // 
            this.MenuItemDelay4.CheckOnClick = true;
            this.MenuItemDelay4.Name = "MenuItemDelay4";
            this.MenuItemDelay4.Size = new System.Drawing.Size(80, 22);
            this.MenuItemDelay4.Text = "4";
            this.MenuItemDelay4.Click += new System.EventHandler(this.MenuItemDelay4_Click);
            // 
            // MenuItemDelay5
            // 
            this.MenuItemDelay5.CheckOnClick = true;
            this.MenuItemDelay5.Name = "MenuItemDelay5";
            this.MenuItemDelay5.Size = new System.Drawing.Size(80, 22);
            this.MenuItemDelay5.Text = "5";
            this.MenuItemDelay5.Click += new System.EventHandler(this.MenuItemDelay5_Click);
            // 
            // Button_Cancel
            // 
            this.Button_Cancel.AutoSize = false;
            this.Button_Cancel.Image = global::PickerTool.Properties.Resources.cancel;
            this.Button_Cancel.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.Button_Cancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Button_Cancel.Name = "Button_Cancel";
            this.Button_Cancel.Size = new System.Drawing.Size(84, 37);
            this.Button_Cancel.Text = "&Cancel";
            this.Button_Cancel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Button_Cancel.ToolTipText = "Cancel pick";
            this.Button_Cancel.Click += new System.EventHandler(this.Button_Cancel_Click);
            // 
            // Button_Pick
            // 
            this.Button_Pick.AutoSize = false;
            this.Button_Pick.Image = global::PickerTool.Properties.Resources.color_picker_black32;
            this.Button_Pick.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.Button_Pick.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Button_Pick.Name = "Button_Pick";
            this.Button_Pick.Size = new System.Drawing.Size(84, 37);
            this.Button_Pick.Text = "&Pick";
            this.Button_Pick.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Button_Pick.ToolTipText = "New pick";
            this.Button_Pick.Click += new System.EventHandler(this.Button_Pick_Click);
            // 
            // PanelResults
            // 
            this.PanelResults.Color1 = System.Drawing.Color.White;
            this.PanelResults.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(230)))), ((int)(((byte)(240)))));
            this.PanelResults.Controls.Add(this.LabelInfo);
            this.PanelResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelResults.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.PanelResults.Location = new System.Drawing.Point(0, 40);
            this.PanelResults.Name = "PanelResults";
            this.PanelResults.Size = new System.Drawing.Size(317, 45);
            this.PanelResults.TabIndex = 1;
            // 
            // LabelInfo
            // 
            this.LabelInfo.BackColor = System.Drawing.Color.Transparent;
            this.LabelInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LabelInfo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelInfo.Location = new System.Drawing.Point(0, 0);
            this.LabelInfo.Name = "LabelInfo";
            this.LabelInfo.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.LabelInfo.Size = new System.Drawing.Size(317, 45);
            this.LabelInfo.TabIndex = 0;
            this.LabelInfo.Text = "Select the pick button from the menu to start.\r\nVisit http://00laboratories.com/ " +
    "for more information.";
            this.LabelInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(317, 85);
            this.Controls.Add(this.PanelResults);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.Text = "Picker Tool";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmMain_KeyDown);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.PanelResults.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton Button_Delay;
        private System.Windows.Forms.ToolStripMenuItem MenuItemDelay0;
        private System.Windows.Forms.ToolStripMenuItem MenuItemDelay1;
        private System.Windows.Forms.ToolStripMenuItem MenuItemDelay2;
        private System.Windows.Forms.ToolStripMenuItem MenuItemDelay3;
        private System.Windows.Forms.ToolStripMenuItem MenuItemDelay4;
        private System.Windows.Forms.ToolStripMenuItem MenuItemDelay5;
        private System.Windows.Forms.ToolStripButton Button_Cancel;
        private ucGradientPanel PanelResults;
        private System.Windows.Forms.Label LabelInfo;
        private System.Windows.Forms.ToolStripButton Button_Pick;
    }
}

