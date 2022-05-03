using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crackto_Wallet.Orders
{
    class LimitOrder : Order
    {
        private double value;

        public LimitOrder(CoinType coinType, double amount, TransactionType transactionType, double value) : base(coinType, amount, transactionType)
        {
            this.value = value;
        }

        public double getValue()
        {
            return value;
        }

        public void setValue(double value)
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException("value");

            this.value = value;
        }
    }
}
