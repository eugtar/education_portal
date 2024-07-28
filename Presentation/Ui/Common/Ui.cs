namespace Presentation
{
    public class Ui
    {
        public Ui() { }

        public string ReadText( string title, bool required = true)
        {
            while (true)
            {
                Logger.Log("\n(Enter \"exit\" to close the program)");
                Logger.Log($"{title}: ", false);

                string value = Console.ReadLine() ?? "";
                value = value.Trim().ToLower();

                if (value == "exit")
                {
                    App.StopProcess();
                }

                if(required)
                {
                    if (string.IsNullOrEmpty(value))
                    {
                        continue;
                    }
                    else
                    {
                        return value;
                    }
                }
                else
                {
                    return value;
                }
                
            }
        }


        public int ReadNumber(string title, bool required = true)
        {
            while (true)
            {
                string number = ReadText(title, required);
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
            for(int i = 0; i < values.Count; i++)
            {
                Logger.Log($"[{i + 1}] {values[i]}");
            }

            while (true)
            {
                int selectedItem = ReadNumber("Select: ");

                if(selectedItem - 1 >= values.Count)
                {
                    continue;
                }
                else
                {
                    return selectedItem - 1;
                }
            }
        }
    }
}
