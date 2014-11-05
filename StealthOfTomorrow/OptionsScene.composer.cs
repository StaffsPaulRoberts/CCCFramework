// AUTOMATICALLY GENERATED CODE

using System;
using System.Collections.Generic;
using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Imaging;
using Sce.PlayStation.Core.Environment;
using Sce.PlayStation.HighLevel.UI;

namespace OptionsUI
{
    partial class OptionsScene
    {
        Slider musicVolSlider;
        Slider soundVolSlider;
        Slider BrightnessSlider;
        Slider ContrastSlider;
        Label MusicLabel;
        Label SoundLabel;
        Label BrightnessLabel;
        Label Contrast;
        Button MenuButton;

        private void InitializeWidget()
        {
            InitializeWidget(LayoutOrientation.Horizontal);
        }

        private void InitializeWidget(LayoutOrientation orientation)
        {
            musicVolSlider = new Slider();
            musicVolSlider.Name = "musicVolSlider";
            soundVolSlider = new Slider();
            soundVolSlider.Name = "soundVolSlider";
            BrightnessSlider = new Slider();
            BrightnessSlider.Name = "BrightnessSlider";
            ContrastSlider = new Slider();
            ContrastSlider.Name = "ContrastSlider";
            MusicLabel = new Label();
            MusicLabel.Name = "MusicLabel";
            SoundLabel = new Label();
            SoundLabel.Name = "SoundLabel";
            BrightnessLabel = new Label();
            BrightnessLabel.Name = "BrightnessLabel";
            Contrast = new Label();
            Contrast.Name = "Contrast";
            MenuButton = new Button();
            MenuButton.Name = "MenuButton";

            // OptionsScene
            this.RootWidget.AddChildLast(musicVolSlider);
            this.RootWidget.AddChildLast(soundVolSlider);
            this.RootWidget.AddChildLast(BrightnessSlider);
            this.RootWidget.AddChildLast(ContrastSlider);
            this.RootWidget.AddChildLast(MusicLabel);
            this.RootWidget.AddChildLast(SoundLabel);
            this.RootWidget.AddChildLast(BrightnessLabel);
            this.RootWidget.AddChildLast(Contrast);
            this.RootWidget.AddChildLast(MenuButton);

            // musicVolSlider
            musicVolSlider.MinValue = 0;
            musicVolSlider.MaxValue = 100;
            musicVolSlider.Value = 100;
            musicVolSlider.Step = 1;

            // soundVolSlider
            soundVolSlider.MinValue = 0;
            soundVolSlider.MaxValue = 100;
            soundVolSlider.Value = 100;
            soundVolSlider.Step = 1;

            // BrightnessSlider
            BrightnessSlider.MinValue = 0;
            BrightnessSlider.MaxValue = 100;
            BrightnessSlider.Value = 100;
            BrightnessSlider.Step = 1;

            // ContrastSlider
            ContrastSlider.MinValue = 0;
            ContrastSlider.MaxValue = 100;
            ContrastSlider.Value = 100;
            ContrastSlider.Step = 1;

            // MusicLabel
            MusicLabel.TextColor = new UIColor(0f / 255f, 0f / 255f, 0f / 255f, 255f / 255f);
            MusicLabel.Font = new UIFont(FontAlias.System, 25, FontStyle.Bold);
            MusicLabel.TextTrimming = TextTrimming.EllipsisWord;
            MusicLabel.LineBreak = LineBreak.Character;

            // SoundLabel
            SoundLabel.TextColor = new UIColor(0f / 255f, 0f / 255f, 0f / 255f, 255f / 255f);
            SoundLabel.Font = new UIFont(FontAlias.System, 25, FontStyle.Bold);
            SoundLabel.TextTrimming = TextTrimming.EllipsisWord;
            SoundLabel.LineBreak = LineBreak.Character;

            // BrightnessLabel
            BrightnessLabel.TextColor = new UIColor(0f / 255f, 0f / 255f, 0f / 255f, 255f / 255f);
            BrightnessLabel.Font = new UIFont(FontAlias.System, 25, FontStyle.Bold);
            BrightnessLabel.TextTrimming = TextTrimming.EllipsisWord;
            BrightnessLabel.LineBreak = LineBreak.Character;

            // Contrast
            Contrast.TextColor = new UIColor(0f / 255f, 0f / 255f, 0f / 255f, 255f / 255f);
            Contrast.Font = new UIFont(FontAlias.System, 25, FontStyle.Bold);
            Contrast.TextTrimming = TextTrimming.EllipsisWord;
            Contrast.LineBreak = LineBreak.Character;

            // MenuButton
            MenuButton.TextColor = new UIColor(0f / 255f, 0f / 255f, 0f / 255f, 255f / 255f);
            MenuButton.TextFont = new UIFont(FontAlias.System, 25, FontStyle.Regular);

            SetWidgetLayout(orientation);

            UpdateLanguage();
        }

