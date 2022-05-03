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
        protected double amount;
        protected TransactionType transactionType;

        protected Order(CoinType coinType, double amount, TransactionType transactionType)
        {
            this.coinType = coinType;
            this.amount = amount;
            this.transactionType = transactionType;
        }
    }
}
