package individualapplication.logiclayer;

import individualapplication.datalayer.complainrepo.ComplainEntity;
import individualapplication.datalayer.complainrepo.ComplainRepository;
import individualapplication.datalayer.complainrepo.complainsubject.ComplainSubjectEntity;
import individualapplication.datalayer.complainrepo.complainsubject.ComplainSubjectRepository;
import individualapplication.datalayer.placerepo.PlaceEntity;
import individualapplication.datalayer.usermatch.buddymatchalgo.BuddyMatchAlgoEntity;
import individualapplication.datalayer.userrepo.UserEntity;
import individualapplication.datalayer.userrepo.UserRepository;
import individualapplication.datalayer.userrepo.preferencerepo.PreferenceEntity;
import individualapplication.datalayer.userrepo.roleentity.RoleEntity;
import individualapplication.logiclayer.complain.ComplainAdminImpl;
import individualapplication.logiclayer.complain.complainsubject.ComplainSubjectAdminImpl;
import individualapplication.models.buddymatch.MatchAlgorithm;
import individualapplication.models.complain.Complain;
import individualapplication.models.complain.CreateComplainRequest;
import individualapplication.models.complain.CreateComplainResponse;
import individualapplication.models.complain.GetComplainsResponse;
import individualapplication.models.complain.complainsubject.ComplainSubject;
import individualapplication.models.complain.complainsubject.GetComplainsSubjectResponse;
import individualapplication.models.places.GetPlacesResponse;
import individualapplication.models.places.Place;
import individualapplication.models.user.GetUsersResponse;
import individualapplication.models.user.User;
import individualapplication.models.user.gender.GenderEnum;
import individualapplication.models.user.preferences.Preference;
import lombok.AllArgsConstructor;
import org.junit.jupiter.api.Test;
import org.junit.jupiter.api.extension.ExtendWith;
import org.mockito.InjectMocks;
import org.mockito.Mock;
import org.mockito.Mockito;
import org.mockito.junit.jupiter.MockitoExtension;
import org.springframework.stereotype.Service;

import java.time.LocalDate;
import java.util.List;
import java.util.Optional;
import java.util.Set;

import static org.junit.jupiter.api.Assertions.assertEquals;
import static org.mockito.ArgumentMatchers.any;
import static org.mockito.Mockito.verify;

@ExtendWith(MockitoExtension.class)
@AllArgsConstructor
@Service
class ComplainAdminImplTest {
    @Mock
    private ComplainRepository complainRepositoryMock;

    @Mock
    private UserRepository userRepositoryMock;

    @Mock
    private ComplainSubjectRepository complainSubjectRepositoryMock;
    @InjectMocks
    private ComplainAdminImpl complainAdmin;

    @InjectMocks
    private ComplainSubjectAdminImpl complainSubjectAdmin;

    @Test
    void createComplain_works(){
        UserEntity complainer = UserEntity.builder().id(0L).userName("Test").firstName("Test").lastName("Test").password("Test")
                .gender(GenderEnum.MALE).email("test@gmail.com").birthday(LocalDate.of(2000, 12, 12)).userRoles(Set.of(RoleEntity.builder().build())).build();
        UserEntity accused = UserEntity.builder().id(1L).userName("Test").firstName("Test").lastName("Test").password("Test")
                .gender(GenderEnum.MALE).email("test@gmail.com").birthday(LocalDate.of(2000, 12, 12)).userRoles(Set.of(RoleEntity.builder().build())).build();
        ComplainSubjectEntity complainSubject = ComplainSubjectEntity.builder().id(0L).name("offensive language").build();

        CreateComplainRequest complainRequest = CreateComplainRequest.builder().complainerId(0L).accusedId(1L).context("Test").subjectId(0L).build();
        ComplainEntity complainEntity = ComplainEntity.builder().id(0L).complainer(complainer).accused(accused).complainSubject(complainSubject).context("Test").build();

        Mockito.when(userRepositoryMock.findById(0L)).thenReturn(Optional.ofNullable(complainer));
        Mockito.when(userRepositoryMock.findById(1L)).thenReturn(Optional.ofNullable(accused));
        Mockito.when(complainSubjectRepositoryMock.findById(0L)).thenReturn(Optional.ofNullable(complainSubject));
        Mockito.when(complainRepositoryMock.save(any(ComplainEntity.class))).thenReturn(complainEntity);

        CreateComplainResponse actualResult = complainAdmin.createComplain(complainRequest);
        CreateComplainResponse expectedResult = CreateComplainResponse.builder().id(0L).build();
        assertEquals(expectedResult, actualResult);
        verify(complainRepositoryMock).save(any(ComplainEntity.class));
    }

