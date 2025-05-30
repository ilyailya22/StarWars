using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Binding.Views;
using MvvmCross.Platforms.Ios.Presenters.Attributes;
using MvvmCross.Platforms.Ios.Views;
using StarWars.Core.ViewModels.Character;
using StarWars.Core.ViewModels.Planet;
using StarWars.iOS.Views.Tables.Cells;

namespace StarWars.iOS.Views.Tables;

[MvxChildPresentation]
public class PlanetsViewController : MvxTableViewController<PlanetsViewModel>
{
    public override void ViewDidLoad()
    {
        base.ViewDidLoad();
        View.BackgroundColor = UIColor.Black;

        var source = new MvxSimpleTableViewSource(
            TableView,
            typeof(UITableViewCell),
            nameof(CustomStarWarsCell)
        );

        TableView.Source = source;
        TableView.RowHeight = 60;

        var set = this.CreateBindingSet<PlanetsViewController, PlanetsViewModel>();
        set.Bind(source).To(vm => vm.PlanetItems);
        set.Bind(source).For(v => v.SelectionChangedCommand).To(vm => vm.SelectPlanetCommand);
        set.Apply();

        TableView.ReloadData();
    }
}