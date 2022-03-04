using SharedLibrary.Features.DynamicForms.Components;

namespace SharedLibrary.Features.DynamicForms.Models;

public class DynamicComponentModel
{
	public string Type { get; set; }
	public string Label { get; set; }
	// Todo: Contstraints, Validation values etc. pp...

	public List<DynamicComponentModel> ChildComponents { get; set; } = new();
}

public static class DynamicComponentExtensions
{
	public static Type GetComponentType(this DynamicComponentModel component)
	{
		var result = (component.Type switch
		{
			"textbox" => typeof(DynamicTextboxComponent),
			_ => typeof(UnknownDynamicComponent),
		});

		return result;
	}

	public static Dictionary<string, object> GetParameters(this DynamicComponentModel component)
	{
		return new Dictionary<string, object>() { { "Component", component }, };
	}
}
