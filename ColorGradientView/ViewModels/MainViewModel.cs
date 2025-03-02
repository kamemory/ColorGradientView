using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using ColorGradientView.Parameters;

namespace ColorGradientView.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            this.Colors = new ObservableCollection<ColorItem>();
            this.AddColor = new RelayCommand(this.OnAddColor);
        }

        public void Init()
        {
            Config c = Config.Load();
            foreach (string item in c.Colors)
            {
                this.Colors.Add(new ColorItem(item));
            }
        }

        public ICommand AddColor { get; private set; }

        public ObservableCollection<ColorItem> Colors { get; private set; }


        private void OnAddColor()
        {
            int r = Random.Shared.Next(256);
            int g = Random.Shared.Next(256);
            int b = Random.Shared.Next(256);
            this.Colors.Add(new ColorItem(r, g, b));
        }
    }
}
