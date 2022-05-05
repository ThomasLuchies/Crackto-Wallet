using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crackto_Wallet.Orders
{
    class LimitOrder : Order
    {
        private double quantity;
        private TimeInForceType timeInForce;

        public LimitOrder(CoinType coinType, double price, TransactionType transactionType, double quantity, TimeInForceType tif) : base(coinType, price, transactionType)
        {
            this.quantity = quantity;
            timeInForce = tif;
        }

        public double getQuantity()
        {
            return quantity;
        }

        public TimeInForceType GetTimeInForce()
        {
            return timeInForce;
        }

        public void setQuantity(double quantity)
        {
            if (quantity < 0)
                throw new ArgumentOutOfRangeException("quantity");

            this.quantity = quantity;
        }

        public void setTimeInForce(TimeInForceType tif)
        {
            if (!timeInForce.Equals(tif))
                timeInForce = tif;
        }
    }
}
