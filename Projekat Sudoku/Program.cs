using System;
using System.Collections.Generic;

namespace Projekat_Sudoku
{
    class Program
    {

        static void Ispis(int[,] tabla, bool[,] otvoreno, int srca, int hint, string tezina, int maxhint)
        {
            
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("\n   TEZINA: ");
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
            Console.Write("   Greske: ");
            Console.ForegroundColor = ConsoleColor.White;
            for (int i = 0; i < 3 - srca; i++) Console.Write("X ");
            for (int i = 0; i < srca; i++)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("♥ "); 
            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("   Unesite polje i broj koji zelite da upisete: ");
        }

        static void Main(string[] args)
        {
            //GENERISANJE TABLE
            
            int[,] kvadratic = new int[3, 3];
            int[,] tabla = new int[9, 9];
            bool[,] otvoreno = new bool[9, 9];
            int srca = 3;

            List<int> xevi = new List<int>();
            List<int> yi = new List<int>();
            xevi.Add(0);
            xevi.Add(1);
            xevi.Add(2);
            xevi.Add(3);
            xevi.Add(4);
            xevi.Add(5);
            xevi.Add(6);
            xevi.Add(7);
            xevi.Add(8);
            yi.Add(0);
            yi.Add(1);
            yi.Add(2);
            yi.Add(3);
            yi.Add(4);
            yi.Add(5);
            yi.Add(6);
            yi.Add(7);
            yi.Add(8);

            Random Random = new Random(); //generise random broj koji je random
            int x = Random.Next(0, xevi.Count);
            int y = Random.Next(0, yi.Count);

            for (int i = 1; i < 10; i++) //koji broj se trenutno ubacuje
            {
                for (int j = 1; j < 10; j++) //koliko tog broja je ubaceno
                {
                    x = Random.Next(0, xevi.Count);
                    y = Random.Next(0, yi.Count);
                    int a = xevi[x];
                    int b = yi[y];
                    tabla[a, b] = i;
                    xevi.Remove(xevi[x]);
                    yi.Remove(yi[y]);
                    //za kvadratice cemo dodati da se uklone svi indexi u tom kvadraticu
                }
                xevi.Add(0);
                xevi.Add(1);
                xevi.Add(2);
                xevi.Add(3);
                xevi.Add(4);
                xevi.Add(5);
                xevi.Add(6);
                xevi.Add(7);
                xevi.Add(8);
                yi.Add(0);
                yi.Add(1);
                yi.Add(2);
                yi.Add(3);
                yi.Add(4);
                yi.Add(5);
                yi.Add(6);
                yi.Add(7);
                yi.Add(8);
            }
            

        //POCETNI MENI
        pocetak:
            Console.Clear();
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
1: Start
2: Exit
Izaberite opciju: ");
            string opcija = Console.ReadLine();
            if (opcija == "2") //ako kaze exit zaustavi se program
                return;
            else if (opcija == "1") //ako kaze start otvara se meni sa ostalim opcijama
            {
                tezine:
                Console.Clear();
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
1: Lako
2: Ne tako lako
3: Nije lako
4: Nazad
Izaberite tezinu: ");
                opcija = Console.ReadLine();
                if (opcija == "4")
                {
                    goto pocetak;
                }
                else if (opcija == "1")
                {
                    int hint = 5;
                    Ispis(tabla, otvoreno, srca, hint, "lako", 5);
                }
                else if (opcija == "2")
                {
                    int hint = 3;
                    Ispis(tabla, otvoreno, srca, hint, "ne tako lako", 3);
                }
                else if (opcija == "3")
                {
                    int hint = 1;
                    Ispis(tabla, otvoreno, srca, hint, "nije lako", 1);
                }
                else
                {
                    Console.WriteLine("nije dobro");
                    System.Threading.Thread.Sleep(1700);
                    goto tezine;
                }
            }
            else //ako unese nesto sto nije u opcijama kaze mu da je glup i vraca ga na pocetak unosa
            {
                Console.WriteLine("nije dobro");
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
