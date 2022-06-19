using System;
using System.Collections.Generic;
using System.Text;

namespace Projekat_Sudoku
{
    class Program
    {
        static void OtvaranjePolja(int brpolja, bool[,] otvoreno)
        {
            
            while (brpolja != 0)
            {
                Random r = new Random();
                int i = r.Next(0, 9);
                int j = r.Next(0, 9);
                if (!otvoreno[i, j])
                {
                    otvoreno[i, j] = true;
                    brpolja--;
                }
            }
            

           
        }
        static void Generator(int[,] tabla)
        {
            List<int> a = new List<int>();
            a.Add(1);
            a.Add(2);
            a.Add(3);
            a.Add(4);
            a.Add(5);
            a.Add(6);
            a.Add(7);
            a.Add(8);
            a.Add(9);

            Random r = new Random();
            int trnt = r.Next(1, 10);

            //Ubacivanje elemenata u prvu kolonu
            for (int i = 0; i < 9; i++)
            {
                trnt = r.Next(1, 10);
                while (!a.Contains(trnt)) trnt = r.Next(1, 10);
                a.Remove(trnt);
                tabla[i, 0] = trnt;
            }

            //popunjavanje prve kocke
            for (int i = 0; i < 3; i++)
            {
                tabla[0 + i, 1] = tabla[3 + i, 0];
                tabla[0 + i, 2] = tabla[6 + i, 0];
            }

            //Popunjavanje prve tri kocke vertikalno
            for (int i = 0; i < 3; i++)
            {
                //prvi deo
                tabla[3 + i, 2] = tabla[0 + i, 0];
                tabla[6 + i, 1] = tabla[0 + i, 0];

                //drugi deo
                tabla[3 + i, 0] = tabla[0 + i, 1];
                tabla[6 + i, 2] = tabla[0 + i, 1];

                //treci deo
                tabla[3 + i, 1] = tabla[0 + i, 2];
                tabla[6 + i, 0] = tabla[0 + i, 2];
            }

            //popunjavanje ostalog
            for (int i = 0; i < 7; i += 3)
            {
                for (int j = 0; j < 3; j++)
                {
                    //prvi red
                    tabla[2 + i, 3 + j] = tabla[0 + i, 0 + j];
                    tabla[1 + i, 6 + j] = tabla[0 + i, 0 + j];

                    //drugi red
                    tabla[0 + i, 3 + j] = tabla[1 + i, 0 + j];
                    tabla[2 + i, 6 + j] = tabla[1 + i, 0 + j];

                    //treci red 
                    tabla[1 + i, 3 + j] = tabla[2 + i, 0 + j];
                    tabla[0 + i, 6 + j] = tabla[2 + i, 0 + j];
                }
            }
        }
        static void Ispis(int[,] tabla, bool[,] otvoreno, int srca, int hint, string tezina, int maxhint)
        {
            
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("\n   Tezina: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(tezina + "\n");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("     A  B  C   D  E  F   G  H  I");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("   -------------------------------");
            Console.ForegroundColor = ConsoleColor.White;

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (j == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(" " + (i + 1) + " ");
                    }
                    if (j % 3 == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write("|");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    if (otvoreno[i, j]) Console.Write(" " + tabla[i, j] + " ");
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write(" . ");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    if (j == 8)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write("|");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
                if (i == 2 || i == 5)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("\n   |---------+---------+----------");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("   -------------------------------");

            Console.Write("\n   Hintovi: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(hint);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("/" + maxhint);

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("   Životi: ");
            Console.ForegroundColor = ConsoleColor.White;
            for (int i = 0; i < 3 - srca; i++) Console.Write("X ");
            for (int i = 0; i < srca; i++)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("♥ "); 
            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("   Unesite polje i broj koji želite da upišete: ");
            Console.ForegroundColor = ConsoleColor.White;
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;

            //GENERISANJE TABLE
            int[,] tabla = new int[9, 9];
            bool [,] otvoreno = new bool[9, 9];
            int srca = 3;
            Generator(tabla);
            
        //POCETNI MENI
        pocetak:
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(@"
█████████████████████████████████████████████████████████████████████████████████████████████
█░░░░░░░░░░░░░░█░░░░░░██░░░░░░█░░░░░░░░░░░░███░░░░░░░░░░░░░░█░░░░░░██░░░░░░░░█░░░░░░██░░░░░░█
█░░▄▀▄▀▄▀▄▀▄▀░░█░░▄▀░░██░░▄▀░░█░░▄▀▄▀▄▀▄▀░░░░█░░▄▀▄▀▄▀▄▀▄▀░░█░░▄▀░░██░░▄▀▄▀░░█░░▄▀░░██░░▄▀░░█
█░░▄▀░░░░░░░░░░█░░▄▀░░██░░▄▀░░█░░▄▀░░░░▄▀▄▀░░█░░▄▀░░░░░░▄▀░░█░░▄▀░░██░░▄▀░░░░█░░▄▀░░██░░▄▀░░█
█░░▄▀░░█████████░░▄▀░░██░░▄▀░░█░░▄▀░░██░░▄▀░░█░░▄▀░░██░░▄▀░░█░░▄▀░░██░░▄▀░░███░░▄▀░░██░░▄▀░░█
█░░▄▀░░░░░░░░░░█░░▄▀░░██░░▄▀░░█░░▄▀░░██░░▄▀░░█░░▄▀░░██░░▄▀░░█░░▄▀░░░░░░▄▀░░███░░▄▀░░██░░▄▀░░█
█░░▄▀▄▀▄▀▄▀▄▀░░█░░▄▀░░██░░▄▀░░█░░▄▀░░██░░▄▀░░█░░▄▀░░██░░▄▀░░█░░▄▀▄▀▄▀▄▀▄▀░░███░░▄▀░░██░░▄▀░░█
█░░░░░░░░░░▄▀░░█░░▄▀░░██░░▄▀░░█░░▄▀░░██░░▄▀░░█░░▄▀░░██░░▄▀░░█░░▄▀░░░░░░▄▀░░███░░▄▀░░██░░▄▀░░█
█████████░░▄▀░░█░░▄▀░░██░░▄▀░░█░░▄▀░░██░░▄▀░░█░░▄▀░░██░░▄▀░░█░░▄▀░░██░░▄▀░░███░░▄▀░░██░░▄▀░░█
█░░░░░░░░░░▄▀░░█░░▄▀░░░░░░▄▀░░█░░▄▀░░░░▄▀▄▀░░█░░▄▀░░░░░░▄▀░░█░░▄▀░░██░░▄▀░░░░█░░▄▀░░░░░░▄▀░░█
█░░▄▀▄▀▄▀▄▀▄▀░░█░░▄▀▄▀▄▀▄▀▄▀░░█░░▄▀▄▀▄▀▄▀░░░░█░░▄▀▄▀▄▀▄▀▄▀░░█░░▄▀░░██░░▄▀▄▀░░█░░▄▀▄▀▄▀▄▀▄▀░░█
█░░░░░░░░░░░░░░█░░░░░░░░░░░░░░█░░░░░░░░░░░░███░░░░░░░░░░░░░░█░░░░░░██░░░░░░░░█░░░░░░░░░░░░░░█
█████████████████████████████████████████████████████████████████████████████████████████████
");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(@"
    1: Start
    2: Exit ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("   Izaberite opciju: " );
            Console.ForegroundColor = ConsoleColor.White;
            string opcija = Console.ReadLine();
            if (opcija == "2") //ako kaze exit zaustavi se program
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Pritisnite bilo koje dugme kako biste zatvorili program.");
                Console.ForegroundColor = ConsoleColor.Gray;
                return;
            }
            else if (opcija == "1") //ako kaze start otvara se meni sa ostalim opcijama
            {
            tezine:
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(@"
█████████████████████████████████████████████████████████████████████████████████████████████
█░░░░░░░░░░░░░░█░░░░░░██░░░░░░█░░░░░░░░░░░░███░░░░░░░░░░░░░░█░░░░░░██░░░░░░░░█░░░░░░██░░░░░░█
█░░▄▀▄▀▄▀▄▀▄▀░░█░░▄▀░░██░░▄▀░░█░░▄▀▄▀▄▀▄▀░░░░█░░▄▀▄▀▄▀▄▀▄▀░░█░░▄▀░░██░░▄▀▄▀░░█░░▄▀░░██░░▄▀░░█
█░░▄▀░░░░░░░░░░█░░▄▀░░██░░▄▀░░█░░▄▀░░░░▄▀▄▀░░█░░▄▀░░░░░░▄▀░░█░░▄▀░░██░░▄▀░░░░█░░▄▀░░██░░▄▀░░█
█░░▄▀░░█████████░░▄▀░░██░░▄▀░░█░░▄▀░░██░░▄▀░░█░░▄▀░░██░░▄▀░░█░░▄▀░░██░░▄▀░░███░░▄▀░░██░░▄▀░░█
█░░▄▀░░░░░░░░░░█░░▄▀░░██░░▄▀░░█░░▄▀░░██░░▄▀░░█░░▄▀░░██░░▄▀░░█░░▄▀░░░░░░▄▀░░███░░▄▀░░██░░▄▀░░█
█░░▄▀▄▀▄▀▄▀▄▀░░█░░▄▀░░██░░▄▀░░█░░▄▀░░██░░▄▀░░█░░▄▀░░██░░▄▀░░█░░▄▀▄▀▄▀▄▀▄▀░░███░░▄▀░░██░░▄▀░░█
█░░░░░░░░░░▄▀░░█░░▄▀░░██░░▄▀░░█░░▄▀░░██░░▄▀░░█░░▄▀░░██░░▄▀░░█░░▄▀░░░░░░▄▀░░███░░▄▀░░██░░▄▀░░█
█████████░░▄▀░░█░░▄▀░░██░░▄▀░░█░░▄▀░░██░░▄▀░░█░░▄▀░░██░░▄▀░░█░░▄▀░░██░░▄▀░░███░░▄▀░░██░░▄▀░░█
█░░░░░░░░░░▄▀░░█░░▄▀░░░░░░▄▀░░█░░▄▀░░░░▄▀▄▀░░█░░▄▀░░░░░░▄▀░░█░░▄▀░░██░░▄▀░░░░█░░▄▀░░░░░░▄▀░░█
█░░▄▀▄▀▄▀▄▀▄▀░░█░░▄▀▄▀▄▀▄▀▄▀░░█░░▄▀▄▀▄▀▄▀░░░░█░░▄▀▄▀▄▀▄▀▄▀░░█░░▄▀░░██░░▄▀▄▀░░█░░▄▀▄▀▄▀▄▀▄▀░░█
█░░░░░░░░░░░░░░█░░░░░░░░░░░░░░█░░░░░░░░░░░░███░░░░░░░░░░░░░░█░░░░░░██░░░░░░░░█░░░░░░░░░░░░░░█
█████████████████████████████████████████████████████████████████████████████████████████████
");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write(@"
    1: Lako
    2: Srednje
    3: Teško
    4: Nazad na početni meni
");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("   Izaberite težinu igre: ");
                Console.ForegroundColor = ConsoleColor.White;
                opcija = Console.ReadLine();
                if (opcija == "4") goto pocetak;

                else if (opcija == "1")
                {
                    int hint = 5;
                    OtvaranjePolja(65, otvoreno);
                    Ispis(tabla, otvoreno, srca, hint, "LAKO", 5);

                }
                else if (opcija == "2")
                {
                    int hint = 3;
                    OtvaranjePolja(55, otvoreno);
                    Ispis(tabla, otvoreno, srca, hint, "SREDNJE", 3);
                }
                else if (opcija == "3")
                {
                    int hint = 1;
                    OtvaranjePolja(45, otvoreno);
                    Ispis(tabla, otvoreno, srca, hint, "TEŠKO", 1);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Izabrana je nepostojeća opcija. Pokušajte ponovo.");
                    System.Threading.Thread.Sleep(1700);
                    goto tezine;
                }
            }
            else //ako unese nesto sto nije u opcijama kaze mu da je glup i vraca ga na pocetak unosa
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Izabrana je nepostojeća opcija. Pokušajte ponovo.");
                System.Threading.Thread.Sleep(1700);
                goto pocetak;
            }
        }

        static void Upis(int[,] tabla, bool[,] otvoreno, int hint, int srca)
        {
            string[] uneto = Console.ReadLine().ToUpper().Split(' ');
            Dictionary<char, int> slova = new Dictionary<char, int>();
            slova.Add('A', 0);
            slova.Add('B', 1);
            slova.Add('C', 2);
            slova.Add('D', 3);
            slova.Add('E', 4);
            slova.Add('F', 5);
            slova.Add('G', 6);
            slova.Add('H', 7);
            slova.Add('I', 8);

            if (uneto[0]=="HINT")
            {
                //natalija
            }

            else if(uneto[0]=="KRAJ")
            {
               return;
            }

            else
            {
                char[] koordinate = uneto[0].ToCharArray();
                int j = slova[koordinate[0]]; //kolona
                int i = koordinate[1]; //vrsta

                /*
                if (otvoreno)
                {
                    //kazi mu d JE GLUP
                }
                */
                if(1==1) //else
                {
                    if (tabla[i, j] == int.Parse(uneto[1]))
                    {
                        //otvoriti polje
                        otvoreno[i, j] = true;

                    }
                    else
                    {
                        //glup si
                        srca--;

                        if (srca == 0) return; //mnogo si glup ispisi
                    }
                }
            }
        }
    }
}
