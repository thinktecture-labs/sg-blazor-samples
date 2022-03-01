using BlazorExamples.Features.PokeApi.Models;
using Microsoft.AspNetCore.Components;

namespace BlazorExamples.Features.PokeApi.Components;

public partial class PokemonCard
{
	[Parameter]
	public PokemonModel Pokemon { get; set; }
}
