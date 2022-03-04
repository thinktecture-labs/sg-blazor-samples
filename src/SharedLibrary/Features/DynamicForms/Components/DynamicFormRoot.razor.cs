using Microsoft.AspNetCore.Components;
using SharedLibrary.Features.DynamicForms.Models;

namespace SharedLibrary.Features.DynamicForms.Components;

public partial class DynamicFormRoot
{
	[Parameter, EditorRequired]
	public DynamicComponentModel Form { get; set; }
}
