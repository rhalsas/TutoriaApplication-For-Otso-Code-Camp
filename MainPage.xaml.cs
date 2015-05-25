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

using System.Diagnostics;
using System.Runtime.Serialization.Json;

using System.Net.Http;
// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace TutorialApplication
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            this.Rest_Test();

            this.FunnyEvent += this.FunnyMessage1;
            this.FunnyEvent += this.FunnyMessage2;

            this.FunnyEvent -= this.FunnyMessage1;

            this.FunnyEvent("C#");

        }

        public delegate void FunnyEventHandler(string _string);

        public event FunnyEventHandler FunnyEvent;

        public void FunnyMessage1(string _string)
        {
            Debug.WriteLine(_string + "Funny again.");
        }
        public void FunnyMessage2(string _string)
        {
            Debug.WriteLine(_string + "It's interesting.");
        }

        public class AnotherObject{

            public String one;
            public String key;
        }

        async public void Rest_Test()
        {

            HttpClient client = new HttpClient();

            string url = "http://echo.jsontest.com/key/value/one/two";

            HttpResponseMessage response = await client.GetAsync(url);

            var str = await response.Content.ReadAsStreamAsync();

            DataContractJsonSerializer deSer = new DataContractJsonSerializer(typeof(AnotherObject));

            AnotherObject obj = (AnotherObject)deSer.ReadObject(str);

            Debug.WriteLine(obj.one + " Almost done: "  + obj.key);


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("This is fun.");


            TextBox box = (TextBox)this.FindName("FunnyBox");

            DataObject obj = new DataObject(box.Text, "Halsas");

            this.Frame.Navigate(typeof(TestPage), obj);
        }
    }
}
