using Acr.UserDialogs;
using MvvmCross;
using MvvmCross.IoC;
using MvvmCross.ViewModels;
using Sample.Core.Services;
//using MvvmCross.Platform.IoC;
using Sample.Core.ViewModels;
using System;
//using Sample.Core.ViewModels;
//using Sample.Core.ViewModels;

namespace Sample.Core
{
    public class App : MvxApplication
    {
        //[Obsolete]
        //public override void Initialize()
        //{
        //    //CreatableTypes()
        //    //    .EndingWith("Service")
        //    //    .AsInterfaces()
        //    //    .RegisterAsLazySingleton();
        //    Mvx.RegisterType<ICalculationService, CalculationService>();
        //    RegisterAppStart<FirstViewModel>();
        //   // RegisterNavigationServiceAppStart<ViewModels.FirstViewModel>();
        //}

        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            //CreatableTypes()
            //    .EndingWith("Client")
            //    .AsInterfaces()
            //    .RegisterAsLazySingleton();

            Mvx.IoCProvider.RegisterSingleton<IUserDialogs>(() => UserDialogs.Instance);

            // register the appstart object
            RegisterCustomAppStart<AppStart>();
        }

    }
}
