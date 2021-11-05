using System;
using System.Collections;
using System.ComponentModel;
using System.Linq;
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
            cboNotificationType.DataSource =
                NotificationManager._conditions.Select(kvp => kvp.Value.GetTitle()).ToArray();

            txtMessage.ListBox = autocompleteBox;
        }

        public NotificationSettings BoundSettings { get; private set; }

        public void BindSettings(NotificationSettings settings)
        {
            BoundSettings = settings;

            // TODO: UI warning if this condition is invalid. We don't want to use a fallback value because the
            // condition might actually be from a plugin that just hasn't registered it yet.
            NotificationManager._conditions.TryGetValue(settings.Condition, out var condition);
            cboNotificationType.Text = condition?.GetTitle() ?? string.Empty;
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
            // TODO: Optimize data structure to avoid this searching
            BoundSettings.Condition = NotificationManager._conditions
                .First(kvp => kvp.Value.GetTitle() == cboNotificationType.Text).Key;
        }

        private void chkTakeScreenshot_CheckedChanged(object sender, EventArgs e)
        {
            BoundSettings.TakeScreenshot = chkTakeScreenshot.Checked;
        }
    }
}