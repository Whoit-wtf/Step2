// See https://aka.ms/new-console-template for more information

using System.Runtime.CompilerServices;
using Step2;

// данные для подключения
// есть вариант с использованием приватного ключа
// https://csharp.hotexamples.com/ru/examples/Renci.SshNet/SshClient/-/php-sshclient-class-examples.html
string user = "avic";
string password = "335544";
string host = "192.168.75.128";


Connection connection = new Connection(host, user, password);
        
connection.RunCommand("ls -lah");

