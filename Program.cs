using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static Random rnd = new Random();

        static void CheckNumbersInMatTable(int[,] matTable, int[] winningNumbers)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("AFTER WE MATCH YOUR NUMBERS HERE'S THE RESULT");
            Console.ForegroundColor = ConsoleColor.Gray;
            for (int i = 0; i < matTable.GetLength(0); i++)
            {
                int hitsCounter =0 ;
                for (int k = 0; k < matTable.GetLength(1); k++)
                {

                    bool marker = false;
                    for (int a = 0; a < winningNumbers.Length; a++)
                    {
                        if (winningNumbers[a]== matTable[i,k])
                        {
                            marker = true;
                            hitsCounter++;
                            break;

                        }
                    }
                    if (marker==true)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("{0}\t", matTable[i, k]);
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    else
                    {
                        Console.Write("{0}\t", matTable[i, k]);
                    }
                    
                }
                Console.Write("= {0} hit's", hitsCounter);
                Console.WriteLine();
            }
        }

        static int[] GetAutomaticRandomNumbers() //מכאן לקרוא לטור מנצח וגם ומילוי אוטומטי במטריצה
        {
            int[] arr = new int[6];
            for (int i = 0; i < arr.Length; i++)
            {
                int number = rnd.Next(1, 46);
                bool a = CheckRandumlyNumbersByComputerRpeat(arr, number);
                while (!a)
                {
                    number = rnd.Next(1, 46);
                    a = CheckRandumlyNumbersByComputerRpeat(arr, number);
                }
                arr[i] = number;
            }
            Array.Sort(arr);
            return arr;
        }
        static bool CheckRandumlyNumbersByComputerRpeat(int[] arr, int number)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == number)
                {
                    return false;
                }
            }
            return true;
        }
        static bool checkIfNumberRepeatByUser(int[] arr, int number)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == number)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("{0} - is already exist in this line", number);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine();
                    return false;
                }
                else if (number >= 46)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("{0} - is bigger then 45", number);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine();
                    return false;
                }
            }
            return true;
        }

        static int[] CheckColumnBeforeInsertingIntoTable()
        {
            int[] arr = new int[6];
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write("enter number: ");
                string pressing = Console.ReadLine();
                int number = InputChecking(pressing);
                bool a = checkIfNumberRepeatByUser(arr, number);
                while (!a)
                {
                    Console.Write("enter number: ");
                    pressing = Console.ReadLine();
                    number = InputChecking(pressing);
                    a = checkIfNumberRepeatByUser(arr, number);
                }
                arr[i] = number;
            }
            Array.Sort(arr);
            return arr;
        }

        static int[,] FillNumbersInMat(int amountOfColumn, int choise)
        {
            int[] arr = new int[6];
            int[,] tableOfNumbers = new int[amountOfColumn, 6];

            for (int i = 0; i < tableOfNumbers.GetLength(0); i++)
            {
                
                if (choise == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("line number: {0}", i + 1);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    arr = CheckColumnBeforeInsertingIntoTable();
                }
                else if (choise == 2)
                {
                    arr = GetAutomaticRandomNumbers();
                }
                for (int k = 0; k < tableOfNumbers.GetLength(1); k++)
                {
                    if (choise == 1)
                    {
                        tableOfNumbers[i, k] = arr[k];
                    }
                    else
                    {
                        tableOfNumbers[i, k] = arr[k];
                    }
                }


            }

            return tableOfNumbers;
        }
        static int InputChecking(string text)
        {
            int numberOutOfString;
            bool result = int.TryParse(text, out numberOutOfString);
            while (!result)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Wrong input try again ");
                Console.ForegroundColor = ConsoleColor.Gray;
                text = Console.ReadLine();
                result = int.TryParse(text, out numberOutOfString);
            }
            return numberOutOfString;
        }

        static void DisplayMatTable(int[,] mat)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("**********here is your number's:**********");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine();
            for (int i = 0; i < mat.GetLength(0); i++)
            {
                for (int k = 0; k < mat.GetLength(1); k++)
                {
                    Console.Write("{0}\t", mat[i, k]);
                }
                Console.WriteLine();
            }
        }


        static void DisplayWinningNumbers(int[] arr)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("******** here is winning number's:********");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("{0}\t", arr[i]);
            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("******************************************");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        static bool KeepPlayingOrExitGame()
        {
            Console.WriteLine();
            Console.WriteLine("do you want to play LOTTERY one more time? :) click Y/N");
            string answer = Console.ReadLine();
            if (answer == "no" || answer == "n" || answer == "N" || answer == "NO" || answer=="No" || answer=="nO")
            {
                Console.Clear();
                string mssg = " bye bye...";
                for (int i = 0; i < mssg.Length; i++)
                {
                    System.Threading.Thread.Sleep(500);
                    Console.ForegroundColor = ConsoleColor.Black + i;
                    Console.Write(mssg[i]);
                }
                Console.ForegroundColor = ConsoleColor.Gray;
                return false;
            }
            Console.Clear();
            return true;
        }
        static void Main(string[] args)
        {
            bool keepPlay = true;
            while (keepPlay)
            {
                int[] winningNumbers = GetAutomaticRandomNumbers();
                Console.WriteLine("******Welcome to the LOTTERY game******");
                int choise = 0;
                while (choise > 2 || choise == 0)
                {
                    Console.WriteLine("for manual lottory function press [1]. \nfor automatic lottory function press [2]. ");
                    string pressing = Console.ReadLine();
                    choise = InputChecking(pressing);
                }
                Console.Clear();
                Console.WriteLine("how many column do you want to fill?: ");
                string input = Console.ReadLine();
                int amountOfColumn = InputChecking(input);
                int[,] tableMat;
                tableMat = FillNumbersInMat(amountOfColumn, choise);
                Console.Clear();
                DisplayMatTable(tableMat);
                DisplayWinningNumbers(winningNumbers);
                Console.WriteLine();
                Console.WriteLine();
                CheckNumbersInMatTable(tableMat, winningNumbers);
                keepPlay = KeepPlayingOrExitGame();
            }
            
        }
    }
}
