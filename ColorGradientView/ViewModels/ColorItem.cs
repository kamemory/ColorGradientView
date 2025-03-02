using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static System.Net.Mime.MediaTypeNames;

namespace ColorGradientView.ViewModels
{
    public class ColorItem : ViewModelBase
    {
        public ColorItem()
        {
        }

        public ColorItem(int r, int g, int b)
        {
            this.Color = string.Format("#{0}{1}{2}", r.ToString("x2"), g.ToString("x2"), b.ToString("x2"));
            this.Color100.Update(r, g, b, 1);
            this.Color200.Update(r, g, b, 2);
            this.Color300.Update(r, g, b, 3);
            this.Color400.Update(r, g, b, 4);
            this.Color500.Update(r, g, b, 5);
            this.Color600.Update(r, g, b, 6);
            this.Color700.Update(r, g, b, 7);
            this.Color800.Update(r, g, b, 8);
            this.Color900.Update(r, g, b, 9);
        }

        public ColorItem(string colorCode)
        {
            this.Color = colorCode;
            this.Update(colorCode);
        }

        public string Color
        {
            get { return _color; }
            set
            {
                if (this.SetProperty(ref _color, value))
                {
                    this.Update(value);
                }
            }
        }

        public GradientItem Color100 { get; } = new GradientItem();
        public GradientItem Color200 { get; } = new GradientItem();
        public GradientItem Color300 { get; } = new GradientItem();
        public GradientItem Color400 { get; } = new GradientItem();
        public GradientItem Color500 { get; } = new GradientItem();
        public GradientItem Color600 { get; } = new GradientItem();
        public GradientItem Color700 { get; } = new GradientItem();
        public GradientItem Color800 { get; } = new GradientItem();
        public GradientItem Color900 { get; } = new GradientItem();


        private string _color = string.Empty;

        private void Update(string c)
        {
            if (string.IsNullOrEmpty(c) || c.Length != 7 || !c.StartsWith("#"))
            {
                return;
            }
            string rs = c.Substring(1, 2);
            string gs = c.Substring(3, 2);
            string bs = c.Substring(5, 2);
            int r = Convert.ToInt32(rs, 16);
            int g = Convert.ToInt32(gs, 16);
            int b = Convert.ToInt32(bs, 16);
            this.Color100.Update(r, g, b, 1);
            this.Color200.Update(r, g, b, 2);
            this.Color300.Update(r, g, b, 3);
            this.Color400.Update(r, g, b, 4);
            this.Color500.Update(r, g, b, 5);
            this.Color600.Update(r, g, b, 6);
            this.Color700.Update(r, g, b, 7);
            this.Color800.Update(r, g, b, 8);
            this.Color900.Update(r, g, b, 9);
        }
    }
}
