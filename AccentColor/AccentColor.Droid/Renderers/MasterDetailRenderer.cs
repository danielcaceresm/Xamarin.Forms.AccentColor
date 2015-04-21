using AccentColor.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(MasterDetailPage), typeof(CustomMasterDetailRenderer))]
namespace AccentColor.Droid.Renderers
{
    public class CustomMasterDetailRenderer : MasterDetailRenderer
    {
        protected override void OnAttachedToWindow()
        {
            var androidGlow = Context.Resources.GetColor(Resource.Color.accent);
            SetScrimColor(androidGlow);
            base.OnAttachedToWindow();
        }
    }
}