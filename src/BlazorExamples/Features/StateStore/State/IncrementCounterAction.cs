using Fluxor;

namespace BlazorExamples.Features.StateStore.State;

public record IncrementCounterAction
{
	public int Increment { get; init; } = 1;

	public IncrementCounterAction(int increment = 1)
	{
		Increment = increment;
	}
}

public static partial class StateStoreReducers
{
	[ReducerMethod]
	public static StateStoreState ReduceIncrementCounter(StateStoreState current, IncrementCounterAction action)
		=> current with { Counter = current.Counter + action.Increment, };
}
