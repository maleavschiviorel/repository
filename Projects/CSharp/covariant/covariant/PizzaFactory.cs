namespace covariant
{
    public class PizzaFactory : IFactory<Pizza>
    {
        public Pizza Create()
        {
            return new Pizza();
        }

       
    }
}