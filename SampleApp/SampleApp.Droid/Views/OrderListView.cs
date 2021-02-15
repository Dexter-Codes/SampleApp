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
using static AndroidX.RecyclerView.Widget.RecyclerView;

namespace SampleApp.Droid.Views
{
    [Activity(Label = "FirstViewModel", Theme = "@style/AppTheme")]
    public class OrderListView:MvxActivity<OrderListViewModel>
    {
        //MvxRecyclerView recyclerView1;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.OrderList);

            var recyclerView1 = FindViewById<MvxRecyclerView>(Resource.Id.recyclerView1);
            recyclerView1.ItemTemplateId = Resource.Layout.ListItem_View;

            //  Create the Adapter and add it to RecyclerView
            var _adapter = new ClientViewAdapter((IMvxAndroidBindingContext)BindingContext);
              recyclerView1.SetLayoutManager(new LinearLayoutManager(this));
            recyclerView1.Adapter = _adapter;



       //     var set = this.CreateBindingSet<OrderListView, OrderListViewModel>();
      //      set.Bind(recyclerView1).To(x => x.ClickCommand);
      //      set.Bind(recyclerView1.Adapter).For(x => x.ItemsSource).To(x => x.OnListClient);
       //     set.Apply();
        }
        
        
    }
    public class ClientViewAdapter : MvxRecyclerAdapter
    {
        private readonly AssetManager _assetManager;
        private readonly MvxViewModel _mvxViewModel;
        public ClientViewAdapter(IMvxAndroidBindingContext bindingContext)
            : base(bindingContext)
        {
            //_assetManager = assetManager;
        }

        public override ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var itemBindingContext = new MvxAndroidBindingContext(parent.Context, BindingContext.LayoutInflaterHolder);
            var view = InflateViewForHolder(parent, viewType, itemBindingContext);

            var peopleOnBoardHolder = new ClientViewHolder(view, itemBindingContext);
            return peopleOnBoardHolder;
        }
    }
    public class ClientViewHolder : MvxRecyclerViewHolder
    {
        private readonly TextView _tvClientNum;
        private readonly TextView _tvStatus;
        private readonly TextView _tvClientName;
        private readonly TextView _tvDate;
        private readonly TextView _tvPropertyId;
        private readonly TextView _tvPropertyNum;


        public ClientViewHolder(Android.Views.View itemView, IMvxAndroidBindingContext context)
           : base(itemView, context)
        {
            _tvClientNum = itemView.FindViewById<TextView>(Resource.Id.text_clientnum);
            _tvStatus = itemView.FindViewById<TextView>(Resource.Id.text_status);
            _tvClientName = itemView.FindViewById<TextView>(Resource.Id.text_clientname);
            _tvDate = itemView.FindViewById<TextView>(Resource.Id.text_date);
            _tvPropertyId = itemView.FindViewById<TextView>(Resource.Id.text_propid);
            _tvPropertyNum = itemView.FindViewById<TextView>(Resource.Id.text_propnum);

            this.DelayBind(() =>
            {
                var set = this.CreateBindingSet<ClientViewHolder, ClientListModel>();
                set.Bind(_tvClientNum).To(x => x.ClientNumber);
                set.Bind(_tvStatus).To(x => x.Status);
                set.Bind(_tvClientName).To(x => x.ClientName);
                set.Bind(_tvDate).To(x => x.Date);
                set.Bind(_tvPropertyId).To(x => x.PropertyId);
                set.Bind(_tvPropertyNum).To(x => x.PropertyNumber);
                set.Apply();
            });
        }
    }
}
