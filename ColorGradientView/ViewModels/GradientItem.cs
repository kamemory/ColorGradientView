using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ColorGradientView.ViewModels
{
    public class GradientItem : ViewModelBase
    {
        public Color Value
        {
            get { return _color; }
            private set
            {
                _color = value;
                this.RaisePropertyChanged(nameof(this.Value));
            }
        }

        public void Update(int r, int g, int b, int rate)
        {
            byte rx;
            byte gx;
            byte bx;
            if (rate < 5)
            {
                rx = this.AdjustLowerValue(r, rate);
                gx = this.AdjustLowerValue(g, rate);
                bx = this.AdjustLowerValue(b, rate);
            }
            else if (rate > 5)
            {
                rx = this.AdjustUpperValue(r, rate);
                gx = this.AdjustUpperValue(g, rate);
                bx = this.AdjustUpperValue(b, rate);
            }
            else
            {
                rx = (byte)r;
                gx = (byte)g;
                bx = (byte)b;
            }
            this.Value = Color.FromRgb(rx, gx, bx);
        }

        public override string ToString()
        {
            return string.Format("#{0:x2}{1:x2}{2:x2}", this._color.R, this._color.G, this._color.B);
        }

        private byte AdjustLowerValue(int v, int rate)
        {
            return (byte)(v / 5.0 * rate);
        }

        private byte AdjustUpperValue(int v, int rate)
        {
            int d = 255 - v;
            int rd = rate - 5;
            return (byte)(d / 5.0 * rd + v);
        }


        private Color _color = Color.FromRgb(255, 255, 255);
    }
}
