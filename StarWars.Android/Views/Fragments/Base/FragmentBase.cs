using Android.Views;
using AndroidX.RecyclerView.Widget;
using MvvmCross.Binding.BindingContext;
using MvvmCross.DroidX.RecyclerView;
using MvvmCross.Platforms.Android.Binding.BindingContext;
using MvvmCross.Platforms.Android.Views.Fragments;
using MvvmCross.ViewModels;
using StarWars.Core.Const;

namespace StarWars.Android.Views.Fragments.Base;

public abstract class FragmentBase<TViewModel> : MvxFragment<TViewModel>
    where TViewModel : class, IMvxViewModel
{
    protected MvxRecyclerView RecyclerView;

    public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
    {
        base.OnCreateView(inflater, container, savedInstanceState);

        var view = this.BindingInflate(GetLayoutId(), container, false);

        RecyclerView = view?.FindViewById<MvxRecyclerView>(GetRecyclerViewId());

        if (RecyclerView != null)
        {
            var spacingInPx = (int)(Resources.DisplayMetrics!.Density * Constants.SpacingDp + 0.5f);
            RecyclerView.AddItemDecoration(new SpacingItemDecoration(spacingInPx));
            RecyclerView.Adapter = (IMvxRecyclerAdapter)CreateAdapter();
        }

        return view!;
    }

    public override void OnViewCreated(View view, Bundle savedInstanceState)
    {
        base.OnViewCreated(view, savedInstanceState);

        var bindingSet = this.CreateBindingSet<MvxFragment<TViewModel>, TViewModel>();

        SetupBindings(bindingSet);

        bindingSet.Apply();
    }
    
    protected abstract int GetLayoutId();
    protected abstract int GetRecyclerViewId();
    protected abstract RecyclerView.Adapter CreateAdapter();
    protected abstract void SetupBindings(MvxFluentBindingDescriptionSet<MvxFragment<TViewModel>, TViewModel> bindingSet);
}