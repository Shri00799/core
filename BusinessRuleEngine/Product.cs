using System;

namespace BusinessRuleEngine
{
    /// <summary>
    /// Product Class
    /// </summary>
    public class Product
    {
        private string _shippingAddress;
        private string _name;
        private readonly string _productCode;

        /// <summary>
        /// Pruduct Constructor
        /// </summary>
        /// <param name="name">Name of the product</param>
        public Product(string name)
        {
            this._name = name;
            _productCode = Guid.NewGuid().ToString("N");
        }

        /// <summary>
        /// Set Shipping Address
        /// </summary>
        /// <param name="shippingAddress">Shipping Address</param>
        public void SetShippingAddress(string shippingAddress)
        {
            this._shippingAddress = shippingAddress;
        }

        /// <summary>
        /// Get Shipping Address
        /// </summary>
        /// <returns></returns>
        public string GetShippingAddress()
        {
            return _shippingAddress;
        }

        /// <summary>
        /// Get Product Code
        /// </summary>
        /// <returns></returns>
        public string GetProductCode()
        {
            return _productCode;
        }
    }

    /// <summary>
    /// Payment class
    /// </summary>
    public class Payment
    {
        private readonly Product _physicalProduct;
        private decimal _amount;
        private IShippingSlipService _shippingSlipService;
        private string _shippingAddress;

        /// <summary>
        /// Peyment details
        /// </summary>
        /// <param name="physicalProduct">Physical Product</param>
        /// <param name="shippingAddress">Shipping Address</param>
        public Payment(Product physicalProduct, string shippingAddress)
        {
            if (physicalProduct == null)
                throw new ArgumentNullException("physicalProduct");
            if (shippingAddress == null)
                throw new ArgumentNullException("shippingAddress");

            this._physicalProduct = physicalProduct;
            this._shippingAddress = shippingAddress;
        }

        /// <summary>
        /// CompletePayment
        /// </summary>
        /// <param name="amount">Amount</param>
        public virtual void CompletePayment(decimal amount)
        {
            _amount = amount;
            if (_physicalProduct != null) _shippingSlipService.GenerateShippingSlipForAddress(_physicalProduct.GetShippingAddress());
        }

        /// <summary>
        /// Set Shipping Service
        /// </summary>
        /// <param name="shippingSlipService"><shipping slip service object</param>
        public void SetShippingService(IShippingSlipService shippingSlipService)
        {
            _shippingSlipService = shippingSlipService;
        }
    }
}
