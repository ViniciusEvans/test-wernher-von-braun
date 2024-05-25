using System.Text;

namespace Domain.Model;
public class Device
{
    public Guid Id { get; set; }
    public string Description { get; set; }
    public string Manufacturer { get; set; }
    public string Url { get; set; }
    public List<CommandDescription> Commands { get; set; }

    public Device()
    {
        Id = Guid.NewGuid();
    }
    public Device(string description, string manufacturer, string url)
    {
        Id = Guid.NewGuid();
        Description = description;
        Manufacturer = manufacturer;
        Url = url;
        Commands = new List<CommandDescription>();
    }

}
public class CommandDescription
{
    public string Operation { get; set; }
    public string Description { get; set; }
    public Command Command { get; set; }
    public string Result { get; set; }
    public string Format { get; set; }
}
public class Command
{
    public string command { get; set; }
    public List<Parameter> Parameters { get; set; }

}

public class Parameter
{
    public string Name { get; set; }
    public string Description { get; set; }

}