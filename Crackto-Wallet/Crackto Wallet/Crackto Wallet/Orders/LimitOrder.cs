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
        private double price;

        public double Quantity
        {
            get { return quantity; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("value");

                quantity = value;
            }
        }

        public double Price
        {
            get { return price; }
            set { price = value; }
        }

        public TimeInForceType TimeInForce { get { return timeInForce; } }

        public LimitOrder(CoinType coinType, TransactionType transactionType, double price, double quantity, TimeInForceType tif) : base(coinType, transactionType, OrderType.LIMIT)
        {
            this.quantity = quantity;
            timeInForce = tif;
            this.price = price;
        }
    }
}
