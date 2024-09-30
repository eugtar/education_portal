namespace Presentation
{
    public class Ui
    {
        public string? ReadText(string title, bool required = true)
        {
            while (true)
            {
                ConsoleAlert.Message("\n(Enter \"exit\" to close the program)");
                ConsoleAlert.Message($"{title}: ", false);

                var value = Console.ReadLine() ?? null;
                value = value?.Trim().ToLower();

                if (value == "exit")
                {
                    App.StopProcess();
                }

                if (required)
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
                var number = ReadText(title, required);
                var intCheck = int.TryParse(number, out int result);

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
            for (int i = 0; i < values.Count; i++)
            {
                ConsoleAlert.Message($"[{i + 1}] {values[i]}");
            }

            while (true)
            {
                var selectedItem = ReadNumber("Select: ");

                if (selectedItem - 1 >= values.Count)
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
