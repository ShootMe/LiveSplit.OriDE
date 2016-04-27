using LiveSplit.Model;
using System.IO;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;
using System;
using System.Data;

namespace LiveSplit.OriDE.Settings {
	public partial class OriSettings : UserControl {
		public List<OriSplit> Splits { get; private set; }
		public bool ShowMapDisplay { get; set; }
		private OriComponent component;
		private bool isLoading;
		public OriSettings(OriComponent comp) {
			isLoading = true;
			InitializeComponent();

			component = comp;
			Splits = new List<OriSplit>();
			isLoading = false;
		}

		private void OriSettings_Load(object sender, EventArgs e) {
			LoadSettings();
		}
		public void LoadSettings() {
			isLoading = true;
			this.flowMain.SuspendLayout();

			for (int i = flowMain.Controls.Count - 1; i > 0; i--) {
				flowMain.Controls.RemoveAt(i);
			}

			foreach (OriSplit split in Splits) {
				OriSplitSettings setting = new OriSplitSettings();
				setting.cboName.DisplayMember = "SplitName";
				setting.cboName.ValueMember = "Type";
				setting.cboName.DataSource = SplitComboData();
				setting.cboName.Text = split.Field;
				setting.txtValue.Text = split.Value;
				setting.chkShouldSplit.Checked = split.ShouldSplit;
				AddHandlers(setting);

				flowMain.Controls.Add(setting);
			}

			chkShowMapDisplay.Checked = ShowMapDisplay;

			isLoading = false;
			this.flowMain.ResumeLayout(true);
		}
		private void AddHandlers(OriSplitSettings setting) {
			setting.txtValue.TextChanged += new EventHandler(txtValue_TextChanged);
			setting.cboName.SelectedIndexChanged += new EventHandler(cboName_SelectedIndexChanged);
			setting.btnRemove.Click += new EventHandler(btnRemove_Click);
			setting.btnUp.Click += new EventHandler(btnUp_Click);
			setting.btnDown.Click += new EventHandler(btnDown_Click);
			setting.chkShouldSplit.CheckedChanged += new EventHandler(chkBox_CheckedChanged);
		}
		private void RemoveHandlers(OriSplitSettings setting) {
			setting.txtValue.TextChanged -= txtValue_TextChanged;
			setting.cboName.SelectedIndexChanged -= cboName_SelectedIndexChanged;
			setting.btnRemove.Click -= btnRemove_Click;
			setting.btnUp.Click -= btnUp_Click;
			setting.btnDown.Click -= btnDown_Click;
		}
		public void btnDown_Click(object sender, EventArgs e) {
			for (int i = flowMain.Controls.Count - 2; i > 1; i--) {
				Control c = flowMain.Controls[i];
				if (c.Contains((Control)sender)) {
					flowMain.Controls.SetChildIndex(c, i + 1);
					UpdateSplits();
					break;
				}
			}
		}
		public void btnUp_Click(object sender, EventArgs e) {
			for (int i = flowMain.Controls.Count - 1; i > 2; i--) {
				Control c = flowMain.Controls[i];
				if (c.Contains((Control)sender)) {
					flowMain.Controls.SetChildIndex(c, i - 1);
					UpdateSplits();
					break;
				}
			}
		}
		public void btnRemove_Click(object sender, EventArgs e) {
			for (int i = flowMain.Controls.Count - 1; i > 1; i--) {
				if (flowMain.Controls[i].Contains((Control)sender)) {
					RemoveHandlers((OriSplitSettings)((Button)sender).Parent);

					flowMain.Controls.RemoveAt(i);
					break;
				}
			}
			UpdateSplits();
		}
		private void txtValue_TextChanged(object sender, EventArgs e) {
			UpdateSplits();
		}
		public void cboName_SelectedIndexChanged(object sender, EventArgs e) {
			UpdateSplits();
		}
		private void chkBox_CheckedChanged(object sender, EventArgs e) {
			UpdateSplits();
		}
		public void UpdateSplits() {
			if (isLoading) return;

			Splits.Clear();
			foreach (Control c in flowMain.Controls) {
				if (c is OriSplitSettings) {
					OriSplitSettings setting = (OriSplitSettings)c;
					if (!string.IsNullOrEmpty(setting.cboName.Text) && !string.IsNullOrEmpty(setting.txtValue.Text)) {
						OriSplit split = new OriSplit(setting.cboName.Text, setting.txtValue.Text, setting.chkShouldSplit.Checked);
						Splits.Add(split);
					}
				}
			}
			ShowMapDisplay = chkShowMapDisplay.Checked;
		}
		public XmlNode UpdateSettings(XmlDocument document) {
			XmlElement xmlSettings = document.CreateElement("Settings");

			XmlElement xmlMap = document.CreateElement("MapDisplay");
			xmlMap.InnerText = chkShowMapDisplay.Checked.ToString();
			xmlSettings.AppendChild(xmlMap);

			XmlElement xmlSplits = document.CreateElement("Splits");
			xmlSettings.AppendChild(xmlSplits);

			foreach (OriSplit split in Splits) {
				XmlElement xmlSplit = document.CreateElement("Split");
				xmlSplit.InnerText = split.Field;

				XmlAttribute att = document.CreateAttribute("Value");
				att.Value = split.Value;
				xmlSplit.Attributes.Append(att);

				att = document.CreateAttribute("ShouldSplit");
				att.Value = split.ShouldSplit.ToString();
				xmlSplit.Attributes.Append(att);

				xmlSplits.AppendChild(xmlSplit);
			}
			return xmlSettings;
		}
		public void SetSettings(XmlNode settings) {
			XmlNode showMapNode = settings.SelectSingleNode("//MapDisplay");
			if (showMapNode != null && showMapNode.InnerText != "") {
				ShowMapDisplay = bool.Parse(showMapNode.InnerText);
			} else {
				ShowMapDisplay = false;
			}

			Splits.Clear();
			XmlNodeList splitNodes = settings.SelectNodes("//Splits/Split");
			foreach (XmlNode splitNode in splitNodes) {
				string name = splitNode.InnerText;
				string value = splitNode.Attributes["Value"].Value;
				bool shouldSplit = bool.Parse(splitNode.Attributes["ShouldSplit"].Value);
				Splits.Add(new OriSplit(name, value, shouldSplit));
			}
		}
		private void btnAddSplit_Click(object sender, EventArgs e) {
			OriSplitSettings setting = new OriSplitSettings();
			setting.cboName.DisplayMember = "SplitName";
			setting.cboName.ValueMember = "Type";
			setting.cboName.DataSource = SplitComboData();
			setting.cboName.Text = "Start Game";
			setting.txtValue.Text = "True";
			setting.chkShouldSplit.Checked = true;
			AddHandlers(setting);

			flowMain.Controls.Add(setting);
			UpdateSplits();
		}
		public DataTable SplitComboData() {
			DataTable dt = new DataTable();
			dt.Columns.Add("SplitName", typeof(string));
			dt.Columns.Add("Type", typeof(string));
			foreach (var pair in OriSplitSettings.AvailableSplits) {
				dt.Rows.Add(pair.Key, pair.Value);
			}
			return dt;
		}
	}
}