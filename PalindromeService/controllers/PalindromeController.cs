using Cloops.Microservices.Attributes;
using PalindromeService.Schema;
using PalindromeService.Services;

namespace PalindromeService.Controllers;

public class PalindromeController
{
    private readonly PalindromeLogic _logic;

    public PalindromeController(PalindromeLogic logic)
    {
        _logic = logic;
    }

    [NatsConsumer("palindrome.check")]
    public PalindromeResponse CheckPalindrome(PalindromeRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Text))
        {
            return new PalindromeResponse
            {
                Text = "",
                IsPalindrome = true,
                LongestPalindrome = "",
                Length = 0
            };
        }

        var longest = _logic.LongestPalindrome(request.Text);

        return new PalindromeResponse
        {
            Text = request.Text,
            IsPalindrome = _logic.IsPalindrome(request.Text),
            LongestPalindrome = longest,
            Length = longest.Length
        };
    }
}
