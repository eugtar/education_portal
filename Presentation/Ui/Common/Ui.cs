namespace Presentation
{
    public class Ui
    {
        public Ui() { }

        public string ReadText( string title)
        {
            while (true)
            {
                Console.WriteLine("\n(Enter \"exit\" to close the program)");
                Console.Write($"{title}: ");
                string value = Console.ReadLine().Trim().ToLower();

                if (string.IsNullOrEmpty(value))
                {
                    continue;
                }
                else if (value == "exit")
                {
                    App.StopProcess();
                }
                else
                {
                    return value;
                }
            }
        }

        public int ReadNumber(string title)
        {
            while (true)
            {
                string number = ReadText(title);
                bool intCheck = int.TryParse(number, out int result);

                if (intCheck)
                {
                    return result;
                }
                else
                {
                    continue;
                }
            }
        }

        public int SelectOne<T>(List<T> values)
        {
            Console.WriteLine();
            
            for(int i = 0; i < values.Count; i++)
            {
                Console.WriteLine($"[{i + 1}] {values[i]}");
            }

            while (true)
            {
                Console.WriteLine("\n(Enter \"exit\" to close the program)");
                Console.Write("Select: ");

                string selectedItem = Console.ReadLine().Trim().ToLower();

                if(string.IsNullOrEmpty(selectedItem))
                {
                    continue;
                }
                else if(selectedItem == "exit")
                {
                    App.StopProcess();
                }
                
                bool intCheck = int.TryParse(selectedItem, out int result);

                if (!intCheck) 
                {
                    continue;
                }
                else if(result - 1 >= values.Count)
                {
                    continue;
                }
                else
                {
                    return result - 1;
                }
            }
        }
    }
}
