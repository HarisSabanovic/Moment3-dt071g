

using System.Text.Json;

namespace Guestbook 
{
    public static class Manager
    {

        public static List<Guest> guestList = Program.guestList;
        static int id = 0;

        public static void addGuestPost()
        {

            //ifall fil existerar l'gger den till objekten i guestlist
            if(File.Exists("guests.json"))
            {
                string guestJson = File.ReadAllText("guests.json");
                guestList = JsonSerializer.Deserialize<List<Guest>>(guestJson)!;
            }

            Console.Clear();
            Console.Write("Write your name: ");
            string guestName = Console.ReadLine()!;

            Console.Write("Write your post: ");
            string guestPost = Console.ReadLine()!;

            //ifall användarens input inte är tom läggs inlägget till och sparas
            //Annars påminner användaren att input inte får vara tom.
            if(!String.IsNullOrEmpty(guestName) || !String.IsNullOrEmpty(guestPost))
            {
                guestList.Add(new Guest(
                id = guestList.Count,
                guestName,
                guestPost
            ));
             SaveGuestbook();
            } else
            {
                Console.WriteLine("You need to input a value. Press any key to continue");
                Console.ReadKey();
            }
        }

        public static void deleteGuestPost()
        {
            Console.Clear();
            Console.WriteLine("Write the index number of post to delete");
            string userString = Console.ReadLine()!;
            int userInput = Convert.ToInt32(userString); //konverterar input från string till integer

            try{
                guestList.RemoveAt(userInput); //tar bort de inlägg från listan som har samma index
                SaveGuestbook();
                Program.Main();
            } catch(Exception error) //felhantering
            {
                Console.Clear();
                Console.WriteLine(error.Message);
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
            }

        }



        //serialiserar och sparar till fil
          private static void SaveGuestbook()
        {
            string json = JsonSerializer.Serialize(guestList);
            File.WriteAllText("guests.json", json);
        }
    }
}