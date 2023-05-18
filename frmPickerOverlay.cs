using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace PickerTool
{
    public partial class frmPickerOverlay : Form
    {
        public frmPickerOverlay()
        {
            InitializeComponent();
        }

        private PickController.ScreenData m_Data;
        private Bitmap m_Screenshot;
        private Graphics m_ScreenshotGraphics;
        private Brush m_BrushTransparentWhite;
        private Rectangle m_ViewRectangle = new Rectangle();
        private Timer m_Timer = new Timer();
        private bool m_Clear = true;
        private Bitmap m_Zoom;
        private Graphics m_ZoomGraphics;
        private Bitmap m_Grid;
        private Graphics m_GridGraphics;
        private Point m_ClientCursor = new Point();

        public frmPickerOverlay(PickController.ScreenData data)
        {
            // create a screenshot.
            m_Screenshot = new Bitmap(data.Screen.Bounds.Width, data.Screen.Bounds.Height, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
            m_ScreenshotGraphics = Graphics.FromImage(m_Screenshot);
            m_ScreenshotGraphics.CopyFromScreen(data.Screen.Bounds.Location.X, data.Screen.Bounds.Location.Y, 0, 0, m_Screenshot.Size);

            // create the zoomed bitmap.
            m_Zoom = new Bitmap(8, 8);
            m_ZoomGraphics = Graphics.FromImage(m_Zoom);

            // create the grid.
            m_Grid = new Bitmap(64, 64);
            m_GridGraphics = Graphics.FromImage(m_Grid);
            for (int x = 1; x <= 8; x++)
            {
                m_GridGraphics.DrawLine(Pens.Black, new Point(x * 8, 0), new Point(x * 8, 64));
                m_GridGraphics.DrawLine(Pens.Black, new Point(0, x * 8), new Point(64, x * 8));
            }

            // set up the form.
            InitializeComponent();
            m_Data = data;
            Size = m_Data.Screen.Bounds.Size;
            Location = m_Data.Screen.Bounds.Location;
            BackgroundImage = m_Screenshot;

            // set up some of the GDI+ components.
            m_BrushTransparentWhite = new SolidBrush(Color.FromArgb(120, Color.White));

            // set up last components.
            m_Timer.Interval = 10;
            m_Timer.Tick += M_Timer_Tick;
            m_Timer.Start();
        }

        /// <summary>
        /// The update loop.
        /// </summary>
        private void M_Timer_Tick(object sender, EventArgs e)
        {
            if (this.IsDisposed)
            {
                m_Timer.Stop();
                m_Timer = null;
                return;
            }

            m_ClientCursor = this.PointToClient(Cursor.Position);
            m_Clear = true;
            this.Invalidate(new Region(new Rectangle(m_ViewRectangle.X - 1, m_ViewRectangle.Y - 1, m_ViewRectangle.Width + 2, m_ViewRectangle.Height + 2)));
            m_ViewRectangle = new Rectangle(m_ClientCursor.X - 128, m_ClientCursor.Y - 128, 256, 256);
            m_Clear = false;
            this.Invalidate(new Region(m_ViewRectangle));

            // update the color preview window.
            try
            {
                if (Bounds.Contains(Cursor.Position))
                    m_Data.Controller.CurrentColor = m_Screenshot.GetPixel(Program.Clamp(m_ClientCursor.X, 0, m_Data.Screen.Bounds.Width), Program.Clamp(m_ClientCursor.Y, 0, m_Data.Screen.Bounds.Height));
            }
            catch (Exception)
            {
                // No idea why but this can happen... move mouse super fast over multiple monitors.
                // I think this is literally a multithreading bug because you can read impossibly large values.
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (m_Clear)
                e.Graphics.FillRectangle(m_BrushTransparentWhite, e.ClipRectangle);
            else
            {
                // disable all smoothing.
                e.Graphics.SmoothingMode = SmoothingMode.None;
                e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
                e.Graphics.PixelOffsetMode = PixelOffsetMode.Half;

                // visually help the user (white surface).
                int x1 = m_ViewRectangle.X; int x2 = m_ViewRectangle.X + m_ViewRectangle.Width;
                int y1 = m_ViewRectangle.Y; int y2 = m_ViewRectangle.Y + m_ViewRectangle.Height;
                e.Graphics.FillRectangle(m_BrushTransparentWhite, new Rectangle(0, 0, x1, this.Height));
                e.Graphics.FillRectangle(m_BrushTransparentWhite, new Rectangle(x2, 0, this.Width - x2, this.Height));
                e.Graphics.FillRectangle(m_BrushTransparentWhite, new Rectangle(x1, 0, x2 - x1, y1));
                e.Graphics.FillRectangle(m_BrushTransparentWhite, new Rectangle(x1, y2, x2 - x1, this.Height - y2));
                // red border.
                e.Graphics.DrawRectangle(Pens.Red, m_ViewRectangle);

                // zoomed image under the mouse.
                m_ZoomGraphics.DrawImage(m_Screenshot, new Rectangle(0, 0, 8, 8), m_ClientCursor.X - 4, m_ClientCursor.Y - 4, 8, 8, GraphicsUnit.Pixel);
                e.Graphics.DrawImage(m_Zoom, m_ClientCursor.X - 32 - 4, m_ClientCursor.Y - 32 - 4, 64, 64);
                // draw grid.
                e.Graphics.DrawImage(m_Grid, m_ClientCursor.X - 32 - 4, m_ClientCursor.Y - 32 - 4);

                Pen lol = new Pen(m_Data.Controller.CurrentColor, 8.0f);
                e.Graphics.DrawRectangle(lol, new Rectangle(m_ClientCursor.X - 32 - 7, m_ClientCursor.Y - 32 - 7, 64 + 7, 64 + 7));
            }
        }

        /// <summary>
        /// Allow cancelling the picker tool with the Escape key.
        /// </summary>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            // Allow canceling the snip with the Escape key
            if (keyData == Keys.Escape) { this.DialogResult = DialogResult.Cancel; Close(); }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void frmPickerOverlay_Load(object sender, EventArgs e)
        {
            this.Click += FrmPickerOverlay_Click;
        }

        private void FrmPickerOverlay_Click(object sender, EventArgs e)
        {
            // User clicked on a color. The preview window contains this color.
            Point cursor = this.PointToClient(Cursor.Position);
            m_Data.Controller.CurrentColor = m_Screenshot.GetPixel(cursor.X, cursor.Y);
            m_Data.Controller.Success = true;
            Close();
        }
    }
}