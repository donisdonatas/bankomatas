﻿using Bankomatas.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.SqlClient;
using System.Data.SQLite;

namespace Bankomatas
{
    internal class Program
    {
        static void Main()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("d47f53e6-65b6-463e-8fbd-054c17390818");
            //SQLiteConnection sqliteConnection;
            //sqliteConnection = SQLite.CreateConnection();
            //SQLite.CreateClientsAccountsTable(sqliteConnection);
            //SQLite.InsertDataToClientsAccountsTable(sqliteConnection);
            //SQLite.ReadData(sqliteConnection);

            Menu.PrimaryMenu();
            Login.LoginAnimation();
            Menu.LoggedUserMenu();


            Console.ReadLine();
        }
    }
}
