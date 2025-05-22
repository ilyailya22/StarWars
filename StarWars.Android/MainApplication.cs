using Android.Runtime;
using MvvmCross.Platforms.Android.Views;
using StarWars.Core;

namespace StarWars.Android;

[Application]
public class MainApplication : MvxAndroidApplication<Setup, App>
{
    public MainApplication(IntPtr handle, JniHandleOwnership transfer) : base(handle, transfer)
    {
    }
}