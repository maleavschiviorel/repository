using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace covariant
{
 
    public class Food
    { }
    public class Pizza:Food
    { }
    public class Salad : Food
    { }

    public interface IFactory<out T>
    { T Create(); }

    public class FoodFactory : IFactory<Food>
    {
        public Food Create()
        {
            return new Food();
        }
    }
    public class PizzaFactory : IFactory<Pizza>
    {
        public Pizza Create()
        {
            return new Pizza();
        }

       
    }
    class Program
    {
        static void Main(string[] args)
        {
            //List<Food> lfood = new List<Food>();
            //lfood.AddRange(new Salad[] { new Salad(), new Salad() });
            //lfood.AddRange(new Pizza[] { new Pizza(), new Pizza() });
            //lfood[0] = new Pizza();
            //Food[] arrfood = new Salad[] {new Salad (),new Salad() };

            //arrfood[0] = new Pizza();


            Console.ReadLine();

        }
    }
}
