namespace Domain.Mapping
{
   using Domain;
   using FluentNHibernate.Mapping;

   public abstract class EntityMap<TEntity> : ClassMap<TEntity> where TEntity : Entity
   {
      #region Non-public members

      protected EntityMap()
      {
         Id(x => x.Id).GeneratedBy.HiLo("1000");

         Version(x => x.Version);
         DynamicUpdate();
      }

      #endregion
   }
}