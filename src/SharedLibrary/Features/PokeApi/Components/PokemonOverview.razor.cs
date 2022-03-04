using Fluxor;
using Fluxor.Blazor.Web.Components;
using Microsoft.AspNetCore.Components;
using SharedLibrary.Features.PokeApi.State;

namespace SharedLibrary.Features.PokeApi.Components;

public partial class PokemonOverview : FluxorComponent
{
	[Inject] private IState<PokeApiState> State { get; set; }
	[Inject] private IDispatcher Dispatcher { get; set; }

	protected bool IsInitialized => State?.Value?.IsInitalized == true;

	protected override void OnInitialized()
	{
		base.OnInitialized();
		if (!IsInitialized)
		{
			Dispatcher.Dispatch(new InitializePokeApiStateAction());
		}
	}
}
