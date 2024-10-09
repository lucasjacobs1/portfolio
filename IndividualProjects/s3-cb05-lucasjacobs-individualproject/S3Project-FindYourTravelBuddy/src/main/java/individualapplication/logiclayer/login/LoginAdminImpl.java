package individualapplication.logiclayer.login;

import individualapplication.datalayer.userrepo.UserEntity;
import individualapplication.datalayer.userrepo.UserRepository;
import individualapplication.logiclayer.execptions.ApiRequestException;
import individualapplication.logiclayer.login.accesstoken.AccessTokenEncoder;
import individualapplication.models.AccessToken;
import individualapplication.models.LoginRequest;
import individualapplication.models.LoginResponse;
import lombok.RequiredArgsConstructor;
import org.springframework.security.crypto.password.PasswordEncoder;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
@RequiredArgsConstructor
public class LoginAdminImpl implements LoginAdmin {
    private final UserRepository userRepository;
    private final PasswordEncoder passwordEncoder;
    private final AccessTokenEncoder accessTokenEncoder;

    @Override
    public LoginResponse login(LoginRequest loginRequest) {
        UserEntity user = userRepository.findByUserName(loginRequest.getUsername());

        if (user == null) {
            throw new ApiRequestException("Username is incorrect");
        }

        if (!matchesPassword(loginRequest.getPassword(), user.getPassword())) {
            throw new ApiRequestException("Password is incorrect");
        }

        String accessToken = generateAccessToken(user);
        return LoginResponse.builder().accessToken(accessToken).build();
    }

    private boolean matchesPassword(String rawPassword, String encodedPassword) {
        return passwordEncoder.matches(rawPassword, encodedPassword);
    }

    private String generateAccessToken(UserEntity user) {
        Long id = user.getId();
        List<String> roles = user.getUserRoles().stream()
                .map(userRole -> userRole.getName().toString())
                .toList();

        return accessTokenEncoder.encode(
                AccessToken.builder()
                        .subject(user.getUserName())
                        .roles(roles)
                        .id(id)
                        .build());
    }

}
