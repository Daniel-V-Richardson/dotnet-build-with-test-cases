using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sentry;

namespace Jenkins_build.Pages
{
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
                //throw new Exception("This is a test exception from the IndexModel.");
        }
    }
}