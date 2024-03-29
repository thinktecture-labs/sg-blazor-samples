﻿using Fluxor;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using SharedLibrary.Features.PokeApi.State;

namespace SharedLibrary
{
	public partial class App
	{
		[Inject] private IDispatcher _dispatcher { get; set; }
		[Inject] private IConfiguration _configuration { get; set; }

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
