using Fluxor;
using SharedLibrary.Features.PokeApi.Models;

namespace SharedLibrary.Features.PokeApi.State;

public record PokemonDataLoadedAction(PokemonModel[] Pokemon);

public partial class PokeApiStateReducers
{
	[ReducerMethod]
	public static PokeApiState ReducePokemonDataLoaded(PokeApiState current, PokemonDataLoadedAction action)
		=> current with
		{
			IsLoading = false,
			CurrentlyLoaded = 0,
			LoadingAmount = action.Pokemon.Length,
			AvailablePokemon = action.Pokemon,
		};
}
