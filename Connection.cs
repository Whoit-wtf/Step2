using Renci.SshNet;

namespace Step2;

public class Connection
{
    // создаем конструктор
    private string host, user, password;
    public Connection(string host, string user, string password)
    {
        this.host = host;
        this.user = user;
        this.password = password;
        
    }
    
    // создаем метод выполнения команд
    public string[] RunCommand(string command)
    {
        string[] result = new string[2];
        
        SshClient client = new SshClient(this.host, this.user, this.password);
        client.Connect();
        
        // проверяем подключение
        if (client.IsConnected)
        {
            Console.WriteLine("SSH connection active");
            int code = client.RunCommand($"{command}").ExitStatus;  //получаем статус выполнения команды
            if (code == 127)
            {
                result[0] = Convert.ToString(code);
                result[1] = $"Команда {command} не найдена";
                Console.WriteLine($"Код выполнения: {result[0]}");
                Console.WriteLine($"Вывод команды: {result[1]}");
            }
            else
            {
                result[0] = Convert.ToString(code);
                result[1] = client.RunCommand($"{command}").Result;
                Console.WriteLine($"Код выполнения: {result[0]}");
                Console.WriteLine($"Вывод команды: {result[1]}");
                
            }
            
            
        }else
        {
            Console.WriteLine("SSH connection NOTactive");
        }
        return result;
    }
}