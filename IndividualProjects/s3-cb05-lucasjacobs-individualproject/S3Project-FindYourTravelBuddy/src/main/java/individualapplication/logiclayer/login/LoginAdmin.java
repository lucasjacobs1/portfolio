package individualapplication.logiclayer.login;

import individualapplication.models.LoginRequest;
import individualapplication.models.LoginResponse;

public interface LoginAdmin {
    LoginResponse login(LoginRequest loginRequest);

}
