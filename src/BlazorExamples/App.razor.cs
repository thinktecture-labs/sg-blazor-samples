using MudBlazor;
using MudBlazor.Utilities;

namespace BlazorExamples
{
	public partial class App
	{
		private MudTheme _theme = new MudTheme()
		{
			Palette = new Palette()
			{
				Primary = new MudColor("#ff584f"),
				Secondary = new MudColor("#3d6fb4"),
				TextPrimary = new MudColor("#ffffff"),
				TextSecondary = new MudColor("#ffffff"),
			},
		};
	}
}
