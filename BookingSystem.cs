using System;
using ticketClass;
using concertClass;
using userClass;
using System.Security.Cryptography.X509Certificates;

namespace bookingSystemClass;


class BookingSystem {
    
    public static List<Concert> concertList = new List<Concert>
            {
                new Concert("Rocking the Night", "2025-02-15", "New York", 15, 150, new RegularConcert()),
                new Concert("Jazz Under the Stars", "2025-03-10", "Los Angeles", 8, 200, new VIPConcert()),
                new Concert("Online Symphony", "2025-01-25", "Virtual", 9999, 50, new OnLineConcert()),
                new Concert("Pop Explosion", "2025-04-18", "Chicago", 12, 120, new RegularConcert()),
                new Concert("Classical Delight", "2025-05-22", "Boston", 7, 180, new VIPConcert()),
                new Concert("Indie Vibes", "2025-06-30", "New York", 16, 100, new RegularConcert()),
                new Concert("Private Serenade", "2025-07-05", "Los Angeles", 5, 5000, new PrivateConcert(new List<User> { User.UserList[3], User.UserList[28], User.UserList[14], User.UserList[12], User.UserList[9] })),
                new Concert("Metal Mayhem", "2025-08-12", "Chicago", 14, 140, new RegularConcert()),
                new Concert("Piano Dreams", "2025-09-09", "New York", 5, 300, new VIPConcert()),
                new Concert("Electronic Escape", "2025-10-11", "Miami", 10, 90, new RegularConcert()),
                new Concert("Country Roads", "2025-11-20", "Los Angeles", 40, 110, new RegularConcert()),
                new Concert("Soulful Evenings", "2025-12-15", "Chicago", 40, 130, new VIPConcert()),
                new Concert("Hip-Hop Heat", "2025-01-10", "New York", 40, 100, new RegularConcert()),
                new Concert("Opera Night", "2025-02-20", "Los Angeles", 40, 220, new VIPConcert()),
                new Concert("Online EDM Party", "2025-03-05", "Virtual", 9999, 60, new OnLineConcert()),
                new Concert("Blues Legends", "2025-04-02", "Chicago", 40, 150, new RegularConcert())
            };

    public void AddConcert() {
        string? cn; // concert name
        do {
            Console.WriteLine("New concert name:");
            cn = Console.ReadLine(); 
        } while(cn == null || cn == "");

        string? cd; // concert date
        do {
            Console.WriteLine("Input concert date (YYYY/MM/DD):");
            cd = Console.ReadLine(); 
        } while(cd == null || cd == "");

        string? cl; // concert location
        do {
            Console.WriteLine("Input concert location:");
            cl = Console.ReadLine(); 
        } while(cl == null || cl == "");

        string? sa = "2"; // seat amount
        int realsa = 0;
        do {
            Console.WriteLine("Input the number of seats: ");
            sa = Console.ReadLine();
            try {
                realsa = Int32.Parse(sa);
            } catch(FormatException) {
                Console.WriteLine("Must be a number.");
                sa = null;
            }
        } while(sa == null || sa == "");

        string? cp; // concert price
        int realcp = 0;
        do {
            Console.WriteLine("Input concert ticket price: ");
            cp = Console.ReadLine();
            try {
                realcp = Int32.Parse(cp);
            } catch(FormatException) {
                Console.WriteLine("Must be a number.");
                cp = null;
            }
        } while(cp == null);

        int ct = 0; // concert type
        string? inputct;
        TypeOfConcert realct = null;
        do {
            Console.WriteLine("Select concert type (1. VIP, 2. Regular, 3. OnLine, 4. Private)");
            inputct = Console.ReadLine();
            try {
                ct = Int32.Parse(inputct);
            } catch(FormatException) {
                ct = 0;
                Console.WriteLine("Must be a number.");
            }
            switch(ct) {
                case 1:
                    VIPConcert vip = new();
                    realct = vip;
                    break;

                case 2:
                    RegularConcert regular = new();
                    realct = regular;
                    break;

                case 3:
                    OnLineConcert onLine = new();
                    realct = onLine;
                    break;

                case 4: 
                    List<User> invitedpeople = new List<User>();
                    for(int i = 0 ; i != realsa ; i++) {
                        string? name;
                        do {
                            Console.WriteLine($"Input username of invited person nr {i+1}: ");
                            name = Console.ReadLine();
                            User invitedperson = User.UserList.Find(x => x.Username == name);
                            if(invitedperson == null) {
                                Console.WriteLine("User not found.");
                                name = null;
                            } else {
                                invitedpeople.Add(invitedperson);
                            }
                            
                        } while(name == null || name == "");
                    }

                    PrivateConcert cprivate = new(invitedpeople);
                    realct = cprivate;
                    break;

                default: 
                    Console.WriteLine("Number out of bounds.");
                    ct = 0;
                    break;
            }
        } while(ct == 0);

        Console.WriteLine($"\nName: {cn}\nDate: {cd}\nLocation: {cl}\nPrice: {cp}\nNumber of seats: {sa}\nPrice: {cp}\nType: {realct.GetType().Name}");
        Console.WriteLine("Do you really want to add this concert? (type 'yes' to continue, anything else to start over)");
        string? choice = Console.ReadLine().ToLower();
        
        if(choice == "yes") {
            concertList.Add( new Concert(cn, cd, cl, realsa, realcp, realct) );
        } else {
            AddConcert();
        }
    }


