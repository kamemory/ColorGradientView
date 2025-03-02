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
            this.SaveColors = new RelayCommand(this.OnSaveColors);
            this.LoadColors = new RelayCommand(this.OnLoadColors);
        }

        public void Init()
        {
            this.OnLoadColors();
        }

        public ICommand AddColor { get; private set; }

        public ICommand SaveColors {  get; private set; }

        public ICommand LoadColors { get; private set; }

        public ObservableCollection<ColorItem> Colors { get; private set; }


        private void OnAddColor()
        {
            int r = Random.Shared.Next(256);
            int g = Random.Shared.Next(256);
            int b = Random.Shared.Next(256);
            this.Colors.Add(new ColorItem(r, g, b));
        }

        private void OnSaveColors()
        {
            List<string> colorText = this.Colors
                .Select(p => p.Color500.ToString())
                .ToList();
            Config.Save(colorText);
        }

        private void OnLoadColors()
        {
            this.Colors.Clear();

            Config c = Config.Load();
            foreach (string item in c.Colors)
            {
                this.Colors.Add(new ColorItem(item));
            }
        }
    }
}
