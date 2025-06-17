using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Presenters.Attributes;
using MvvmCross.Platforms.Ios.Views;
using StarWars.Core.ViewModels.Planet;
using StarWars.iOS.Extensions;

namespace StarWars.iOS.Views.Tables;

[MvxModalPresentation(WrapInNavigationController = false)]
public class PlanetDetailViewController : MvxViewController<PlanetDetailViewModel>
{
    private UILabel _labelValueName;
    private UILabel _labelValueRotationPeriod;
    private UILabel _labelValueOrbitalPeriod;
    private UILabel _labelValueDiameter;
    private UILabel _labelValueClimate;
    private UILabel _labelValueGravity;
    private UILabel _labelValueTerrain;
    private UILabel _labelValueSurfaceWater;
    private UILabel _labelValuePopulation;
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
        mainStack.AddArrangedSubview(CreateLabeledField("Rotation Period:", out _labelValueRotationPeriod));
        mainStack.AddArrangedSubview(CreateLabeledField("Orbital Period:", out _labelValueOrbitalPeriod));
        mainStack.AddArrangedSubview(CreateLabeledField("Diameter:", out _labelValueDiameter));
        mainStack.AddArrangedSubview(CreateLabeledField("Climate:", out _labelValueClimate));
        mainStack.AddArrangedSubview(CreateLabeledField("Gravity:", out _labelValueGravity));
        mainStack.AddArrangedSubview(CreateLabeledField("Terrain:", out _labelValueTerrain));
        mainStack.AddArrangedSubview(CreateLabeledField("Surface Water:", out _labelValueSurfaceWater));
        mainStack.AddArrangedSubview(CreateLabeledField("Population:", out _labelValuePopulation));
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
        
        var bindingSet = this.CreateBindingSet<PlanetDetailViewController, PlanetDetailViewModel>();

        bindingSet.Bind(_labelValueName)
            .To(vm => vm.Planet.Name);

        bindingSet.Bind(_labelValueRotationPeriod)
            .To(vm => vm.Planet.RotationPeriod);

        bindingSet.Bind(_labelValueOrbitalPeriod)
            .To(vm => vm.Planet.OrbitalPeriod);

        bindingSet.Bind(_labelValueDiameter)
            .To(vm => vm.Planet.Diameter);

        bindingSet.Bind(_labelValueClimate)
            .To(vm => vm.Planet.Climate);

        bindingSet.Bind(_labelValueGravity)
            .To(vm => vm.Planet.Gravity);

        bindingSet.Bind(_labelValueTerrain)
            .To(vm => vm.Planet.Terrain);

        bindingSet.Bind(_labelValueSurfaceWater)
            .To(vm => vm.Planet.SurfaceWater);

        bindingSet.Bind(_labelValuePopulation)
            .To(vm => vm.Planet.Population);

        bindingSet.Bind(_labelValueCreated)
            .To(vm => vm.Planet.Created);

        bindingSet.Bind(_labelValueEdited)
            .To(vm => vm.Planet.Edited);

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