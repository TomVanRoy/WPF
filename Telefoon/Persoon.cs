using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace TelefoonWindow
{
    class Persoon
    {
        public Persoon(string naam, string telefoonnr, groep groep, BitmapImage foto)
        {
            Naam = naam;
            TelefoonNr = telefoonnr;
            Groep = groep;
            Foto = foto;
        }

        internal enum groep
        {
            Familie,
            Werk,
            Vrienden
        }

        public string Naam { get; set; }
        public string TelefoonNr { get; set; }
        public groep Groep { get; set; }
        public BitmapImage Foto { get; set; }
    }
}
