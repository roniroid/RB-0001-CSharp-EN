using Microsoft.Extensions.Configuration;

namespace Roniroid.Basics.BL.Models;

public class Token
{
    public string Secret { get; set; }
    public TimeSpan Lifetime { get; set; }
    public string Issuer { get; set; }
    public string Audience { get; set; }
}
