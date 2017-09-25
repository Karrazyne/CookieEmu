using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace D2PSync.Database
{
    public class DatabaseManager
    {
        public static readonly object Object = new object();
        private static MySqlConnection Connection { get; set; }

        public static List<uint> OrmeIdentifier = new List<uint>{57765, 18700, 33436};
        public static List<uint> OrgeIdentifier = new List<uint> { 18707, 34010 };
        public static List<uint> AvoineIdentifier = new List<uint> { 18708, 34013 };
        public static List<uint> ChanvreIdentifier = new List<uint> { 34014, 18734 };
        public static List<uint> SeigleIdentifier = new List<uint> {34012, 18843};
        public static List<uint> MaltIdentifier = new List<uint> { 18845, 34011 };
        public static List<uint> MilletIdentifier = new List<uint> { 24632 };
        public static List<uint> BambouSacreIdentifier = new List<uint> {29944};
        public static List<uint> BambouSombreIdentifier = new List<uint> { 30090, 30092 };
        public static List<uint> EdelweissIdentifier = new List<uint> { 30737 };
        public static List<uint> OrchideeIdentifier = new List<uint> { 30738 };
        public static List<uint> MentheIdentifier = new List<uint> { 30739 };
        public static List<uint> CobaltIdentifier = new List<uint> { 34504, 34507 };

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
