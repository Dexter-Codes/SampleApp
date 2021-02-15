using Android.App;
using Android.OS;
using Sample.Core.ViewModels;
using MvvmCross.Platforms.Android.Views;
using MvvmCross.Binding.BindingContext;
using Android.Widget;

namespace SampleApp.Droid.Views
{
    [Activity(Label = "FirstViewModel", Theme = "@style/AppTheme")]
    public class FirstView : MvxActivity<FirstViewModel>
    {
        Button btn1;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.FirstView);

           // InitView();
          //  SetViewBinding();
        }
        void InitView()
        {
            //btn1 = FindViewById<Button>(Resource.Id.btn1);
        }
        void SetViewBinding()
        {
            var set = this.CreateBindingSet<FirstView, FirstViewModel>();
            set.Bind(btn1).To(x => x.ClickCommand);
            set.Bind(btn1).For(l => l.Text).To(vm => vm.RegisterBtnTitle);
        }

    }
}
