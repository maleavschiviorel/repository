using System;
using InterfaceActions.Actions;

namespace ActionImplementations
{
   using Domain.Domain;

   public class EmailNotification : INotifyUsersAction
    {
        public void Notify(Product product)
        {
            Console.WriteLine("Send Email: Product {0} is availalble in stores. Hurry!");
        }
    }
}