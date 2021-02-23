using System;
using Android.Widget;
using MvvmCross.Binding.BindingContext;
using MvvmCross.DroidX.RecyclerView;
using MvvmCross.Platforms.Android.Binding.BindingContext;
using Sample.Core.Models;

namespace SampleApp.Droid.Holder
{
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
