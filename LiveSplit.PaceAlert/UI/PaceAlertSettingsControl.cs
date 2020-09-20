using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Forms;
using System.Xml;
using LiveSplit.Model;
using LiveSplit.PaceAlert.Discord;
using LiveSplit.UI;
using Settings = LiveSplit.PaceAlert.Logic.Settings;

namespace LiveSplit.PaceAlert.UI
{
    public partial class PaceAlertSettingsControl : UserControl
    {
        private LiveSplitState _state;
        private BindingList<string> splitNames;
        
        public PaceAlertSettingsControl(LiveSplitState state)
        {
            InitializeComponent();

            _state = state;
            Dock = DockStyle.Fill;
            
            
            BuildSplitNames();
            state.RunManuallyModified += splitNames_RunManuallyModified;
            
        }

        public XmlNode GetSettings(XmlDocument document)
        {
            var element = document.CreateElement("Settings");

            SettingsHelper.CreateSetting(document, element, "Version",
                Assembly.GetExecutingAssembly().GetName().Version.ToString(3));
            
            SettingsHelper.CreateSetting(document, element, "SelectedSplit", Settings.SelectedSplit);
            
            return element;
        }

        public void SetSettings(XmlNode settings)
        {
            cboSelectedSplit.SelectedIndex = SettingsHelper.ParseInt(settings["SelectedSplit"], -1);
        }

        private void BuildSplitNames()
        {
            splitNames = new BindingList<string>();

            for (int i = 0; i < _state.Run.Count; i++)
            {
                splitNames.Add(_state.Run[i].Name);
            }
            
            cboSelectedSplit.DataSource = splitNames;
        }

        private void splitNames_RunManuallyModified(object sender, EventArgs e)
        {
            // TODO: Moving splits Up/Down results in a deletion followed by an addition, which isn't handled correctly
            
            for (int i = 0; i < _state.Run.Count; i++)
            {
                if (splitNames.Count > i)
                {
                    if (splitNames[i] == _state.Run[i].Name) continue;
                    
                    if (splitNames.Count < _state.Run.Count)
                    {
                        //Split was added at this index
                        splitNames.Insert(i, _state.Run[i].Name);

                        break;
                    }
                    
                    if (splitNames.Count > _state.Run.Count)
                    {
                        //Split was removed at this index
                        splitNames.RemoveAt(i);
                        if (i == cboSelectedSplit.SelectedIndex)
                        {
                            //Selected Split was deleted, deselect all splits
                            cboSelectedSplit.SelectedIndex = -1;
                        }

                        break;
                    }
                    
                    //Split was renamed at this index
                    splitNames[i] = _state.Run[i].Name;
                    break;
                }
                
                //Split was added to end
                splitNames.Add(_state.Run[i].Name);
            }

            if (splitNames.Count > _state.Run.Count)
            {
                //Split was removed from end
                splitNames.RemoveAt(splitNames.Count - 1);
            }
        }

        private void btnSetURL_Click(object sender, EventArgs e)
        {
            using (var form = new WebhookURLForm())
            {
                form.ShowDialog();
            }
        }

        private void btnSendMessage_Click(object sender, EventArgs e)
        {
            PaceBot.SendMessage(txtMessage.Text);
        }

        private void cboSelectedSplit_SelectedIndexChanged(object sender, EventArgs e)
        {
            Settings.SelectedSplit = cboSelectedSplit.SelectedIndex;
        }
    }
}