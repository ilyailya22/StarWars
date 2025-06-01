using StarWars.iOS.Enums;

namespace StarWars.iOS.Extensions;

public static class ViewConstraintsExtensions
{
    public static UIView HeightTo(
        this UIView view,
        float value,
        ConstraintEquality equality = ConstraintEquality.Equal)
    {
        var constraint = equality switch
        {
            ConstraintEquality.LessThan => view.HeightAnchor.ConstraintLessThanOrEqualTo(value),
            ConstraintEquality.GreaterThan => view.HeightAnchor.ConstraintGreaterThanOrEqualTo(value),
            _ => view.HeightAnchor.ConstraintEqualTo(value)
        };

        return ActivateConstraint(view, constraint);
    }

    public static UIView WidthTo(
        this UIView view,
        float value,
        ConstraintEquality equality = ConstraintEquality.Equal)
    {
        var constraint = equality switch
        {
            ConstraintEquality.LessThan => view.WidthAnchor.ConstraintLessThanOrEqualTo(value),
            ConstraintEquality.GreaterThan => view.WidthAnchor.ConstraintGreaterThanOrEqualTo(value),
            _ => view.WidthAnchor.ConstraintEqualTo(value)
        };

        return ActivateConstraint(view, constraint);
    }

    public static UIView WidthToWidthOf(
        this UIView view,
        UIView relativeView,
        float value = 0,
        ConstraintEquality equality = ConstraintEquality.Equal)
    {
        return ApplyConstraint(
            view,
            view.WidthAnchor,
            relativeView.WidthAnchor,
            equality,
            value);
    }

    public static UIView WidthMultiplierOf(
        this UIView view,
        UIView relativeView,
        float multiplier,
        ConstraintEquality equality = ConstraintEquality.Equal)
    {
        var constraint = equality switch
        {
            ConstraintEquality.LessThan => view.WidthAnchor.ConstraintLessThanOrEqualTo(relativeView.WidthAnchor, multiplier),
            ConstraintEquality.GreaterThan => view.WidthAnchor.ConstraintGreaterThanOrEqualTo(relativeView.WidthAnchor, multiplier),
            _ => view.WidthAnchor.ConstraintEqualTo(relativeView.WidthAnchor, multiplier)
        };

        return ActivateConstraint(view, constraint);
    }

    public static UIView HeightMultiplierOf(
        this UIView view,
        UIView relativeView,
        float multiplier,
        ConstraintEquality equality = ConstraintEquality.Equal)
    {
        var constraint = equality switch
        {
            ConstraintEquality.LessThan => view.HeightAnchor.ConstraintLessThanOrEqualTo(relativeView.HeightAnchor, multiplier),
            ConstraintEquality.GreaterThan => view.HeightAnchor.ConstraintGreaterThanOrEqualTo(relativeView.HeightAnchor, multiplier),
            _ => view.HeightAnchor.ConstraintEqualTo(relativeView.HeightAnchor, multiplier)
        };

        return ActivateConstraint(view, constraint);
    }

    public static UIView HeightToHeightOf(
        this UIView view,
        UIView relativeView,
        float value = 0,
        ConstraintEquality equality = ConstraintEquality.Equal)
    {
        return ApplyConstraint(
            view,
            view.HeightAnchor,
            relativeView.HeightAnchor,
            equality,
            value);
    }

    public static UIView TopToTopOf(
        this UIView view,
        UIView relativeView,
        float value = 0,
        ConstraintEquality equality = ConstraintEquality.Equal)
    {
        return ApplyConstraint(
            view,
            view.TopAnchor,
            relativeView.TopAnchor,
            equality,
            value);
    }

    public static UIView TopToBottomOf(
        this UIView view,
        UIView relativeView,
        float value = 0,
        ConstraintEquality equality = ConstraintEquality.Equal)
    {
        return ApplyConstraint(
            view,
            view.TopAnchor,
            relativeView.BottomAnchor,
            equality,
            value);
    }
    
