namespace AlternativeEngineerBlogServer.Domain.Shared;
public sealed class Name
{
    public string Value { get; private set; }

    public Name(string value)
    {
        Value = value;
    }
}

