using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Dynamic;
using System.Data;
using System.Xml.Schema;
using System.Security.Cryptography.X509Certificates;

namespace FAS1

{
    class Activity
    {
        public string date;
        public string state;
        public string title;
        public Activity(string date, string state, string title)
        {
            this.date = date;
            this.state = state;
            this.title = title;
        }
        public Activity()
        { }

        public string Print()
        {
            return $" Date : {date} State: {state} Title: {title} ";
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Activity> lista = new List<Activity>();
            DateTime date = new DateTime();
            date = DateTime.Now; date.ToString("yyyy-MM dd");



            // int time = now.Date{ DataSetDateTime }
            /*   time = now.Month;
               time = now.Day;*/

            string readPath = @"C:\Users\Dator 3\bin\FAS1.txt";
            Console.WriteLine("To Do List");
            Console.WriteLine("Commands: ");
            Console.WriteLine("ADD = add new item to the list");
            Console.WriteLine("LOAD = Read the list");
            Console.WriteLine("Quit = Exit ");
            while (true)
            {
                Activity Uppgift = new Activity();


                string comand = Console.ReadLine().ToUpper();
                switch (comand)

                {
                    case "ADD":
                        Console.WriteLine("Add something to the list");
                        Console.WriteLine("Enter the of the name of task");
                        Uppgift.title = Console.ReadLine();
                        Uppgift.date = date.ToString();
                        Console.WriteLine("what is the state of the activity?");
                        Uppgift.state = Console.ReadLine();
                        Console.WriteLine("wolud you save the content?");
                        string answer = Console.ReadLine();
                        lista.Add(Uppgift);


                        if (answer == "ja")
                        {



                            using (StreamWriter writetext = new StreamWriter(readPath))
                            {
                                foreach (var task in lista)
                                {

                                    writetext.WriteLine(task.Print());
                                }
                            }
                            Console.WriteLine("the content is saved now");
                        }



                        else
                        {
                            Console.WriteLine("the content is not saved");
                            if (lista.Any()) { lista.RemoveAt(lista.Count - 1); }

                        }
                        break;
                    case "LOAD":
                        {

                            using (StreamReader readtext = new StreamReader(readPath))
                            {
                                while (readtext.Peek() >= 0)
                                {
                                    string readText = readtext.ReadLine();
                                    Console.WriteLine(readText);
                                }
                            }
                        }
                        break;
                    case "REMOVE":
                        Console.WriteLine("nedanstående personer finns regisrerade i adressboken \n ange nummret på personen du vill ta bort");
                        for (int i = 0; i < lista.Count; i++)
                        { Console.WriteLine("{0} - {1}", i + 1, lista[i].Print()); }
                        Console.WriteLine();
                        Console.WriteLine("ange vilket nummer du vill ta bort");
                        int toRemove = int.Parse(Console.ReadLine());
                        lista.RemoveAt(toRemove - 1);
                        Console.WriteLine("upgiffterna om person {0} togs bort", toRemove);
                        using (StreamWriter streamWriter = new StreamWriter(readPath))
                        {
                            foreach (var A in lista)
                            { streamWriter.WriteLine(A.Print()); }
                        }
                        break;

                    case "SAVE FILE":
                        Console.WriteLine("give teh file name");
                        string name = Console.ReadLine();

                        var dirPath = @"C:\Users\Dator 3\bin\" + $"{name}.txt";
                        using (StreamWriter writetext = File.CreateText(dirPath))
                        {
                            foreach (var task in lista)
                            {

                                writetext.WriteLine(task.Print());
                            }
                        }

                        Console.WriteLine("FILE IS CREATED");

                        break;
                    case "move upward":
                        
                        break;
                }
            }
            static void MoveUpWard() { }
        }
    }
}






/*case "sparaFilen":
                            Console.WriteLine("give teh file name");
// string name = Console.ReadLine();
//string Path = @"C:\Users\Dator 3\bin\";
/* using (FileStream fs = File.Create(Path))
 {
     // Add some text to file    
     Byte[] title = new UTF8Encoding(true).GetBytes("New Text File");
     fs.Write(title, 0, title.Length);
     byte[] author = new UTF8Encoding(true).GetBytes($"{name}");
     fs.Write(author, 0, author.Length);
 }*/