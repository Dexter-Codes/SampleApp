﻿using System;
using Android.App;
using Android.OS;
using Android.Widget;
using MvvmCross.Platforms.Android.Views;
using Sample.Core.ViewModels;

namespace SampleApp.Droid.Views
{
    [Activity(Label = "FirstViewModel", Theme = "@style/AppMaterialTheme")]
    public class OrderDetailView : MvxActivity<OrderDetailViewModel>
    {
        //ImageView imageView;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.OrderDetail);
        }
       
    }
}
