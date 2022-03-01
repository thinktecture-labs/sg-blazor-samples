using BlazorExamples.Features.PokeApi.Services;
using Fluxor;

namespace BlazorExamples.Features.PokeApi.State;

public record LoadPokemonDataAction;

public partial class PokeApiStateReducers
{
	[ReducerMethod]
	public static PokeApiState ReduceLoadPokemonData(PokeApiState current, LoadPokemonDataAction action)
		=> current with { IsLoading = true, CurrentlyLoaded = 0, LoadingAmount = 0, };
}

public class LoadPokemonDataEffect : Effect<LoadPokemonDataAction>
{
	private PokemonApiHttpClient _client { get; }

	public LoadPokemonDataEffect(PokemonApiHttpClient client)
	{
		_client = client;
	}

	public override async Task HandleAsync(LoadPokemonDataAction action, IDispatcher dispatcher)
	{
		var result = await _client.LoadPokemonDataAsync();

		if (result.HasError)
		{
			dispatcher.Dispatch(new PokemonDataLoadingFailedAction(result.ErrorString));
		}
		else
		{
			dispatcher.Dispatch(new PokemonDataLoadedAction(result.Data));
		}
	}
}
