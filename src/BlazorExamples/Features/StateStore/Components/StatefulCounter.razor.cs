using BlazorExamples.Features.StateStore.State;
using Fluxor;
using Fluxor.Blazor.Web.Components;
using Microsoft.AspNetCore.Components;

namespace BlazorExamples.Features.StateStore.Components
{
	public partial class StatefulCounter : FluxorComponent
	{
		[Inject] private IState<StateStoreState> _state { get; set; }
		[Inject] private IDispatcher _dispatcher { get; set; }

		public bool IsInitialized => _state != null;
		public StateStoreState State => _state.Value;

		public int ChangeValue { get; set; } = 1;

		public void DoIncrementCounter()
		{
			_dispatcher.Dispatch(new IncrementCounterAction(ChangeValue));
		}
		
		public void DoDecrementCounter()
		{
			_dispatcher.Dispatch(new DecrementCounterAction(ChangeValue));
		}

		public void DoResetCounter()
		{
			_dispatcher.Dispatch(new ResetCounterAction());
		}
	}
}
