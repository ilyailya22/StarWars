using Android.Views;
using MvvmCross.Binding.BindingContext;
using MvvmCross.DroidX.RecyclerView;
using MvvmCross.Platforms.Android.Binding.BindingContext;
using MvvmCross.ViewModels;

namespace StarWars.Android.ViewHolders;

public class BaseRecyclerViewHolder<TItemViewModel> : MvxRecyclerViewHolder
    where TItemViewModel : MvxNotifyPropertyChanged
{
    public BaseRecyclerViewHolder(View itemView, IMvxAndroidBindingContext context)
        : base(itemView, context)
    {
        InitComponents(itemView);

        this.DelayBind(InitView);
    }

    protected virtual void InitComponents(View itemView)
    {
    }

    protected virtual void ApplyBindings(MvxFluentBindingDescriptionSet<BaseRecyclerViewHolder<TItemViewModel>, TItemViewModel> bindingSet)
    {
    }

    private void InitView()
    {
        ApplyBindings();
    }

    private void ApplyBindings()
    {
        var bindingSet = this.CreateBindingSet<BaseRecyclerViewHolder<TItemViewModel>, TItemViewModel>();

        ApplyBindings(bindingSet);

        bindingSet.Apply();
    }
}