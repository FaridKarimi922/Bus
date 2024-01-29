namespace Buss.FolderBus
{
    public class SeatsBus
    {
        public SeatsBus(int number)
        {
            Number = number;
        }
        public int Number { get; set; }
        public Traveler? Traveler { get; set; }

    }
}
