using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Kollektsioonid
{
    public class MainClass
    {
        public static void Main(string[] args)
        {
            // 5
            List<int> sortedNumbers = OmaUlesanne.Numbri();
            Console.WriteLine("Paaritu ja paaritu on eraldatud: " + string.Join(", ", sortedNumbers));

            // 4
            StartMaakonnadMenu();

            RunOtherTasks();
        }

        public static void StartMaakonnadMenu()
        {
            var maakonnad = new Maakonnad();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("1. Küsitlus");
                Console.WriteLine("2. Lisa linn");
                Console.WriteLine("3. Näita maakonda linna järgi");
                Console.WriteLine("4. Näita linna maakonna järgi");
                Console.WriteLine("5. Välju");

                string choice = Console.ReadLine().Trim();

                switch (choice)
                {
                    case "1":
                        maakonnad.Küsitlus();
                        break;
                    case "2":
                        Console.Write("Linn: ");
                        var linn = Console.ReadLine().Trim();
                        Console.Write("Maakond: ");
                        var maakond = Console.ReadLine().Trim();
                        maakonnad.LisaSissekanne(linn, maakond);
                        break;
                    case "3":
                        maakonnad.NäitaMaakondLinnaJärgi();
                        break;
                    case "4":
                        maakonnad.NäitaLinnMaakonnaJärgi();
                        break;
                    case "5":

                        return;
                    default:
                        Console.WriteLine("Vale valik.");
                        break;
                }

                Console.WriteLine("Jätkamiseks vajuta Enter...");
                Console.ReadLine();
            }
        }

        public static void RunOtherTasks()
        {
            // 3
            List<Inimene> inimesed = new List<Inimene>();
            Inimene inimene1 = new Inimene();
            inimene1.Nimi = "Pjotr 1";
            inimene1.Vanus = 52;
            inimene1.Sugu = Sugu.mees;
            inimene1.Pikkus = 200;
            inimene1.Kaal = 100;
            Inimene inimene2 = new Inimene("Jelizaveta");
            inimene2.Vanus = 98;
            inimene2.Sugu = Sugu.naine;
            inimene2.Pikkus = 160;
            inimene2.Kaal = 70;
            Inimene inimene3 = new Inimene("Roman");
            inimene3.Vanus = 19;
            inimene3.Sugu = Sugu.mees;
            inimene3.Pikkus = 180;
            inimene3.Kaal = 55;
            inimesed.Add(inimene1);
            inimesed.Add(inimene2);
            inimesed.Add(inimene3);
            inimesed.Add(new Inimene("Irina", 18, Sugu.naine));

            foreach (Inimene inimene in inimesed)
            {
                Console.WriteLine($"{inimene.Nimi} on {inimene.Vanus} aastat vana. Ta on {inimene.Sugu}. SBI={inimene.HB_vorrand()}");
            }

            Auto auto1 = new Auto("681MRP", Color.Bisque, inimene1);
            Auto auto2 = new Auto("180ABC", Color.NavajoWhite, inimene2);
            Auto auto3 = new Auto("079TDI", Color.Red, inimene3);
            auto1.KelleOmaAuto();

            Dictionary<Auto, Inimene> register = new Dictionary<Auto, Inimene>
            {
                { auto1, inimene1 },
                { auto2, inimene3 },
                { auto3, inimene3 }
            };

            foreach (Auto item in register.Keys)
            {
                Console.WriteLine($"{item.Regnumber} - {item.Omanik.Nimi}");
            }

            foreach (KeyValuePair<Auto, Inimene> pair in register)
            {
                Console.WriteLine($"{pair.Key.Regnumber} - {pair.Value.Nimi}");
            }


            string text = "AAAAA BBB RRR OOOOO";
            string[] texts = text.Split(' ');
            Console.WriteLine("Тексты: " + string.Join(", ", texts));
        }
    }
}
