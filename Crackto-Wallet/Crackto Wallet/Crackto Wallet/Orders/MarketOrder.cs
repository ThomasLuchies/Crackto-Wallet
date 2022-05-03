using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crackto_Wallet.Orders
{
    class MarketOrder : Order
    {
        private double quantity;
        private string quantityType; //TOTAL or AMOUNT

        public MarketOrder(CoinType coinType, double amount, TransactionType transactionType, double quantity, string quantityType) : base(coinType, amount, transactionType)
        {
            this.quantity = quantity;
            this.quantityType = quantityType;
        }

        public double getQuantity()
        {
            return quantity;
        }

        public string getQuantityType()
        {
            return quantityType;
        }

        public void setQuantity(double quantity)
        {
            if (quantity < 0)
                throw new ArgumentOutOfRangeException("quantity");

            this.quantity = quantity;
        }

        public void setQuantityType(string quantityType)
        {
            this.quantityType = quantityType;
        }
    }
}
