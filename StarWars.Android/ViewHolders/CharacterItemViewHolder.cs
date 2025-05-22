using _Microsoft.Android.Resource.Designer;
using Android.Views;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Android.Binding.BindingContext;
using StarWars.Core.ViewModels.Character;

namespace StarWars.Android.ViewHolders;

public class CharacterItemViewHolder(View itemView, IMvxAndroidBindingContext context)
    : BaseRecyclerViewHolder<CharacterItemViewModel>(itemView, context)
{
    private TextView _preferredContainerView;

    protected override void InitComponents(View itemView)
    {
        base.InitComponents(itemView);

        _preferredContainerView = itemView?.FindViewById<TextView>(ResourceConstant.Id.characterContainerView);
    }

    protected override void ApplyBindings(MvxFluentBindingDescriptionSet<BaseRecyclerViewHolder<CharacterItemViewModel>, CharacterItemViewModel> set)
    {
        base.ApplyBindings(set);
        
        set.Bind(_preferredContainerView)
            .For(v => v.Text)
            .To(vm => vm.Name);
    }
}