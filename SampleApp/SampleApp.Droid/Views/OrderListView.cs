using System;
using Android.App;
using Android.Content.Res;
using Android.OS;
using Android.Views;
using Android.Widget;
using AndroidX.RecyclerView.Widget;
using MvvmCross.Binding.BindingContext;
using MvvmCross.DroidX.RecyclerView;
using MvvmCross.Platforms.Android.Binding.BindingContext;
using MvvmCross.Platforms.Android.Views;
using MvvmCross.ViewModels;
using Sample.Core.Models;
using Sample.Core.ViewModels;
using SampleApp.Droid.Adapter;
using static AndroidX.RecyclerView.Widget.RecyclerView;

namespace SampleApp.Droid.Views
{
    [Activity(Label = "FirstViewModel", Theme = "@style/AppMaterialTheme")]
    public class OrderListView:MvxActivity<OrderListViewModel>
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.OrderList);

            var recyclerView1 = FindViewById<MvxRecyclerView>(Resource.Id.recyclerView1);
            recyclerView1.ItemTemplateId = Resource.Layout.ListItem_View;
            //recyclerView1.HasFixedSize = true;

            //  Create the Adapter and add it to RecyclerView
            var _adapter = new ClientViewAdapter((IMvxAndroidBindingContext)BindingContext);
            recyclerView1.SetLayoutManager(new LinearLayoutManager(this));
            recyclerView1.Adapter = _adapter;

        }
        
        
    }
    
}
