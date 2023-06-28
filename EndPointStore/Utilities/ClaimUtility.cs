using System.Security.Claims;

namespace EndPointStore.Utilities
{
    public class ClaimUtility
    {
        public static string? GetUserId(ClaimsPrincipal User)
        {
            try
            {
                var claimsIdentity = User.Identity as ClaimsIdentity;

                if (claimsIdentity.FindFirst(ClaimTypes.NameIdentifier) != null)
                {
                    string userId =claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
                    return userId;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {

                return null;
            }

        }
    }
}
