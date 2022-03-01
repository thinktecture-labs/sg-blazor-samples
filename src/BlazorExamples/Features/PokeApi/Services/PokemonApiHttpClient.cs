using System.Net.Http.Json;
using BlazorExamples.Features.PokeApi.Models;
using BlazorExamples.Features.PokeApi.State;
using Fluxor;

namespace BlazorExamples.Features.PokeApi.Services;

public class PokemonApiHttpClient
{
	private readonly HttpClient _client;
	private readonly IDispatcher _dispatcher;

	public PokemonApiHttpClient(HttpClient client, IDispatcher dispatcher)
	{
		_client = client;
		_dispatcher = dispatcher;
	}

	public async Task<PokemonDataLoadingResult> LoadPokemonDataAsync()
	{
		int amount = 50;

		try
		{
			var result = await _client.GetFromJsonAsync<PokemonListResult>($"pokemon/?offset=0&limit={amount}");

			List<PokemonModel> pokemonList = new List<PokemonModel>();
			int loaded = 0;
			foreach (var entry in result.Results)
			{
				var pokemon = await _client.GetFromJsonAsync<PokemonModel>(entry.Url);
				pokemonList.Add(pokemon);
				loaded++;

				// Do NOT do this in production: Too many updates without real value, can has performance impact
				_dispatcher.Dispatch(new PokemonLoadingUpdateAction(amount, loaded));
			}

			return new PokemonDataLoadingResult() { Data = pokemonList.ToArray(), };
		}
		catch (Exception ex)
		{
			return new PokemonDataLoadingResult() { ErrorString = ex.Message, };
		}
	}

	private class PokemonListResult
	{
		public PokemonListEntry[] Results { get; set; }
	}

	private class PokemonListEntry
	{
		public string Name { get; set; }
		public string Url { get; set; }
	}
}

public class PokemonDataLoadingResult
{
	public PokemonModel[] Data { get; set; } = Array.Empty<PokemonModel>();
	public string ErrorString = null;
	public bool HasError => !String.IsNullOrWhiteSpace(ErrorString);
}
