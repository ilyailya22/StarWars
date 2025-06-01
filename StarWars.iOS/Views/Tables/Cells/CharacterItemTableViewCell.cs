using MvvmCross.Binding.BindingContext;
using StarWars.Core.ViewModels.Character;
using StarWars.iOS.Views.Tables.Cells.Base;

namespace StarWars.iOS.Views.Tables.Cells;

public class CharacterItemTableViewCell(IntPtr handle) : BaseTableViewCell<CharacterItemViewModel>(handle)
{
    private UILabel _characterContainerLabel;
    public static readonly NSString Key = new(nameof(CharacterItemTableViewCell));

    protected override void InitComponents()
    {
        base.InitComponents();

        _characterContainerLabel = new UILabel
        {
            TranslatesAutoresizingMaskIntoConstraints = false
        };

        ContentView.AddSubview(_characterContainerLabel);

        NSLayoutConstraint.ActivateConstraints([
            _characterContainerLabel.LeadingAnchor.ConstraintEqualTo(ContentView.LeadingAnchor, 16),
            _characterContainerLabel.TrailingAnchor.ConstraintEqualTo(ContentView.TrailingAnchor, -16),
            _characterContainerLabel.CenterYAnchor.ConstraintEqualTo(ContentView.CenterYAnchor)
        ]);
    }

    protected override void ApplyBindings(MvxFluentBindingDescriptionSet<BaseTableViewCell<CharacterItemViewModel>, CharacterItemViewModel> set)
    {
        base.ApplyBindings(set);

        set.Bind(_characterContainerLabel)
            .For(v => v.Text)
            .To(vm => vm.Name);
    }
}