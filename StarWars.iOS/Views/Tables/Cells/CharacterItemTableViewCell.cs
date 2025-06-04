using MvvmCross.Binding.BindingContext;
using StarWars.Core.ViewModels.Character;
using StarWars.iOS.Extensions;
using StarWars.iOS.Views.Tables.Cells.Base;

namespace StarWars.iOS.Views.Tables.Cells;

public class CharacterItemTableViewCell(IntPtr handle) : BaseTableViewCell<CharacterItemViewModel>(handle)
{
    private UILabel _characterContainerLabel;
    public static readonly NSString Key = new(nameof(CharacterItemTableViewCell));

    protected override void InitComponents()
    {
        base.InitComponents();
        
        ContentView.BackgroundColor = UIColor.Black;

        _characterContainerLabel = new UILabel
        {
            BackgroundColor = UIColor.Black,
            Font = UIFont.SystemFontOfSize(24),
            TextColor = UIColor.FromRGB(255, 232, 31),
            TranslatesAutoresizingMaskIntoConstraints = false
        };

        ContentView.AddSubview(_characterContainerLabel);

        _characterContainerLabel
            .StartToStartOf(ContentView, 16)
            .EndToEndOf(ContentView, 16)
            .CenterToCenterVerticalOf(ContentView);
    }

    protected override void ApplyBindings(MvxFluentBindingDescriptionSet<BaseTableViewCell<CharacterItemViewModel>, CharacterItemViewModel> set)
    {
        base.ApplyBindings(set);

        set.Bind(_characterContainerLabel)
            .For(v => v.Text)
            .To(vm => vm.Name);
    }
}