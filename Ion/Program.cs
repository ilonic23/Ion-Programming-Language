using Tommy;
namespace Ion;

static class Program
{
    static void Main(string[] args)
    {
        // TODO : Parse arguments 
        
        
        // Parsing arguments
        
        if (args[0] == "new")
        {
            // Asking for the name
            Console.Write("Enter name: ");
            string? temp = Console.ReadLine();
            string name = temp ?? "";
            if (name == "")
            {
                Console.WriteLine("Operation aborted.");
                Environment.Exit(1);
            }
            // Creating all files
            else
            {
                Directory.CreateDirectory($"./{name}");
                Directory.SetCurrentDirectory($"./{name}");
                
                Directory.CreateDirectory("./source");
                Directory.CreateDirectory("./debug");
                File.Create("./source/main.ion").Close();
                File.Create("./config.toml").Close();
                File.Create("./README.md").Close();
                
                //Writing to config.toml file
                using (FileStream fs = new FileStream("./config.toml", FileMode.Open, FileAccess.ReadWrite))
                {
                    
                    using (StreamWriter writer = new StreamWriter(fs))
                    {
                        // Write to the file
                        writer.WriteLine("title = \"Configuration\"");
                        writer.WriteLine($"[project.info]\nname = \"{name}\"\nversion = 1.0.0\nauthor = \"\"");
                        writer.WriteLine($"\n[project.ion]\nincluded = []\nversion = 1.0.0");
                        writer.WriteLine($"\n[project.debug]\ndebug = true\nlog = false");
                        writer.Close();
                    }
                    fs.Close();
                }
                
                //Writing to README.md file
                using (FileStream fs = new FileStream("./README.md", FileMode.Open, FileAccess.ReadWrite))
                {
                    
                    using (StreamWriter writer = new StreamWriter(fs))
                    {
                        // Write to the file
                        writer.WriteLine($"# {name} made with ion\n\n");
                        writer.Close();
                    }
                    fs.Close();
                }
            }
        }
    }
}