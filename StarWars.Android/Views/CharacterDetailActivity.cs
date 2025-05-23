using _Microsoft.Android.Resource.Designer;
using MvvmCross.Platforms.Android.Presenters.Attributes;
using MvvmCross.Platforms.Android.Views;
using StarWars.Core.ViewModels;

namespace StarWars.Android.Views;

[MvxActivityPresentation]
[Activity(Label = "@string/app_name_character_detail")]
public class CharacterDetailActivity : MvxActivity<CharacterDetailViewModel>
{
    protected override void OnCreate(Bundle? savedInstanceState)
    {
        base.OnCreate(savedInstanceState);

        // Set our view from the "main" layout resource
        SetContentView(ResourceConstant.Layout.activity_character_detail);
    }
}