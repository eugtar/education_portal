namespace Presentation
{
    public class Logger
    {
        public Logger() { }

        public static void Log<T>(T message, bool line = true) 
        {
            if (line) 
            {
                Console.WriteLine(message);
            }
            else 
            {
                Console.Write(message);
            }
        }

        public static void LogResult<T>(T message, bool error = false) 
        {
            if (error)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"[Error]: ");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"[Success]: ");
            }

            Console.ResetColor();
            Console.WriteLine($"{message}");
        }
    }
}
