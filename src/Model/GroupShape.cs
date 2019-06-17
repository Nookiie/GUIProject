using System;
using System.Collections.Generic;
using System.Drawing;

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
            if (base.Contains(point))
            {
                foreach (var item in SubShapes)
                {
                    if (item.Contains(point))
                        return true;
                }
                return false;
            }
            else
                return false;
        }

        public override bool Contains(PointF[] Polygon, PointF point)
        {
            if (base.Contains(Polygon, point))
            {
                foreach (var item in SubShapes)
                {
                    if (item.Contains(Polygon, point))
                        return true;
                }
                return false;
            }
            else
                return false;
        }

        public override void DrawSelf(Graphics grfx)
        {
            base.DrawSelf(grfx);

            foreach (var item in SubShapes)
            {
                item.DrawSelf(grfx);
            }
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
