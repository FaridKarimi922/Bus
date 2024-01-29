using Buss.FolderBus;
using Buss.FolderTravel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buss.FolderTicket
{
    public abstract class Ticket
    {
        public Ticket(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
        public Traveler Traveler { get; set; }
        public Bus Bus { get; set; }
        public FolderTravel.Path Travel { get; set; }
        public abstract void SetToTicket();

    }
    public class SoldTicket
    {
        public int Id { get; set; }
        public Traveler Traveler { get; set; }
        public Bus Bus { get; set; }
        public FolderTravel.Path Travel { get; set; }


    }
    public class ReservedTicket
    {
        public int Id { get; set; }
        public Traveler Traveler { get; set; }
        public Bus Bus { get; set; }
        public FolderTravel.Path Travel { get; set; }


    }
}
