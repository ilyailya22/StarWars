using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Presenters.Attributes;
using MvvmCross.Platforms.Ios.Views;
using StarWars.Core.ViewModels;
using StarWars.iOS.Extensions;

namespace StarWars.iOS.Views;

[MvxRootPresentation(WrapInNavigationController = true)]
public class MainViewController : MvxViewController<MainViewModel>
{
    private UIButton _charactersButton;
    private UIButton _planetsButton;
    private UILabel _titleLabel;
    private UIView _contentContainer;

    public override void ViewDidLoad()
    {
        base.ViewDidLoad();

        View!.BackgroundColor = UIColor.Black;

        _titleLabel = new UILabel
        {
            Text = "Star Wars",
            Font =  UIFont.BoldSystemFontOfSize(32f),
            TextColor = UIColor.FromRGB(255, 232, 31),
            TextAlignment = UITextAlignment.Center
        };

        _charactersButton = new UIButton(UIButtonType.System);
        _charactersButton.SetTitle("Characters", UIControlState.Normal);
        _charactersButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
        _charactersButton.BackgroundColor = UIColor.FromRGB(255, 215, 0);
        _charactersButton.Layer.CornerRadius = 5;

        _planetsButton = new UIButton(UIButtonType.System);
        _planetsButton.SetTitle("Planets", UIControlState.Normal);
        _planetsButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
        _planetsButton.BackgroundColor = UIColor.FromRGB(255, 215, 0);
        _planetsButton.Layer.CornerRadius = 5;

        _contentContainer = new UIView
        {
            BackgroundColor = UIColor.Clear
        };

        View.AddSubviews(_titleLabel, _charactersButton, _planetsButton, _contentContainer);
        
        _titleLabel.TranslatesAutoresizingMaskIntoConstraints = false;
        _charactersButton.TranslatesAutoresizingMaskIntoConstraints = false;
        _planetsButton.TranslatesAutoresizingMaskIntoConstraints = false;
        _contentContainer.TranslatesAutoresizingMaskIntoConstraints = false;

        _titleLabel
            .TopToTopSafeAreaOf(View)
            .StartToStartOf(View)
            .EndToEndOf(View)
            .HeightTo(40);

        _charactersButton
            .TopToBottomOf(_titleLabel, 16)
            .StartToStartOf(View, 16)
            .EndToCenterOf(View, 8);

        _planetsButton
            .TopToBottomOf(_titleLabel, 16)
            .StartToCenterOf(View, 8)
            .EndToEndOf(View, 16);

        _contentContainer
            .TopToBottomOf(_charactersButton, 16)
            .StartToStartOf(View)
            .EndToEndOf(View)
            .BottomToBottomOf(View);

        var set = this.CreateBindingSet<MainViewController, MainViewModel>();

        set.Bind(_charactersButton).To(vm => vm.SelectCharactersViewCommand);
        set.Bind(_planetsButton).To(vm => vm.SelectPlanetsViewCommand);

        set.Apply();
    }
}