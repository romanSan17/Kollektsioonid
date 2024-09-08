using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kollektsioonid
{
    public class Maakonnad
    {
        private Dictionary<string, string> dictionary;

        public Maakonnad()
        {
            dictionary = new Dictionary<string, string>
            {
                { "Tallinn", "Harju" },
                { "Tartu", "Tartu" },
                { "Narva", "Ida-Viru" },
                { "Pärnu", "Pärnu" },
                { "Kohtla-Järve", "Ida-Viru" }
            };
        }

        // Saada maakond linna järgi
        public string GetMaakond(string linn)
        {
            return dictionary.TryGetValue(linn, out var maakond) ? maakond : "Tundmatu linn";
        }

        // Saada linn maakonna järgi
        public string GetLinn(string maakond)
        {
            foreach (var entry in dictionary)
            {
                if (entry.Value.Equals(maakond, StringComparison.OrdinalIgnoreCase))
                    return entry.Key;
            }
            return "Tundmatu maakond";
        }

        // Lisa uus sissekanne
        public void LisaSissekanne(string linn, string maakond)
        {
            if (dictionary.ContainsKey(linn))
            {
                Console.WriteLine($"Linn {linn} on juba olemas.");
            }
            else
            {
                dictionary[linn] = maakond;
                Console.WriteLine($"Lisatud: {linn} - {maakond}");
            }
        }

        // Küsitlus
        public void Küsitlus()
        {
            var linnad = new List<string>(dictionary.Keys);
            var maakonnad = new List<string>(dictionary.Values);
            var random = new Random();
            int skoor = 0;
            int kogus = 5;

            Console.WriteLine("Kontrolli oma teadmisi.");

            for (int i = 0; i < kogus; i++)
            {
                bool küsiLinna = random.Next(2) == 0;
                if (küsiLinna)
                {
                    var maakond = maakonnad[random.Next(maakonnad.Count)];
                    var õigeVastus = GetLinn(maakond);
                    Console.Write($"Milline linn on maakonnas {maakond}? ");
                    var vastus = Console.ReadLine().Trim();
                    if (vastus.Equals(õigeVastus, StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine("Õige!");
                        skoor++;
                    }
                    else
                    {
                        Console.WriteLine($"Vale. Õige vastus: {õigeVastus}.");
                    }
                }
                else
                {
                    var linn = linnad[random.Next(linnad.Count)];
                    var õigeVastus = GetMaakond(linn);
                    Console.Write($"Milline maakond on linnal {linn}? ");
                    var vastus = Console.ReadLine().Trim();
                    if (vastus.Equals(õigeVastus, StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine("Õige!");
                        skoor++;
                    }
                    else
                    {
                        Console.WriteLine($"Vale. Õige vastus: {õigeVastus}.");
                    }
                }
            }

            Console.WriteLine($"Tulemused: {skoor} {kogus} küsimusest ({(skoor / (double)kogus) * 100:0.0}%)");
        }

        // Näita maakonda linna järgi
        public void NäitaMaakondLinnaJärgi()
        {
            Console.Write("Linn: ");
            var linn = Console.ReadLine().Trim();
            var maakond = GetMaakond(linn);
            Console.WriteLine($"Maakond: {maakond}");
        }

        // Näita linna maakonna järgi
        public void NäitaLinnMaakonnaJärgi()
        {
            Console.Write("Maakond: ");
            var maakond = Console.ReadLine().Trim();
            var linn = GetLinn(maakond);
            Console.WriteLine($"Linn: {linn}");
        }
    }
}