using System.Drawing;

namespace Works.Core.Windows.Forms {
    public static class RectangleCornerExtension {
        public static Point TopLeftCorner(this Rectangle self){
            return new Point(self.Left, self.Top);
        }

        public static Point TopRightCorner(this Rectangle self){
            return new Point(self.Right, self.Top);
        }

        public static Point BottomLeftCorner(this Rectangle self){
            return new Point(self.Left, self.Bottom);
        }

        public static Point BottomRightCorner(this Rectangle self){
            return new Point(self.Right, self.Bottom);
        }
    }
}
