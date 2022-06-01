using System.Web;
using Microsoft.AspNetCore.Components;

namespace SharedLibrary.Features.DeepLinking.Components;

public partial class DeepLinkableComponent: ComponentBase
{
    [Parameter]
    public Guid DataId { get; set; }

    private int selectedTab = 0;

    [Inject]
    private NavigationManager _navigationManager { get; set; } = null!;

    protected override void OnInitialized()
    {
        base.OnInitialized();

        // From Query (because [Parameter, SupplyParameterFromQuery(Name = "XX")] does not work in components)
        SetTabFromUri(_navigationManager.Uri);

        // Register Navigation event
        _navigationManager.LocationChanged += (s, e) => SetTabFromUri(e.Location);
    }

    private void SetTabFromUri(string uri)
    {
        var query = HttpUtility.ParseQueryString(new Uri(uri).Query);
        var queryParameter = query["tab"];
        int.TryParse(queryParameter, out var newTab);

        if (newTab != selectedTab)
        {
            selectedTab = newTab;
            StateHasChanged();
        }
    }

    private void OnSelectionChanged(int newIndex)
    {
        // Do not navigate when nothing really changed
        if (newIndex != selectedTab)
        {
            // Persist change in URI (to be able to be copied / deeplinked)
            var newUri = _navigationManager.GetUriWithQueryParameter("tab", newIndex);
            _navigationManager.NavigateTo(newUri);
        }
    }
}
