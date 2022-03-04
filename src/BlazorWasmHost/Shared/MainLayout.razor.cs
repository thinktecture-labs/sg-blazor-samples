using MudBlazor;
using MudBlazor.ThemeManager;
using MudBlazor.Utilities;

namespace BlazorWasmHost.Shared
{
	public partial class MainLayout
	{
		private ThemeManagerTheme _themeManager = new ThemeManagerTheme()
		{
			Theme = new MudTheme()
			{
				Palette = new Palette()
				{
					Primary = new MudColor("#ff584f"),
					Secondary = new MudColor("#3d6fb4"),
					TextPrimary = new MudColor("#000000"),
					TextSecondary = new MudColor("#ffffff"),
					AppbarBackground = new MudColor("#ff584f"),
				},
			},
		};

		private bool _menuExpanded = true;
		private bool _themeManagerExpanded = false;

		private void ToggleMenu()
		{
			_menuExpanded = !_menuExpanded;
		}

		private void ToggleThemeManager()
		{
			_themeManagerExpanded = !_themeManagerExpanded;
		}

		private void UpdateTheme(ThemeManagerTheme theme)
		{
			_themeManager = theme;
			StateHasChanged();
		}
	}
}
