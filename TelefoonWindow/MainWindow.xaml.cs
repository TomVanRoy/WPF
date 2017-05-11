using System;
using System.Collections.Generic;
using System.Linq;
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

namespace TelefoonWindow
{
    /// <summary>
    /// Interaction logic for TelefoonWindow.xaml
    /// </summary>
    public partial class TelefoonWindow : Window
    {
        public TelefoonWindow()
        {
            InitializeComponent();
        }

        public void Window_Loaded(object sender, RoutedEventArgs e)
        {
            List<Persoon> personen = new List<Persoon>();
            personen.Add(new Persoon("Anne", "0498/65.46.54", Persoon.groep.Vrienden, new BitmapImage(new Uri(@"images\anne.jpg", UriKind.Relative))));
            personen.Add(new Persoon("Bob", "0498/65.46.54", Persoon.groep.Vrienden, new BitmapImage(new Uri(@"images\bob.jpg", UriKind.Relative))));
            personen.Add(new Persoon("Collega1", "0498/65.46.54", Persoon.groep.Werk, new BitmapImage(new Uri(@"images\collega1.jpg", UriKind.Relative))));
            personen.Add(new Persoon("Collega2", "0498/65.46.54", Persoon.groep.Werk, new BitmapImage(new Uri(@"images\collega2.jpg", UriKind.Relative))));
            personen.Add(new Persoon("Collega3", "0498/65.46.54", Persoon.groep.Werk, new BitmapImage(new Uri(@"images\collega3.jpg", UriKind.Relative))));
            personen.Add(new Persoon("Ed", "0498/65.46.54", Persoon.groep.Vrienden, new BitmapImage(new Uri(@"images\ed.jpg", UriKind.Relative))));
            personen.Add(new Persoon("Grote Zus", "0498/65.46.54", Persoon.groep.Familie, new BitmapImage(new Uri(@"images\grotezus.jpg", UriKind.Relative))));
            personen.Add(new Persoon("Kleine Zus", "0498/65.46.54", Persoon.groep.Familie, new BitmapImage(new Uri(@"images\kleinezus.jpg", UriKind.Relative))));
            personen.Add(new Persoon("Tante Non", "0498/65.46.54", Persoon.groep.Familie, new BitmapImage(new Uri(@"images\tantenon.jpg", UriKind.Relative))));
            personen.Add(new Persoon("Vader", "0498/65.46.54", Persoon.groep.Familie, new BitmapImage(new Uri(@"images\vader.jpg", UriKind.Relative))));
            
            foreach (var persoon in personen)
            {
                ListBoxPersonen.Items.Add(persoon);
            }
        }

        private void ButtonTelefoon_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
