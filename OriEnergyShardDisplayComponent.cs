using LiveSplit.Model;
using LiveSplit.OriDE.Memory;
using LiveSplit.UI;
using LiveSplit.UI.Components;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;
namespace LiveSplit.OriDE {
    public class OriEnergyShardDisplayComponent : IComponent {
        public string ComponentName => "Ori Energy Shard Display";
        public float HorizontalWidth => textInfo.HorizontalWidth;
        public float MinimumHeight => textInfo.MinimumHeight;
        public float VerticalHeight => textInfo.VerticalHeight;
        public float MinimumWidth => textInfo.MinimumWidth;
        public float PaddingTop => textInfo.PaddingTop;
        public float PaddingBottom => textInfo.PaddingBottom;
        public float PaddingLeft => textInfo.PaddingLeft;
        public float PaddingRight => textInfo.PaddingRight;
        public IDictionary<string, Action> ContextMenuControls => null;

        private InfoTextComponent textInfo;
        private OriMemory memory;
        public int TotalCount;
        private int lastCount;
        public OriEnergyShardDisplayComponent(OriMemory memory) {
            textInfo = new InfoTextComponent("Energy Shards:", "99");
            textInfo.NameLabel.VerticalAlignment = StringAlignment.Far;
            textInfo.LongestString = "Energy Shards: 99";
            this.memory = memory;
        }

        public void Update(IInvalidator invalidator, LiveSplitState state, float width, float height, LayoutMode mode) {
            bool hasWJ = memory.GetAbility("Wall Jump");
            int currentCount = hasWJ ? 0 : memory.CurrentEnergyShardCount();

            if (currentCount > lastCount) {
                TotalCount += currentCount - lastCount;
            }

            lastCount = currentCount;

            textInfo.InformationName = "Energy Shards:";
            textInfo.InformationValue = $"{TotalCount}";
            textInfo.Update(invalidator, state, width, height, mode);
            if (invalidator != null) {
                invalidator.Invalidate(0, 0, width, height);
            }
        }
        public void DrawHorizontal(Graphics g, LiveSplitState state, float height, Region clipRegion) {
            if (state.LayoutSettings.BackgroundColor.ToArgb() != Color.Transparent.ToArgb()) {
                g.FillRectangle(new SolidBrush(state.LayoutSettings.BackgroundColor), 0, 0, HorizontalWidth, height);
            }
            PrepareDraw(state, LayoutMode.Horizontal);
            textInfo.DrawHorizontal(g, state, height, clipRegion);
        }
        public void DrawVertical(Graphics g, LiveSplitState state, float width, Region clipRegion) {
            if (state.LayoutSettings.BackgroundColor.ToArgb() != Color.Transparent.ToArgb()) {
                g.FillRectangle(new SolidBrush(state.LayoutSettings.BackgroundColor), 0, 0, width, VerticalHeight);
            }
            PrepareDraw(state, LayoutMode.Vertical);
            textInfo.DrawVertical(g, state, width, clipRegion);
        }
        private void PrepareDraw(LiveSplitState state, LayoutMode mode) {
            textInfo.NameLabel.HasShadow = textInfo.ValueLabel.HasShadow = state.LayoutSettings.DropShadows;
            textInfo.NameLabel.HorizontalAlignment = StringAlignment.Far;
            textInfo.ValueLabel.HorizontalAlignment = StringAlignment.Far;
            textInfo.NameLabel.VerticalAlignment = StringAlignment.Near;
            textInfo.ValueLabel.VerticalAlignment = StringAlignment.Near;
            textInfo.NameLabel.ForeColor = state.LayoutSettings.TextColor;
            textInfo.ValueLabel.ForeColor = state.LayoutSettings.TextColor;
        }
        public XmlNode GetSettings(XmlDocument document) { return document.CreateElement("Settings"); }
        public Control GetSettingsControl(LayoutMode mode) { return null; }
        public void SetSettings(XmlNode settings) { }
        public void Dispose() { }
        public override bool Equals(object obj) {
            return obj != null && obj is OriEnergyShardDisplayComponent;
        }
        public override int GetHashCode() {
            return 123456787;
        }
    }
}