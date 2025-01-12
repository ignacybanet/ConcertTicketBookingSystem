using System;
using ticketClass;
using concertClass;
using userClass;
using System.Security.Cryptography.X509Certificates;

namespace bookingSystemClass;


class BookingSystem {

    User currentUser = User.SignIn();

    public static List<Concert> concertList = new List<Concert>
            {
                new Concert("Rocking the Night", "2025-02-15", "New York", 15, 150, new RegularConcert()),
                new Concert("Jazz Under the Stars", "2025-02-15", "Los Angeles", 8, 200, new VIPConcert()),
                new Concert("Online Symphony", "2025-02-15", "Virtual", 9999, 50, new OnLineConcert()),
                new Concert("Pop Explosion", "2025-02-16", "Chicago", 12, 120, new RegularConcert()),
                new Concert("Classical Delight", "2025-02-16", "Boston", 7, 180, new VIPConcert()),
                new Concert("Indie Vibes", "2025-02-17", "New York", 16, 100, new RegularConcert()),
                new Concert("Private Serenade", "2025-02-17", "Los Angeles", 5, 5000, new PrivateConcert(new List<User> { User.UserList[3], User.UserList[28], User.UserList[14], User.UserList[12], User.UserList[9] })),
                new Concert("Metal Mayhem", "2025-02-18", "Chicago", 14, 140, new RegularConcert()),
                new Concert("Piano Dreams", "2025-02-19", "New York", 5, 300, new VIPConcert()),
                new Concert("Electronic Escape", "2025-02-19", "Miami", 10, 90, new RegularConcert()),
                new Concert("Country Roads", "2025-02-20", "Los Angeles", 40, 110, new RegularConcert()),
                new Concert("Soulful Evenings", "2025-02-20", "Chicago", 40, 130, new VIPConcert()),
                new Concert("Hip-Hop Heat", "2025-02-21", "New York", 40, 100, new RegularConcert()),
                new Concert("Opera Night", "2025-02-21", "Los Angeles", 40, 220, new VIPConcert()),
                new Concert("Online EDM Party", "2025-02-22", "Virtual", 9999, 60, new OnLineConcert()),
                new Concert("Blues Legends", "2025-02-22", "Chicago", 40, 150, new RegularConcert())
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

    public void DisplayConcert() {
        Console.WriteLine("Select how do you want to display concerts\n1. Name\n2. Location\n 3. Date");
        string? choice = "";
        int intchoice = 0;
        
        do {
            try {
                choice = Console.ReadLine();
                intchoice = Int32.Parse(choice);
            } catch(FormatException) {
                Console.WriteLine("Must be a number.");
                choice = null;
            }

            switch(intchoice) {
            case 1:
                Console.WriteLine("Name: ");
                string userConcertName = Console.ReadLine();
                int j;
                List<Concert> selectedConcertsName = new List<Concert>();

                selectedConcertsName = concertList.Where(concertName => concertName.Name == userConcertName).ToList();

                if (selectedConcertsName.Count == 0) {
                    Console.WriteLine("No concerts found");
                } else {
                    j = 1;
                    foreach (var concert in selectedConcertsName)
                    {
                        Console.WriteLine($"{j}. Name: {concert.Name}, Date: {concert.Date}, Location: {concert.Location}, Price: {concert.ConcertPrice}");
                        j++;
                    }
                }
                break;

            case 2:
                Console.WriteLine("Location: ");
                string userConcertLocation = Console.ReadLine();
                
                List<Concert> selectedConcertsLocation = new List<Concert>();
                selectedConcertsLocation = concertList.Where(concertName => concertName.Location == userConcertLocation).ToList();
                if (selectedConcertsLocation.Count == 0) {
                    Console.WriteLine("No concerts found");
                } else {
                    j = 1;
                    foreach (var concert in selectedConcertsLocation)
                    {
                        Console.WriteLine($"{j}. Name: {concert.Name}, Date: {concert.Date}, Location: {concert.Location}, Price: {concert.ConcertPrice}");
                        j++;
                    } 
                }
                break;

            case 3:
                Console.WriteLine("Date (YYYY/MM/DD): ");
                string userConcertDate = Console.ReadLine();

                List<Concert> selectedConcertsDate = new List<Concert>();
                selectedConcertsDate = concertList.Where(concertName => concertName.Date == userConcertDate).ToList();

                if (selectedConcertsDate.Count == 0) {
                    Console.WriteLine("No concerts found");
                } else {
                    j = 1;
                    foreach (var concert in selectedConcertsDate)
                    {
                        Console.WriteLine($"{j}. Name: {concert.Name}, Date: {concert.Date}, Location: {concert.Location}, Price: {concert.ConcertPrice}");
                        j++;
                    }
                }
                

                break;
            
            default:
                Console.WriteLine("Something went wrong.");
                choice = null;
                break;
        }
            
        } while (choice == null || choice == "");
    }

    /*
    public void ReserveTicket(Concert concert) {
        Console.WriteLine($"Concert: {concert.Name}\nDate: {concert.Date}\nLocation: {concert.Location}\nPrice: {concert.ConcertPrice}");
        Console.WriteLine("Do you really want to buy a ticket to this concert? (type 'yes' to continue, anything else to cancel)");

        /*
        string? choice = Console.ReadLine().ToLower();
        Random rnd = new();
        int[] seats = concert.SeatArray;
        int seat;
        bool loop = true;

        if (choice == "yes") {
            if (concert.ConcertType is PrivateConcert && !((PrivateConcert)concert.ConcertType).InvitedUsers.Contains(currentUser)) {
                Console.WriteLine("This is a private concert. You need to be invited to buy a ticket.");
            } else {
                if (seats.Length == 0) {
                    Console.WriteLine("No seats available.");
                    return;
                }

                do {
                    seat = rnd.Next(0, seats.Length); // Random seat index within valid range
                    if (seat < 0 || seat >= seats.Length) {
                        Console.WriteLine("Generated seat index is out of range.");
                        continue;
                    }

                    if (seats[seat] == 1) {
                        // Seat is occupied
                        continue;
                    } else {
                        seats[seat] = 1; // Seat is free, so occupy it
                        loop = false;
                    }
                } while (loop);

                Ticket.ListOfTickets.Add(new Ticket(concert, concert.ConcertPrice, seat, currentUser));
                Console.WriteLine("Ticket bought!");
            }
        } else {
            Console.WriteLine("Ticket not bought.");
        }
           
    }
    */ 
    public void FilterConcert() {
        Console.WriteLine("Select how do you want to sort concerts\n1. Price\n2. Name");
        string? choice = "";
        int intchoice = 0;
        
        do {
            try {
            choice = Console.ReadLine();
            intchoice = Int32.Parse(choice);
            } catch(FormatException) {
                Console.WriteLine("Must be a number");
                choice = null;
            }
            int j;
            switch(intchoice) {
            case 1:
                var selectedConcertsPrice = concertList.OrderBy(concert => concert.ConcertPrice);
                j = 1;
                foreach (var concert in selectedConcertsPrice)
                {
                    Console.WriteLine($"{j}. Name: {concert.Name}, Date: {concert.Date}, Location: {concert.Location}, Price: {concert.ConcertPrice}");
                    j++;
                }
                break;

            case 2:
                var selectedConcertsName = concertList.OrderBy(concert => concert.Name);
                j = 1;
                foreach (var concert in selectedConcertsName)
                {
                    Console.WriteLine($"{j}. Name: {concert.Name}, Date: {concert.Date}, Location: {concert.Location}, Price: {concert.ConcertPrice}");
                    j++;
                }
                break;

            /*case 3:
                var selectedConcertsSeatAmount = concertList.OrderBy(concert => concert.SeatArray);
                j = 1;
                foreach (var concert in selectedConcertsSeatAmount)
                {
                    Console.WriteLine($"{j}. Name: {concert.Name}, Date: {concert.Date}, Location: {concert.Location}, Price: {concert.ConcertPrice}");
                    j++;
                }
                break;*/
            
            default:
                Console.WriteLine("Something went wrong");
                choice = null;
                break;
        }
            
        } while (choice == null || choice == "");
    }   

    public void UI() {

        while(true) {
            if (currentUser.Role == "admin") {
                
                Console.WriteLine("1. Add concert\n2. Edit concert\n3. Remove concert\n4. Exit");
                string? choice = Console.ReadLine();
                int realchoice = 0;
                try {
                    realchoice = Int32.Parse(choice);
                } catch(FormatException) {
                    Console.WriteLine("Must be a number.");
                    continue;
                }

                switch(realchoice) {
                    case 1:
                        AddConcert();
                        break;

                    case 2:
                        EditConcert();
                        break;

                    case 3:
                        RemoveConcert();
                        break;

                    case 4:
                        return;
                    
                    case 2145:
                        Console.WriteLine("The time my suffering stopped. Fried egg jellyfish");
                        break;

                    default:
                        Console.WriteLine("Number out of bounds.");
                        break;
                }
            }


            else if (currentUser.Role == "user" || currentUser.Role == "vip") {
                
                Console.WriteLine("1. Display concerts\n2. Filter concerts\n3. Exit");
                string? choice = Console.ReadLine();
                int realchoice = 0;
                try {
                    realchoice = Int32.Parse(choice);
                } catch(FormatException) {
                    Console.WriteLine("Must be a number.");
                    continue;
                }

                switch(realchoice) {
                    case 1:
                        DisplayConcert();
                        break;

                    case 2:
                        FilterConcert();
                        break;

                    case 3:
                        return;

                    case 62:
                        Console.WriteLine("Oi hhhuuuggghhhiiieee");
                        break;
                        
                    default:
                        Console.WriteLine("Number out of bounds.");
                        break;
                }
            }
        }
    }
}
    
    
