using System;
using System.Collections.Generic;

namespace concertClass;

interface TypeOfConcert {
    
}

class VIPConcert : TypeOfConcert {}
class RegularConcert : TypeOfConcert {}
class OnLineConcert : TypeOfConcert {}
class PrivateConcert : TypeOfConcert {}

class Concert {
    public string Name;
    public string Date;
    public string Location;
    public int[] SeatArray;

    public TypeOfConcert ConcertType;

    public Concert(string concertName, string concertDate, string concertLocation, int seatAmount, TypeOfConcert concertType) {
        Name = concertName;
        Date = concertDate;
        Location = concertLocation;
        SeatArray = new int[seatAmount];
        ConcertType = concertType;
    }

}