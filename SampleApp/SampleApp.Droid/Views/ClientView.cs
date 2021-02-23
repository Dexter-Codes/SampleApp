using System;
using Android.App;
using Android.OS;
using Android.Widget;
using AndroidX.RecyclerView.Widget;
using MvvmCross.DroidX.RecyclerView;
using MvvmCross.Platforms.Android.Binding.BindingContext;
using MvvmCross.Platforms.Android.Views;
using SampleApp.Droid.Adapter;

namespace SampleApp.Droid.Views
{
    [Activity(Label = "FirstViewModel", Theme = "@style/AppMaterialTheme")]
    public class ClientView:MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.ClientView);

            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
    
            var recyclerView = FindViewById<MvxRecyclerView>(Resource.Id.recyclerView1);
            recyclerView.ItemTemplateId = Resource.Layout.Item_ClientList;
            //recyclerView.HasFixedSize = true;

            //  Create the Adapter and add it to RecyclerView
            var _adapter = new ClientListAdapter((IMvxAndroidBindingContext)BindingContext);
            recyclerView.SetLayoutManager(new LinearLayoutManager(this));
            recyclerView.Adapter = _adapter;
        }
    }
}
