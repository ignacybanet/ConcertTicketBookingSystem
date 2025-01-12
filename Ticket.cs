using System;
using concertClass;
using userClass;
using bookingSystemClass;

namespace ticketClass;

class Ticket {
    public Concert TicketConcert;
    public int Price;
    public int SeatNumber;
    public User TicketOwner;

    public Ticket(Concert chosenConcert, int ticketPrice, int ticketSeat, User owner) {
        TicketConcert = chosenConcert;
        Price = ticketPrice;
        SeatNumber = ticketSeat;
        TicketOwner = owner;
    }


    List<Ticket> ListOfTickets = new List<Ticket>{
        new Ticket(BookingSystem.concertList[0], 150, 3, User.UserList[2]),
        new Ticket(BookingSystem.concertList[0], 150, 10, User.UserList[3]),
        new Ticket(BookingSystem.concertList[1], 200, 5, User.UserList[4]),
        new Ticket(BookingSystem.concertList[1], 200, 20, User.UserList[5]),
        new Ticket(BookingSystem.concertList[2], 50, 0, User.UserList[6]), 
        new Ticket(BookingSystem.concertList[3], 120, 8, User.UserList[7]),
        new Ticket(BookingSystem.concertList[3], 120, 15, User.UserList[8]),
        new Ticket(BookingSystem.concertList[4], 180, 2, User.UserList[9]),
        new Ticket(BookingSystem.concertList[4], 180, 25, User.UserList[10]),
        new Ticket(BookingSystem.concertList[5], 100, 4, User.UserList[11]),
        new Ticket(BookingSystem.concertList[5], 100, 17, User.UserList[12]),
        new Ticket(BookingSystem.concertList[6], 5000, 1, User.UserList[13]), 
        new Ticket(BookingSystem.concertList[6], 5000, 2, User.UserList[14]),
        new Ticket(BookingSystem.concertList[7], 140, 9, User.UserList[15]),
        new Ticket(BookingSystem.concertList[7], 140, 21, User.UserList[16]),
        new Ticket(BookingSystem.concertList[8], 300, 3, User.UserList[17]),
        new Ticket(BookingSystem.concertList[8], 300, 7, User.UserList[19]),
        new Ticket(BookingSystem.concertList[9], 90, 6, User.UserList[20]),
        new Ticket(BookingSystem.concertList[9], 90, 13, User.UserList[21]),
        new Ticket(BookingSystem.concertList[10], 110, 11, User.UserList[22]),
        new Ticket(BookingSystem.concertList[10], 110, 16, User.UserList[23]),
        new Ticket(BookingSystem.concertList[11], 130, 12, User.UserList[24]),
        new Ticket(BookingSystem.concertList[11], 130, 18, User.UserList[25]),
        new Ticket(BookingSystem.concertList[12], 100, 19, User.UserList[26]),
        new Ticket(BookingSystem.concertList[12], 100, 22, User.UserList[27]),
        new Ticket(BookingSystem.concertList[13], 220, 14, User.UserList[28]),
        new Ticket(BookingSystem.concertList[13], 220, 24, User.UserList[29]),
        new Ticket(BookingSystem.concertList[14], 50, 0, User.UserList[2]), 
        new Ticket(BookingSystem.concertList[15], 150, 26, User.UserList[9]),
        new Ticket(BookingSystem.concertList[15], 150, 18, User.UserList[8]),
        new Ticket(BookingSystem.concertList[16], 150, 27, User.UserList[25]),
        new Ticket(BookingSystem.concertList[16], 150, 8, User.UserList[27]),
        new Ticket(BookingSystem.concertList[17], 200, 30, User.UserList[13]),
        new Ticket(BookingSystem.concertList[17], 200, 35, User.UserList[12]),
        new Ticket(BookingSystem.concertList[18], 60, 0, User.UserList[4]), 
        new Ticket(BookingSystem.concertList[19], 120, 20, User.UserList[16]),
        new Ticket(BookingSystem.concertList[19], 120, 40, User.UserList[9]),
        new Ticket(BookingSystem.concertList[20], 180, 6, User.UserList[14]),
        new Ticket(BookingSystem.concertList[20], 180, 9, User.UserList[3]),
        new Ticket(BookingSystem.concertList[21], 100, 22, User.UserList[17]),
        new Ticket(BookingSystem.concertList[21], 100, 29, User.UserList[2]),
        new Ticket(BookingSystem.concertList[22], 5000, 4, User.UserList[12]), 
        new Ticket(BookingSystem.concertList[22], 5000, 5, User.UserList[19]),
        new Ticket(BookingSystem.concertList[23], 140, 17, User.UserList[9]),
        new Ticket(BookingSystem.concertList[23], 140, 30, User.UserList[2]),
        new Ticket(BookingSystem.concertList[24], 300, 10, User.UserList[9]),
        new Ticket(BookingSystem.concertList[24], 300, 14, User.UserList[23]), 
        new Ticket(BookingSystem.concertList[25], 90, 11, User.UserList[10]),
        new Ticket(BookingSystem.concertList[25], 90, 12, User.UserList[14]),
        new Ticket(BookingSystem.concertList[26], 110, 28, User.UserList[15])
         
    };
}