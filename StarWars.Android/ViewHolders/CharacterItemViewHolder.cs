using _Microsoft.Android.Resource.Designer;
using Android.Views;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Android.Binding.BindingContext;
using StarWars.Core.ViewModels;

namespace StarWars.Android.ViewHolders;

public class CharacterItemViewHolder(View itemView, IMvxAndroidBindingContext context)
    : BaseRecyclerViewHolder<CharacterViewModel>(itemView, context)
{
    private TextView _preferredContainerView;

    protected override void InitComponents(View itemView)
    {
        base.InitComponents(itemView);

        _preferredContainerView = itemView?.FindViewById<TextView>(ResourceConstant.Id.preferredContainerView);
    }

    protected override void ApplyBindings(MvxFluentBindingDescriptionSet<BaseRecyclerViewHolder<CharacterViewModel>, CharacterViewModel> set)
    {
        base.ApplyBindings(set);
        set.Bind(_preferredContainerView)
            .For(v => v.Text)
            .To(vm => vm.Name);
    }
}