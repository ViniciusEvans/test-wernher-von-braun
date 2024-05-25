using Domain.Model;

namespace Domain;
public class DevicesListProvider
{

    public List<Device> Devices = new();
    public DevicesListProvider()
    {
        var device = new Device("Dispositivo para obter volumetria da chuva da cidade de Rio de Janeiro", "Test LTDA.", "localhost");
        device.Commands.Add(
            new CommandDescription()
            {
                Operation = "mkdir",
                Description = "cria um diretório novo",
                Command = new Command()
                {
                    command = "mkdir",
                    Parameters = new List<Parameter>
                    {
                        new Parameter()
                        {
                            Name = "<drive>:",
                            Description= "Especifica a unidade na qual você deseja criar o novo diretório."
                        },
                        new Parameter()
                        {
                            Name = "<path>",
                            Description = @"Especifica o nome e o local do novo diretório. 
                                        O comprimento máximo de qualquer caminho é determinado 
                                        pelo sistema de arquivos. Esse é um parâmetro necessário."
                        }
                        ,
                        new Parameter()
                        {
                            Name = "/?",
                            Description= "Exibe a ajuda no prompt de comando."
                        }
                    }
                },
                Result = "None",
                Format = "None"
            });

        Devices.Add(device);
    }
}