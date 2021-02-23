using System;
using Android.App;
using Android.OS;
using MvvmCross.Platforms.Android.Views;
using Sample.Core.ViewModels;

namespace SampleApp.Droid.Views
{
    [Activity(Label = "LoginView", Theme = "@style/AppTheme")]
    public class LoginView:MvxActivity<LoginViewModel>
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Login);
        }
    }
}
