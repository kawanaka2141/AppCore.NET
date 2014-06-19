using System.Collections.Generic;
using System.Drawing;

namespace System.Windows.Forms {
    public static class DraggableControlExtension {
        private static readonly Dictionary<Control, bool> draggables = new Dictionary<Control, bool>();
        private static Size mouseOffset;

        private static readonly Dictionary<Func<Control, MouseEventHandler>, Action<object, MouseEventArgs>> handlers = new Dictionary<Func<Control, MouseEventHandler>, Action<object, MouseEventArgs>>();

        public static void Draggable(this Control control, bool enable){
            if(enable){
                if(draggables.ContainsKey(control)) return;
                draggables.Add(control, false);
                control.MouseDown += Control_MouseDown;
                control.MouseUp += Control_MouseUp;
                control.MouseMove += Control_MouseMove;
            }
            else{
                if(! draggables.ContainsKey(control)) return;
                draggables.Remove(control);
                control.MouseDown -= Control_MouseDown;
                control.MouseUp -= Control_MouseUp;
                control.MouseMove -= Control_MouseMove;
            }
        }

        private static void Control_MouseDown(object sender, MouseEventArgs e){
            mouseOffset = new Size(e.Location);
            draggables[(Control)sender] = true;
        }

        private static void Control_MouseUp(object sender, MouseEventArgs e){
            draggables[(Control)sender] = false;
        }

        private static void Control_MouseMove(object sender, MouseEventArgs e){
            if(!draggables[(Control)sender]) return;

            var newOffset = e.Location - mouseOffset;
            ((Control)sender).Left += newOffset.X;
            ((Control)sender).Top += newOffset.Y;
        }
    }
}
