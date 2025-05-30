using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Binding.Views;
using MvvmCross.Platforms.Ios.Presenters.Attributes;
using MvvmCross.Platforms.Ios.Views;
using StarWars.Core.ViewModels.Character;
using StarWars.iOS.Views.Tables.Cells;

namespace StarWars.iOS.Views.Tables;

[MvxChildPresentation]
public class CharactersViewController : MvxTableViewController<CharactersViewModel>
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

        var set = this.CreateBindingSet<CharactersViewController, CharactersViewModel>();
        set.Bind(source).To(vm => vm.CharacterItems);
        set.Bind(source).For(v => v.SelectionChangedCommand).To(vm => vm.SelectCharacterCommand);
        set.Apply();

        TableView.ReloadData();
    }
}