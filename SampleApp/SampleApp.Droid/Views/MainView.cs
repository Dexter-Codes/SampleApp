using System;
using Android.Views;
using Acr.UserDialogs;
using Android.Views.InputMethods;
using AndroidX.Core.View;
using AndroidX.DrawerLayout.Widget;
using MvvmCross.Platforms.Android.Views;
using Sample.Core.ViewModels;
using MvvmCross.Platforms.Android.Presenters.Attributes;
using Android.App;
using Android.Content.PM;

namespace SampleApp.Droid.Views
{
    [MvxActivityPresentation]
    [Activity(Label = "View for FirstViewModel",
        LaunchMode = LaunchMode.SingleTop,
         Name = "SampleApp.Droid.Views.MainView",
        Theme = "@style/AppTheme")]
    public class MainView: MvxActivity<MainViewModel>
    {
        public DrawerLayout DrawerLayout { get; set; }

        protected override void OnCreate(Android.OS.Bundle bundle)
        {
            base.OnCreate(bundle);

            UserDialogs.Init(this);

            SetContentView(Resource.Layout.MainView);

            DrawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);

            if (bundle == null)
            {
                ViewModel.ShowPeopleViewModelCommand.Execute(null);
                ViewModel.ShowMenuViewModelCommand.Execute(null);
            }
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    DrawerLayout.OpenDrawer(GravityCompat.Start);
                    return true;
            }
            return base.OnOptionsItemSelected(item);
        }

        public override void OnBackPressed()
        {
            if (DrawerLayout != null && DrawerLayout.IsDrawerOpen(GravityCompat.Start))
                DrawerLayout.CloseDrawers();
            else
                base.OnBackPressed();
        }

        public void HideSoftKeyboard()
        {
            if (CurrentFocus == null)
                return;

            InputMethodManager inputMethodManager = (InputMethodManager)GetSystemService(InputMethodService);
            inputMethodManager.HideSoftInputFromWindow(CurrentFocus.WindowToken, 0);

            CurrentFocus.ClearFocus();
        }
    }
}
