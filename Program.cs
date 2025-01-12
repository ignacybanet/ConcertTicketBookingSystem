using System;
using ticketClass;
using concertClass;
using bookingSystemClass;
using userClass;

class Program {
    static void Main() {
        BookingSystem sstenm = new();
        sstenm.DisplayConcert();
    }
}