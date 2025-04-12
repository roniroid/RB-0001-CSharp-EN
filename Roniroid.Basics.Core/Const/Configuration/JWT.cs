namespace Roniroid.Basics.Core.Const.Configuration;

public static class JWT
{
    private const string PREFIX = "Jwt";

    public const string KEY = PREFIX + ":Key";
    public const string EXPIRE_MINUTES = PREFIX + ":ExpireMinutes";
    public const string ISSUER = PREFIX + ":Issuer";
    public const string AUDIENCE = PREFIX + ":Audience";
}
