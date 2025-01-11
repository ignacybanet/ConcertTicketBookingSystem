using System;
using ticketClass;
using concertClass;
using System.Security.Cryptography.X509Certificates;

namespace bookingSystemClass;


class BookingSystem {
    
    public List<Concert> concertList = new List<Concert>();

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
                    PrivateConcert cprivate = new();
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

    public void ReserveTicket() {
        
    }

    public void FilterConcert() {
        
    }
}