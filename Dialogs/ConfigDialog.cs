using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SortImage;

namespace SortImage
{
    public partial class ConfigDialog : Form
    {
       private SortImgSettings settings;
       private List<int> inkeys;
       private bool watchKeyPress = false;

        public ConfigDialog(SortImgSettings set) {
            InitializeComponent();
            settings = set;
            this.KeyUp += new KeyEventHandler(Key);
            inkeys = settings.GetKeyBinds();
            updateKeyText(inkeys[0]);
            keyList.DataSource = settings.GetKeyNames();
            dupCheckType.SelectedIndex = settings.DuplicateCheckMode;
            enableLoggingCheckbox.Checked = settings.LogValue;
            fileSortComboBox.SelectedIndex = settings.OrderBy;
        }

        private void Config_Load(object sender, EventArgs e) {}

        private void Key(Object o, KeyEventArgs e) {
            if (!watchKeyPress) {
                return;
            }

            if (e.KeyValue <= 0) {
                return;
            }

            if (inkeys.Contains(e.KeyValue) && inkeys[keyList.SelectedIndex] != e.KeyValue) { //Setting a key to same and not current selected place
                MessageBox.Show("Can't use same key for seperate actions");
            } else {
                inkeys[keyList.SelectedIndex] = e.KeyValue;
                updateKeyText(inkeys[keyList.SelectedIndex]);
                settings.SaveKey(Convert.ToString(keyList.SelectedItem), Convert.ToString(inkeys[keyList.SelectedIndex]));
            }

            watchKeyPress = false;
            configDone.Enabled = true;
            pickKey.Enabled = true;
            keyList.Enabled = true;
            infoYell.Visible = false;
            dupCheckType.Enabled = true;
        }

        private void keyList_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateKeyText(inkeys[keyList.SelectedIndex]);
        }

        private void pickKey_Click(object sender, EventArgs e)
        {
            configDone.Enabled = false;
            pickKey.Enabled = false;
            keyList.Enabled = false;
            infoYell.Visible = true;
            dupCheckType.Enabled = false;
            watchKeyPress = true;
        }

        private void dupCheckType_SelectedIndexChanged(object sender, EventArgs e)
        {
            settings.DuplicateCheckMode = dupCheckType.SelectedIndex;
        }

        private void updateKeyText(int keyValue)
        {
            currentKey.Text = Convert.ToString(keyValue) + " (" + Enum.GetName(typeof(Keys), keyValue) + ")";
        }

        private void enableLoggingCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            settings.LogValue = enableLoggingCheckbox.Checked;
        }

        private void fileSortComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            settings.OrderBy = fileSortComboBox.SelectedIndex;
        }
    }
}