    public static UIView TopToCenterOf(
        this UIView view,
        UIView relativeView,
        float value = 0,
        ConstraintEquality equality = ConstraintEquality.Equal)
    {
        return ApplyConstraint(
            view,
            view.TopAnchor,
            relativeView.CenterYAnchor,
            equality,
            value);
    }

    public static UIView ToAllAxis(
        this UIView view,
        UIView relativeView,
        float left = 0,
        float top = 0,
        float right = 0,
        float bottom = 0)
    {
        return view
            .TopToTopOf(relativeView, top)
            .StartToStartOf(relativeView, left)
            .EndToEndOf(relativeView, right)
            .BottomToBottomOf(relativeView, bottom);
    }

    public static UIView BottomToTopOf(
        this UIView view,
        UIView relativeView,
        float value = 0,
        ConstraintEquality equality = ConstraintEquality.Equal)
    {
        return ApplyConstraint(
            view,
            view.BottomAnchor,
            relativeView.TopAnchor,
            equality,
            -value);
    }

    public static UIView BottomToBottomOf(
        this UIView view,
        UIView relativeView,
        float value = 0,
        ConstraintEquality equality = ConstraintEquality.Equal)
    {
        return ApplyConstraint(
            view,
            view.BottomAnchor,
            relativeView.BottomAnchor,
            equality,
            -value);
    }

    public static UIView BottomToCenterOf(
        this UIView view,
        UIView relativeView,
        float value = 0,
        ConstraintEquality equality = ConstraintEquality.Equal)
    {
        return ApplyConstraint(
            view,
            view.BottomAnchor,
            relativeView.CenterYAnchor,
            equality,
            -value);
    }

    public static UIView StartToStartOf(
        this UIView view,
        UIView relativeView,
        float value = 0,
        ConstraintEquality equality = ConstraintEquality.Equal)
    {
        return ApplyConstraint(
            view,
            view.LeadingAnchor,
            relativeView.LeadingAnchor,
            equality,
            value);
    }

    public static UIView StartToEndOf(
        this UIView view,
        UIView relativeView,
        float value = 0,
        ConstraintEquality equality = ConstraintEquality.Equal)
    {
        return ApplyConstraint(
            view,
            view.LeadingAnchor,
            relativeView.TrailingAnchor,
            equality,
            value);
    }

    public static UIView StartToCenterOf(
        this UIView view,
        UIView relativeView,
        float value = 0,
        ConstraintEquality equality = ConstraintEquality.Equal)
    {
        return ApplyConstraint(
            view,
            view.LeadingAnchor,
            relativeView.CenterXAnchor,
            equality,
            value);
    }

    public static UIView EndToStartOf(
        this UIView view,
        UIView relativeView,
        float value = 0,
        ConstraintEquality equality = ConstraintEquality.Equal)
    {
        return ApplyConstraint(
            view,
            view.TrailingAnchor,
            relativeView.LeadingAnchor,
            equality,
            -value);
    }

    public static UIView EndToEndOf(
        this UIView view,
        UIView relativeView,
        float value = 0,
        ConstraintEquality equality = ConstraintEquality.Equal)
    {
        return ApplyConstraint(
            view,
            view.TrailingAnchor,
            relativeView.TrailingAnchor,
            equality,
            -value);
    }

    public static UIView EndToCenterOf(
        this UIView view,
        UIView relativeView,
        float value = 0,
        ConstraintEquality equality = ConstraintEquality.Equal)
    {
        return ApplyConstraint(
            view,
            view.TrailingAnchor,
            relativeView.CenterXAnchor,
            equality,
            -value);
    }
    
    public static UIView TopToTopSafeAreaOf(
        this UIView view,
        UIView relativeView,
        float value = 0,
        ConstraintEquality equality = ConstraintEquality.Equal)
    {
        return ApplyConstraint(
            view,
            view.TopAnchor,
            relativeView.SafeAreaLayoutGuide.TopAnchor,
            equality,
            value);
    }

