using System;
using Android.App;
using Android.Runtime;
using MvvmCross.Platforms.Android.Views;
using MvvmCross.Platforms.Android.Core;
using Sample.Core;

namespace SampleApp.Droid
{
    [Application]
    public class MainApplication : MvxAndroidApplication<MvxAndroidSetup<App>, App>
    {
        public MainApplication(IntPtr javaReference, JniHandleOwnership transfer)
            : base(javaReference, transfer)
        {
        }
    }
}
