﻿namespace XpfSamples.S03ApplicationBar
{
    using RedBadger.Xpf.Media;

    public class ApplicationBarIconButton
    {
        private readonly ImageSource iconImageSource;

        private readonly string text;

        public ApplicationBarIconButton(string text, ImageSource iconImageSource)
        {
            this.text = text;
            this.iconImageSource = iconImageSource;
        }

        public ImageSource IconImageSource
        {
            get
            {
                return this.iconImageSource;
            }
        }

        public string Text
        {
            get
            {
                return this.text;
            }
        }
    }
}