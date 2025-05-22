using System.Threading.Tasks;
using MvvmCross.ViewModels;

namespace StarWars.Core.ViewModels;

public sealed class DetailViewModel : MvxViewModel
{
    public override async Task Initialize()
    {
        await base.Initialize();
    }
}