namespace FourthTask
{
    public interface IFlyable
    {
        public void FlyTo(Point destinationPoint);

        public double GetFlyTime(Point destinationPoint);
    }
}
