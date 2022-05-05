using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crackto_Wallet.Orders
{
    public class LimitOrder : Order
    {
<<<<<<< Updated upstream
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
=======
        private double value;
        private double timeInForce;

        public double Value 
        { 
            get { return value; } 
            set 
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("value");

                value = value;
            } 
        }

        public double TimeInForce { get { return timeInForce; } }

        public LimitOrder(CoinType coinType, double amount, TransactionType transactionType, double value, double timeInForce) : base(coinType, amount, transactionType, OrderType.LIMIT)
        {
            this.value = value;
            this.timeInForce = timeInForce;
>>>>>>> Stashed changes
        }
    }
}
