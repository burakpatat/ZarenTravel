
namespace Zaren.Blazor.Utility
{
    public static class Helper
    {
        public static bool Contains(string input, string findMe)
        {
            return string.IsNullOrWhiteSpace(input) ? false : input.IndexOf(findMe, StringComparison.InvariantCultureIgnoreCase) > -1;
        }
    }
}
