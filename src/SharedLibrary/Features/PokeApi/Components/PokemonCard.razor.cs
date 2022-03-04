using Microsoft.AspNetCore.Components;
using SharedLibrary.Features.PokeApi.Models;

namespace SharedLibrary.Features.PokeApi.Components;

public partial class PokemonCard
{
	[Parameter]
	public PokemonModel Pokemon { get; set; }
}
