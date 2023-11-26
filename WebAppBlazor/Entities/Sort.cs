namespace WebAppBlazor.Entities;

public enum Sort
{
    Id,
    Weight,
    Name
}

public static class SortExtensions
{
    public static string ToCapitalString(this Sort sort)
    {
        var sortString = sort.ToString();
        return sortString.First().ToString().ToUpper() + sortString[1..];
    }
}