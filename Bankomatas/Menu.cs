﻿using Bankomatas.Classes;
using Bankomatas.System;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bankomatas
{
    public static class Menu
    {
        internal static string CardGuid { get; set; }
        public static void PrimaryMenu()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Sveiki atvykę čia Bankomatas.");
            Console.WriteLine("Norėdami atlikti operacijas turite patvirtinti autorizaciją.");
            Card card = new Card();
            CardGuid = card.CheckCard();
            card.CheckPIN();
        }

        public static int LoggedUserMenu()
        {
            bool isGoodChoise = false;
            int menuChoise = 0;
            
            while (!isGoodChoise)
            {
                Exception err = null;
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Sveiki prisijungę prie savo paskyros.");
                Console.WriteLine("Pasirinkite pageidaujamą operaciją:");
                Console.WriteLine("[1] Matyti einamajį balansą.");
                Console.WriteLine("[2] Paskutinės 5 atliktos opracijos.");
                Console.WriteLine("[3] Pinigų išėmimas.");
                Console.WriteLine("[0] Pasiimti kortelę. Ir uždaryti programą.");
                Console.ForegroundColor = ConsoleColor.White;
                isGoodChoise = false;
                try
                {
                    menuChoise = int.Parse(Console.ReadLine());
                }
                catch(FormatException ex)
                {
                    //Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Pasirinkimo klaida. Klaidos pranešimas: {ex.Message}");
                    Console.WriteLine("Bandykite dar kartą.");
                    err = ex;
                    Thread.Sleep(3000);
                }
                catch(Exception ex)
                {
                    //Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Pasirinkimo klaida. Klaidos pranešimas: {ex.Message}");
                    Console.WriteLine("Bandykite dar kartą.");
                    err = ex;
                    Thread.Sleep(3000);
                }
                finally
                {
                    if(err == null)
                    {
                        isGoodChoise = true;
                    }
                }
            }
            return menuChoise;
        }

        public static void SecondaryMenu()
        {
            bool isGoodChoise = false;
            //Card card = new Card();
            while (!isGoodChoise)
            {
                switch (LoggedUserMenu())
                {
                    case 1:
                        decimal Balance = SQLite.GetBalance(CardGuid);
                        Console.WriteLine($"Dabartinis balansas: {Balance}Eur.");
                        isGoodChoise = true;
                        break;
                    case 2:
                        Console.WriteLine("Paskutinės 5 atliktos opracijos:");
                        SQLite.GetLastTransactions(CardGuid, 5);
                        isGoodChoise = true;
                        break;
                    case 3:
                        Console.WriteLine("Menu choise 3");
                        isGoodChoise = true;
                        break;
                    case 0:
                        Console.WriteLine("Menu choise Exit");
                        isGoodChoise = true;
                        break;
                    default:
                        //Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Pasirinkimo klaida.");
                        Console.WriteLine("Bandykite dar kartą.");
                        Thread.Sleep(2000);
                        break;
                }
            }
        }
    }
}
