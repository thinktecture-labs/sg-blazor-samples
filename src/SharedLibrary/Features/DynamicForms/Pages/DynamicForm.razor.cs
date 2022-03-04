using SharedLibrary.Features.DynamicForms.Models;

namespace SharedLibrary.Features.DynamicForms.Pages;

public partial class DynamicForm
{
	private DynamicComponentModel Form { get; set; } = new DynamicComponentModel()
	{
		Type = "Form",
		Label = "Dynamic Form Sample",
		ChildComponents = new()
		{
			new DynamicComponentModel() { Type = "textbox", Label = "Name", },
		},
	};
}
