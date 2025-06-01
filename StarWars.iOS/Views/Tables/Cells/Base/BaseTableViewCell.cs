using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Binding.Views;
using MvvmCross.ViewModels;

namespace StarWars.iOS.Views.Tables.Cells.Base;

public class BaseTableViewCell<TItemViewModel> : MvxTableViewCell
    where TItemViewModel : MvxNotifyPropertyChanged
{
    protected BaseTableViewCell(IntPtr handle) : base(handle)
    {
        InitComponents();
        this.DelayBind(InitBindings);
    }

    protected virtual void InitComponents()
    {
    }

    protected virtual void ApplyBindings(MvxFluentBindingDescriptionSet<BaseTableViewCell<TItemViewModel>, TItemViewModel> bindingSet)
    {
    }

    private void InitBindings()
    {
        var set = this.CreateBindingSet<BaseTableViewCell<TItemViewModel>, TItemViewModel>();
        ApplyBindings(set);
        set.Apply();
    }
}