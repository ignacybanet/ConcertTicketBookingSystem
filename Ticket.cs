using System;
using concertClass;

namespace ticketClass;

class Ticket {
    public Concert TicketConcert;
    public int Price;
    public int SeatNumber;

    public Ticket(Concert chosenConcert, int ticketPrice, int ticketSeat) {
        TicketConcert = chosenConcert;
        Price = ticketPrice;
        SeatNumber = ticketSeat;
    }

    public void reserveSeat() {
        
    }
}