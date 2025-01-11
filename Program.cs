using System;
using ticketClass;
using concertClass;
using bookingSystemClass;


class Program {
    static void Main() {
        BookingSystem sstenm = new();
        sstenm.AddConcert();
    }
}