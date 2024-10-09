package individualapplication.logiclayer;

import individualapplication.datalayer.placerepo.PlaceEntity;
import individualapplication.datalayer.usermatch.buddymatchalgo.BuddyMatchAlgoEntity;
import individualapplication.datalayer.usermatch.matches.MatchEntity;
import individualapplication.datalayer.usermatch.matches.MatchRepository;
import individualapplication.datalayer.usermatch.pendingusermatch.PendingBuddyMatchEntity;
import individualapplication.datalayer.userrepo.UserEntity;
import individualapplication.datalayer.userrepo.UserRepository;
import individualapplication.datalayer.userrepo.preferencerepo.PreferenceEntity;
import individualapplication.logiclayer.matchingbuddies.matches.MatchAdminImpl;
import individualapplication.models.buddymatch.MatchAlgorithm;
import individualapplication.models.buddymatch.acceptedmatch.BuddyMatch;
import individualapplication.models.buddymatch.acceptedmatch.CreateMatchRequest;
import individualapplication.models.buddymatch.acceptedmatch.CreateMatchResponse;
import individualapplication.models.buddymatch.acceptedmatch.GetMatchesResponse;
import individualapplication.models.buddymatch.pendingmatch.CreatePendingMatchRequest;
import individualapplication.models.buddymatch.pendingmatch.CreatePendingMatchResponse;
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

import static org.junit.jupiter.api.Assertions.assertEquals;
import static org.mockito.ArgumentMatchers.any;
import static org.mockito.Mockito.verify;

@ExtendWith(MockitoExtension.class)
@AllArgsConstructor
@Service
class MatchAdminImpleTest {

    @Mock
    private UserRepository userRepository;

    @Mock
    private MatchRepository matchRepository;

    @InjectMocks
    private MatchAdminImpl matchAdmin;

    @Test
    void createMatchResponse_works() {
        UserEntity userEntity1 = UserEntity.builder().userName("Henkie").firstName("Test").lastName("Test").password("123")
                .gender(GenderEnum.MALE).email("test@gmail.com").birthday(LocalDate.of(2000, 12, 12)).build();
        UserEntity userEntity2 = UserEntity.builder().userName("Joe123").firstName("John").lastName("Test").password("123")
                .gender(GenderEnum.MALE).email("joe@gmail.com").birthday(LocalDate.of(2000, 12, 12)).build();

        User user1 = User.builder().userName("Henkie").firstName("Test").lastName("Test").password("123")
                .gender(GenderEnum.MALE).email("test@gmail.com").birthday(LocalDate.of(2000, 12, 12)).build();
        User user2 = User.builder().userName("Joe123").firstName("John").lastName("Test").password("123")
                .gender(GenderEnum.MALE).email("joe@gmail.com").birthday(LocalDate.of(2000, 12, 12)).build();

        CreateMatchRequest createUserMatchRequest = CreateMatchRequest.builder().buddy1(user1).buddy2(user2).build();

        MatchEntity match = MatchEntity.builder().id(0L).buddy1(userEntity1).buddy2(userEntity2).build();

        Mockito.when(matchRepository.save(any(MatchEntity.class))).thenReturn(match);
        Mockito.when(userRepository.findById(createUserMatchRequest.getBuddy1().getId())).thenReturn(Optional.ofNullable(userEntity1));
        Mockito.when(userRepository.findById(createUserMatchRequest.getBuddy2().getId())).thenReturn(Optional.ofNullable(userEntity2));

        CreateMatchResponse actualResult = matchAdmin.createMatchResponse(createUserMatchRequest);
        CreateMatchResponse expectedResult = CreateMatchResponse.builder().id(0L).build();
        assertEquals(expectedResult, actualResult);
        verify(matchRepository).save(any(MatchEntity.class));

    }

    @Test
    void getAllMatchesByLoggedInUser_Works() {

        PlaceEntity place = PlaceEntity.builder().id(0L).name("New York").build();
        BuddyMatchAlgoEntity matchAlgorithm = BuddyMatchAlgoEntity.builder().id(0L).name("Basic Matching").build();
        PreferenceEntity preference = PreferenceEntity.builder().id(0L).gender(GenderEnum.MALE).minAge(18L).maxAge(25L).place(place).build();
        UserEntity userEntity1 = UserEntity.builder().id(0L).userName("Henkie").firstName("Test").lastName("Test").password("123")
                .gender(GenderEnum.MALE).email("test@gmail.com").birthday(LocalDate.of(2000, 12, 12)).preference(preference).buddyMatchAlgo(matchAlgorithm).build();
        UserEntity userEntity2 = UserEntity.builder().id(1L).userName("Joe123").firstName("John").lastName("Test").password("123")
                .gender(GenderEnum.MALE).email("joe@gmail.com").birthday(LocalDate.of(2000, 12, 12)).preference(preference).buddyMatchAlgo(matchAlgorithm).build();

        MatchEntity buddyMatch = MatchEntity.builder().buddy1(userEntity1).buddy2(userEntity2).id(0L).build();

        Place placeUser = Place.builder().id(0L).name("New York").build();
        Preference preferenceUser = Preference.builder().id(0L).gender(GenderEnum.MALE).minAge(18L).maxAge(25L).place(placeUser).build();
        MatchAlgorithm matchAlgorithm1 = MatchAlgorithm.builder().id(0L).name("Basic Matching").build();
        User user1 = User.builder().id(0L).userName("Henkie").firstName("Test").lastName("Test").password("123")
                .gender(GenderEnum.MALE).email("test@gmail.com").birthday(LocalDate.of(2000, 12, 12)).preference(preferenceUser).algoChoice(matchAlgorithm1).build();
        User user2 = User.builder().id(1L).userName("Joe123").firstName("John").lastName("Test").password("123")
                .gender(GenderEnum.MALE).email("joe@gmail.com").birthday(LocalDate.of(2000, 12, 12)).preference(preferenceUser).algoChoice(matchAlgorithm1).build();

        BuddyMatch buddyMatch1 = BuddyMatch.builder().buddy1(user1).buddy2(user2).id(0L).build();

        Mockito.when(matchRepository.getAllByBuddy1_IdOrBuddy2_Id(0L, 0L))
                .thenReturn(List.of(buddyMatch));

        GetMatchesResponse actualResult = matchAdmin.getAllByUserLoggedInId(0L);
        GetMatchesResponse expectedResult = GetMatchesResponse.builder().buddyMatches(List.of(buddyMatch1)).build();

        assertEquals(expectedResult, actualResult);
        verify(matchRepository).getAllByBuddy1_IdOrBuddy2_Id(0L,0L);

    }
}
