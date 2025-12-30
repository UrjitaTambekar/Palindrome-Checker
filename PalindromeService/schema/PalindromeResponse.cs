namespace PalindromeService.Schema;

public class PalindromeResponse
{
    public string Text { get; set; } = string.Empty;
    public bool IsPalindrome { get; set; }
    public string LongestPalindrome { get; set; } = string.Empty;
    public int Length { get; set; }
}
