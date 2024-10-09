// Moment 3 - DT071G
// Guestbook av Haris Sabanovic
// Student mejl hasa2303@student.miun.se



using System.Net;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json;
using Microsoft.VisualBasic;


//namespace är guestbook, organiserar och strukturerar koden för att gruppera de olika klasser, metoder osv
namespace Guestbook {

    class Program 
    {
        //skapar en lista som lagrar objekt av type Guest
        public static List<Guest> guestList = new List<Guest>();
        public static void Main()
        {

            //håller igång programmet i en oändlig loop tills användaren väljer att avsluta
            while(true)
            {
            
            //skriver ut de val som användaren har
            Console.Clear();
            Console.WriteLine("H A R I S  G U E S T B O O K");
            Console.WriteLine("1. Write in guestbook");
            Console.WriteLine("2. Delete post\n");
            Console.WriteLine("X. Close application\n");

            //ifall filen existerar ska den läsa in objekten och lägg den i guestlist
            if(File.Exists("guests.json"))
            {
                string jsonString = File.ReadAllText("guests.json");
                guestList = JsonSerializer.Deserialize<List<Guest>>(jsonString)!;
            }

            // loopar igenom listan och ger objekten samma id som dess index
             for(int index = 0; index < guestList.Count; index++)
            {
                guestList[index].Id = index;
            }


            //loopar igenom varje objekt och skriver ut dem
            foreach(Guest guest in guestList)
            {
                Console.WriteLine($"[{guest.Id}]. {guest.Name}: {guest.Post}");
            }

            //användarens input
            string userChoice = Console.ReadLine()!;


            //beroende på användarens input körs olika funktioner
            if(userChoice == "1")
            {
                Manager.addGuestPost();
                continue;
            } else if (userChoice == "2")
            {
                Manager.deleteGuestPost();
                continue;
            } else if (userChoice.ToLower() == "x")
            {
                break;
            } else {
                Console.WriteLine("Fel inmatat värde, skriv  1 , 2 eller X");
                continue;
            }
            }


            
        }
    }
}