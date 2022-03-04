using Fluxor;
using SharedLibrary.Features.PokeApi.Models;

namespace SharedLibrary.Features.PokeApi.State;

public record PokemonDataLoadingFailedAction(string Reason);

public partial class PokeApiStateReducers
{
	[ReducerMethod]
	public static PokeApiState ReducePokemonDataLoadingFailed(PokeApiState current, PokemonDataLoadingFailedAction action)
		=> current with
		{
			IsLoading = false,
			CurrentlyLoaded = 0,
			LoadingAmount = 0,
			AvailablePokemon = Array.Empty<PokemonModel>(),
			ErrorText = action.Reason,
		};
}
