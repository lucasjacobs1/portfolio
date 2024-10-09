package individualapplication.logiclayer;

import individualapplication.datalayer.placerepo.PlaceEntity;
import individualapplication.datalayer.usermatch.buddymatchalgo.BuddyMatchAlgoEntity;
import individualapplication.datalayer.userrepo.preferencerepo.PreferenceEntity;
import individualapplication.datalayer.userrepo.preferencerepo.PreferenceRepository;
import individualapplication.datalayer.userrepo.roleentity.RoleEntity;
import individualapplication.datalayer.userrepo.UserEntity;
import individualapplication.datalayer.userrepo.UserRepository;
import static org.junit.jupiter.api.Assertions.*;
import static org.mockito.ArgumentMatchers.any;
import static org.mockito.Mockito.*;

import individualapplication.datalayer.userrepo.roleentity.RoleRepository;
import individualapplication.logiclayer.execptions.InvalidEmailException;
import individualapplication.logiclayer.execptions.InvalidUsernameException;
import individualapplication.logiclayer.user.UserAdminImpl;
import individualapplication.logiclayer.execptions.InvalidBirthdayException;
import individualapplication.models.buddymatch.MatchAlgorithm;
import individualapplication.models.places.Place;
import individualapplication.models.user.*;
import individualapplication.models.user.gender.GenderEnum;
import individualapplication.models.user.preferences.Preference;
import lombok.AllArgsConstructor;
import org.hibernate.mapping.Any;
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
import java.util.Optional;
import java.util.Set;

@ExtendWith(MockitoExtension.class)
@AllArgsConstructor
@Service
class UserAdminImplTest {
    @Mock
    private UserRepository UserRepositoryMock;


    @Mock
    private RoleRepository roleRepository;

    @InjectMocks
    private UserAdminImpl userAdmin;

    @Mock
    private PasswordEncoder passwordEncoder;

    @Mock
    private PreferenceRepository preferenceRepository;

    @Test
    void GetAllUsers_works(){
        PlaceEntity place = PlaceEntity.builder().id(0L).name("New York").build();
        BuddyMatchAlgoEntity matchAlgorithm = BuddyMatchAlgoEntity.builder().id(0L).name("Basic Matching").build();
        PreferenceEntity preference = PreferenceEntity.builder().id(0L).gender(GenderEnum.MALE).minAge(18L).maxAge(25L).place(place).build();
        UserEntity userEntity1 = UserEntity.builder().userName("Henkie").firstName("Test").lastName("Test").password("123")
                .gender(GenderEnum.MALE).email("test@gmail.com").birthday(LocalDate.of(2000, 12, 12)).preference(preference).buddyMatchAlgo(matchAlgorithm).build();
        UserEntity userEntity2 = UserEntity.builder().userName("Joe123").firstName("John").lastName("Test").password("123")
                .gender(GenderEnum.MALE).email("joe@gmail.com").birthday(LocalDate.of(2000, 12, 12)).preference(preference).buddyMatchAlgo(matchAlgorithm).build();

        Mockito.when(UserRepositoryMock.findAll())
                .thenReturn(List.of(userEntity1, userEntity2));

        GetUsersResponse actualResult = userAdmin.getUsers();
        Place placeUser = Place.builder().id(0L).name("New York").build();
        Preference preferenceUser = Preference.builder().id(0L).gender(GenderEnum.MALE).minAge(18L).maxAge(25L).place(placeUser).build();
        MatchAlgorithm matchAlgorithm1 = MatchAlgorithm.builder().id(0L).name("Basic Matching").build();
        User user1 = User.builder().userName("Henkie").firstName("Test").lastName("Test").password("123")
                .gender(GenderEnum.MALE).email("test@gmail.com").birthday(LocalDate.of(2000, 12, 12)).preference(preferenceUser).algoChoice(matchAlgorithm1).build();
        User user2 = User.builder().userName("Joe123").firstName("John").lastName("Test").password("123")
                .gender(GenderEnum.MALE).email("joe@gmail.com").birthday(LocalDate.of(2000, 12, 12)).preference(preferenceUser).algoChoice(matchAlgorithm1).build();

        GetUsersResponse expectedResult = GetUsersResponse.builder().users(List.of(user1, user2)).build();

        assertEquals(expectedResult, actualResult);

        verify(UserRepositoryMock).findAll();
    }

