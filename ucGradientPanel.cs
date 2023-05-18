using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace PickerTool
{
    public partial class ucGradientPanel : Panel
    {
        public ucGradientPanel()
        {
            InitializeComponent();

            SetStyle(ControlStyles.ResizeRedraw, true);
        }

        private Rectangle m_Rect = new Rectangle();
        private LinearGradientBrush m_Brush;

        private Color m_Color1;
        public Color Color1
        { get { return m_Color1; } set { m_Color1 = value; if (DesignMode) Invalidate(); } }
        private Color m_Color2;
        public Color Color2
        { get { return m_Color2; } set { m_Color2 = value; if (DesignMode) Invalidate(); } }
        private LinearGradientMode m_GradientMode;
        public LinearGradientMode GradientMode
        { get { return m_GradientMode; } set { m_GradientMode = value; if (DesignMode) Invalidate(); } }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (this.ClientRectangle.Width == 0 || this.ClientRectangle.Height == 0) return; // minimize, restore.

            if (!m_Rect.Equals(this.ClientRectangle))
            {
                m_Rect = this.ClientRectangle;
                m_Brush = new LinearGradientBrush(m_Rect, m_Color1, m_Color2, m_GradientMode);
            }

            e.Graphics.FillRectangle(m_Brush, m_Rect);
        }
    }
}