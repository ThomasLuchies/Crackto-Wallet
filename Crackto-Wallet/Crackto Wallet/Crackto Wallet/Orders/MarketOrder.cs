using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crackto_Wallet.Orders
{
    public class MarketOrder : Order
    {
        private MarketOrderType marketType;
        private double quantity;

        public double Quantity
        {
            get { return quantity; }
            set
            {
                if (quantity < 0)
                    throw new ArgumentOutOfRangeException("quantity");

                value = value;
            }
        }
        public MarketOrderType MarketType { get { return marketType; } }

        public MarketOrder(CoinType coinType, TransactionType transactionType, MarketOrderType marketType, double quantity) : base(coinType, transactionType, OrderType.MARKET)
        {
            this.marketType = marketType;
            this.quantity = quantity;
        }
    }
}
