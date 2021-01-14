using System;
using System.Collections.Generic;

namespace Lab2
{

    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();

            bool menyLoop = true;
            string answer;
            while (menyLoop)
            {
                /*Meny val med olika färger för att underlätta för användaren */
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\n   ==== Välj meny: ==== ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("1. Multiplikationstabellen");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("2. Användare input");
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("3. Slumpade värden");
                Console.ForegroundColor = ConsoleColor.Yellow; /* tillägg i menyn för lab3 att register person*/
                Console.WriteLine("4. Registera person");
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("5. Avsluta programmet");
                Console.ResetColor();

                answer = Console.ReadLine();
                if (answer == "1")
                {
                    Multiplicera(); //anropar metod
                }
                else if (answer == "2")
                {
                    getValue();
                }
                else if (answer == "3")
                {
                    Slumpade();
                }
                else if (answer == "4")
                {

                    AddPerson(); //Nya metoden för lab3
                }
                else if (answer == "5")
                {
                    Exit();
                    menyLoop = false; // programm avslut utan krasch
                }
            }
        }
        static void Multiplicera()
        {
            for (int i = 1; i < 10; i++)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("{0} : \t", i);
                for (int j = 1; j < 10; j++)
                {
                    Console.Write("{0} \t", i * j);
                }
                Console.WriteLine();
                Console.ResetColor();
            }
        }
        static void getValue()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Ange hur många värden du vill räkna ut:");
            int num = Int32.Parse(Console.ReadLine());
            double[] n = new double[num];

            double min = 10000;
            double max = n[0];

            for (int i = 0; i < n.Length; i++)
            {
                Console.WriteLine("Ange värden {0}", i + 1);
                n[i] = Int32.Parse(Console.ReadLine());
            }
            for (int i = 0; i < n.Length; i++)
            {
                if (min > n[i])
                {
                    min = n[i];
                }
                else if (max < n[i])
                {
                    max = n[i];
                }
            }
            double summa = 0;
            for (int i = 0; i < n.Length; i++)
            {
                summa += n[i];
            }

            double medel = summa / num;
            Console.WriteLine("Total summan: {0}", summa);
            Console.WriteLine("Medelvärdet: {0}", medel);
            Console.WriteLine("Minsta värdet: {0}", min);
            Console.WriteLine("Största värdet: {0}", max);

            Console.ResetColor();
        }
        static void Slumpade()
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("Ange random nummer mellan 0-100");
            int randomAntal = Int32.Parse(Console.ReadLine());
            var random = new Random();
            double[] n = new double[randomAntal];

            for (int i = 0; i < randomAntal; i++)
            {
                n[i] = random.Next(100);
            }
            double summa = 0;
            Array.Sort(n);
            for (int i = 0; i < randomAntal; i++)
            {
                Console.WriteLine("Random nummer {1} {0}", n[i], i);
                summa += n[i];
            }
            double medel = summa / randomAntal;
            Console.WriteLine("Total summan av alla värden blev : {0}", summa);
            Console.WriteLine("Medelvärdet av alla värden blev : {0}", medel);
            Console.ResetColor();
        }

        static List<Person> personList = new List<Person>();  //Lista på personer 
        static void AddPerson()
        {
            Console.Clear();

            Person person = new Person(); //Person klassen
            Hair hair = new Hair(); //Hår struct

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Vad heter personen du vill registera?");
            person.Name = Console.ReadLine();
            Console.WriteLine("Kön?");
            person.Gender = Console.ReadLine();
            Console.WriteLine($"Vad har {person.Name} för ögonfärg?"); //$ för att 
            person.EyeColor = Console.ReadLine();
            Console.WriteLine($"Ange {person.Name} födelsedatum (yyyy-mm-dd):");
            person.Birth = CheckFormat(Console.ReadLine());
            Console.WriteLine($"Vad har {person.Name} för hårfärg?");
            hair.HairColor = Console.ReadLine();
            Console.WriteLine($"Hår längd på {person.Name}?");
            hair.HairLength = Console.ReadLine();
            Console.ResetColor();


            person.Hair = hair;
            personList.Add(person); //spara person lista

        }
        private static DateTime CheckFormat(string input)
        {
            DateTime dateValue;

            if (!DateTime.TryParse(input, out dateValue))
            {
                Console.WriteLine("Fel inmatning, försök igen!");
                input = Console.ReadLine();
            }

            return dateValue;
            
        }

        static void Exit()
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("============ Exit ============ \n");
            Console.ResetColor();
        }
    }
}

