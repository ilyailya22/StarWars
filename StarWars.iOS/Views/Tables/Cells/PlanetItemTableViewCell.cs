using MvvmCross.Binding.BindingContext;
using StarWars.Core.ViewModels.Character;
using StarWars.Core.ViewModels.Planet;
using StarWars.iOS.Extensions;
using StarWars.iOS.Views.Tables.Cells.Base;

namespace StarWars.iOS.Views.Tables.Cells;

public class PlanetItemTableViewCell(IntPtr handle) : BaseTableViewCell<PlanetItemViewModel>(handle)
{
    private UILabel _planetContainerLabel;
    public static readonly NSString Key = new(nameof(PlanetItemTableViewCell));

    protected override void InitComponents()
    {
        base.InitComponents();
        
        ContentView.BackgroundColor = UIColor.Black;

        _planetContainerLabel = new UILabel
        {
            BackgroundColor = UIColor.Black,
            Font = UIFont.SystemFontOfSize(24),
            TextColor = UIColor.FromRGB(255, 232, 31),
            TranslatesAutoresizingMaskIntoConstraints = false
        };

        ContentView.AddSubview(_planetContainerLabel);

        _planetContainerLabel
            .StartToStartOf(ContentView, 16)
            .EndToEndOf(ContentView, 16)
            .CenterToCenterVerticalOf(ContentView);
    }

    protected override void ApplyBindings(MvxFluentBindingDescriptionSet<BaseTableViewCell<PlanetItemViewModel>, PlanetItemViewModel> set)
    {
        base.ApplyBindings(set);

        set.Bind(_planetContainerLabel)
            .For(v => v.Text)
            .To(vm => vm.Name);
    }
}