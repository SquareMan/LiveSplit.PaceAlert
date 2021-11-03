using System;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LiveSplit.PaceAlert.Logic;

namespace LiveSplit.PaceAlert.UI
{
    public partial class MessageTextBox : TextBox
    {
        private ListBox _listBox;

        public ListBox ListBox
        {
            get => _listBox;
            set
            {
                _listBox = value;
                if (_listBox == null) return;
                _listBox.DataSource = NotificationManager._variableFuncs.Keys.ToArray();
            }
        }

        public MessageTextBox()
        {
            InitializeComponent();
        }

        private void ShowListBox()
        {
            Control c = this;
            Point offset = GetPositionFromCharIndex(SelectionStart - 1);
            offset.Y += ListBox.Font.Height + 2;
            while (c != ListBox.Parent)
            {
                offset.X += c.Location.X;
                offset.Y += c.Location.Y;
                c = c.Parent;
            }

            ListBox.Location = offset;

            ListBox.BringToFront();
            ListBox.Show();
        }

        private void DoAutocomplete()
        {
            // Find how much of the selected variable needs to be appended
            if (!(ListBox.SelectedItem is string selectedItem)) return;
            var startIndex = Text.LastIndexOf('$', Math.Max(SelectionStart - 1, 0));
            var remainingText = selectedItem.Substring(SelectionStart - startIndex);

            // Insert the remaining text into the appropriate place in the Text
            var stringBuilder = new StringBuilder(Text, MaxLength);
            stringBuilder.Insert(SelectionStart, remainingText);
            var newSelectionStart = SelectionStart + remainingText.Length;
            Text = stringBuilder.ToString();
            SelectionStart = newSelectionStart;
        }

        private void MessageTextBox_Leave(object sender, EventArgs e)
        {
            ListBox.Hide();
        }

        private void MessageTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (ListBox == null) return;
            if (e.KeyCode == Keys.D9 && e.Shift && SelectionStart > 0 && Text[SelectionStart - 1] == '$') ShowListBox();
            if (!ListBox.Visible) return;

            switch (e.KeyCode)
            {
                case Keys.Up when ListBox.SelectedIndex > 0:
                    ListBox.SelectedIndex -= 1;
                    e.SuppressKeyPress = true;
                    break;
                case Keys.Down when ListBox.SelectedIndex < ListBox.Items.Count - 1:
                    ListBox.SelectedIndex += 1;
                    e.SuppressKeyPress = true;
                    break;
                case Keys.Escape:
                    ListBox.Hide();
                    e.SuppressKeyPress = true;
                    break;
                case Keys.Enter:
                case Keys.Tab:
                    DoAutocomplete();
                    ListBox.Hide();
                    e.SuppressKeyPress = true;
                    break;
                case Keys.Space:
                    DoAutocomplete();
                    ListBox.Hide();
                    //Don't suppress key press to allow the space character to go through.
                    break;
            }
        }

        private void MessageTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (ListBox == null || !ListBox.Visible) return;

            // Find what the user has already entered to determine which options to display
            var startIndex = Text.LastIndexOf('$', Math.Max(SelectionStart - 1, 0));
            if (startIndex < 0) return;
            var substring = Text.Substring(startIndex, SelectionStart - startIndex) + e.KeyChar;

            // Find which variables begin with the user's current input
            ListBox.DataSource = NotificationManager._variableFuncs.Keys.Where(k => k.StartsWith(substring)).ToArray();
            if (ListBox.Items.Count == 0) ListBox.Hide();
        }
    }
}