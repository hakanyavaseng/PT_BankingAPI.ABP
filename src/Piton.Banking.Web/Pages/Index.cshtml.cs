using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace Piton.Banking.Web.Pages;

public class IndexModel : BankingPageModel
{
    public void OnGet()
    {

    }

    public async Task OnPostLoginAsync()
    {
        await HttpContext.ChallengeAsync("oidc");
    }
}
