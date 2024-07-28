using System.Text.Json;

namespace Domain
{
    public abstract class Repository<T> where T : notnull
    {
        protected string _dir = $@"{Directory.GetParent(Environment.CurrentDirectory).Parent.FullName}\Store";
        protected string _path;

        public Repository(string name) 
        {
            _path = $@"{_dir}\{name.ToLower()}.json";

            if(!Directory.Exists(_dir)) 
            {
                Directory.CreateDirectory(_dir);
            }

            if (!File.Exists(_path))
            {
                File.Create(_path).Close();
                File.WriteAllText(_path, "[]");
            }
        }

        public List<T?> Read() 
        {
            string text = File.ReadAllText(_path);

            List<T?> values = JsonSerializer.Deserialize<List<T?>>(text) ?? [];

            return values;
        } 

        public void Write(List<T?> list)
        {
            string json = JsonSerializer.Serialize(list);
            File.WriteAllText(_path, json);
        }
    }
}
