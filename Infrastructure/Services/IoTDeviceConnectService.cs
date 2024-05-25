namespace Infrastructure.Service;
public class IotDeviceConnectService
{
    private TelnetClient _telnetClient;

    public void ConnectToDevice(string url)
    {
        _telnetClient = new TelnetClient();
        _telnetClient.Connect(url, 23);

        Login("", "");
    }

    public void Login(string user, string password)
    {
        _telnetClient.SendCommand(user);
        ReceiveData();
        _telnetClient.SendCommand(password);
        ReceiveData();

    }

    public void SendCommand(string command)
    {
        _telnetClient.SendCommand(command);
    }

    public string ReceiveData()
    {
        return _telnetClient.ReadData();
    }

    public void CloseConnection()
    {
        _telnetClient.Close();
    }
}