    public static UIView BottomToBottomSafeAreaOf(
        this UIView view,
        UIView relativeView,
        float value = 0,
        ConstraintEquality equality = ConstraintEquality.Equal)
    {
        return ApplyConstraint(
            view,
            view.BottomAnchor,
            relativeView.SafeAreaLayoutGuide.BottomAnchor,
            equality,
            -value);
    }

    public static UIView CenterToCenterHorizontalOf(
        this UIView view,
        UIView relativeView,
        float value = 0,
        ConstraintEquality equality = ConstraintEquality.Equal)
    {
        return ApplyConstraint(
            view,
            view.CenterXAnchor,
            relativeView.CenterXAnchor,
            equality,
            value);
    }

    public static UIView CenterToCenterVerticalOf(
        this UIView view,
        UIView relativeView,
        float value = 0,
        ConstraintEquality equality = ConstraintEquality.Equal)
    {
        return ApplyConstraint(
            view,
            view.CenterYAnchor,
            relativeView.CenterYAnchor,
            equality,
            value);
    }

    public static UIView CenterToBottomOf(
        this UIView view,
        UIView relativeView,
        float value = 0,
        ConstraintEquality equality = ConstraintEquality.Equal)
    {
        return ApplyConstraint(
            view,
            view.CenterYAnchor,
            relativeView.BottomAnchor,
            equality,
            value);
    }

    public static NSLayoutConstraint[] GetViewConstraints(this UIView view)
    {
        return view.Superview?.Constraints
            .Where(c => (c.FirstItem != null && c.FirstItem.Equals(view)) ||
                        (c.SecondItem != null && c.SecondItem.Equals(view)))
            .ToArray() ?? new NSLayoutConstraint[] { };
    }

    public static UIView WidthToContentOf(
        this UIView view,
        UIView contentView,
        float margin = 0,
        ConstraintEquality equality = ConstraintEquality.Equal)
    {
        // Create a width constraint that is flexible based on content size
        var constraint = equality switch
        {
            ConstraintEquality.LessThan => view.WidthAnchor.ConstraintLessThanOrEqualTo(contentView.WidthAnchor, 1.0f, margin),
            ConstraintEquality.GreaterThan => view.WidthAnchor.ConstraintGreaterThanOrEqualTo(contentView.WidthAnchor, 1.0f, margin),
            _ => view.WidthAnchor.ConstraintEqualTo(contentView.WidthAnchor, 1.0f, margin)
        };

        return ActivateConstraint(view, constraint);
    }

    private static UIView ApplyConstraint<TAnchor>(
        UIView view,
        NSLayoutAnchor<TAnchor> anchor,
        NSLayoutAnchor<TAnchor> relativeAnchor,
        ConstraintEquality equality,
        float value)
        where TAnchor : NSObject
    {
        var constraint = GetConstraintByEquality(
            anchor,
            relativeAnchor,
            equality,
            value);

        return ActivateConstraint(view, constraint);
    }

    private static UIView ActivateConstraint(this UIView view, NSLayoutConstraint constraint)
    {
        constraint.Active = true;

        return view;
    }
    
    private static NSLayoutConstraint GetConstraintByEquality<TAnchor>(
        NSLayoutAnchor<TAnchor> anchor,
        NSLayoutAnchor<TAnchor> relativeAnchor,
        ConstraintEquality constraintEquality,
        float value = 0)
        where TAnchor : NSObject
    {
        return constraintEquality switch
        {
            ConstraintEquality.LessThan => anchor.ConstraintLessThanOrEqualTo(relativeAnchor, value),
            ConstraintEquality.GreaterThan => anchor.ConstraintGreaterThanOrEqualTo(relativeAnchor, value),
            _ => anchor.ConstraintEqualTo(relativeAnchor, value),
        };
    }
}
    