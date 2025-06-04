using _Microsoft.Android.Resource.Designer;
using Android.Views;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Android.Binding.BindingContext;
using MvvmCross.Platforms.Android.Presenters.Attributes;
using MvvmCross.Platforms.Android.Views.Fragments;
using StarWars.Core.ViewModels;
using StarWars.Core.ViewModels.Planet;

namespace StarWars.Android.Views.Fragments;

[MvxFragmentPresentation(ActivityHostViewModelType = typeof(MainViewModel), FragmentContentId = ResourceConstant.Id.content_frame, AddToBackStack = true)]
public sealed class PlanetDetailFragment : MvxFragment<PlanetDetailViewModel>
{
    private TextView _textViewValueName;
    private TextView _textViewValueRotationPeriod;
    private TextView _textViewValueOrbitalPeriod;
    private TextView _textViewValueDiameter;
    private TextView _textViewValueClimate;
    private TextView _textViewValueGravity;
    private TextView _textViewValueTerrain;
    private TextView _textViewValueSurfaceWater;
    private TextView _textViewValuePopulation;
    private TextView _textViewValueCreated;
    private TextView _textViewValueEdited;
    
    private Button _buttonGoBackCommand;
    
    public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
    {
        base.OnCreateView(inflater, container, savedInstanceState);

        var view = this.BindingInflate(ResourceConstant.Layout.planet_detail_fragment, container, false);
        
        _textViewValueName = view?.FindViewById<TextView>(ResourceConstant.Id.valuePlanetName);
        _textViewValueRotationPeriod = view?.FindViewById<TextView>(ResourceConstant.Id.valuePlanetRotationPeriod);
        _textViewValueOrbitalPeriod = view?.FindViewById<TextView>(ResourceConstant.Id.valuePlanetOrbitalPeriod);
        _textViewValueDiameter = view?.FindViewById<TextView>(ResourceConstant.Id.valuePlanetDiameter);
        _textViewValueClimate = view?.FindViewById<TextView>(ResourceConstant.Id.valuePlanetClimate);
        _textViewValueGravity = view?.FindViewById<TextView>(ResourceConstant.Id.valuePlanetGravity);
        _textViewValueTerrain = view?.FindViewById<TextView>(ResourceConstant.Id.valuePlanetTerrain);
        _textViewValueSurfaceWater = view?.FindViewById<TextView>(ResourceConstant.Id.valuePlanetSurfaceWater);
        _textViewValuePopulation = view?.FindViewById<TextView>(ResourceConstant.Id.valuePlanetPopulation);
        _textViewValueCreated = view?.FindViewById<TextView>(ResourceConstant.Id.valuePlanetCreated);
        _textViewValueEdited = view?.FindViewById<TextView>(ResourceConstant.Id.valuePlanetEdited);
        
        _buttonGoBackCommand = view?.FindViewById<Button>(ResourceConstant.Id.backButtonPlanet);

        return view;
    }

    public override void OnViewCreated(View view, Bundle savedInstanceState)
    {
        base.OnViewCreated(view, savedInstanceState);
        
        var bindingSet = this.CreateBindingSet<PlanetDetailFragment, PlanetDetailViewModel>();
        
        bindingSet.Bind(_textViewValueName)
            .For("Text")
            .To(vm => vm.Planet.Name);
        
        bindingSet.Bind(_textViewValueRotationPeriod)
            .For("Text")
            .To(vm => vm.Planet.RotationPeriod);
        
        bindingSet.Bind(_textViewValueOrbitalPeriod)
            .For("Text")
            .To(vm => vm.Planet.OrbitalPeriod);
        
        bindingSet.Bind(_textViewValueDiameter)
            .For("Text")
            .To(vm => vm.Planet.Diameter);
        
        bindingSet.Bind(_textViewValueClimate)
            .For("Text")
            .To(vm => vm.Planet.Climate);
        
        bindingSet.Bind(_textViewValueGravity)
            .For("Text")
            .To(vm => vm.Planet.Gravity);
        
        bindingSet.Bind(_textViewValueTerrain)
            .For("Text")
            .To(vm => vm.Planet.Terrain);
        
        bindingSet.Bind(_textViewValueSurfaceWater)
            .For("Text")
            .To(vm => vm.Planet.SurfaceWater);
        
        bindingSet.Bind(_textViewValuePopulation)
            .For("Text")
            .To(vm => vm.Planet.Population);
        
        bindingSet.Bind(_textViewValueCreated)
            .For("Text")
            .To(vm => vm.Planet.Created);
        
        bindingSet.Bind(_textViewValueEdited)
            .For("Text")
            .To(vm => vm.Planet.Edited);
        
        bindingSet.Bind(_buttonGoBackCommand)
            .For("Click")
            .To(vm => vm.GoBackCommand);
        
        bindingSet.Apply();
    }
}