    public void EditConcert() {
        
        for(int i = 0; i != concertList.Count; i++) {
            Console.WriteLine($"{i + 1}. {concertList[i].Name}");
        }

        string? choice1;
        int realchoice = 0;

        do {
            Console.WriteLine("Which concert would you like to edit? (pick a number)");
            
            try {
                choice1 = Console.ReadLine();
                realchoice = Int32.Parse(choice1);
            } catch(FormatException) {
                Console.WriteLine("Must be a number.");
                choice1 = "";
            }
        } while(choice1 == "");
        

        Concert concert = concertList[realchoice-1];
        Console.WriteLine($"Name: {concert.Name}\nDate: {concert.Date}\nPrice: {concert.ConcertPrice}");

        string? cn; // concert name
        do {
            Console.WriteLine("Edit concert name:");
            cn = Console.ReadLine(); 
        } while(cn == null || cn == "");

        string? cd; // concert date
        do {
            Console.WriteLine("Edit concert date (YYYY/MM/DD):");
            cd = Console.ReadLine(); 
        } while(cd == null || cd == "");

        string? cp; // concert price
        int realcp = 0;
        do {
            Console.WriteLine("Edit concert ticket price: ");
            cp = Console.ReadLine();
            try {
                realcp = Int32.Parse(cp);
            } catch(FormatException) {
                Console.WriteLine("Must be a number.");
                cp = null;
            }
        } while(cp == null);

        Console.WriteLine($"Name: {concert.Name} -> {cn}\nDate: {concert.Date} -> {cd}\nPrice: {concert.ConcertPrice} -> {realcp}");
        Console.WriteLine("Do you really want to commit these changes? (type 'yes' to continue, anything else to revert changes.)");
        string? choice = Console.ReadLine().ToLower();
        
        if(choice == "yes") {
            concert.Name = cn;
            concert.Date = cd;
            concert.ConcertPrice = realcp;
        } else {
            Console.WriteLine("Changes reverted.");
        }

        
    }


    public void RemoveConcert() {
        for(int i = 0; i != concertList.Count; i++) {
            Console.WriteLine($"{i + 1}. {concertList[i].Name}");
        }

        string? choice1;
        int realchoice = 0;

        do {
            Console.WriteLine("Which concert would you like to remove? (pick a number)");
            
            try {
                choice1 = Console.ReadLine();
                realchoice = Int32.Parse(choice1);
            } catch(FormatException) {
                Console.WriteLine("Must be a number.");
                choice1 = "";
            }
        } while(choice1 == "");
        
        Concert concert = concertList[realchoice-1];

        Console.WriteLine("Do you really want to remove this concert? (type 'yes' to continue, anything else cancel)");
        string? choice = Console.ReadLine().ToLower();
        
        if(choice == "yes") {
            Console.WriteLine($"Concert {concert.Name} has been removed!");
            concertList.Remove(concert);
        }
    }

    public void GenerateReport() {
        //admin
    }

    public void DisplayConcert() {
        Console.WriteLine("Aviable concerts: ");
        for(int i = 0; i != concertList.Count; i++) {
            Console.WriteLine($"{i+1}. {concertList[i].Name}, Date: {concertList[i].Date}, In: {concertList[i].Location} || Cost: {concertList[i].ConcertPrice}");
        }
    }

    public void ReserveTicket() {
        
    }

    public void FilterConcert() {
        
    }
}