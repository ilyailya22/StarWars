using _Microsoft.Android.Resource.Designer;
using AndroidX.RecyclerView.Widget;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Android.Binding.BindingContext;
using MvvmCross.Platforms.Android.Presenters.Attributes;
using MvvmCross.Platforms.Android.Views.Fragments;
using StarWars.Android.Adapters;
using StarWars.Android.Views.Fragments.Base;
using StarWars.Core.ViewModels;
using StarWars.Core.ViewModels.Planet;

namespace StarWars.Android.Views.Fragments;

[MvxFragmentPresentation(ActivityHostViewModelType = typeof(MainViewModel), FragmentContentId = ResourceConstant.Id.content_frame)]
public sealed class PlanetsFragment : FragmentBase<PlanetsViewModel>
{
    protected override int GetLayoutId() => ResourceConstant.Layout.planets_fragment;
    protected override int GetRecyclerViewId() => ResourceConstant.Id.planetsList;

    protected override RecyclerView.Adapter CreateAdapter() =>
        new PlanetsAdapter((IMvxAndroidBindingContext)BindingContext);

    protected override void SetupBindings(MvxFluentBindingDescriptionSet<MvxFragment<PlanetsViewModel>, PlanetsViewModel> bindingSet)
    {
        bindingSet.Bind(RecyclerView)
            .For(v => v.ItemsSource)
            .To(vm => vm.PlanetItems);

        bindingSet.Bind(RecyclerView)
            .For(v => v.ItemClick)
            .To(vm => vm.SelectPlanetCommand);
    }
}