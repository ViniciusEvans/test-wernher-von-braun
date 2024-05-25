using System.Net.Sockets;
using System.Text;

namespace Infrastructure.Service;

public class TelnetClient
{
	private TcpClient _socket;

	public void Connect(string ipAddress, int port)
	{
		_socket = new TcpClient(ipAddress, port);


	}

	public string ReadData()
	{
		StringBuilder response = new();

		Thread.Sleep(2000);

		byte[] buffer = new byte[1_024];

		_socket.Client.Receive(buffer);

		response.Append(Encoding.UTF8.GetString(buffer));

		return response.ToString();
	}


	public void SendCommand(string command)
	{
		byte[] commandBytes = Encoding.ASCII.GetBytes((command + "\n").Replace("\0xFF", "\0xFF\0xFF"));
		_socket.GetStream().Write(commandBytes);
	}
	public void Close()
	{
		_socket.Client.Shutdown(SocketShutdown.Both);
	}
}