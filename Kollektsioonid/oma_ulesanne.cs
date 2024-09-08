using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kollektsioonid
{
    public class OmaUlesanne
    {
        public static List<int> Numbri()
        {
            Random random = new Random();

            // Juhuslike numbrite nimekirja loomine
            List<int> numbers = new List<int>();
            for (int i = 0; i < 10; i++)
            {
                numbers.Add(random.Next(1, 101)); 
            }

            // saadud numbrid
            Console.WriteLine("Random numbers: " + string.Join(", ", numbers));

            // paariline ja paaritu
            List<int> evenNumbers = numbers.Where(x => x % 2 == 0).ToList(); 
            List<int> oddNumbers = numbers.Where(x => x % 2 != 0).ToList();

            // ühendus
            List<int> result = evenNumbers.Concat(oddNumbers).ToList();

            return result;
        }
    }
}
