using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crackto_Wallet.Orders
{
    abstract class Order
    {
        protected CoinType coinType;
        protected double price;
        protected TransactionType transactionType;

        protected Order(CoinType coinType, double price, TransactionType transactionType)
        {
            this.coinType = coinType;
            this.price = price;
            this.transactionType = transactionType;
        }
    }
}
