using Fluxor;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor.Services;
using SharedLibrary.Features.PokeApi.Services;

namespace SharedLibrary
{
	public static class ServiceCollectionExtensions
	{
		public static IServiceCollection AddSharedStuff(this IServiceCollection services)
		{
			services.AddFluxor(o =>
			{
				o.ScanAssemblies(typeof(PokemonApiHttpClient).Assembly);
				o.UseReduxDevTools(ro =>
				{
					ro.Name = "SG Blazor Samples";
				});
			});

			services.AddHttpClient<PokemonApiHttpClient>(client =>
			{
				client.BaseAddress = new Uri("https://pokeapi.co/api/v2/");
			});

			services.AddMudServices();

			return services;
		}
	}
}
