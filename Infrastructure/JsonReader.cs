using System.Text.Json;
using Domain;

namespace Infrastructure
{
    public class JsonReader<T> where T : class
    {
        protected string _directory;
        protected string _path;

        public JsonReader(string name)
        {
            _directory = $@"{Directory.GetParent(Environment.CurrentDirectory)!.Parent!.FullName}\Store";
            _path = $@"{_directory}\{name.ToLower()}.json";

            Directory.CreateDirectory(_directory);

            if (!File.Exists(_path))
            {
                File.WriteAllText(_path, "[]");
            }
        }

        public IEnumerable<T> Read()
        {
            string text = File.ReadAllText(_path);

            IEnumerable<T> objects = JsonSerializer.Deserialize<IEnumerable<T>>(text) ?? [];

            return objects;
        }

        public void Save(IEnumerable<T> objects)
        {
            string json = JsonSerializer.Serialize(objects);
            File.WriteAllText(_path, json);
        }

    }
}