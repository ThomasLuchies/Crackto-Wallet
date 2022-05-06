using Crackto_Wallet.Orders;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Timers;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Crackto_Wallet.Screens
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    /// 


    public sealed partial class OrderPage : Page
    {
        private APICaller apiCaller = new APICaller();

        public OrderPage()
        {
            this.InitializeComponent();
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            AddDropdownValues();
            AddAllOrders();
        }

        private void AddDropdownValues()
        {
            foreach (var coinType in Enum.GetValues(typeof(CoinType)))
            {
                AllCoinTypesDropdownMarket.Items.Add(coinType);
                AllCoinTypesDropdownLimit.Items.Add(coinType);
            }

            foreach (var value in Enum.GetValues(typeof(OrderType)))
            {
                BuySellDropdownMarket.Items.Add(value);
                BuySellDrowndownLimit.Items.Add(value);
            }

            foreach (var marketType in Enum.GetValues(typeof(MarketOrderType)))
                MarketTypeDropdown.Items.Add(marketType);
        }

        private void AddAllOrders()
        {
            string JSONResponse = apiCaller.GetActiveOrders();
            if (JSONResponse == null)
                return;

            Debug.WriteLine("JSON Response: ", JSONResponse);
            Nancy.Json.JavaScriptSerializer serializer = new Nancy.Json.JavaScriptSerializer();
            Orders orders = serializer.Deserialize<Orders>(JSONResponse);

            foreach (var order in orders.orders)
                ActiveOrders.Items.Add(order);

        }

        public class Orders
        {
            public List<Order> orders = new List<Order>();
        }

        public class Order
        {
            public string symbol;
            public int orderId;
            public string type;
            public string side;
            public string price;
            public string time;
        }

        private void Button_Click_Market(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_Limit(object sender, RoutedEventArgs e)
        {

        }
    }
}
