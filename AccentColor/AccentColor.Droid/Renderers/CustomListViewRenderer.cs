using AccentColor.Droid.Renderers;
using Android.Content;
using Android.Graphics;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Color = Android.Graphics.Color;

[assembly: ExportRenderer(typeof(ListView), typeof(CustomListViewRenderer))]
namespace AccentColor.Droid.Renderers
{
    public class CustomListViewRenderer : ListViewRenderer
    {
        protected override void OnAttachedToWindow()
        {
            var androidGlow = Context.Resources.GetColor(Resource.Color.accent);
            BrandGlowEffect(Context, androidGlow);
            base.OnAttachedToWindow();
        }

        private static void BrandGlowEffect(Context context, Color brandColor)
        {
            try
            {
                //http://evendanan.net/android/branding/2013/12/09/branding-edge-effect/
                //glow
                int glowDrawableId = context.Resources.GetIdentifier("overscroll_glow", "drawable", "android");
                var androidGlow = context.Resources.GetDrawable(glowDrawableId);
                androidGlow.SetColorFilter(brandColor, PorterDuff.Mode.SrcIn);

                //edge
                int edgeDrawableId = context.Resources.GetIdentifier("overscroll_edge", "drawable", "android");
                var androidEdge = context.Resources.GetDrawable(edgeDrawableId);
                androidEdge.SetColorFilter(brandColor, PorterDuff.Mode.SrcIn);
            }
            catch
            {
                //Can't change list view brand color
            }
        }
    }
}