namespace covariant
{
    public class FoodFactory : IFactory<Food>
    {
        public Food Create()
        {
            return new Food();
        }
    }
}