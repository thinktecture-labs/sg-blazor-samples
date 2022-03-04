using Fluxor;
using SharedLibrary.Features.PokeApi.Models;

namespace SharedLibrary.Features.PokeApi.State;

[FeatureState]
public record PokeApiState
{
	public bool IsInitalized { get; init; } = false;

	public bool IsLoading { get; init; } = false;
	public int LoadingAmount { get; init; } = 0;
	public int CurrentlyLoaded { get; init; } = 0;
	public string? ErrorText { get; init; } = null;

	public PokemonModel[] AvailablePokemon { get; init; } = Array.Empty<PokemonModel>();

	public bool HasError => !String.IsNullOrWhiteSpace(ErrorText);
}
