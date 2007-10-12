using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;
namespace ActiveDirectoryHelper.Collections
{
    public class HighlightSetting 
    {
        private string orgUnit = string.Empty;
        /// <summary>
        /// Organizational Unit to configure for color highlighting
        /// </summary>
        [Description("Organizational Unit to configure for color highlighting")]
        public string OrgUnit
        {
            get { return orgUnit; }
            set { orgUnit = value; }
        }
        private Color highlightColor = new Color();

        /// <summary>
        /// Color to use in higlighting
        /// </summary>
        [Description("Color to use in higlighting")]
        [XmlIgnore()] 
        public Color HighlightColor
        {
            get { return highlightColor; }
            set { highlightColor = value; }
        }


        [XmlElement("HighlightColor")]
        [Browsable(false)]
        public string XmlColorType
        {
            get
            {
                return SerializeColor(HighlightColor);
            }
            set
            {
                HighlightColor = DeserializeColor(value);
            }
        }


        public HighlightSetting()
        {
            
        }
        public HighlightSetting(string orgUnit, Color highlightColor)
        {
            this.orgUnit = orgUnit;
            this.highlightColor = highlightColor;

        }


        public string SerializeColor(Color color)
        {
            if (color.IsNamedColor)
                return string.Format("{0}:{1}",
                    ColorFormat.NamedColor, color.Name);
            else
                return string.Format("{0}:{1}:{2}:{3}:{4}",
                    ColorFormat.ARGBColor,
                    color.A, color.R, color.G, color.B);
        }
        public Color DeserializeColor(string color)
        {
            byte a, r, g, b;

            string[] pieces = color.Split(new char[] { ':' });

            ColorFormat colorType = (ColorFormat)
                Enum.Parse(typeof(ColorFormat), pieces[0], true);

            switch (colorType)
            {
                case ColorFormat.NamedColor:
                    return Color.FromName(pieces[1]);

                case ColorFormat.ARGBColor:
                    a = byte.Parse(pieces[1]);
                    r = byte.Parse(pieces[2]);
                    g = byte.Parse(pieces[3]);
                    b = byte.Parse(pieces[4]);

                    return Color.FromArgb(a, r, g, b);
            }
            return Color.Empty;
        }
        public enum ColorFormat
        {
            NamedColor,
            ARGBColor
        }
    }
}