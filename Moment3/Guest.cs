using System.Data.Common;

namespace Guestbook {

    public class Guest {

        public int? Id {get; set;} // en nullable int egenskap som representerar unikt id värde

        public string? Name {get; set;} // en nullable sträng som representerar namnet

        public string? Post {get; set;} // en nullbale sträng som representerar inlägget

        public Guest() { } // en tom konstruktor som låter objekt skapas utan att behöva ge värden direkt


        // en konstruktor som skapar ett guest objekt
        // sätter värde på id, name och inlägg
        public Guest(int id, string name, string post)
        {
            Id = id;
            Name = name;
            Post = post;
        }
    }
}