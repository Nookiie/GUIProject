﻿using System;
using System.Collections.Generic;
using System.Drawing;

namespace Draw
{
    /// <summary>
    /// Класът ... е основен примитив, който е наследник на базовия Shape.
    /// </summary>
    public class LineShape : Shape
    {
        #region Constructor

        public LineShape(PointF pt1, PointF pt2) : base(pt1, pt2)
        {

        }

        public LineShape(LineShape line) : base(line)
        {

        }

        #endregion

        #region Properties
        #endregion

        #region Methods

        /// <summary>
        /// Проверка за принадлежност на точка point към правоъгълника.
        /// В случая на правоъгълник този метод може да не бъде пренаписван, защото
        /// Реализацията съвпада с тази на абстрактния клас Shape, който проверява
        /// дали точката е в обхващащия правоъгълник на елемента (а той съвпада с
        /// елемента в този случай).
        /// </summary>
        public override bool Contains(PointF point)
        {
            if (base.Contains(point))
                return true; /// <-----
            else
                return false;
        }
        /// <summary>
        /// Частта, визуализираща конкретния примитив.
        /// </summary>
        public override void DrawSelf(Graphics grfx, PointF pt1, PointF pt2)
        {
            base.DrawSelf(grfx, pt1, pt2);
        }
        #endregion
    }
}