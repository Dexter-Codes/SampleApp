using System;
using Android.Content.Res;
using Android.Views;
using MvvmCross.DroidX.RecyclerView;
using MvvmCross.Platforms.Android.Binding.BindingContext;
using MvvmCross.ViewModels;
using SampleApp.Droid.Holder;
using static AndroidX.RecyclerView.Widget.RecyclerView;

namespace SampleApp.Droid.Adapter
{
    public class ClientListAdapter: MvxRecyclerAdapter
    {
        private readonly AssetManager _assetManager;
        private readonly MvxViewModel _mvxViewModel;
        public ClientListAdapter(IMvxAndroidBindingContext bindingContext)
            : base(bindingContext)
        {
            //_assetManager = assetManager;
        }

        public override ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var itemBindingContext = new MvxAndroidBindingContext(parent.Context, BindingContext.LayoutInflaterHolder);
            var view = InflateViewForHolder(parent, viewType, itemBindingContext);

            var peopleOnBoardHolder = new ClientListViewHolder(view, itemBindingContext);
            return peopleOnBoardHolder;
        }
    }
}