    @Test
    void createUserWithInvalidBirthday_works(){
        //arrange
        CreateUserRequest userRequest = CreateUserRequest.builder().userName("Test").firstName("Test").lastName("Test").password("Test")
                .gender(GenderEnum.MALE).email("test@gmail.com").birthday(LocalDate.now().minusYears(10)).build();
        //act
        var e = assertThrows(InvalidBirthdayException.class, () -> userAdmin.createUser(userRequest));
        //assert
        assertEquals(HttpStatus.BAD_REQUEST+" \"You need to be at least 18 years old\"", e.getMessage());
    }

    @Test
    void createUserWithWrongUsername_works(){
        //arrange
        CreateUserRequest userRequest = CreateUserRequest.builder().userName("").firstName("Test").lastName("Test").password("Test")
                .gender(GenderEnum.MALE).email("test@gmail.com").birthday(LocalDate.now().minusYears(19)).build();
        //act
        var e = assertThrows(InvalidUsernameException.class, () -> userAdmin.createUser(userRequest));
        //assert
        assertEquals(HttpStatus.BAD_REQUEST+" \"Username is not valid\"", e.getMessage());
    }

    @Test
    void createUserWithWrongEmail_works(){
        //arrange
        CreateUserRequest userRequest = CreateUserRequest.builder().userName("test").firstName("Test").lastName("Test").password("Test")
                .gender(GenderEnum.MALE).email("testgmail.com").birthday(LocalDate.now().minusYears(19)).build();
        //act
        var e = assertThrows(InvalidEmailException.class, () -> userAdmin.createUser(userRequest));
        //assert
        assertEquals(HttpStatus.BAD_REQUEST+" \"Email is not valid\"", e.getMessage());
    }

    @Test
    void createUser_Works(){
        CreateUserRequest userRequest = CreateUserRequest.builder().userName("Test").firstName("Test").lastName("Test").password("Test")
                .gender(GenderEnum.MALE).email("test@gmail.com").birthday(LocalDate.of(2000, 12, 12)).role(RoleEnum.ADMIN).build();
        UserEntity user = UserEntity.builder().userName("Test").firstName("Test").lastName("Test").password("Test")
                .gender(GenderEnum.MALE).email("test@gmail.com").birthday(LocalDate.of(2000, 12, 12)).userRoles(Set.of(RoleEntity.builder().build())).build();

        Mockito.when(passwordEncoder.encode("Test")).thenReturn("Test");
        Mockito.when(UserRepositoryMock.existsByUserName("Test")).thenReturn(false);
        Mockito.when(UserRepositoryMock.save(any(UserEntity.class))).thenReturn(user);
        Mockito.when(preferenceRepository.save(any(PreferenceEntity.class))).thenReturn(any(PreferenceEntity.class));
        CreateUserResponse actualResult = userAdmin.createUser(userRequest);
        CreateUserResponse expectedResult = CreateUserResponse.builder().build();
        assertEquals(expectedResult, actualResult);
        verify(UserRepositoryMock).save(any(UserEntity.class));
    }

