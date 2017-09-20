namespace Repository.Interfaces
{
   using Domain.Domain;

   public interface IRepository
   {
      #region Public members

      void Save<TEntity>(TEntity entity) where TEntity : Entity;
      void Delete<TEntity>(TEntity entity) where TEntity : Entity;

      TEntity Get<TEntity>(long id) where TEntity : Entity;

      #endregion
   }
}