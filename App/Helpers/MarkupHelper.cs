using Microsoft.AspNetCore.Components;

namespace AllWeKnow.App.Helpers;

public class MarkupHelper
{
    public MarkupString ToMarkupString(string original)
    {
        return (MarkupString)original;
    }
}