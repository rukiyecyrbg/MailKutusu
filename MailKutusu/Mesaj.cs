using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailKutusu
{
    public class Mesaj
    {
        public string Baslik { get; set; }
        public string Gonderen { get; set; }
        public string Alici { get; set; }
        public string Icerik { get; set; }

        public override string ToString()
        {
            return "BASLIK" + Baslik + "\n GÖNDEREN: "+ Gonderen + "\n ALICI: " + Alici + "\n İÇERİK: " + Icerik;
        }
    }
}
