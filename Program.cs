// See https://aka.ms/new-console-template for more information
using System.Security.Cryptography;
using System.Text;
Random rng = new Random();

Console.WriteLine("Hello, World!");

var lista = new List<sana>();

const Int32 BufferSize = 128;
using (var fileStream = File.OpenRead("jutut.txt"))
using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize))
{
    String line;
    while ((line = streamReader.ReadLine()) != null)
        lista.Add(new sana() { ruotsi = line.Split(';')[1], suomi = line.Split(';')[0] });
      
  }

var shuffledcards = lista.OrderBy(a => rng.Next()).ToList();
while (true)
{
    foreach (var sanaa in shuffledcards)
    {
        var r = rng.Next(2);
        if(r == 0)
        {
            Console.WriteLine("mitä on: " + sanaa.suomi);
            if (sanaa.ruotsi.Contains(Console.ReadLine()))
            {
                Console.BackgroundColor = ConsoleColor.Green;
                Console.WriteLine("Oikein, se oli " + sanaa.ruotsi);
                Console.ResetColor();
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("väärin, se oli " + sanaa.ruotsi);
                Console.ResetColor();
            }
        }
        else
        {
            Console.WriteLine("mitä on: " + sanaa.ruotsi);
            if (sanaa.suomi.Contains(Console.ReadLine()))
            {
                Console.BackgroundColor = ConsoleColor.Green;
                Console.WriteLine("Oikein, se oli " + sanaa.suomi);
                Console.ResetColor();
                Console.Write("");
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("väärin, se oli " + sanaa.suomi);
                Console.ResetColor();
                Console.Write("");
            }
        }
       
        
    }
    Console.WriteLine("Loopataan");
}




public class sana
{
    public string suomi { get; set; }
    public string ruotsi { get; set; }
}