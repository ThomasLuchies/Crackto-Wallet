using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crackto_Wallet.Orders
{
    class MarketOrder : Order
    {
        private MarketOrderType marketType;
        private double quantity;

        public MarketOrder(CoinType coinType, double price, TransactionType transactionType, MarketOrderType marketType, double quantity) : base(coinType, price, transactionType)
        {
            this.marketType = marketType;
            this.quantity = quantity;
        }

        public double getQuantity()
        {
            return quantity;
        }

        public MarketOrderType getMarketType()
        {
            return marketType;
        }

        public void setQuantity(double quantity)
        {
            if (quantity < 0)
                throw new ArgumentOutOfRangeException("quantity");

            this.quantity = quantity;
        }

        public void setMarketType(MarketOrderType marketType)
        {
            this.marketType = marketType;
        }
    }
}
