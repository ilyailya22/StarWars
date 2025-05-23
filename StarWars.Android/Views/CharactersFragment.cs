using _Microsoft.Android.Resource.Designer;
using Android.Views;
using MvvmCross.DroidX.RecyclerView;
using MvvmCross.Platforms.Android.Presenters.Attributes;
using MvvmCross.Platforms.Android.Views.Fragments;
using StarWars.Core.ViewModels;

namespace StarWars.Android.Views;

[MvxFragmentPresentation(ActivityHostViewModelType = typeof(MainViewModel), FragmentContentId = ResourceConstant.Id.content_frame, AddToBackStack = true)]
public sealed class CharactersFragment : MvxFragment<CharactersViewModel>
{
    public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
    {
        var view = inflater.Inflate(ResourceConstant.Layout.characters_fragment, container, false);

        var charactersList = view?.FindViewById<MvxRecyclerView>(ResourceConstant.Id.charactersList);
        charactersList?.AddItemDecoration(new SpacingItemDecoration(16));

        return view;
    }
}