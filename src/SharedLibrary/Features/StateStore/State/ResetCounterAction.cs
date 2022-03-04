using Fluxor;

namespace SharedLibrary.Features.StateStore.State;

public record ResetCounterAction { }

public static partial class StateStoreReducers
{
	[ReducerMethod]
	public static StateStoreState ReduceResetCounter(StateStoreState current, ResetCounterAction action)
		=> current with { Counter = 0, };
}
