namespace Buss.FolderTravel
{
    public class NormalPath : Path
    {
        public NormalPath( string origin, string destination) : base( origin, destination)
        {
        }

        public override void SetPrice(int price)
        {
            if (price < 80)
            {
                throw new Exception("The price is low for normal!!!");
            }
            base.SetPrice(price);
        }
    }
}