    @Test
    void updateUser_works(){
        PlaceEntity place = PlaceEntity.builder().id(0L).name("New York").build();
        PreferenceEntity preference = PreferenceEntity.builder().id(0L).gender(GenderEnum.MALE).minAge(18L).maxAge(25L).place(place).build();
        BuddyMatchAlgoEntity matchAlgorithm = BuddyMatchAlgoEntity.builder().id(0L).name("Basic Matching ").build();

        UpdateUserRequest request = UpdateUserRequest.builder().id(0L).userName("NewTest").email("test1@gmail.com").password("Test").build();
        UserEntity user = UserEntity.builder().id(0L).userName("Test").firstName("Test").lastName("Test").password("Test")
                .gender(GenderEnum.MALE).email("test@gmail.com").birthday(LocalDate.of(2000, 12, 12)).userRoles(Set.of(RoleEntity.builder().build())).preference(preference).buddyMatchAlgo(matchAlgorithm).build();
        UserEntity userUpdate = UserEntity.builder().id(0L).userName("test").firstName("Test").lastName("Test").password("Test")
                .gender(GenderEnum.MALE).email("test@gmail.com").birthday(LocalDate.of(2000, 12, 12)).userRoles(Set.of(RoleEntity.builder().build())).preference(preference).buddyMatchAlgo(matchAlgorithm).build();
        RoleEntity role = RoleEntity.builder().id(0L).user(user).name(RoleEnum.USER).build();

        Mockito.when(UserRepositoryMock.findById(request.getId())).thenReturn(Optional.ofNullable(user));
        Mockito.when(UserRepositoryMock.save(any(UserEntity.class))).thenReturn(userUpdate);
        Mockito.when(passwordEncoder.encode("Test")).thenReturn("Test");
        Mockito.when(roleRepository.getRoleEntityByUserId(0L)).thenReturn(role);

        try{
            userAdmin.updateUser(request);
            verify(UserRepositoryMock).save(any(UserEntity.class));
        }catch (Exception exception){

        }

        Optional<User> actual = userAdmin.getUserById(0L);
        assertTrue(actual.isPresent());
        assertEquals("NewTest",actual.get().getUserName());
    }

    @Test
    void GetAllUsersByGender_works(){
        PlaceEntity place = PlaceEntity.builder().id(0L).name("New York").build();
        BuddyMatchAlgoEntity matchAlgorithm = BuddyMatchAlgoEntity.builder().id(0L).name("Basic Matching").build();
        PreferenceEntity preference = PreferenceEntity.builder().id(0L).gender(GenderEnum.MALE).minAge(18L).maxAge(25L).place(place).build();
        UserEntity userEntity1 = UserEntity.builder().userName("Henkie").firstName("Test").lastName("Test").password("123")
                .gender(GenderEnum.MALE).email("test@gmail.com").birthday(LocalDate.of(2000, 12, 12)).preference(preference).buddyMatchAlgo(matchAlgorithm).build();
        UserEntity userEntity2 = UserEntity.builder().userName("Joe123").firstName("John").lastName("Test").password("123")
                .gender(GenderEnum.MALE).email("joe@gmail.com").birthday(LocalDate.of(2000, 12, 12)).preference(preference).buddyMatchAlgo(matchAlgorithm).build();

        Mockito.when(UserRepositoryMock.getUserEntitiesByGender(GenderEnum.MALE))
                .thenReturn(List.of(userEntity1, userEntity2));

        GetUsersResponse actualResult = userAdmin.getUsersByGender(GenderEnum.MALE);
        Place placeUser = Place.builder().id(0L).name("New York").build();
        Preference preferenceUser = Preference.builder().id(0L).gender(GenderEnum.MALE).minAge(18L).maxAge(25L).place(placeUser).build();
        MatchAlgorithm matchAlgorithm1 = MatchAlgorithm.builder().id(0L).name("Basic Matching").build();
        User user1 = User.builder().userName("Henkie").firstName("Test").lastName("Test").password("123")
                .gender(GenderEnum.MALE).email("test@gmail.com").birthday(LocalDate.of(2000, 12, 12)).preference(preferenceUser).algoChoice(matchAlgorithm1).build();
        User user2 = User.builder().userName("Joe123").firstName("John").lastName("Test").password("123")
                .gender(GenderEnum.MALE).email("joe@gmail.com").birthday(LocalDate.of(2000, 12, 12)).preference(preferenceUser).algoChoice(matchAlgorithm1).build();

        GetUsersResponse expectedResult = GetUsersResponse.builder().users(List.of(user1, user2)).build();

        assertEquals(expectedResult, actualResult);

        verify(UserRepositoryMock).getUserEntitiesByGender(GenderEnum.MALE);
    }

    @Test
    void DeletesUserAndPreferenceByUserId_Works() {
        PreferenceEntity preference = PreferenceEntity.builder().id(2L).build();
        Long userId = 1L;
        UserEntity user =  UserEntity.builder().preference(preference).build();

        when(UserRepositoryMock.findById(userId)).thenReturn(Optional.of(user));

        userAdmin.deleteUser(userId);

        verify(UserRepositoryMock).deleteById(userId);
        verify(preferenceRepository).deleteById(preference.getId());
    }
}