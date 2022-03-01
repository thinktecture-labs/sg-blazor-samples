using Fluxor;

namespace BlazorExamples.Features.PokeApi.State;

public record InitializePokeApiStateAction;

public partial class PokeApiStateReducers
{
	[ReducerMethod]
	public static PokeApiState ReduceInitializePokeApiState(PokeApiState current, InitializePokeApiStateAction action)
		=> current with { IsInitalized = true, };
}

public class InitializePokeApiStateEffect : Effect<InitializePokeApiStateAction>
{
	public override Task HandleAsync(InitializePokeApiStateAction action, IDispatcher dispatcher)
	{
		dispatcher.Dispatch(new LoadPokemonDataAction());
		return Task.CompletedTask;
	}
}
