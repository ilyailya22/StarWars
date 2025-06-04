using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Binding.Views;
using MvvmCross.Platforms.Ios.Presenters.Attributes;
using MvvmCross.Platforms.Ios.Views;
using StarWars.Core.ViewModels.Planet;
using StarWars.iOS.Extensions;
using StarWars.iOS.Views.Tables.Cells;

namespace StarWars.iOS.Views.Tables;

[MvxChildPresentation]
public class PlanetsViewController : MvxViewController<PlanetsViewModel>
{
    private UITableView _tableView;

    public override void ViewDidLoad()
    {
        base.ViewDidLoad();

        View!.BackgroundColor = UIColor.Black;

        _tableView = new UITableView
        {
            BackgroundColor = UIColor.Black,
            TranslatesAutoresizingMaskIntoConstraints = false,
            RowHeight = UITableView.AutomaticDimension,
            EstimatedRowHeight = 44
        };

        View.AddSubview(_tableView);

        _tableView
            .TopToTopSafeAreaOf(View)
            .BottomToBottomSafeAreaOf(View)
            .StartToStartOf(View)
            .EndToEndOf(View);
        
        _tableView.RegisterClassForCellReuse(typeof(PlanetItemTableViewCell), nameof(PlanetItemTableViewCell));
        
        var source = new MvxSimpleTableViewSource(
            _tableView,
            typeof(PlanetItemTableViewCell),
            PlanetItemTableViewCell.Key
        );

        _tableView.Source = source;
        
        var set = this.CreateBindingSet<PlanetsViewController, PlanetsViewModel>();
        
        set.Bind(source)
            .For(v => v.ItemsSource)
            .To(vm => vm.PlanetItems);
        
        set.Bind(source)
            .For(v => v.SelectionChangedCommand)
            .To(vm => vm.SelectPlanetCommand);
        
        set.Apply();

        _tableView.ReloadData();
    }
}