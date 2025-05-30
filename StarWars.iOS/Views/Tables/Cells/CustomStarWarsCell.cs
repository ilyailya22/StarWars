using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Binding.Views;

namespace StarWars.iOS.Views.Tables.Cells;

public class CustomStarWarsCell : MvxTableViewCell
{
    public CustomStarWarsCell(IntPtr handle) : base(handle)
    {
        BackgroundColor = UIColor.FromRGB(17, 17, 17);

        var label = new UILabel
        {
            Font = UIFont.BoldSystemFontOfSize(32f),
            TextColor = UIColor.FromRGB(255, 232, 31),
            BackgroundColor = UIColor.Clear
        };
        ContentView.AddSubview(label);
        label.TranslatesAutoresizingMaskIntoConstraints = false;

        NSLayoutConstraint.ActivateConstraints(new[]
        {
            label.TopAnchor.ConstraintEqualTo(ContentView.TopAnchor, 8),
            label.LeadingAnchor.ConstraintEqualTo(ContentView.LeadingAnchor, 16),
            label.TrailingAnchor.ConstraintEqualTo(ContentView.TrailingAnchor, -16),
            label.BottomAnchor.ConstraintEqualTo(ContentView.BottomAnchor, -8)
        });

        this.DelayBind(() =>
        {
            var set = this.CreateBindingSet<CustomStarWarsCell, string>();
            set.Bind(label).To(vm => vm);
            set.Apply();
        });
    }
}