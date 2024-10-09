package individualapplication.logiclayer;

import individualapplication.datalayer.userrepo.UserEntity;
import individualapplication.datalayer.userrepo.UserRepository;
import individualapplication.datalayer.userrepo.roleentity.RoleEntity;
import individualapplication.logiclayer.execptions.ApiRequestException;
import individualapplication.logiclayer.execptions.InvalidAccessTokenException;
import individualapplication.logiclayer.execptions.InvalidBirthdayException;
import individualapplication.logiclayer.login.LoginAdmin;
import individualapplication.logiclayer.login.LoginAdminImpl;
import individualapplication.logiclayer.login.accesstoken.AccessTokenEncoder;
import individualapplication.logiclayer.login.accesstoken.AccessTokenEncoderDecoderImpl;
import individualapplication.models.AccessToken;
import individualapplication.models.LoginRequest;
import individualapplication.models.LoginResponse;
import individualapplication.models.user.RoleEnum;
import individualapplication.models.user.gender.GenderEnum;
import lombok.AllArgsConstructor;
import org.junit.jupiter.api.Test;
import org.junit.jupiter.api.extension.ExtendWith;
import org.mockito.InjectMocks;
import org.mockito.Mock;
import org.mockito.Mockito;
import org.mockito.junit.jupiter.MockitoExtension;
import org.springframework.http.HttpStatus;
import org.springframework.security.crypto.password.PasswordEncoder;
import org.springframework.stereotype.Service;

import java.time.LocalDate;
import java.util.List;
import java.util.Set;

import static org.junit.jupiter.api.Assertions.*;
import static org.mockito.ArgumentMatchers.any;

@ExtendWith(MockitoExtension.class)
@AllArgsConstructor
@Service
class LoginAdminImplTest {

    private AccessTokenEncoderDecoderImpl accessTokenEncoderDecoder = new AccessTokenEncoderDecoderImpl("E91E158E4C6656F68B1B5D1C316736DE98D2AD6EF3BFB4y4F78E9CFCDF5");

    @Mock
    private UserRepository userRepository;

    @Mock
    private AccessTokenEncoder accessTokenEncoder;

    @InjectMocks
    private LoginAdminImpl loginAdmin;

    @Mock
    private PasswordEncoder passwordEncoder;


    @Test
    void encodeValidAccessToken_ReturnAccessTokenString_Works() {
        //Arrange
        UserEntity user = UserEntity.builder().userName("Test").firstName("Test").lastName("Test").password("Test")
                .gender(GenderEnum.MALE).email("test@gmail.com").birthday(LocalDate.of(2000, 12, 12)).userRoles(Set.of(RoleEntity.builder().id(0L).name(RoleEnum.USER).build())).build();
        AccessToken accessToken = AccessToken.builder()
                .subject(user.getUserName())
                .id(user.getId())
                .build();
        List<String> roles = user.getUserRoles().stream()
                .map(userRole -> userRole.getName().toString())
                .toList();
        accessToken.setRoles(roles);
        //Act
        String actual  = accessTokenEncoderDecoder.encode(accessToken);
        //Assert
        assertTrue(!actual.isEmpty());
    }



    @Test
    void decodeAccessToken_ReturnAccessToken_Works() {
        //Arrange
        UserEntity user = UserEntity.builder().userName("Test").firstName("Test").lastName("Test").password("Test")
                .gender(GenderEnum.MALE).email("test@gmail.com").birthday(LocalDate.of(2000, 12, 12)).userRoles(Set.of(RoleEntity.builder().id(0L).name(RoleEnum.USER).build())).build();
        AccessToken expected = AccessToken.builder()
                .subject(user.getUserName())
                .id(user.getId())
                .build();
        List<String> roles = user.getUserRoles().stream()
                .map(userRole -> userRole.getName().toString())
                .toList();
        expected.setRoles(roles);
        String accessTokenString  = accessTokenEncoderDecoder.encode(expected);
        //Act
        AccessToken actual = accessTokenEncoderDecoder.decode(accessTokenString);
        //Assert
        assertEquals(expected,actual,"It doesn't decode the accessTokenString in the right way");
    }

    @Test
    void decode_whenAccessTokenIsInvalid_ReturnAccessToken_Works() {
        //Arrange
        UserEntity user = UserEntity.builder().userName("Test").firstName("Test").lastName("Test").password("Test")
                .gender(GenderEnum.MALE).email("test@gmail.com").birthday(LocalDate.of(2000, 12, 12)).userRoles(Set.of(RoleEntity.builder().id(0L).name(RoleEnum.USER).build())).build();
        AccessToken expected = AccessToken.builder()
                .subject(user.getUserName())
                .id(user.getId())
                .build();
        List<String> roles = user.getUserRoles().stream()
                .map(userRole -> userRole.getName().toString())
                .toList();
        expected.setRoles(roles);
        String accessToken  = "test";
        //Assert
        assertThrows(InvalidAccessTokenException.class, () ->
                        //Act
                        accessTokenEncoderDecoder.decode(accessToken)
                ,"It doesn't throw an exception when the accessTokenString is in valid");
    }

    @Test
    void login_works(){
        UserEntity user = UserEntity.builder().userName("test").firstName("Test").lastName("Test").password("$2a$10$ZfnSi72p0GY9vXOqUTxoBuPhG3Qte9/Y5U2JrWSAx21.Ls6hmGxAu")
                .gender(GenderEnum.MALE).email("test@gmail.com").birthday(LocalDate.of(2000, 12, 12)).userRoles(Set.of(RoleEntity.builder().id(1L).name(RoleEnum.USER).build())).build();
        LoginRequest loginRequest = LoginRequest.builder().username("test").password("test").build();

        Mockito.when(userRepository.findByUserName(any(String.class))).thenReturn(user);
        Mockito.when(passwordEncoder.matches(any(String.class),any(String.class))).thenReturn(true);
        Mockito.when(accessTokenEncoder.encode(any(AccessToken.class))).thenReturn(any(String.class));

        LoginResponse actualResult = loginAdmin.login(loginRequest);
        LoginResponse expectedResult = LoginResponse.builder().build();

        assertEquals(expectedResult, actualResult);

    }

    @Test
    void login_InvalidPassword_works(){
        UserEntity user = UserEntity.builder().userName("test").firstName("Test").lastName("Test").password("$2a$10$ZfnSi72p0GY9vXOqUTxoBuPhG3Qte9/Y5U2JrWSAx21.Ls6hmGxAu")
                .gender(GenderEnum.MALE).email("test@gmail.com").birthday(LocalDate.of(2000, 12, 12)).userRoles(Set.of(RoleEntity.builder().id(1L).name(RoleEnum.USER).build())).build();
        LoginRequest loginRequest = LoginRequest.builder().username("test").password("test").build();

        Mockito.when(userRepository.findByUserName(any(String.class))).thenReturn(user);
        Mockito.when(passwordEncoder.matches(any(String.class),any(String.class))).thenReturn(false);

        var e = assertThrows(ApiRequestException.class, () -> loginAdmin.login(loginRequest));

        assertEquals("Password is incorrect", e.getMessage());


    }
}
