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

<<<<<<< Updated upstream
        public MarketOrder(CoinType coinType, double price, TransactionType transactionType, MarketOrderType marketType, double quantity) : base(coinType, price, transactionType)
        {
            this.marketType = marketType;
            this.quantity = quantity;
        }
=======
        public double Quantity 
        { 
            get { return quantity; } 
            set 
            {
                if (quantity < 0)
                    throw new ArgumentOutOfRangeException("quantity");
>>>>>>> Stashed changes

                value = value;
            } 
        }

<<<<<<< Updated upstream
        public MarketOrderType getMarketType()
        {
            return marketType;
        }
=======
        public string QuantityType { get { return quantityType; } set { value = value; } }
>>>>>>> Stashed changes

        public MarketOrder(CoinType coinType, double amount, TransactionType transactionType, double quantity, string quantityType) : base(coinType, amount, transactionType, OrderType.MARKET)
        {
            this.quantity = quantity;
<<<<<<< Updated upstream
        }

        public void setMarketType(MarketOrderType marketType)
        {
            this.marketType = marketType;
=======
            this.quantityType = quantityType;
>>>>>>> Stashed changes
        }
    }
}
