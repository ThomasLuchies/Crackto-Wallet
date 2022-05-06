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
using Crackto_Wallet.FileManager;
using Newtonsoft.Json;
using Windows.UI.Popups;
using Nancy.Json;
using System.Diagnostics;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Crackto_Wallet.Screens
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LoginPage : Page
    {
        public LoginPage()
        {
            this.InitializeComponent();
        }

        private void TextBlock_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            String APIKEY = apikey.Text;
            String SECRETKEY = secretkey.Text;

            Keys keys = new Keys
            {
                apikey = APIKEY,
                secretkey = SECRETKEY,
            };

            JavaScriptSerializer serializer = new JavaScriptSerializer();
            string json = serializer.Serialize(keys);
            FileManagerJSON fileManager = new FileManagerJSON();
          
            // Create sample file; replace if exists.
            Windows.Storage.StorageFolder storageFolder =
                Windows.Storage.ApplicationData.Current.LocalFolder;
            Windows.Storage.StorageFile sampleFile =
                 await storageFolder.CreateFileAsync("apikeys.json", Windows.Storage.CreationCollisionOption.ReplaceExisting);
            await Windows.Storage.FileIO.WriteTextAsync(sampleFile, json);

            string text = await Windows.Storage.FileIO.ReadTextAsync(sampleFile);

            Debug.WriteLine(text);

            this.Frame.Navigate(typeof(MainPage));
        }
        public class Keys
        {
            public string apikey;
            public string secretkey;
        }
    }
}
