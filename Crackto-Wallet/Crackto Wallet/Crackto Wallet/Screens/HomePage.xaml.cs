using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
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
using WinRTXamlToolkit.Controls.DataVisualization.Charting;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Crackto_Wallet
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        List<Crypto> lstSource = new List<Crypto>();
        APICaller aPICaller = new APICaller();
        private APICaller apiCaller;
        public MainPage()
        {
            this.InitializeComponent();
            this.apiCaller = new APICaller();
        }

        private void Navigation_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            string test = apiCaller.GetBalance();
            testBlock.Text = test;

            System.Timers.Timer aTimer = new System.Timers.Timer();
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            aTimer.Interval = 10000;
            aTimer.Enabled = true;
            LoadChartContents();
        }
        private void LoadChartContents()
        {
            lstSource.Add(new Crypto() { Name = DateTime.Now.ToString("hh:mm:ss"), Price = (aPICaller.GetCoinValue(CoinType.BTCBUSD)) });
            (LineChart.Series[0] as LineSeries).ItemsSource = lstSource;
        }

        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            lstSource.Add(new Crypto() { Name = DateTime.Now.ToString("hh:mm:ss"), Price = (aPICaller.GetCoinValue(CoinType.BTCBUSD)) });
            /*  ((LineSeries)LineChart.Series[0]).ItemsSource = null;
                *  ((LineSeries)LineChart.Series[0]).ItemsSource = lstSource;            
                *          
                *(LineChart.Series[0] as LineSeries).ItemsSource = lstSource;*/
        }

/*
        async Task Main()
        {
            await DoStuff();
        }
        async Task DoStuff()
        {
            await Task.Delay(1000);
            ((LineSeries)LineChart.Series[0]).ItemsSource = null;
            ((LineSeries)LineChart.Series[0]).ItemsSource = lstSource;
            throw new Exception();
        }*/
    }
}
