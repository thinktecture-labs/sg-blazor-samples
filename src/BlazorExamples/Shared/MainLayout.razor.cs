namespace BlazorExamples.Shared
{
	public partial class MainLayout
	{
		private bool _menuExpanded = true;

		private void ToggleMenu()
		{
			_menuExpanded = !_menuExpanded;
		}
	}
}
