﻿using System;
using System.Threading.Tasks;
using Android.OS;
using Android.Runtime;
using Android.Views;
using AndroidX.VectorDrawable.Graphics.Drawable;
using Google.Android.Material.Navigation;
using MvvmCross.Platforms.Android.Binding.BindingContext;
using MvvmCross.Platforms.Android.Presenters.Attributes;
using MvvmCross.Platforms.Android.Views.Fragments;
using Sample.Core.ViewModels;

namespace SampleApp.Droid.Views
{
    [MvxFragmentPresentation(typeof(MainViewModel), Resource.Id.navigation_frame)]
    [Register("SampleApp.Droid.Views.MenuView")]
    public class MenuFragment : MvxFragment<MenuViewModel>, NavigationView.IOnNavigationItemSelectedListener
    {
        private NavigationView _navigationView;
        private IMenuItem _previousMenuItem;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var ignore = base.OnCreateView(inflater, container, savedInstanceState);

            var view = this.BindingInflate(Resource.Layout.MenuView, null);

            _navigationView = view.FindViewById<NavigationView>(Resource.Id.navigation_view);
            _navigationView.SetNavigationItemSelectedListener(this);
            _navigationView.Menu.FindItem(Resource.Id.nav_people).SetChecked(true);

            //var iconPlanets = _navigationView.Menu.FindItem(Resource.Id.nav_planets);
            //iconPlanets.SetTitle(Strings.TargetPlanets);
            //iconPlanets.SetCheckable(false);
            //iconPlanets.SetChecked(true);
            //var imgPlanet = VectorDrawableCompat.Create(Resources, Resource.Drawable.planet, Activity.Theme);
            //iconPlanets.SetIcon(imgPlanet);

           // _previousMenuItem = iconPlanets;

            var iconPeople = _navigationView.Menu.FindItem(Resource.Id.nav_people);
            iconPeople.SetTitle("TargetPeople");
            iconPeople.SetCheckable(false);
            var imgPeople = VectorDrawableCompat.Create(Resources, Resource.Drawable.people, Activity.Theme);
            iconPeople.SetIcon(imgPeople);

            //var iconStatistics = _navigationView.Menu.FindItem(Resource.Id.nav_statistics);
            //iconStatistics.SetTitle(Strings.Statistics);
            //iconStatistics.SetCheckable(false);
            //var imgStatistics = VectorDrawableCompat.Create(Resources, Resource.Drawable.statistics, Activity.Theme);
            //iconStatistics.SetIcon(imgStatistics);

            return view;
        }

        public bool OnNavigationItemSelected(IMenuItem item)
        {
            if (_previousMenuItem != null)
                _previousMenuItem.SetChecked(false);

            item.SetCheckable(true);
            item.SetChecked(true);

            _previousMenuItem = item;

            Task.Run(() => Navigate(item.ItemId));

            return true;
        }

        private async Task Navigate(int itemId)
        {
            ((MainView)Activity).DrawerLayout.CloseDrawers();
            await Task.Delay(TimeSpan.FromMilliseconds(250));

            switch (itemId)
            {
               // case Resource.Id.nav_planets:
               //     ViewModel.ShowPlanetsCommand.Execute(null);
                 //   break;
                case Resource.Id.nav_people:
                    ViewModel.ShowPeopleCommand.Execute(null);
                    break;
             //   case Resource.Id.nav_statistics:
               //     ViewModel.ShowStatusCommand.Execute(null);
                 //   break;
            }
        }
    }
}
