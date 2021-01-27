using Android.App;
using Android.OS;
using Sample.Core.ViewModels;
using MvvmCross.Platforms.Android.Views;

namespace SampleApp.Droid.Views
{
    [Activity(Label = "FirstViewModel", Theme = "@style/AppTheme")]
    public class FirstView : MvxActivity<FirstViewModel>
    {

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.FirstView);
        }

    }
}
