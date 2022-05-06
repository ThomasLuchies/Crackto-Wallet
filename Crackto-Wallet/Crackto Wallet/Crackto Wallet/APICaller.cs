using Crackto_Wallet.Orders;
using Nancy.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Crackto_Wallet
{
    public class APICaller
    {
        private string APIURL = "https://testnet.binance.vision";
        private string APIKey = "iC8dgRNbVuc5nSvxvQPAVHhfIwKclB0hTaY2D9KaF2RhMBT8U94qjoGFtbc8LQJR";
        private string SecretKey = "IUAEy4p7ZTlY8cPCqukCCg3ACDRy09pOyxlMvJA4IdpCbBn3DKd2DSjglkShAGYf";


        public string PlaceOrder(Order order)
        {
            string endPoint = "/api/v3/order";

            Dictionary<string, string> reqParams = new Dictionary<string, string>()
            {
                {"symbol", order.CoinType.ToString()},
                {"side", order.TransactionType.ToString() },
                {"type", order.OrderType.ToString() },
                {"timestamp", ((int)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds).ToString()}
            };

            if (order is LimitOrder limitOrder)
            {
                reqParams.Add("quantity", limitOrder.Quantity.ToString());
                reqParams.Add("price", limitOrder.Amount.ToString());
                reqParams.Add("timeInForce", limitOrder.TimeInForce.ToString());
            }
            else if (order is MarketOrder marketOrder)
            {
                if(marketOrder.MarketType.Equals(MarketOrderType.QUOTE_ORDER_QTY))
                {
                    reqParams.Add("quoteOrderQty", marketOrder.MarketType.ToString());
                }
                else if(marketOrder.MarketType.Equals(MarketOrderType.QUANTITY))
                {
                    reqParams.Add("quantity", marketOrder.Quantity.ToString());
                }
            }
            Task<string> result = APICall(reqParams, endPoint, true);

            return result.IsCompletedSuccessfully ? result.Result : null;
        }

        public string GetBalance()
        {
            string endPoint = APIURL + "/api/v3/account";

            Dictionary<string, string> reqParams = new Dictionary<string, string>()
            {
                {"recvWindow", "5000" },
                {"timestamp", ((int)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds).ToString()}
            };
            Task<string> result = APICall(reqParams, endPoint, true);

            return result.IsCompletedSuccessfully ? result.Result : null;
        }

        public string GetActiveOrders()
        {
            string endPoint = APIURL + "/api/v3/openOrders";
            Dictionary<string, string> reqParams = new Dictionary<string, string>()
            {
                {"timestamp", ((int)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds).ToString()}
            };
            Task<string> result = APICall(reqParams, endPoint, true);

            return result.IsCompletedSuccessfully ? result.Result : null;
        }

        public double GetCoinValue(CoinType coinType)
        {
            string endPoint = APIURL + "/api/v3/ticker/price";
            Dictionary<string, string> reqParams= new Dictionary<string, string>()
            {
                { "symbol", coinType.ToString() }
            };
            Task<string> result = APICall(reqParams, endPoint, false);
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            CoinValueResult resultArr = serializer.Deserialize<CoinValueResult>(result.Result);

            return resultArr.price;
        }

        public class CoinValueResult
        {
            public string symbol;
            public double price;
        }


        public string CreateHmacSignature(string inputs)
        {
            byte[] keyBytes = Encoding.UTF8.GetBytes(SecretKey);
            byte[] queryStringBytes = Encoding.UTF8.GetBytes(inputs);
            HMACSHA256 hmacsha256 = new HMACSHA256(keyBytes);

            byte[] bytes = hmacsha256.ComputeHash(queryStringBytes);

            return BitConverter.ToString(bytes).Replace("-", "").ToLower();
        }

        public async Task<string> APICall(Dictionary<string, string> reqParams, string endPoint, bool signature)
        {
            string paramsString = "?";

            int count = 0;
            foreach(KeyValuePair<string, string> reqParam in reqParams)
            {
                paramsString += reqParam.Key + "=" + reqParam.Value;

                if(count != 0 || count != reqParams.Count - 1)
                    paramsString += "&";
            }

            if(signature)
                paramsString += "&signature=" + CreateHmacSignature(paramsString);

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("X-MBX-APIKEY", APIKey);
                HttpResponseMessage response = client.GetAsync(endPoint + paramsString).Result;
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                else
                {

                    return await response.Content.ReadAsStringAsync();
                }
            }

            return null;
        }
    }
}
