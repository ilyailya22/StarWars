using Android.Graphics;
using Android.Views;
using AndroidX.RecyclerView.Widget;

namespace StarWars.Android;

public sealed class SpacingItemDecoration(int space) : RecyclerView.ItemDecoration
{
    public override void GetItemOffsets(Rect outRect, View view, RecyclerView parent, RecyclerView.State state)
    {
        outRect.Top = space;
        
        if (parent.GetChildAdapterPosition(view) == parent.GetAdapter()!.ItemCount - 1)
        {
            outRect.Bottom = space;
        }
    }
}