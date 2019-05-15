using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;

namespace Draw.src.Model
{
    public class TriangleShape : Shape
    {
        #region Constructor

        public TriangleShape(RectangleShape rectangle) : base(rectangle)
        {

        }

        #endregion
        
        #region Methods

        public override GraphicsPath GetPath(Rectangle bounds)
        {
            GraphicsPath path = new GraphicsPath();

            Point top = new Point(bounds.X + bounds.Width / 2, bounds.Y);
            Point right = new Point(bounds.X + bounds.Width, bounds.Y + bounds.Height);
            Point left = new Point(bounds.X, bounds.Y + bounds.Height);

            path.AddPolygon(new Point[]
            {
            top,
            right,
            left
            });
            return path;
        }

        public override bool Contains(PointF point)
        {
            return base.Contains(point);
        }

        public override void Rotate(Graphics grfx)
        {
            base.Rotate(grfx);
        }

        public override void DrawSelf(Graphics grfx)
        {
        }
        #endregion
    }
}
