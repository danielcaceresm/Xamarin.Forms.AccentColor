using AccentColor.Droid.Service;
using AccentColor.Services;
using Android.App;
using Android.Content.Res;
using Android.Widget;
using Xamarin.Forms;

[assembly: Dependency(typeof(AndroidDisplayAlertService))]
namespace AccentColor.Droid.Service
{
    public class AndroidDisplayAlertService : IDisplayAlertService
    {
        public void ShowAlert(string title, string content, string buttonText)
        {
            var alert = new AlertDialog.Builder(Forms.Context);
            alert.SetTitle(title);
            alert.SetMessage(content);
            alert.SetNegativeButton(buttonText, (sender, e) => { });

            var dialog = alert.Show();
            BrandAlertDialog(dialog);
        }

        public static void BrandAlertDialog(AlertDialog dialog)
        {
            try
            {
                Resources resources = dialog.Context.Resources;
                var color = dialog.Context.Resources.GetColor(Resource.Color.accent);

                var alertTitleId = resources.GetIdentifier("alertTitle", "id", "android");
                var alertTitle = (TextView)dialog.Window.DecorView.FindViewById(alertTitleId);
                alertTitle.SetTextColor(color); // change title text color

                var titleDividerId = resources.GetIdentifier("titleDivider", "id", "android");
                var titleDivider = dialog.Window.DecorView.FindViewById(titleDividerId);
                titleDivider.SetBackgroundColor(color); // change divider color
            }
            catch
            {
                //Can't change dialog brand color
            }
        }
    }
}