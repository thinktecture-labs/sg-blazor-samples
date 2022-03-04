using Fluxor;

namespace SharedLibrary.Features.PokeApi.State;

public record PokemonLoadingUpdateAction(int Amount, int Loaded);

public partial class PokeApiStateReducers
{
	[ReducerMethod]
	public static PokeApiState ReducePokemonLoadingUpdate(PokeApiState current, PokemonLoadingUpdateAction action)
		=> current with { IsLoading = true, CurrentlyLoaded = action.Loaded, LoadingAmount = action.Amount, };
}
