using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Reflection;
using System;

public class Program
{
    [Import]
    public IMessageSender MessageSender { get; set; }

    public static void Main(string[] args)
    {
        Program p = new Program();
        p.Run();
    }

    public void Run()
    {
        Compose();
        MessageSender.Send("Message Sent");
        Console.ReadKey();
    }

    private void Compose()
    {
        AssemblyCatalog catalog = new AssemblyCatalog(Assembly.GetExecutingAssembly());
        var container = new CompositionContainer(catalog);
        container.ComposeParts(this);
    }
}

public interface IMessageSender
{
    void Send(string message);
}

[Export(typeof(IMessageSender))]
public class EmailSender : IMessageSender
{
    public void Send(string message)
    {
        Console.WriteLine(message);
    }
}
