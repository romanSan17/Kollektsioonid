using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kollektsioonid
{
    internal class Auto
    {
        public string Regnumber { get; set; }
        public Color Varv { get; set; }
        public Inimene Omanik { get; set; }
        public Auto() { }
        public Auto(string regnumber, Color varv, Inimene omanik)
        {
            Regnumber = regnumber;
            Varv = varv;
            Omanik = omanik;
        }
        public void KelleOmaAuto()
        {
            Console.WriteLine($"{Varv.Name} auto regnumbriga {Regnumber} on {Omanik.Nimi} oma");
        }
    }
}