using System;
using InterfaceActions.Actions;

namespace ActionImplementations
{
   using Domain.Domain;

   public class SmsNotification : INotifyUsersAction
    {
        public void Notify(Product product)
        {
            Console.WriteLine("Send SMS: Product {0} is availalble in stores. Hurry!");
        }
    }
}