using Microsoft.AspNetCore.Components;
using SharedLibrary.Features.DynamicForms.Models;

namespace SharedLibrary.Features.DynamicForms.Components;

public class DynamicComponentBase : ComponentBase
{
	[Parameter, EditorRequired]
	public DynamicComponentModel Component { get; set; }

	[Parameter]
	public dynamic Value { get; set; }
}
