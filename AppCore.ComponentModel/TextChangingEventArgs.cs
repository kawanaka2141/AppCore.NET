using System.ComponentModel;

namespace Works.Core.ComponentModel {
    public class TextChangingEventArgs : CancelEventArgs {
        public string ChangedText { private set; get; }

        public TextChangingEventArgs(string changedText) {
            ChangedText = changedText;
        }
    }
}
