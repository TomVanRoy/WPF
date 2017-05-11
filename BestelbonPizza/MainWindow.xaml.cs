using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BestelbonPizza
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonPlus_Click(object sender, RoutedEventArgs e)
        {
            if (Convert.ToInt16(TextAantal.Text) < 10)
            {
                TextAantal.Text = (Convert.ToInt16(TextAantal.Text) + 1).ToString();
            }
        }

        private void ButtonMinus_Click(object sender, RoutedEventArgs e)
        {
            if (Convert.ToInt16(TextAantal.Text) > 1)
            {
                TextAantal.Text = (Convert.ToInt16(TextAantal.Text) - 1).ToString();
            }
        }

        private void ButtonBestellen_Click(object sender, RoutedEventArgs e)
        {
            string result = $"U heeft {TextAantal.Text} ";
            string ingredienten = string.Empty;
            foreach (FrameworkElement kind in boxen.Children)
            {
                if (kind is RadioButton)
                {
                    if (((RadioButton)kind).IsChecked == true)
                    {
                        result += $"{kind.Name} pizza('s) besteld met: ";
                    }
                }
                if (kind is CheckBox)
                {
                    if (((CheckBox)kind).IsChecked == true)
                    {
                        ingredienten += $"{kind.Name}, ";
                    }
                }
            }
            int laatste = ingredienten.LastIndexOf(',');
            ingredienten = ingredienten.Remove(laatste);
            laatste = ingredienten.LastIndexOf(',');
            ingredienten = ingredienten.Substring(0, laatste) + " en " + ingredienten.Substring(laatste + 2);
            result += ingredienten;
            if (ButtonKorst.IsChecked == true)
            {
                result += "met een extra dikke korst";
            }
            if (ButtonKorst.IsChecked == true && ButtonKaas.IsChecked == true)
            {
                result += " en ";
            }
            if (ButtonKorst.IsChecked == true)
            {
                result += "met een extra kaas";
            }
            TextResult.Text = result;
        }

        private void ButtonKaas_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}
