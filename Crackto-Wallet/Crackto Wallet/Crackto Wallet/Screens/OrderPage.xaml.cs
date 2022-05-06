using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using WinRTXamlToolkit.Controls.DataVisualization.Charting;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Crackto_Wallet.Screens
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class OrderPage : Page
    {
        public OrderPage()
        {
            this.InitializeComponent();
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            LoadChartContents();
        }
        
        private void LoadChartContents()
        {
            List<Crypto> lstSource = new List<Crypto>();
            APICaller aPICaller = new APICaller();
            lstSource.Add(new Crypto() { Name = "BTCBUSD", Price = aPICaller.GetCoinValue(CoinType.BTCBUSD) });
            lstSource.Add(new Crypto() { Name = "BTCBUSD", Price=40000 });
            lstSource.Add(new Crypto() { Name = "BTCBUSD", Price = 30000 });
            Console.WriteLine(aPICaller.GetCoinValue(CoinType.BTCBUSD));
            (LineChart.Series[0] as LineSeries).ItemsSource = lstSource;
        }
    }
}
