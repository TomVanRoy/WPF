using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ParkingBon
{
    /// <summary>
    /// Interaction logic for ParkingBonWindow.xaml
    /// </summary>
    public partial class ParkingBonWindow : Window
    {
        public ParkingBonWindow()
        {
            InitializeComponent();
            Nieuw();
        }

        private void Nieuw()
        {
            DatumBon.SelectedDate = DateTime.Now;
            AankomstLabelTijd.Content = DateTime.Now.ToLongTimeString();
            TeBetalenLabel.Content = "0 €";
            VertrekLabelTijd.Content = AankomstLabelTijd.Content;
            StatusBarLabel.Content = "nieuwe bon";
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (MessageBox.Show("Programma afsluiten ?", "Afsluiten", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No) == MessageBoxResult.No)
            {
                e.Cancel = true;
            }
        }

        private void minder_Click(object sender, RoutedEventArgs e)
        {
            int bedrag = Convert.ToInt32(TeBetalenLabel.Content.ToString().Replace(" €", ""));
            if (bedrag > 0)
            {
                bedrag -= 1;
            }
            TeBetalenLabel.Content = bedrag.ToString() + " €";
            VertrekLabelTijd.Content = Convert.ToDateTime(AankomstLabelTijd.Content).AddHours(0.5 * bedrag).ToLongTimeString();
        }

        private void meer_Click(object sender, RoutedEventArgs e)
        {
            int bedrag = Convert.ToInt32(TeBetalenLabel.Content.ToString().Replace(" €", ""));
            DateTime vertrekuur = Convert.ToDateTime(AankomstLabelTijd.Content).AddHours(0.5 * bedrag);
            if (vertrekuur.Hour < 22)
            {
                bedrag += 1;
            }
            TeBetalenLabel.Content = bedrag.ToString() + " €";
            VertrekLabelTijd.Content = Convert.ToDateTime(AankomstLabelTijd.Content).AddHours(0.5 * bedrag).ToLongTimeString();
        }

        private void OpenExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            try
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.FileName = "Bon";
                dlg.DefaultExt = ".bon";
                dlg.Filter = "Text documents |*.bon";
                if (dlg.ShowDialog() == true)
                {
                    using (StreamReader bestand = new StreamReader(dlg.FileName))
                    {
                        var line = bestand.ReadLine();
                        var datetimeString = line.Split('/');
                        DatumBon.SelectedDate = new DateTime(int.Parse(datetimeString[2]), int.Parse(datetimeString[1]), int.Parse(datetimeString[0]));
                        AankomstLabelTijd.Content = bestand.ReadLine();
                        TeBetalenLabel.Content = bestand.ReadLine();
                        VertrekLabelTijd.Content = bestand.ReadLine();
                    }
                    StatusBarLabel.Content = System.IO.Path.GetFullPath(dlg.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("openen mislukt : " + ex.Message);
            }
        }
        private void NewExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            Nieuw();
        }

        private void SaveExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            try
            {
                SaveFileDialog dlg = new SaveFileDialog();
                dlg.FileName = DateTime.Today.ToString("dd-MM-yyyy") + "om" + DateTime.Now.ToString("HH-mm-ss");
                dlg.DefaultExt = ".bon";
                dlg.Filter = "Text documents |*.bon";
                if (dlg.ShowDialog() == true)
                {
                    using (StreamWriter bestand = new StreamWriter(dlg.FileName))
                    {
                        bestand.WriteLine(DatumBon.SelectedDate.Value.ToShortDateString());
                        bestand.WriteLine(AankomstLabelTijd.Content.ToString());
                        bestand.WriteLine(TeBetalenLabel.Content.ToString());
                        bestand.WriteLine(VertrekLabelTijd.Content.ToString());

                    }
                    StatusBarLabel.Content = System.IO.Path.GetFullPath(dlg.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("opslaan mislukt: " + ex.Message);
            }
        }

        private void PrintPreviewExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            PrintPreview preview = new PrintPreview();
            preview.Owner = this;
            preview.AfdrukDocument = StelAfdrukSamen();
            preview.ShowDialog();
        }


        private FixedDocument StelAfdrukSamen()
        {
            FixedDocument document = new FixedDocument();
            document.DocumentPaginator.PageSize = new System.Windows.Size(A4breedte, A4hoogte);
            PageContent inhoud = new PageContent();
            document.Pages.Add(inhoud);
            FixedPage page = new FixedPage();
            inhoud.Child = page;
            page.Width = 640;
            page.Height = 320;
            return document;
        }

        private void CloseExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            this.Close();
        }
    }
}