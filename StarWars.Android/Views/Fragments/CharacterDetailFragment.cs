using _Microsoft.Android.Resource.Designer;
using Android.Views;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Android.Binding.BindingContext;
using MvvmCross.Platforms.Android.Presenters.Attributes;
using MvvmCross.Platforms.Android.Views.Fragments;
using StarWars.Core.ViewModels;
using StarWars.Core.ViewModels.Character;

namespace StarWars.Android.Views.Fragments;

[MvxFragmentPresentation(ActivityHostViewModelType = typeof(DetailViewModel), FragmentContentId = ResourceConstant.Id.content_frame_detail)]
public sealed class CharacterDetailFragment : MvxFragment<CharacterDetailViewModel>
{
    private TextView _textViewValueName;
    private TextView _textViewValueHeight;
    private TextView _textViewValueMass;
    private TextView _textViewValueHairColor;
    private TextView _textViewValueSkinColor;
    private TextView _textViewValueEyeColor;
    private TextView _textViewValueBirthYear;
    private TextView _textViewValueGender;
    private TextView _textViewValueHomeworld;
    private TextView _textViewValueCreated;
    private TextView _textViewValueEdited;
    
    private Button _buttonGoBackCommand;
    
    public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
    {
        base.OnCreateView(inflater, container, savedInstanceState);

        var view = this.BindingInflate(ResourceConstant.Layout.character_detail_fragment, container, false);
        
        _textViewValueName = view?.FindViewById<TextView>(ResourceConstant.Id.valueCharacterName);
        _textViewValueHeight = view?.FindViewById<TextView>(ResourceConstant.Id.valueCharacterHeight);
        _textViewValueMass = view?.FindViewById<TextView>(ResourceConstant.Id.valueCharacterMass);
        _textViewValueHairColor = view?.FindViewById<TextView>(ResourceConstant.Id.valueCharacterHairColor);
        _textViewValueSkinColor = view?.FindViewById<TextView>(ResourceConstant.Id.valueCharacterSkinColor);
        _textViewValueEyeColor = view?.FindViewById<TextView>(ResourceConstant.Id.valueCharacterEyeColor);
        _textViewValueBirthYear = view?.FindViewById<TextView>(ResourceConstant.Id.valueCharacterBirthYear);
        _textViewValueGender = view?.FindViewById<TextView>(ResourceConstant.Id.valueCharacterGender);
        _textViewValueHomeworld = view?.FindViewById<TextView>(ResourceConstant.Id.valueCharacterHomeworld);
        _textViewValueCreated = view?.FindViewById<TextView>(ResourceConstant.Id.valueCharacterCreated);
        _textViewValueEdited = view?.FindViewById<TextView>(ResourceConstant.Id.valueCharacterEdited);
        
        _buttonGoBackCommand = view?.FindViewById<Button>(ResourceConstant.Id.backButtonCharacter);

        return view;
    }

    public override void OnViewCreated(View view, Bundle savedInstanceState)
    {
        base.OnViewCreated(view, savedInstanceState);
        
        var bindingSet = this.CreateBindingSet<CharacterDetailFragment, CharacterDetailViewModel>();
        
        bindingSet.Bind(_textViewValueName)
            .For("Text")
            .To(vm => vm.Character.Name);
        
        bindingSet.Bind(_textViewValueHeight)
            .For("Text")
            .To(vm => vm.Character.Height);
        
        bindingSet.Bind(_textViewValueMass)
            .For("Text")
            .To(vm => vm.Character.Mass);
        
        bindingSet.Bind(_textViewValueHairColor)
            .For("Text")
            .To(vm => vm.Character.HairColor);
        
        bindingSet.Bind(_textViewValueSkinColor)
            .For("Text")
            .To(vm => vm.Character.SkinColor);
        
        bindingSet.Bind(_textViewValueEyeColor)
            .For("Text")
            .To(vm => vm.Character.EyeColor);
        
        bindingSet.Bind(_textViewValueBirthYear)
            .For("Text")
            .To(vm => vm.Character.BirthYear);
        
        bindingSet.Bind(_textViewValueGender)
            .For("Text")
            .To(vm => vm.Character.Gender);
        
        bindingSet.Bind(_textViewValueHomeworld)
            .For("Text")
            .To(vm => vm.Character.Homeworld.Name);
        
        _textViewValueHomeworld.Click += async (sender, args) =>
        {
            var planet = ViewModel?.Character?.Homeworld;
            if (planet != null && ViewModel.SelectPlanetCommand.CanExecute(planet))
            {
                await ViewModel.SelectPlanetCommand.ExecuteAsync(planet);
            }
        };
        
        bindingSet.Bind(_textViewValueCreated)
            .For("Text")
            .To(vm => vm.Character.Created);
        
        bindingSet.Bind(_textViewValueEdited)
            .For("Text")
            .To(vm => vm.Character.Edited);
        
        bindingSet.Bind(_buttonGoBackCommand)
            .For("Click")
            .To(vm => vm.GoBackCommand);
        
        bindingSet.Apply();
    }
}