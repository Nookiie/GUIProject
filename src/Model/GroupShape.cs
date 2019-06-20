using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;

namespace Draw
{
    /// <summary>
    /// Класът правоъгълник е основен примитив, който е наследник на базовия Shape.
    /// </summary>
	[Serializable]
    public class GroupShape : Shape
    {
        #region Constructor
        public GroupShape(RectangleF rect) : base(rect)
        {

        }

        public GroupShape(RectangleShape rectangle) : base(rectangle)
        {

        }

        #endregion

        public List<Shape> SubShapes { get; set; }

        #region Methods

        public override bool Contains(PointF point)
        {
            double radians = Rotation * Math.PI / 180;
            PointF center = new PointF(Rectangle.Left + Rectangle.Width / 2, Rectangle.Top + Rectangle.Height / 2);

            float newPointX = point.X - center.X;
            float newPointY = point.Y - center.Y;
            double rotationPointX = newPointX * Math.Cos(-radians) - newPointY * Math.Sin(-radians);
            double rotationPointY = newPointY * Math.Cos(-radians) + newPointX * Math.Sin(-radians);

            PointF translatedPoint = new PointF((float)(rotationPointX + center.X), (float)(rotationPointY + center.Y));

            if (base.Contains(translatedPoint))
            {
                foreach (var item in SubShapes)
                {
                    item.Rotation = this.Rotation;
                    if (item.Contains(translatedPoint))
                        return true;
                }
                return false;
            }
            else
                return false;
        }

        public override bool Contains(PointF[] Polygon, PointF point)
        {
            double radians = Rotation * Math.PI / 180;
            PointF center = new PointF(Rectangle.Left + Rectangle.Width / 2, Rectangle.Top + Rectangle.Height / 2);

            float newPointX = point.X - center.X;
            float newPointY = point.Y - center.Y;
            double rotationPointX = newPointX * Math.Cos(-radians) - newPointY * Math.Sin(-radians);
            double rotationPointY = newPointY * Math.Cos(-radians) + newPointX * Math.Sin(-radians);

            PointF translatedPoint = new PointF((float)(rotationPointX + center.X), (float)(rotationPointY + center.Y));

            if (base.Contains(Polygon, translatedPoint))
            {
                foreach (var item in SubShapes)
                {
                    if (item.Contains(Polygon, translatedPoint))
                        return true;
                }
                return false;
            }
            else
                return false;

        }

        public override void DrawSelf(Graphics grfx)
        {
            foreach (var item in SubShapes)
            {
                item.Rotation = this.Rotation;
                item.Rotate(grfx);
                item.DrawSelf(grfx);
            }
            base.DrawSelf(grfx);
        }

        public override void Rotate(Graphics grfx)
        {
            base.Rotate(grfx);

            foreach (var item in SubShapes)
            {
                item.Rotate(grfx);
            }
        }

        public override PointF Location
        {
            set
            {
                float dx = value.X - Location.X;
                float dy = value.Y - Location.Y;

                base.Location = value;

                foreach (var item in SubShapes)
                {
                    item.Location = new PointF(item.Location.X + dx, item.Location.Y + dy);
                }
            }
        }

        public override Color FillColor
        {
            set
            {
                foreach (var item in SubShapes)
                {
                    item.FillColor = value;
                }
            }
        }

        public override Color BorderColor
        {
            set
            {
                foreach (var item in SubShapes)
                {
                    item.BorderColor = value;
                }
            }
        }

        public override float Rotation
        {
            set
            {
                foreach (var item in SubShapes)
                {
                    item.Rotation = value;
                }
            }

        }
        #endregion
    }
}
