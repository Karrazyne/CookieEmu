namespace CookieEmu.Common.Console
{
    public static class Logger
    {
        public static string[] Logo { get; } = {
            @"  _____            _    _      ______                 ",
            @" / ____|          | |  (_)    |  ____|                ",
            @"| |     ___   ___ | | ___  ___| |__   _ __ ___  _   _ ",
            @"| |    / _ \ / _ \| |/ / |/ _ \  __| | '_ ` _ \| | | |",
            @"| |___| (_) | (_) |   <| |  __/ |____| | | | | | |_| |",
            @" \_____\___/ \___/|_|\_\_|\___|______|_| |_| |_|\__,_|"
        };

        public static void InitializeLogger(string service)
        {

            System.Console.Title = $"LastEmu - {service}";
            foreach (var t in Logo)
                System.Console.WriteLine(t.PadLeft((System.Console.BufferWidth + t.Length)/2));
        }

        public static void Write(string text) => System.Console.WriteLine(text);
    }
}
