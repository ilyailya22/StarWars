using MvvmCross.Binding.BindingContext;
using StarWars.Core.ViewModels.Character;
using StarWars.Core.ViewModels.Planet;
using StarWars.iOS.Views.Tables.Cells.Base;

namespace StarWars.iOS.Views.Tables.Cells;

public class PlanetItemTableViewCell : BaseTableViewCell<PlanetItemViewModel>
{
    private UILabel _preferredContainerLabel;
    public static readonly NSString Key = new NSString(nameof(PlanetItemTableViewCell));

    public PlanetItemTableViewCell(IntPtr handle) : base(handle)
    {
    }

    protected override void InitComponents()
    {
        base.InitComponents();

        _preferredContainerLabel = new UILabel
        {
            TranslatesAutoresizingMaskIntoConstraints = false
        };

        ContentView.AddSubview(_preferredContainerLabel);

        NSLayoutConstraint.ActivateConstraints(new[]
        {
            _preferredContainerLabel.LeadingAnchor.ConstraintEqualTo(ContentView.LeadingAnchor, 16),
            _preferredContainerLabel.TrailingAnchor.ConstraintEqualTo(ContentView.TrailingAnchor, -16),
            _preferredContainerLabel.CenterYAnchor.ConstraintEqualTo(ContentView.CenterYAnchor)
        });
    }

    protected override void ApplyBindings(MvxFluentBindingDescriptionSet<BaseTableViewCell<PlanetItemViewModel>, PlanetItemViewModel> set)
    {
        base.ApplyBindings(set);

        set.Bind(_preferredContainerLabel)
            .For(v => v.Text)
            .To(vm => vm.Name);
    }
}