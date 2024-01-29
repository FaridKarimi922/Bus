using Buss.FolderBus;
using Buss.FolderTicket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buss.FolderTravel
{
    public class Trip
    {
        public Trip() { }
        public int TripId { get; set; }
        public Path PathId { get; set; }
        public Bus BusId { get; set; }

        public List<Payment> payments { get; set; } = new List<Payment>();
        public override string ToString()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            return ($"Trip Number: {TripId}\n\nPath Number {PathId}\nBus Number  {BusId}\n");
        }
    }
}