        private LayoutOrientation _currentLayoutOrientation;
        public void SetWidgetLayout(LayoutOrientation orientation)
        {
            switch (orientation)
            {
                case LayoutOrientation.Vertical:
                    this.DesignWidth = 544;
                    this.DesignHeight = 960;

                    musicVolSlider.SetPosition(279, 215);
                    musicVolSlider.SetSize(362, 58);
                    musicVolSlider.Anchors = Anchors.Height;
                    musicVolSlider.Visible = true;

                    soundVolSlider.SetPosition(282, 278);
                    soundVolSlider.SetSize(362, 58);
                    soundVolSlider.Anchors = Anchors.Height;
                    soundVolSlider.Visible = true;

                    BrightnessSlider.SetPosition(279, 215);
                    BrightnessSlider.SetSize(362, 58);
                    BrightnessSlider.Anchors = Anchors.Height;
                    BrightnessSlider.Visible = true;

                    ContrastSlider.SetPosition(282, 278);
                    ContrastSlider.SetSize(362, 58);
                    ContrastSlider.Anchors = Anchors.Height;
                    ContrastSlider.Visible = true;

                    MusicLabel.SetPosition(113, 315);
                    MusicLabel.SetSize(214, 36);
                    MusicLabel.Anchors = Anchors.None;
                    MusicLabel.Visible = true;

                    SoundLabel.SetPosition(113, 315);
                    SoundLabel.SetSize(214, 36);
                    SoundLabel.Anchors = Anchors.None;
                    SoundLabel.Visible = true;

                    BrightnessLabel.SetPosition(113, 315);
                    BrightnessLabel.SetSize(214, 36);
                    BrightnessLabel.Anchors = Anchors.None;
                    BrightnessLabel.Visible = true;

                    Contrast.SetPosition(113, 315);
                    Contrast.SetSize(214, 36);
                    Contrast.Anchors = Anchors.None;
                    Contrast.Visible = true;

                    MenuButton.SetPosition(57, 30);
                    MenuButton.SetSize(214, 56);
                    MenuButton.Anchors = Anchors.None;
                    MenuButton.Visible = true;

                    break;

                default:
                    this.DesignWidth = 960;
                    this.DesignHeight = 544;

                    musicVolSlider.SetPosition(30, 351);
                    musicVolSlider.SetSize(362, 58);
                    musicVolSlider.Anchors = Anchors.Height;
                    musicVolSlider.Visible = true;

                    soundVolSlider.SetPosition(30, 451);
                    soundVolSlider.SetSize(362, 58);
                    soundVolSlider.Anchors = Anchors.Height;
                    soundVolSlider.Visible = true;

                    BrightnessSlider.SetPosition(549, 351);
                    BrightnessSlider.SetSize(362, 58);
                    BrightnessSlider.Anchors = Anchors.Height;
                    BrightnessSlider.Visible = true;

                    ContrastSlider.SetPosition(549, 451);
                    ContrastSlider.SetSize(362, 58);
                    ContrastSlider.Anchors = Anchors.Height;
                    ContrastSlider.Visible = true;

                    MusicLabel.SetPosition(154, 315);
                    MusicLabel.SetSize(80, 36);
                    MusicLabel.Anchors = Anchors.None;
                    MusicLabel.Visible = true;

                    SoundLabel.SetPosition(153, 427);
                    SoundLabel.SetSize(88, 36);
                    SoundLabel.Anchors = Anchors.None;
                    SoundLabel.Visible = true;

                    BrightnessLabel.SetPosition(664, 315);
                    BrightnessLabel.SetSize(135, 36);
                    BrightnessLabel.Anchors = Anchors.None;
                    BrightnessLabel.Visible = true;

                    Contrast.SetPosition(678, 427);
                    Contrast.SetSize(107, 36);
                    Contrast.Anchors = Anchors.None;
                    Contrast.Visible = true;

                    MenuButton.SetPosition(57, 30);
                    MenuButton.SetSize(214, 56);
                    MenuButton.Anchors = Anchors.None;
                    MenuButton.Visible = true;

                    break;
            }
            _currentLayoutOrientation = orientation;
        }

        public void UpdateLanguage()
        {
            this.Title = "Options";

            MusicLabel.Text = "Music";

            SoundLabel.Text = "Sound";

            BrightnessLabel.Text = "Brightness";

            Contrast.Text = "Contrast";

            MenuButton.Text = "Menu";
        }

        private void onShowing(object sender, EventArgs e)
        {
            switch (_currentLayoutOrientation)
            {
                case LayoutOrientation.Vertical:
                    break;

                default:
                    break;
            }
        }

        private void onShown(object sender, EventArgs e)
        {
            switch (_currentLayoutOrientation)
            {
                case LayoutOrientation.Vertical:
                    break;

                default:
                    break;
            }
        }

    }
}
