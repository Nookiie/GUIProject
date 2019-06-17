using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;

namespace Draw.src.Processors
{
    public class GeometricProcessor : DisplayProcessor
    {
        #region Constructor

        public GeometricProcessor()
        {

        }

        #endregion
        public override void DrawShape(Graphics grfx, Shape item)
        {
            // grfx.Transform = new System.Drawing.Drawing2D.Matrix();
            // grfx.Transform = new Matrix();
            // grfx.Transform.RotateAt(item.Rotation, new PointF(item.Location.X + item.Width / 2, item.Location.Y + item.Height / 2)); // From the Center
            // item.Rotate(grfx);
            // grfx.RotateTransform(item.Rotation);

            /*
            grfx.TranslateTransform(item.Location.X, item.Location.Y);
            grfx.RotateTransform(item.Rotation);
            grfx.TranslateTransform(-item.Location.X, -item.Location.Y);
            */

            using (Matrix m = new Matrix())
            {
                m.RotateAt(item.Rotation, new PointF(item.Rectangle.Left + (item.Rectangle.Width / 2), item.Rectangle.Top + (item.Rectangle.Height / 2)));
                grfx.Transform = m;
                base.DrawShape(grfx, item);
                grfx.ResetTransform();

                // item.Location.X - 3, item.Location.Y - 3, item.Width + 6, item.Height + 6
            }
        }
        /// <summary>
        /// Where the Changes are configured for the Rotation Matrix
        /// </summary>
        /// <param name="grfx"></param> 
        public override void Draw(Graphics grfx)
        {
            base.Draw(grfx);
        }
    }
}
