using System.Text.RegularExpressions;

namespace PalindromeService.Services;

public class PalindromeLogic
{
    private string Normalize(string text)
    {
        return Regex.Replace(text.ToLower(), "[^a-z0-9]", "");
    }

    public bool IsPalindrome(string text)
    {
        var normalized = Normalize(text);
        var reversed = new string(normalized.Reverse().ToArray());
        return normalized == reversed;
    }

    public string LongestPalindrome(string s)
    {
        if (string.IsNullOrEmpty(s)) return "";

        int start = 0, end = 0;

        int Expand(int left, int right)
        {
            while (left >= 0 && right < s.Length && s[left] == s[right])
            {
                left--;
                right++;
            }
            return right - left - 1;
        }

        for (int i = 0; i < s.Length; i++)
        {
            int len1 = Expand(i, i);
            int len2 = Expand(i, i + 1);
            int len = Math.Max(len1, len2);

            if (len > end - start)
            {
                start = i - (len - 1) / 2;
                end = i + len / 2;
            }
        }

        return s.Substring(start, end - start + 1);
    }
}
