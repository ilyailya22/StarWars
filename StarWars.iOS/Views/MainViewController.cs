using MvvmCross.Platforms.Ios.Presenters.Attributes;
using MvvmCross.Platforms.Ios.Views;
using StarWars.Core.ViewModels;

namespace StarWars.iOS.Views;

[MvxRootPresentation(WrapInNavigationController = true)]
public class MainViewController : MvxViewController<MainViewModel>
{
    private UIButton _charactersButton;
    private UIButton _planetsButton;
    private UILabel _titleLabel;
    private UIView _contentContainer;
    private UIViewController _selectedViewController;

    public override void ViewDidLoad()
    {
        base.ViewDidLoad();

        View.BackgroundColor = UIColor.Black;

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

        // Layout constraints
        _titleLabel.TranslatesAutoresizingMaskIntoConstraints = false;
        _charactersButton.TranslatesAutoresizingMaskIntoConstraints = false;
        _planetsButton.TranslatesAutoresizingMaskIntoConstraints = false;
        _contentContainer.TranslatesAutoresizingMaskIntoConstraints = false;

        NSLayoutConstraint.ActivateConstraints(new[]
        {
            _titleLabel.TopAnchor.ConstraintEqualTo(View.SafeAreaLayoutGuide.TopAnchor, 32),
            _titleLabel.LeadingAnchor.ConstraintEqualTo(View.LeadingAnchor),
            _titleLabel.TrailingAnchor.ConstraintEqualTo(View.TrailingAnchor),
            _titleLabel.HeightAnchor.ConstraintEqualTo(40),

            _charactersButton.TopAnchor.ConstraintEqualTo(_titleLabel.BottomAnchor, 16),
            _charactersButton.LeadingAnchor.ConstraintEqualTo(View.LeadingAnchor, 16),
            _charactersButton.TrailingAnchor.ConstraintEqualTo(View.CenterXAnchor, -8),

            _planetsButton.TopAnchor.ConstraintEqualTo(_titleLabel.BottomAnchor, 16),
            _planetsButton.LeadingAnchor.ConstraintEqualTo(View.CenterXAnchor, 8),
            _planetsButton.TrailingAnchor.ConstraintEqualTo(View.TrailingAnchor, -16),

            _contentContainer.TopAnchor.ConstraintEqualTo(_charactersButton.BottomAnchor, 16),
            _contentContainer.LeadingAnchor.ConstraintEqualTo(View.LeadingAnchor),
            _contentContainer.TrailingAnchor.ConstraintEqualTo(View.TrailingAnchor),
            _contentContainer.BottomAnchor.ConstraintEqualTo(View.BottomAnchor)
        });

        _charactersButton.TouchUpInside += async (s, e) => await ViewModel.SelectCharactersViewCommand.ExecuteAsync();
        _planetsButton.TouchUpInside += async (s, e) => await ViewModel.SelectPlanetsViewCommand.ExecuteAsync();
    }
}