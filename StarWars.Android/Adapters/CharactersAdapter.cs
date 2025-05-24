using _Microsoft.Android.Resource.Designer;
using Android.Views;
using AndroidX.RecyclerView.Widget;
using MvvmCross.DroidX.RecyclerView;
using MvvmCross.Platforms.Android.Binding.BindingContext;
using StarWars.Android.ViewHolders;
using StarWars.Core.ViewModels;

namespace StarWars.Android.Adapters;

public class CharactersAdapter(IMvxAndroidBindingContext bindingContext) : MvxRecyclerAdapter(bindingContext)
{
    private const int ItemType = 1002;

    public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
    {
        return viewType switch
        {
            ItemType => CreateItemViewHolder(parent),
            _ => base.OnCreateViewHolder(parent, viewType)
        };
    }

    public override int GetItemViewType(int position)
    {
        var itemViewModel = GetItem(position);

        return itemViewModel switch
        {
            CharacterViewModel => ItemType,
            _ => base.GetItemViewType(position)
        };
    }

    private RecyclerView.ViewHolder CreateItemViewHolder(ViewGroup parent)
    {
        var itemBindingContext = new MvxAndroidBindingContext(parent.Context, BindingContext.LayoutInflaterHolder);

        var itemView = itemBindingContext.BindingInflate(ResourceConstant.Layout.item_character, parent, false);
        var holder = new CharacterItemViewHolder(itemView, itemBindingContext);

        return holder;
    }
}