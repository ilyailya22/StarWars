using MvvmCross.Binding.BindingContext;
using StarWars.Core.ViewModels.Character;
using StarWars.Core.ViewModels.Planet;
using StarWars.iOS.Views.Tables.Cells.Base;

namespace StarWars.iOS.Views.Tables.Cells;

public class PlanetItemTableViewCell(IntPtr handle) : BaseTableViewCell<PlanetItemViewModel>(handle)
{
    private UILabel _planetContainerLabel;
    public static readonly NSString Key = new(nameof(PlanetItemTableViewCell));

    protected override void InitComponents()
    {
        base.InitComponents();

        _planetContainerLabel = new UILabel
        {
            TranslatesAutoresizingMaskIntoConstraints = false
        };

        ContentView.AddSubview(_planetContainerLabel);

        NSLayoutConstraint.ActivateConstraints([
            _planetContainerLabel.LeadingAnchor.ConstraintEqualTo(ContentView.LeadingAnchor, 16),
            _planetContainerLabel.TrailingAnchor.ConstraintEqualTo(ContentView.TrailingAnchor, -16),
            _planetContainerLabel.CenterYAnchor.ConstraintEqualTo(ContentView.CenterYAnchor)
        ]);
    }

    protected override void ApplyBindings(MvxFluentBindingDescriptionSet<BaseTableViewCell<PlanetItemViewModel>, PlanetItemViewModel> set)
    {
        base.ApplyBindings(set);

        set.Bind(_planetContainerLabel)
            .For(v => v.Text)
            .To(vm => vm.Name);
    }
}