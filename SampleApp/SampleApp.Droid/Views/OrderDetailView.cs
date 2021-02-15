using System;
using Android.App;
using Android.OS;
using MvvmCross.Platforms.Android.Views;
using Sample.Core.ViewModels;

namespace SampleApp.Droid.Views
{
    [Activity(Label = "FirstViewModel", Theme = "@style/AppTheme")]
    public class OrderDetailView : MvxActivity<OrderDetailViewModel>
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.OrderDetail);
        }
    }
}
