namespace InterfaceActions.Actions
{
   using Domain.Domain;

   public interface INotifyUsersAction
    {
        #region Public members

        void Notify(Product product);

        #endregion
    }
}