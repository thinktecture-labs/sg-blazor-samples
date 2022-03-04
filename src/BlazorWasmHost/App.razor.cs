using System.Reflection;
using Fluxor;
using Microsoft.AspNetCore.Components;
using SharedLibrary.Features.PokeApi.State;

namespace BlazorWasmHost
{
	public partial class App
	{
		[Inject] private IDispatcher _dispatcher { get; set; }
		[Inject] private IConfiguration _configuration { get; set; }

		private Assembly[] AdditionalAssemblies = new Assembly[]
		{
			typeof(PokeApiState).Assembly,
		};

		protected override void OnAfterRender(bool firstRender)
		{
			if (firstRender)
			{
				if (_configuration.GetValue<bool>("pokemon:preload"))
				{
					_dispatcher.Dispatch(new InitializePokeApiStateAction());
				}
			}

			base.OnAfterRender(firstRender);
		}
	}
}
