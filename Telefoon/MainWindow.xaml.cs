using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Media;

namespace TelefoonWindow
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Persoon> personen = new List<Persoon>();
        public MainWindow()
        {
            InitializeComponent();
        }

        public void Window_Loaded(object sender, RoutedEventArgs e)
        {

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

            ComboBoxGroep.Items.Add("- iedereen -");
            ComboBoxGroep.Items.Add(Persoon.groep.Familie);
            ComboBoxGroep.Items.Add(Persoon.groep.Vrienden);
            ComboBoxGroep.Items.Add(Persoon.groep.Werk);
            ComboBoxGroep.SelectedIndex = 0;
        }

        public void ButtonTelefoon_Click(object sender, RoutedEventArgs e)
        {
            if (ListBoxPersonen.SelectedItem != null)
            {
                Persoon per = (Persoon)ListBoxPersonen.SelectedItem;
                if (MessageBox.Show($"Wil je {per.Naam} bellen\nop nummer: {per.TelefoonNr}", "Telefoon", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.Yes) == MessageBoxResult.Yes)
                {
                    SoundPlayer speler = new SoundPlayer(@"C:\VisualStudio\Projects\WPF\Telefoon\images\PHONE.wav");
                    speler.Play();
                }
            }
            else
            {
                MessageBox.Show("Je moet eerst iemand selecteren", "Niemand gekozen", MessageBoxButton.OK, MessageBoxImage.Exclamation, MessageBoxResult.OK);
            }
        }

        private void ComboBoxGroep_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBoxPersonen.Items.Clear();
            foreach (Persoon per in personen)
            {
                if (per.Groep.ToString() == ComboBoxGroep.SelectedItem.ToString() || ComboBoxGroep.SelectedIndex == 0)
                {
                    ListBoxPersonen.Items.Add(per);
                }
            }
        }
    }
}