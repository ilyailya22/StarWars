using _Microsoft.Android.Resource.Designer;
using Android.Views;
using MvvmCross.Binding.BindingContext;
using MvvmCross.DroidX.RecyclerView;
using MvvmCross.Platforms.Android.Binding.BindingContext;
using MvvmCross.Platforms.Android.Presenters.Attributes;
using MvvmCross.Platforms.Android.Views.Fragments;
using StarWars.Android.Adapters;
using StarWars.Core.ViewModels;

namespace StarWars.Android.Views;

[MvxFragmentPresentation(ActivityHostViewModelType = typeof(MainViewModel), FragmentContentId = ResourceConstant.Id.content_frame)]
public sealed class CharactersFragment : MvxFragment<CharactersViewModel>
{
    private MvxRecyclerView _charactersList;
    public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
    {
        var ignored = base.OnCreateView(inflater, container, savedInstanceState);

        var view = this.BindingInflate(ResourceConstant.Layout.characters_fragment, container, false);
        
        _charactersList = view?.FindViewById<MvxRecyclerView>(ResourceConstant.Id.charactersList);
        _charactersList.Adapter = new CharactersAdapter((IMvxAndroidBindingContext)this.BindingContext);

        return view;
    }

    public override void OnViewCreated(View view, Bundle savedInstanceState)
    {
        base.OnViewCreated(view, savedInstanceState);
        
        var bindingSet = this.CreateBindingSet<CharactersFragment, CharactersViewModel>();
        bindingSet.Bind(_charactersList)
            .For(v => v.ItemsSource)
            .To(vm => vm.Characters);
        
        bindingSet.Bind(_charactersList)
            .For(v => v.ItemClick)
            .To(vm => vm.SelectCharacterCommand);
        
        bindingSet.Apply();
    }
}