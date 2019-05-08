using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Draw.src.Processors
{
    public class GeometricProcessor : DialogProcessor
    {
        #region Constructor

        public GeometricProcessor()
        {

        }

        #endregion

        public override void DrawShape(Graphics grfx, Shape item)
        {

            // grfx.Transform = new Matrix(), item.Matrix()...
            // grfx.Transform = new System.Drawing.Drawing2D.Matrix();
            // grfx.Transform.RotateAt(20, new PointF(item.Location.X + item.Width / 2, item.Location.Y + item.Height / 2)); // From the Center
            item.Rotate(grfx);

            base.DrawShape(grfx, item);

        }
    }
}
