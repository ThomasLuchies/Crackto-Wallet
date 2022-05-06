using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crackto_Wallet.Orders
{
    public class LimitOrder : Order
    {
        private double quantity;
        private TimeInForceType timeInForce;

        public double Quantity
        {
            get { return quantity; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("value");

                value = value;
            }
        }

        public TimeInForceType TimeInForce { get { return timeInForce; } }

        public LimitOrder(CoinType coinType, double price, TransactionType transactionType, double quantity, TimeInForceType tif) : base(coinType, price, transactionType, OrderType.LIMIT)
        {
            this.quantity = quantity;
            timeInForce = tif;
        }
    }
}
