using System;
using System.Collections.Generic;
using InterfaceActions.Actions;

namespace Factories.Factory
{
   using Domain.Domain;

   public class ProductFactory
    {
        #region Public members

        public ProductFactory(INotifyUsersAction notifyUsersAction)
        {
            _notifyUsersAction = notifyUsersAction;
        }

        public Product CreateNewProduct(string name, long price, IList<string> categoryNames,
                                        Action<IProductOptions> optionalParams)
        {
            var options = new ProductOptions();
            if (optionalParams != null)
                optionalParams(options);
            string description = options.GetDescription();
            if (string.IsNullOrWhiteSpace(description))
                description = "No Description available";

            var product = new Product(name, description, price, 0, categoryNames);
            OnProductCreation(product);
            return product;
        }

        public Product CreateExportedProduct(string name, long price, long ranking, IList<string> categoryNames,
                                             Action<IProductOptions> optionalParams)
        {
            var options = new ProductOptions();
            if (optionalParams != null)
                optionalParams(options);
            string description = options.GetDescription();
            if (string.IsNullOrWhiteSpace(description))
                description = "No Description available";

            var product = new Product(name, description, price, ranking, categoryNames);
            OnProductCreation(product);
            return product;
        }

        public void OnProductCreation(Product product)
        {
            _notifyUsersAction.Notify(product);
        }

        #endregion

        #region Public nested type: ProductOptions

        public class ProductOptions : IProductOptions
        {
            #region IProductOptions Members

            public IProductOptions WithDescrption(Func<string> desciptionDelegate)
            {
                _description = desciptionDelegate();
                return this;
            }

            public string GetDescription()
            {
                return _description;
            }

            #endregion

            #region Non-public members

            private string _description;

            #endregion
        }

        #endregion

        #region Non-public members

        private readonly INotifyUsersAction _notifyUsersAction;

        #endregion
    }
}