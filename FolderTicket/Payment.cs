using Buss.Enums;
using Buss.FolderTravel;

namespace Buss.FolderTicket
{
    public class Payment
    {
        public int PaymentID { get; set; }
        public double Price { get; set; }
        public StatusType Status { get; set; } = StatusType.n;
        public Trip TripID { get; set; }

        public override string ToString()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            return $"{TripID}\n {PaymentID} {Status.ToString()} {Price} ";
        }
    }
}