    @Test
    void GetAllComplains_works(){
        ComplainSubjectEntity complainSubject = ComplainSubjectEntity.builder().id(0L).name("offensive language").build();
        PlaceEntity place = PlaceEntity.builder().id(0L).name("New York").build();
        BuddyMatchAlgoEntity matchAlgorithm = BuddyMatchAlgoEntity.builder().id(0L).name("Basic Matching").build();
        PreferenceEntity preference = PreferenceEntity.builder().id(0L).gender(GenderEnum.MALE).minAge(18L).maxAge(25L).place(place).build();
        UserEntity userEntity1 = UserEntity.builder().userName("Henkie").firstName("Test").lastName("Test").password("123")
                .gender(GenderEnum.MALE).email("test@gmail.com").birthday(LocalDate.of(2000, 12, 12)).preference(preference).buddyMatchAlgo(matchAlgorithm).build();
        UserEntity userEntity2 = UserEntity.builder().userName("Joe123").firstName("John").lastName("Test").password("123")
                .gender(GenderEnum.MALE).email("joe@gmail.com").birthday(LocalDate.of(2000, 12, 12)).preference(preference).buddyMatchAlgo(matchAlgorithm).build();
        ComplainEntity complain = ComplainEntity.builder().id(0L).complainer(userEntity1).accused(userEntity2).complainSubject(complainSubject).context("test").build();

        Mockito.when(complainRepositoryMock.findAll())
                .thenReturn(List.of(complain));

        ComplainSubject complainSubject1 = ComplainSubject.builder().id(0L).name("offensive language").build();
        Place placeUser = Place.builder().id(0L).name("New York").build();
        Preference preferenceUser = Preference.builder().id(0L).gender(GenderEnum.MALE).minAge(18L).maxAge(25L).place(placeUser).build();
        MatchAlgorithm matchAlgorithm1 = MatchAlgorithm.builder().id(0L).name("Basic Matching").build();

        User user1 = User.builder().userName("Henkie").firstName("Test").lastName("Test").password("123")
                .gender(GenderEnum.MALE).email("test@gmail.com").birthday(LocalDate.of(2000, 12, 12)).preference(preferenceUser).algoChoice(matchAlgorithm1).build();
        User user2 = User.builder().userName("Joe123").firstName("John").lastName("Test").password("123")
                .gender(GenderEnum.MALE).email("joe@gmail.com").birthday(LocalDate.of(2000, 12, 12)).preference(preferenceUser).algoChoice(matchAlgorithm1).build();
        Complain complain1 = Complain.builder().id(0L).complainerId(user1).accusedId(user2).subjectId(complainSubject1).context("test").build();

        GetComplainsResponse actualResult = complainAdmin.getComplains();
        GetComplainsResponse expectedResult = GetComplainsResponse.builder().complains(List.of(complain1)).build();

        assertEquals(expectedResult, actualResult);

        verify(complainRepositoryMock).findAll();
    }

    @Test
    void getAllSubjectComplains_Works(){
        ComplainSubjectEntity complainSubjectEntity1 = ComplainSubjectEntity.builder().id(0L).name("offensive language").build();
        ComplainSubjectEntity complainSubjectEntity2 = ComplainSubjectEntity.builder().id(1L).name("threaten").build();

        ComplainSubject complainSubject1 = ComplainSubject.builder().id(0L).name("offensive language").build();
        ComplainSubject complainSubject2 = ComplainSubject.builder().id(1L).name("threaten").build();

        Mockito.when(complainSubjectRepositoryMock.findAll()).thenReturn(List.of(complainSubjectEntity1, complainSubjectEntity2));
        GetComplainsSubjectResponse actualResult = complainSubjectAdmin.getComplainSubjects();
        GetComplainsSubjectResponse expectedResult = GetComplainsSubjectResponse.builder().complainSubjects(List.of(complainSubject1, complainSubject2)).build();

        assertEquals(expectedResult, actualResult);
        verify(complainSubjectRepositoryMock).findAll();
    }


}
