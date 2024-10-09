package individualapplication.logiclayer.login.accesstoken;

import individualapplication.models.AccessToken;

public interface AccessTokenEncoder {
    String encode(AccessToken accessToken);
}
