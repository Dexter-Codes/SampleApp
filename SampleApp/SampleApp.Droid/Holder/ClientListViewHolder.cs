using System;
using Android.Widget;
using MvvmCross.Binding.BindingContext;
using MvvmCross.DroidX.RecyclerView;
using MvvmCross.Platforms.Android.Binding.BindingContext;
using Sample.Core.Models;
using Sample.Core.ViewModels;

namespace SampleApp.Droid.Holder
{
    public class ClientListViewHolder: MvxRecyclerViewHolder
    {
        private readonly TextView _tvClientName;
        private readonly TextView _tvClientNum;

        public ClientListViewHolder(Android.Views.View itemView, IMvxAndroidBindingContext context)
            : base(itemView, context)
        {
            _tvClientNum = itemView.FindViewById<TextView>(Resource.Id.text_clientnum);
            _tvClientName = itemView.FindViewById<TextView>(Resource.Id.text_clientname);
            

            this.DelayBind(() =>
            {
                var set = this.CreateBindingSet<ClientListViewHolder, ClientListModel>();
                set.Bind(_tvClientNum).To(x => x.ClientNumber);
                set.Bind(_tvClientName).To(x => x.ClientName);
                set.Apply();
            });
        }
    }
}
