using System.Linq;
using AccentColor.Services;
using Xamarin.Forms;

namespace AccentColor
{
    public class App : Application
    {
        public App()
        {
            var label = new Label
            {
                XAlign = TextAlignment.Center,
                Text = "Welcome to Xamarin Forms!"
            };

            var entry = new Entry();
            Grid.SetRow(entry, 1);

            var listView = new ListView
            {
                ItemsSource = Enumerable.Range(0, 100).Select(x => string.Format("Text {0}", x)).ToList()
            };
            Grid.SetRow(listView, 2);

            var button = new Button
            {
                Text = "Show alert"
            };
            button.Clicked += (sender, args) =>  DependencyService.Get<IDisplayAlertService>().ShowAlert("Branded alert", "This is a branded alert!", "OK");
            Grid.SetRow(button, 3);

            var page = new ContentPage
            {
                Content = new Grid
                {
                    VerticalOptions = LayoutOptions.Center,
                    RowDefinitions =
                    {
                        new RowDefinition {Height = GridLength.Auto},
                        new RowDefinition {Height = GridLength.Auto},
                        new RowDefinition {Height = new GridLength(1, GridUnitType.Star)},
                        new RowDefinition {Height = GridLength.Auto}
                    },
                    Children =
                    {
                        label,
                        entry,
                        listView,
                        button
                    }
                }
            };

            // The root page of your application
            MainPage = new MasterDetailPage { Master = new ContentPage { Title = "Master" }, Detail = page };
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
