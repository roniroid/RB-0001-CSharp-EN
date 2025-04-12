using Microsoft.Extensions.Configuration;
using Roniroid.Basics.BL.Models;

using Constants = Roniroid.Basics.Core.Const.Configuration;

namespace Roniroid.Basics.BL.Builders;

public class TokenBuilder
{
    private IConfiguration _configuration;
    private Token _token = new Token();

    public TokenBuilder(IConfiguration configuration)
    {
        this._configuration = configuration;
        this.SetJwtSecret();
        this.SetJwtLifetime();
        this.SetJwtIssuer();
        this.SetJwtAudience();
    }

    private TokenBuilder SetJwtSecret(){
        const string configKey = Constants.JWT.KEY;

        if (_configuration[configKey] == null)
        {
            throw new Exception("JWT Key is not set in the configuration.");
        }

        this._token.Secret = _configuration[configKey];

        return this;
    }

    private TokenBuilder SetJwtLifetime(){
        const string configKey = Constants.JWT.EXPIRE_MINUTES;

        if (_configuration[configKey] == null)
        {
            throw new Exception("JWT Expire Minutes is not set in the configuration.");
        }

        int expireMinutes = Convert.ToInt32(_configuration[configKey]);

        this._token.Lifetime = TimeSpan.FromMinutes(expireMinutes);

        return this;
    }

    private TokenBuilder SetJwtIssuer(){
        const string configKey = Constants.JWT.ISSUER;

        if (_configuration[configKey] == null)
        {
            throw new Exception("JWT Issuer is not set in the configuration.");
        }

        this._token.Issuer = _configuration[configKey];

        return this;
    }

    private TokenBuilder SetJwtAudience(){
        const string configKey = Constants.JWT.AUDIENCE;

        if (_configuration[configKey] == null)
        {
            throw new Exception("JWT Audience is not set in the configuration.");
        }

        this._token.Audience = _configuration[configKey];

        return this;
    }

    public Token Build() => _token;
}
