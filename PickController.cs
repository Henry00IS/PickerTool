using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PickerTool
{
    public class PickController
    {
        public class ColorPickedEventArgs
        {
            public System.Drawing.Color Color;
        }
        public delegate void ColorPickedEventHandler(object sender, ColorPickedEventArgs e);
        public event ColorPickedEventHandler ColorPicked;

        private frmMain m_MainWindow;
        public Color CurrentColor;
        public bool Success;

        public struct ScreenData
        {
            public frmPickerOverlay Overlay;
            public Screen Screen;
            public PickController Controller;
        }

        private List<ScreenData> m_ScreenData;

        public PickController(frmMain main)
        {
            m_MainWindow = main;
            m_ScreenData = new List<ScreenData>();
        }

        public void Show()
        {
            foreach (Screen screen in Screen.AllScreens)
            {
                ScreenData data = new ScreenData
                {
                    Screen = screen,
                    Controller = this
                };
                data.Overlay = new frmPickerOverlay(data);
                data.Overlay.FormClosed += Overlay_FormClosed;
                m_ScreenData.Add(data);
            }
            
            foreach (ScreenData data in m_ScreenData)
            {
                data.Overlay.Show();
                data.Overlay.Location = data.Screen.Bounds.Location;
            }

            // show the main window again.
            m_MainWindow.Visible = true;
        }

        /// <summary>
        /// When any of the overlays closes (probably due to the Escape key) cancel all of them.
        /// </summary>
        private void Overlay_FormClosed(object sender, FormClosedEventArgs e)
        {
            foreach (ScreenData data in m_ScreenData)
            {
                // remove event handler to prevent recursion.
                data.Overlay.FormClosed -= Overlay_FormClosed;
                data.Overlay.Close();
            }

            // clear all of the references.
            m_ScreenData.Clear();

            // did the user pick a color?
            if (Success)
                if (ColorPicked != null)
                    ColorPicked(this, new ColorPickedEventArgs { Color = CurrentColor });
        }

        public void Close()
        {
            Overlay_FormClosed(null, new FormClosedEventArgs(CloseReason.None));
        }
    }
}
