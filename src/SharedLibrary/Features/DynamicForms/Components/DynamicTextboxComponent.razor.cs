namespace SharedLibrary.Features.DynamicForms.Components;

public partial class DynamicTextboxComponent
{
	public DynamicTextboxComponent()
	{
		Value = "";
	}

	private string StringValue
	{
		get => (string)Value;
		set => Value = value;
	}
}
