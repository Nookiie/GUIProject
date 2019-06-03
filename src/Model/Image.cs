using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Draw.src.Model
{
    public class Image : Shape
    {
        #region Constructor

        public Image()
        {

        }
        public Image(Bitmap image) : base(image)
        {

        }

        #endregion

        #region Properties

        private Bitmap image;
        public Bitmap Images
        {
            get { return image; }
            set { image = value; }
        }
        #endregion

        #region Methods

        public override void DrawSelf(Graphics grfx)
        {
            base.DrawSelf(grfx);
        }

        #endregion

    }
}