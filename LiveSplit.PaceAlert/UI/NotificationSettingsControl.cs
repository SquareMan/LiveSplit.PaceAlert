using System;
using System.Collections;
using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;
using LiveSplit.Model;
using LiveSplit.PaceAlert.Logic;
using LiveSplit.TimeFormatters;

namespace LiveSplit.PaceAlert.UI
{
    internal partial class NotificationSettingsControl : UserControl
    {
        private static readonly ITimeFormatter _timeFormatter;

        static NotificationSettingsControl()
        {
            _timeFormatter = new ShortTimeFormatter();
        }

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
            cboSelectedSplit.SelectedItem = settings.SelectedSegment.Name;
            txtMessage.Text = settings.MessageTemplate;
            chkTakeScreenshot.Checked = settings.TakeScreenshot;
            txtTimeSpan.Text = _timeFormatter.Format(settings.DeltaTarget);

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
            NotificationManager.SendMessageFormatted(new NotificationManager.NotificationStats(_state, BoundSettings),
                0, CancellationToken.None);
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            // This control is inside a FlowLayoutPanel that is part of the main PaceAlertSettingsControl
            var settingsControl = Parent.Parent as PaceAlertSettingsControl;
            settingsControl?.RemoveNotificationControl(this);
        }

        private void txtTimeSpan_Validating(object sender, CancelEventArgs e)
        {
            TimeSpan parsedTimeSpan;

            try
            {
                parsedTimeSpan = TimeSpanParser.Parse(txtTimeSpan.Text);
                BoundSettings.DeltaTarget = parsedTimeSpan;
            }
            catch
            {
                parsedTimeSpan = BoundSettings.DeltaTarget;
            }

            txtTimeSpan.Text = _timeFormatter.Format(parsedTimeSpan);
        }

        private void cboSelectedSplit_SelectionChangeCommitted(object sender, EventArgs e)
        {
            BoundSettings.SelectedSegment = _state.Run[cboSelectedSplit.SelectedIndex];
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

        private void chkTakeScreenshot_CheckedChanged(object sender, EventArgs e)
        {
            BoundSettings.TakeScreenshot = chkTakeScreenshot.Checked;
        }
    }
}