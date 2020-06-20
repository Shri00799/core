using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessRuleEngine
{
    /// <summary>
    /// Interface to Shipping Slip Service
    /// </summary>
    public interface IShippingSlipService
    {
        void GenerateShippingSlipForAddress(string shippingAddress);
    }
}
