using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessRuleEngine
{
    class Program
    {
        static Product _product;
        static Payment _payment;
        static Product _physicalProduct;
        static IShippingSlipService _shippingService;
        static decimal PaymentAmount = 100;
        static string ShippingAddress;

        static void Main(string[] args)
        {
            int senario = 1;
            switch (senario)
            {
                case 1:
                    ShippingAddress = "";
                    //1) If the Payment is for physical product, generate a packing slip for shipping.
                    PaymentForAPhysicalProductGeneratesAPackagingSlipForShippingTest();
                    break;
                case 2:

                default:
                    break;
            }

        }

        private static void PaymentForAPhysicalProductGeneratesAPackagingSlipForShippingTest()
        {
            _physicalProduct = new Product("Mobile");
            var physicalProduct = _physicalProduct;
            const string shippingAddress = "Jayanagar, Bangalore";
            physicalProduct.SetShippingAddress(shippingAddress);

            _payment = new Payment(_physicalProduct, ShippingAddress);
            _shippingService = new ShippingSlipService();

            _payment.SetShippingService(_shippingService);

            _payment.CompletePayment(PaymentAmount);
            _shippingService.GenerateShippingSlipForAddress(_physicalProduct.GetShippingAddress());
        }

        /// <summary>
        /// 
        /// </summary>
        private static void PaymentIsDoneForProduct()
        {
            
        }
        private static void ProductIsReadyForPayment()
        {
            
        }
        private static void ShouldAlsoGenerateAShippingSlipForTheProduct()
        {
            
        }
    }
}
