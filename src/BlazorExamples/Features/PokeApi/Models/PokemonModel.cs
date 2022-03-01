using System.Text.Json.Serialization;

namespace BlazorExamples.Features.PokeApi.Models
{
	public class PokemonModel
	{
		public int Id { get; set; } = 0;
		public string Name { get; set; }
		public int Order { get; set; }
		public int Height { get; set; }
		public int Weight { get; set; }

		public Sprites Sprites { get; set; } = new();
	}

	public class Sprites
	{
		[JsonPropertyName("back_default")]
		public string Back { get; set; }
		[JsonPropertyName("back_shiny")]
		public string BackShiny { get; set; }
		[JsonPropertyName("front_default")]
		public string Front { get; set; }
		[JsonPropertyName("front_shiny")]
		public string FrontShiny { get; set; }
	}
}
