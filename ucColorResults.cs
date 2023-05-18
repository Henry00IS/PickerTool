using System.Drawing;
using System.Windows.Forms;

namespace PickerTool
{
    public partial class ucColorResults : UserControl
    {
        private Color m_Color;
        private string m_Separator = ", ";
        private string m_Suffix = "";

        private bool m_HexUppercase = true;
        private bool m_HexComponents = false;
        private string m_HexPrefix = "#";

        public ucColorResults()
        {
            InitializeComponent();
        }

        public void SetColor(Color color)
        {
            m_Color = color;
            UpdateTextboxes();
        }

        private void UpdateTextboxes()
        {
            TextBoxRGB.Text = m_Color.R.ToString() + m_Suffix + m_Separator + m_Color.G.ToString() + m_Suffix + m_Separator + m_Color.B.ToString() + m_Suffix;
            TextBoxRGBF.Text = (m_Color.R / 255.0f).ToString("0.000").Replace(",", ".") + m_Suffix + m_Separator + (m_Color.G / 255.0f).ToString("0.000").Replace(",", ".") + m_Suffix + m_Separator + (m_Color.B / 255.0f).ToString("0.000").Replace(",", ".") + m_Suffix;

            // hex textbox:
            string hexR = m_Color.R.ToString("X2");
            string hexG = m_Color.G.ToString("X2");
            string hexB = m_Color.B.ToString("X2");
            if (!m_HexUppercase)
            {
                hexR = hexR.ToLowerInvariant();
                hexG = hexG.ToLowerInvariant();
                hexB = hexB.ToLowerInvariant();
            }
            if (m_HexComponents)
                TextBoxHEX.Text = m_HexPrefix + hexR + m_Separator + m_HexPrefix + hexG + m_Separator + m_HexPrefix + hexB;
            else
                TextBoxHEX.Text = m_HexPrefix + hexR + hexG + hexB;

            ColorConversions.HSLColor HSL = ColorConversions.FromRGB(m_Color.R, m_Color.G, m_Color.B);
            TextBoxHSL.Text = HSL.H.ToString("0.00000000").Replace(",", ".") + m_Suffix + m_Separator + HSL.S.ToString("0.00000000").Replace(",", ".") + m_Suffix + m_Separator + HSL.L.ToString("0.00000000").Replace(",", ".") + m_Suffix;
            double H = 0.0d;
            double S = 0.0d;
            double V = 0.0d;
            ColorConversions.ColorToHSV(m_Color, out H, out S, out V);
            TextBoxHSV.Text = H.ToString("0.00000000").Replace(",", ".") + m_Suffix + m_Separator + S.ToString("0.00000000").Replace(",", ".") + m_Suffix + m_Separator + V.ToString("0.00000000").Replace(",", ".") + m_Suffix;
            PanelColorPreview.BackColor = m_Color;
        }

        private void buttonSeparatorComma_Click(object sender, System.EventArgs e)
        {
            m_Separator = ",";
            UpdateTextboxes();
        }

        private void buttonSeparatorSemicolon_Click(object sender, System.EventArgs e)
        {
            m_Separator = ";";
            UpdateTextboxes();
        }

        private void buttonSuffixNone_Click(object sender, System.EventArgs e)
        {
            m_Suffix = "";
            UpdateTextboxes();
        }

        private void buttonSuffixFloat_Click(object sender, System.EventArgs e)
        {
            m_Suffix = "f";
            UpdateTextboxes();
        }

        private void buttonSuffixDouble_Click(object sender, System.EventArgs e)
        {
            m_Suffix = "d";
            UpdateTextboxes();
        }

        /// <summary>Called whenever the user types a prefix for hexadecimal numbers.</summary>
        private void HexPrefixBox_TextChanged(object sender, System.EventArgs e)
        {
            m_HexPrefix = hexPrefixBox.Text;
            UpdateTextboxes();
        }

        private void HexUppercase_CheckedChanged(object sender, System.EventArgs e)
        {
            m_HexUppercase = hexUppercase.Checked;
            UpdateTextboxes();
        }

        private void HexComponents_CheckedChanged(object sender, System.EventArgs e)
        {
            m_HexComponents = hexComponents.Checked;
            UpdateTextboxes();
        }

        private void SettingSeparator_TextChanged(object sender, System.EventArgs e)
        {
            m_Separator = settingSeparator.Text;
            UpdateTextboxes();
        }

        private void SettingSuffix_TextChanged(object sender, System.EventArgs e)
        {
            m_Suffix = settingSuffix.Text;
            UpdateTextboxes();
        }

        /// <summary>Whether the settings menu can be closed.</summary>
        private bool settingsMenuCanClose = true;

        private void SettingsMenu_Closing(object sender, ToolStripDropDownClosingEventArgs e)
        {
            if (e.CloseReason != ToolStripDropDownCloseReason.ItemClicked) return;
            e.Cancel = !settingsMenuCanClose;
        }

        private void SettingsMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            settingsMenuCanClose = true;

            if (e.ClickedItem == hexUppercase)
                settingsMenuCanClose = false;

            if (e.ClickedItem == hexComponents)
                settingsMenuCanClose = false;
        }

        private void SettingsMenu_MouseLeave(object sender, System.EventArgs e)
        {
            settingsMenuCanClose = true;
        }
    }
}