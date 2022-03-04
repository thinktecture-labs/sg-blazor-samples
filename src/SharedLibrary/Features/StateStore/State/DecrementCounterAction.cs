using Fluxor;

namespace SharedLibrary.Features.StateStore.State;

public record DecrementCounterAction
{
	public int Decrement { get; init; } = 1;

	public DecrementCounterAction(int decrement = 1)
	{
		Decrement = decrement;
	}
}

public static partial class StateStoreReducers
{
	[ReducerMethod]
	public static StateStoreState ReduceDecrementCounter(StateStoreState current, DecrementCounterAction action)
		=> current with { Counter = current.Counter - action.Decrement, };
}
