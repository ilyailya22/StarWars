using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Presenters.Attributes;
using MvvmCross.Platforms.Ios.Views;
using StarWars.Core.ViewModels.Character;
using StarWars.iOS.Extensions;

namespace StarWars.iOS.Views.Tables;

[MvxModalPresentation(WrapInNavigationController = false)]
public class CharacterDetailViewController : MvxViewController<CharacterDetailViewModel>
{
    private UILabel _labelValueName;
    private UILabel _labelValueHeight;
    private UILabel _labelValueMass;
    private UILabel _labelValueHairColor;
    private UILabel _labelValueSkinColor;
    private UILabel _labelValueEyeColor;
    private UILabel _labelValueBirthYear;
    private UILabel _labelValueGender;
    private UILabel _labelValueHomeworld;
    private UILabel _labelValueCreated;
    private UILabel _labelValueEdited;
    
    private UIButton _boBackButton;

    public override void ViewDidLoad()
    {
        base.ViewDidLoad();

        View!.BackgroundColor = UIColor.Black;

        var mainStack = new UIStackView
        {
            Axis = UILayoutConstraintAxis.Vertical,
            Alignment = UIStackViewAlignment.Fill,
            Distribution = UIStackViewDistribution.EqualSpacing,
            Spacing = 12,
            TranslatesAutoresizingMaskIntoConstraints = false
        };

        mainStack.AddArrangedSubview(CreateLabeledField("Name:", out _labelValueName));
        mainStack.AddArrangedSubview(CreateLabeledField("Height:", out _labelValueHeight));
        mainStack.AddArrangedSubview(CreateLabeledField("Mass:", out _labelValueMass));
        mainStack.AddArrangedSubview(CreateLabeledField("HairColor:", out _labelValueHairColor));
        mainStack.AddArrangedSubview(CreateLabeledField("HairColor:", out _labelValueSkinColor));
        mainStack.AddArrangedSubview(CreateLabeledField("SkinColor:", out _labelValueEyeColor));
        mainStack.AddArrangedSubview(CreateLabeledField("BirthYear:", out _labelValueBirthYear));
        mainStack.AddArrangedSubview(CreateLabeledField("Gender:", out _labelValueGender));
        mainStack.AddArrangedSubview(CreateLabeledField("Homeworld:", out _labelValueHomeworld));
        mainStack.AddArrangedSubview(CreateLabeledField("Created:", out _labelValueCreated));
        mainStack.AddArrangedSubview(CreateLabeledField("Edited:", out _labelValueEdited));

        _boBackButton = new UIButton(UIButtonType.System);
        _boBackButton.SetTitle("Back", UIControlState.Normal);
        _boBackButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
        _boBackButton.BackgroundColor = UIColor.FromRGB(255, 215, 0);
        _boBackButton.Layer.CornerRadius = 5;
        _boBackButton.TranslatesAutoresizingMaskIntoConstraints = false;

        View.AddSubviews(mainStack, _boBackButton);

        mainStack
            .TopToTopSafeAreaOf(View, 20)
            .StartToStartOf(View, 16)
            .EndToEndOf(View, 16);
        
        _boBackButton
            .TopToBottomOf(mainStack, 24)
            .StartToStartOf(View, 32)
            .EndToEndOf(View, 32)
            .HeightTo(44);
        
        var bindingSet = this.CreateBindingSet<CharacterDetailViewController, CharacterDetailViewModel>();

        bindingSet.Bind(_labelValueName)
            .To(vm => vm.Character.Name);

        bindingSet.Bind(_labelValueHeight)
            .To(vm => vm.Character.Height);

        bindingSet.Bind(_labelValueMass)
            .To(vm => vm.Character.Mass);

        bindingSet.Bind(_labelValueHairColor)
            .To(vm => vm.Character.HairColor);

        bindingSet.Bind(_labelValueSkinColor)
            .To(vm => vm.Character.SkinColor);

        bindingSet.Bind(_labelValueEyeColor)
            .To(vm => vm.Character.EyeColor);

        bindingSet.Bind(_labelValueBirthYear)
            .To(vm => vm.Character.BirthYear);

        bindingSet.Bind(_labelValueGender)
            .To(vm => vm.Character.Gender);

        bindingSet.Bind(_labelValueHomeworld)
            .To(vm => vm.Character.Homeworld.Name);
        
        _labelValueHomeworld.UserInteractionEnabled = true;
        var tapGesture = new UITapGestureRecognizer(async () =>
        {
            var planet = ViewModel?.Character?.Homeworld;
            if (planet != null && ViewModel.SelectPlanetCommand.CanExecute(planet))
            {
                await ViewModel.SelectPlanetCommand.ExecuteAsync(planet);
            }
        });
        _labelValueHomeworld.AddGestureRecognizer(tapGesture);
        
        bindingSet.Bind(_labelValueCreated)
            .To(vm => vm.Character.Created);

        bindingSet.Bind(_labelValueEdited)
            .To(vm => vm.Character.Edited);

        bindingSet.Bind(_boBackButton)
            .To(vm => vm.GoBackCommand);

        bindingSet.Apply();
    }

    private UIStackView CreateLabeledField(string title, out UILabel valueLabel)
    {
        var titleLabel = new UILabel
        {
            Text = title,
            Font = UIFont.BoldSystemFontOfSize(18),
            TextColor = UIColor.White,
            TranslatesAutoresizingMaskIntoConstraints = false,
        };

        valueLabel = new UILabel
        {
            Font = UIFont.SystemFontOfSize(18),
            TextColor = UIColor.FromRGB(255, 232, 31),
            Lines = 0,
            LineBreakMode = UILineBreakMode.WordWrap,
            TranslatesAutoresizingMaskIntoConstraints = false
        };

        return new UIStackView([titleLabel, valueLabel])
        {
            Axis = UILayoutConstraintAxis.Horizontal,
            Alignment = UIStackViewAlignment.Center,
            Spacing = 8,
            TranslatesAutoresizingMaskIntoConstraints = false
        };
    }
}