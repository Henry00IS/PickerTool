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
    public partial class frmPickerPreview : Form
    {
        public frmPickerPreview()
        {
            InitializeComponent();
        }

        /// <summary>
        /// This variable is shared accross all overlays.
        /// Whether or not the user cancelled the operation.
        /// </summary>
        public bool Success = false;

        private Timer m_Timer;

        private void frmPickerTool_Load(object sender, EventArgs e)
        {
            // Allow the form to be 32x32 and bypass the default restrictions.
            base.SetBoundsCore(0, 0, 32, 32, BoundsSpecified.Size);
            m_Timer = new Timer();
            m_Timer.Interval = 10;
            m_Timer.Tick += M_Timer_Tick;
            m_Timer.Start();
        }

        private void M_Timer_Tick(object sender, EventArgs e)
        {
            if (this.IsDisposed)
            {
                m_Timer.Stop();
                m_Timer = null;
                return;
            }
            Location = new Point(Cursor.Position.X + 28, Cursor.Position.Y + 28);
        }
    }
}
