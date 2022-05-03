using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Crackto_Wallet
{
    public class APICaller
    {
        private string APIURL = "https://testnet.binance.vision/api";
        private string APIKey = "iC8dgRNbVuc5nSvxvQPAVHhfIwKclB0hTaY2D9KaF2RhMBT8U94qjoGFtbc8LQJR";
        private string SecretKey = "IUAEy4p7ZTlY8cPCqukCCg3ACDRy09pOyxlMvJA4IdpCbBn3DKd2DSjglkShAGYf";


        public Task PlaceOrder()
        {
            return null;
        }

        public Task GetBalance()
        {
            return null;
        }

        public Task GetActiveOrders()
        {
            return null;
        }

        public double GetCoinValue(CoinType coinType)
        {
            string endPoint = APIURL + "/api/v3/ticker/price?symbol=" + coinType.ToString();
            endPoint += coinType.ToString();
            Task<string> result = APICall(endPoint);

            return result.IsCompletedSuccessfully ? Convert.ToDouble(result.Result) : 0;
        }

        public async Task<string> APICall(string endPoint)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(endPoint);
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ToString();
                }
            }

            return null;
        }
    }
}
