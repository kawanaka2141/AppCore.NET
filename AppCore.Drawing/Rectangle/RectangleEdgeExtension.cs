using System.Drawing;

namespace Works.Core.Windows.Forms {
    public static class RectangleEdgeExtension {
        public static Rectangle TopEdge(this Rectangle self){
            return new Rectangle(self.Left, self.Top, self.Width, 0);
        }

        public static Rectangle BottomEdge(this Rectangle self){
            return new Rectangle(self.Left, self.Bottom, self.Width, 0);
        }

        public static Rectangle LeftEdge(this Rectangle self){
            return new Rectangle(self.Left, self.Top, 0, self.Height);
        }

        public static Rectangle RightEdge(this Rectangle self){
            return new Rectangle(self.Right, self.Top, 0, self.Height);
        }
    }
}
