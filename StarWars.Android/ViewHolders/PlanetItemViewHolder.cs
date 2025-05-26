using _Microsoft.Android.Resource.Designer;
using Android.Views;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Android.Binding.BindingContext;
using StarWars.Core.ViewModels.Planet;

namespace StarWars.Android.ViewHolders;

public class PlanetItemViewHolder(View itemView, IMvxAndroidBindingContext context)
    : BaseRecyclerViewHolder<PlanetItemViewModel>(itemView, context)
{
    private TextView _planetContainerView;

    protected override void InitComponents(View itemView)
    {
        base.InitComponents(itemView);

        _planetContainerView = itemView?.FindViewById<TextView>(ResourceConstant.Id.planetContainerView);
    }

    protected override void ApplyBindings(MvxFluentBindingDescriptionSet<BaseRecyclerViewHolder<PlanetItemViewModel>, PlanetItemViewModel> set)
    {
        base.ApplyBindings(set);
        
        set.Bind(_planetContainerView)
            .For(v => v.Text)
            .To(vm => vm.Name);
    }
}