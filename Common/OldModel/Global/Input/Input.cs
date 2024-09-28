namespace Common.Model.Global.Input;

public class Input
{
    public string Id { get; set; }
    public string Label { get; set; }
    public string Type { get; set; } = "text";
    public int ColumnSpan { get; set; } = 4;
    public bool IsOptional { get; set; } = false;
    public int? MaxLength { get; set; } = null;
    public string Placeholder { get; set; } = "Input Text";
    public string Value { get; set; } = "";
    public bool IsDisabled { get; set; } = false;
    public bool IsHidden { get; set; } = false;
    public bool IsReadOnly { get; set; } = false;
    public string LeadingText { get; set; } = "";
    public List<string>? AdditionalClasses_Input { get; set; } = null;
    public List<string>? AdditionalClasses_Label { get; set; } = null;
}

