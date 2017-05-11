using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace HobbyLijst
{
    public class Hobby
    {
        // Constructor
        public Hobby(string nCategorie, string nActiviteit, BitmapImage nSymbool)
        {
            Categorie = nCategorie;
            Activiteit = nActiviteit;
            Symbool = nSymbool;
        }

        // Property
        public string Categorie { get; set; }
        public string Activiteit { get; set; }
        public BitmapImage Symbool { get; set; }
    }
}
