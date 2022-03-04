using Microsoft.AspNetCore.Components;
using SharedLibrary.Features.DynamicForms.Models;

namespace SharedLibrary.Features.DynamicForms.Components;

public partial class DynamicComponents
{
	[Parameter] public List<DynamicComponentModel> Components { get; set; }
}
