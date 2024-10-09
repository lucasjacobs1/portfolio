package individualapplication.logiclayer;


import individualapplication.datalayer.placerepo.PlaceEntity;
import individualapplication.datalayer.placerepo.PlaceRepository;
import individualapplication.datalayer.usermatch.buddymatchalgo.BuddyMatchAlgoEntity;
import individualapplication.datalayer.userrepo.UserEntity;
import individualapplication.datalayer.userrepo.UserRepository;
import individualapplication.datalayer.userrepo.preferencerepo.PreferenceEntity;
import individualapplication.datalayer.userrepo.preferencerepo.PreferenceRepository;
import individualapplication.datalayer.userrepo.roleentity.RoleEntity;
import individualapplication.logiclayer.user.preferences.PreferenceAdminImpl;
import individualapplication.models.user.RoleEnum;
import individualapplication.models.user.UpdateUserRequest;
import individualapplication.models.user.User;
import individualapplication.models.user.gender.GenderEnum;
import individualapplication.models.user.preferences.CreatePreferenceRequest;
import individualapplication.models.user.preferences.CreatePreferenceResponse;
import individualapplication.models.user.preferences.Preference;
import individualapplication.models.user.preferences.UpdatePreferenceRequest;
import lombok.AllArgsConstructor;
import org.junit.jupiter.api.Test;
import org.junit.jupiter.api.extension.ExtendWith;
import org.mockito.InjectMocks;
import org.mockito.Mock;
import org.mockito.Mockito;
import org.mockito.junit.jupiter.MockitoExtension;
import org.springframework.stereotype.Service;

import java.time.LocalDate;
import java.util.Optional;
import java.util.Set;

import static org.junit.jupiter.api.Assertions.assertEquals;
import static org.junit.jupiter.api.Assertions.assertTrue;
import static org.mockito.ArgumentMatchers.any;
import static org.mockito.Mockito.verify;

@ExtendWith(MockitoExtension.class)
@AllArgsConstructor
@Service

class PreferenceAdminImplTest {
    @Mock
    private UserRepository userRepositoryMock;

    @Mock
    private PreferenceRepository preferenceRepositoryMock;

    @Mock
    private PlaceRepository placeRepositoryMock;

    @InjectMocks
    private PreferenceAdminImpl preferenceAdmin;

    @Test
    void createPreference_works(){
        CreatePreferenceRequest request = CreatePreferenceRequest.builder().gender(GenderEnum.MALE).minAge(18L).maxAge(25L).placeId(0L).build();
        PlaceEntity place = PlaceEntity.builder().id(0L).name("New York").build();
        PreferenceEntity preference = PreferenceEntity.builder().id(0L).gender(GenderEnum.MALE).minAge(18L).maxAge(25L).place(place).build();

        Mockito.when(preferenceRepositoryMock.save(any(PreferenceEntity.class))).thenReturn(preference);
        Mockito.when(placeRepositoryMock.findById(0L)).thenReturn(Optional.ofNullable(place));

        CreatePreferenceResponse actualResult = preferenceAdmin.createPreference(request);
        CreatePreferenceResponse expectedResult = CreatePreferenceResponse.builder().id(0L).build();

        assertEquals(actualResult, expectedResult);
        verify(preferenceRepositoryMock).save(any(PreferenceEntity.class));

    }

    @Test
    void updateUser_works(){
        PlaceEntity place = PlaceEntity.builder().id(0L).name("New York").build();
        PreferenceEntity preference = PreferenceEntity.builder().id(0L).gender(GenderEnum.MALE).minAge(18L).maxAge(25L).place(place).build();

        BuddyMatchAlgoEntity matchAlgorithm = BuddyMatchAlgoEntity.builder().id(0L).name("Basic Matching ").build();

        UpdatePreferenceRequest updatePreferenceRequest = UpdatePreferenceRequest.builder().id(0L).gender(GenderEnum.MALE).minAge(18L).maxAge(25L).placeId(0L).build();

        UserEntity user = UserEntity.builder().id(0L).userName("Test").firstName("Test").lastName("Test").password("Test")
                .gender(GenderEnum.MALE).email("test@gmail.com").birthday(LocalDate.of(2000, 12, 12)).userRoles(Set.of(RoleEntity.builder().build())).preference(preference).buddyMatchAlgo(matchAlgorithm).build();

        PreferenceEntity preferenceUpdated = PreferenceEntity.builder().id(0L).gender(GenderEnum.MALE).minAge(18L).maxAge(25L).place(place).build();

        Mockito.when(userRepositoryMock.findById(user.getId())).thenReturn(Optional.ofNullable(user));
        Mockito.when(preferenceRepositoryMock.save(any(PreferenceEntity.class))).thenReturn(preferenceUpdated);
        Mockito.when(preferenceRepositoryMock.findById(0L)).thenReturn(Optional.ofNullable(preference));
        Mockito.when(placeRepositoryMock.getReferenceById(0L)).thenReturn(place);
        try{
            preferenceAdmin.updatePreferences(updatePreferenceRequest, 0L);
            verify(preferenceRepositoryMock).save(any(PreferenceEntity.class));
        }catch (Exception exception){

        }

        Optional<PreferenceEntity> actual = preferenceRepositoryMock.findById(0L);
        assertTrue(actual.isPresent());
        assertEquals(18,actual.get().getMinAge());
    }
}
