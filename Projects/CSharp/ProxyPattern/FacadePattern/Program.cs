namespace FacadePattern
{
    class Program
    {
        public class BussinessClient
        {
            public Car CarRented { get; set; }
            public TableInRestaurant TableRestaurant { get; set; }
            public TicketForTrip TicketTrip { get; set; }
        }

        public class OrdinaryClient
        {
            public TableInRestaurant TableRestaurant { get; set; }
        }


        public class Car
        { }
        public class TableInRestaurant
        {

        }
        public class TicketForTrip
        { }
        public class CarRentFirm
        {
            public Car RentCar()
            {
                return new Car();
            }
        }
        public class Restaurant
        {
            public TableInRestaurant RentTable()
            {
                return new TableInRestaurant();
            }
        }

        public class TuristFirm
        {
            public TicketForTrip GetTicketTrip()
            {
                return new TicketForTrip();
            }

        }

        public class Hotel
        {
            private CarRentFirm carRentFirm = new CarRentFirm();
            private Restaurant restaurant = new Restaurant();
            private TuristFirm turistFirm = new TuristFirm();

            public void EnterBussenesClient(BussinessClient client)
            {
                client.CarRented = carRentFirm.RentCar();
                client.TableRestaurant = restaurant.RentTable();
                client.TicketTrip = turistFirm.GetTicketTrip();
            }

            public void EnterOrnirayClient(OrdinaryClient client)
            {
                client.TableRestaurant = restaurant.RentTable();
            }

        }
        static void Main(string[] args)
        {
            Hotel hotel = new Hotel();
            BussinessClient bussinessClient = new BussinessClient();
            OrdinaryClient ordinaryClient = new OrdinaryClient();
            hotel.EnterBussenesClient(bussinessClient);
            hotel.EnterOrnirayClient(ordinaryClient);

        }
    }
}
