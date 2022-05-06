using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crackto_Wallet.Orders
{
    public abstract class Order
    {
        private CoinType coinType;
        private double amount;
        private TransactionType transactionType;
        private OrderType orderType;

        public CoinType CoinType { get => coinType; set => coinType = value; }
        public double Amount { get => amount; set => amount = value; }
        public TransactionType TransactionType { get => transactionType; set => transactionType = value; }
        public OrderType OrderType { get => orderType; set => orderType = value; }

        protected Order(CoinType coinType, double amount, TransactionType transactionType, OrderType orderType)
        {
            this.coinType = coinType;
            this.transactionType = transactionType;
            this.orderType = orderType;
        }

        
    }
}
