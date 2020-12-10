using System;
using System.Collections;
using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;
using LiveSplit.Model;
using LiveSplit.PaceAlert.Logic;

namespace LiveSplit.PaceAlert.UI
{
    internal partial class NotificationSettingsControl : UserControl
    {
        private readonly LiveSplitState _state;

        public NotificationSettingsControl(LiveSplitState state, IEnumerable splitNames, ListBox autocompleteBox)
        {
            InitializeComponent();

            _state = state;
            cboSelectedSplit.DataSource = splitNames;
            cboNotificationType.DataSource = Enum.GetValues(typeof(NotificationType));

            txtMessage.ListBox = autocompleteBox;
        }

        public NotificationSettings BoundSettings { get; private set; }

        public void BindSettings(NotificationSettings settings)
        {
            BoundSettings = settings;

            cboNotificationType.SelectedIndex = (int) settings.Type;
            cboSelectedSplit.SelectedIndex = settings.SelectedSplit;
            cboAheadBehind.SelectedIndex = settings.Ahead ? 0 : 1;
            txtMessage.Text = settings.MessageTemplate;

            // Set individual time text boxes, using TotalHours to account for TimeSpans with 24 or more hours
            txtDeltaHour.Text = ((int) settings.DeltaTarget.TotalHours).ToString("D2");
            txtDeltaMinute.Text = settings.DeltaTarget.Minutes.ToString("D2");
            txtDeltaSecond.Text = settings.DeltaTarget.Seconds.ToString("D2");
            txtDeltaMillisecond.Text = settings.DeltaTarget.Milliseconds.ToString("D3");

            // Parse Settings for Timing Method Comparison
            switch (settings.TimingMethod)
            {
                case TimingMethod.RealTime:
                    rdoRealTime.Checked = true;
                    break;
                case TimingMethod.GameTime:
                    rdoGameTime.Checked = true;
                    break;
            }
        }

        private void btnSendMessage_Click(object sender, EventArgs e)
        {
            NotificationManager.SendMessageFormatted(new NotificationManager.NotificationStats(_state, BoundSettings), 0, CancellationToken.None);
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            // This control is inside a FlowLayoutPanel that is part of the main PaceAlertSettingsControl
            var settingsControl = Parent.Parent as PaceAlertSettingsControl;
            settingsControl?.RemoveNotificationControl(this);
        }

        private void txtDeltaHour_Validating(object sender, CancelEventArgs e)
        {
            if (int.TryParse(txtDeltaHour.Text, out var newTime) && newTime >= 0)
            {
                txtDeltaHour.Text = newTime.ToString("D2");

                var oldTime = BoundSettings.DeltaTarget;
                BoundSettings.DeltaTarget =
                    new TimeSpan(0, newTime, oldTime.Minutes, oldTime.Seconds, oldTime.Milliseconds);
            }
            else
            {
                txtDeltaHour.Text = ((int) BoundSettings.DeltaTarget.TotalHours).ToString("D2");
            }
        }

        private void txtDeltaMinute_Validating(object sender, CancelEventArgs e)
        {
            if (int.TryParse(txtDeltaMinute.Text, out var newTime) && newTime >= 0 && newTime < 60)
            {
                txtDeltaMinute.Text = newTime.ToString("D2");

                var oldTime = BoundSettings.DeltaTarget;
                BoundSettings.DeltaTarget = new TimeSpan(oldTime.Days, oldTime.Hours, newTime, oldTime.Seconds,
                    oldTime.Milliseconds);
            }
            else
            {
                txtDeltaMinute.Text = BoundSettings.DeltaTarget.Minutes.ToString("D2");
            }
        }

        private void txtDeltaSecond_Validating(object sender, CancelEventArgs e)
        {
            if (int.TryParse(txtDeltaSecond.Text, out var newTime) && newTime >= 0 && newTime < 60)
            {
                txtDeltaSecond.Text = newTime.ToString("D2");

                var oldTime = BoundSettings.DeltaTarget;
                BoundSettings.DeltaTarget = new TimeSpan(oldTime.Days, oldTime.Hours, oldTime.Minutes, newTime,
                    oldTime.Milliseconds);
            }
            else
            {
                txtDeltaSecond.Text = BoundSettings.DeltaTarget.Seconds.ToString("D2");
            }
        }

        private void txtDeltaMillisecond_Validating(object sender, CancelEventArgs e)
        {
            if (int.TryParse(txtDeltaMillisecond.Text, out var newTime) && newTime >= 0 && newTime < 1000)
            {
                txtDeltaMillisecond.Text = newTime.ToString("D3");

                var oldTime = BoundSettings.DeltaTarget;
                BoundSettings.DeltaTarget =
                    new TimeSpan(oldTime.Days, oldTime.Hours, oldTime.Minutes, oldTime.Seconds, newTime);
            }
            else
            {
                txtDeltaMillisecond.Text = BoundSettings.DeltaTarget.Milliseconds.ToString("D3");
            }
        }

        private void cboSelectedSplit_SelectionChangeCommitted(object sender, EventArgs e)
        {
            BoundSettings.SelectedSplit = cboSelectedSplit.SelectedIndex;
        }

        private void cboAheadBehind_SelectionChangeCommitted(object sender, EventArgs e)
        {
            BoundSettings.Ahead = cboAheadBehind.SelectedIndex == 0;
        }

        private void rdoRealTime_CheckedChanged(object sender, EventArgs e)
        {
            BoundSettings.TimingMethod = rdoRealTime.Checked ? TimingMethod.RealTime : TimingMethod.GameTime;
        }

        private void txtMessage_Validated(object sender, EventArgs e)
        {
            BoundSettings.MessageTemplate = txtMessage.Text;
        }

        private void cboNotificationType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            BoundSettings.Type = (NotificationType) cboNotificationType.SelectedIndex;
        }
    }
}