using Fluxor;

namespace BlazorExamples.Features.StateStore.State
{
	[FeatureState]
	public record StateStoreState
	{
		public int Counter { get; init; } = 0;
	}
}
