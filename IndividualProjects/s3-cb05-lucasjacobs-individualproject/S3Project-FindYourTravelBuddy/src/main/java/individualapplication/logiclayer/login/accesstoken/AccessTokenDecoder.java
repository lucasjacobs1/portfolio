package individualapplication.logiclayer.login.accesstoken;

import individualapplication.models.AccessToken;

public interface AccessTokenDecoder {
    AccessToken decode(String accessTokenEncoded);
}
