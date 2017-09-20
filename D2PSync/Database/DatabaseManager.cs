﻿using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace D2PSync.Database
{
    public class DatabaseManager
    {
        public static readonly object Object = new object();
        private static MySqlConnection Connection { get; set; }

        public static List<uint> Identifiers = new List<uint>() {68611, 69026, 18699};

        public static void Connect(string host, string username, string password, string databaseName)
        {
            lock (Object)
            {
                try
                {
                    var connectionString = $"server={host};uid={username};pwd={password};database={databaseName}";
                    Connection = new MySqlConnection{ConnectionString = connectionString};
                    Connection.Open();
                    Console.WriteLine("Connected to database " + databaseName);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }

        public static void GetIdentifiers()
        {
            
        }

        public static void Close()
        {
            lock (Object)
            {
                try
                {
                    Connection?.Close();
                    Connection = null;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }

        public static int ExecuteNonQuery(string query)
        {
            lock(Object)
                return new MySqlCommand($"{query}", Connection).ExecuteNonQuery();
        }
    }
}
