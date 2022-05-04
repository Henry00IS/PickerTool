using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PickerTool
{
    public partial class frmMain : Form
    {
        const string copyright = "Copyright © Henry de Jongh and http://00laboratories.com/ 2016";

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            
        }

        private int m_Delay = 0;

        private void MenuItemDelay0_Click(object sender, EventArgs e)
        {
            m_Delay = 0;
            MenuItemDelay1.Checked = false;
            MenuItemDelay2.Checked = false;
            MenuItemDelay3.Checked = false;
            MenuItemDelay4.Checked = false;
            MenuItemDelay5.Checked = false;
        }

        private void MenuItemDelay1_Click(object sender, EventArgs e)
        {
            m_Delay = 1;
            MenuItemDelay0.Checked = false;
            MenuItemDelay2.Checked = false;
            MenuItemDelay3.Checked = false;
            MenuItemDelay4.Checked = false;
            MenuItemDelay5.Checked = false;
        }

        private void MenuItemDelay2_Click(object sender, EventArgs e)
        {
            m_Delay = 2;
            MenuItemDelay0.Checked = false;
            MenuItemDelay1.Checked = false;
            MenuItemDelay3.Checked = false;
            MenuItemDelay4.Checked = false;
            MenuItemDelay5.Checked = false;
        }

        private void MenuItemDelay3_Click(object sender, EventArgs e)
        {
            m_Delay = 3;
            MenuItemDelay0.Checked = false;
            MenuItemDelay1.Checked = false;
            MenuItemDelay2.Checked = false;
            MenuItemDelay4.Checked = false;
            MenuItemDelay5.Checked = false;
        }

        private void MenuItemDelay4_Click(object sender, EventArgs e)
        {
            m_Delay = 4;
            MenuItemDelay0.Checked = false;
            MenuItemDelay1.Checked = false;
            MenuItemDelay2.Checked = false;
            MenuItemDelay3.Checked = false;
            MenuItemDelay5.Checked = false;
        }

        private void MenuItemDelay5_Click(object sender, EventArgs e)
        {
            m_Delay = 5;
            MenuItemDelay0.Checked = false;
            MenuItemDelay1.Checked = false;
            MenuItemDelay2.Checked = false;
            MenuItemDelay3.Checked = false;
            MenuItemDelay4.Checked = false;
        }

        private PickController m_Controller;

        private void Button_Pick_Click(object sender, EventArgs e)
        {
            // Make sure the old pick is closed first.
            Button_Cancel_Click(this, e);

            // Ensure the window is completely hidden (for the screenshot).
            Visible = false;
            System.Threading.Thread.Sleep(250);
            Application.DoEvents();

            // Delay for the time defined by the user.
            System.Threading.Thread.Sleep(m_Delay * 1000);

            // Use the pick controller to show the overlay and handle the pick.
            m_Controller = new PickController(this);
            m_Controller.ColorPicked += Controller_ColorPicked;
            m_Controller.Show();

            // Undo any result values.
            LabelInfo.Visible = true;
            PanelResults.Controls.Remove(m_ColorResults);
            Height = 124;

            // Enable this form again and help the user.
            Button_Cancel.Enabled = true;
            Visible = true;
        }

        private ucColorResults m_ColorResults = new ucColorResults();

        /// <summary>
        /// Called when the user picked a color.
        /// </summary>
        private void Controller_ColorPicked(object sender, PickController.ColorPickedEventArgs e)
        {
            LabelInfo.Visible = false;
            PanelResults.Controls.Add(m_ColorResults);
            Height = 80 + m_ColorResults.Height;

            m_ColorResults.Location = new Point(4, 0);
            m_ColorResults.TextBoxRGB.Text = e.Color.R.ToString() + ", " + e.Color.G.ToString() + ", " + e.Color.B.ToString();
            m_ColorResults.TextBoxRGBF.Text = (e.Color.R / 255.0f).ToString("0.000").Replace(",", ".") + ", " + (e.Color.G / 255.0f).ToString("0.000").Replace(",", ".") + ", " + (e.Color.B / 255.0f).ToString("0.000").Replace(",", ".");
            m_ColorResults.TextBoxHEX.Text = "#" + e.Color.R.ToString("X2") + e.Color.G.ToString("X2") + e.Color.B.ToString("X2");
            ColorConversions.HSLColor HSL = ColorConversions.FromRGB(e.Color.R, e.Color.G, e.Color.B);
            m_ColorResults.TextBoxHSL.Text = HSL.H.ToString("0.00000000").Replace(",",".") + ", " + HSL.S.ToString("0.00000000").Replace(",", ".") + ", " + HSL.L.ToString("0.00000000").Replace(",", ".");
            double H = 0.0d;
            double S = 0.0d;
            double V = 0.0d;
            ColorConversions.ColorToHSV(e.Color, out H, out S, out V);
            m_ColorResults.TextBoxHSV.Text = H.ToString("0.00000000").Replace(",", ".") + ", " + S.ToString("0.00000000").Replace(",", ".") + ", " + V.ToString("0.00000000").Replace(",", ".");
            m_ColorResults.PanelColorPreview.BackColor = e.Color;
            Button_Cancel.Enabled = false;
        }

        /// <summary>
        /// The user can hit cancel to stop the operation.
        /// </summary>
        private void Button_Cancel_Click(object sender, EventArgs e)
        {
            if (m_Controller != null) {
                m_Controller.Close();
                Button_Cancel.Enabled = false;
            }
        }

        /// <summary>
        /// Allow cancelling the picker tool with the Escape key.
        /// </summary>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            // Allow canceling the snip with the Escape key
            if (keyData == Keys.Escape) { Button_Cancel_Click(this, null); }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        /// <summary>
        /// Add shortcuts.
        /// </summary>
        private void frmMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.N)
                Button_Pick_Click(this, null);
        }
    }
}
