package individualapplication.logiclayer;

import individualapplication.datalayer.placerepo.PlaceEntity;
import individualapplication.datalayer.usermatch.buddymatchalgo.BuddyMatchAlgoEntity;
import individualapplication.datalayer.usermatch.deniedusermatch.DeniedUserMatchEntity;
import individualapplication.datalayer.usermatch.deniedusermatch.DeniedUserMatchRepository;
import individualapplication.datalayer.usermatch.pendingusermatch.PendingBuddyMatchEntity;
import individualapplication.datalayer.usermatch.pendingusermatch.PendingBuddyMatchRepository;
import individualapplication.datalayer.usermatch.potential.PotentialUserMatchEntity;
import individualapplication.datalayer.usermatch.potential.PotentialUserMatchRepository;
import individualapplication.datalayer.userrepo.UserEntity;
import individualapplication.datalayer.userrepo.UserRepository;
import individualapplication.datalayer.userrepo.preferencerepo.PreferenceEntity;
import individualapplication.logiclayer.matchingbuddies.PotentialMatchUsersImpl;
import individualapplication.models.buddymatch.MatchAlgorithm;
import individualapplication.models.buddymatch.potentialusermatch.CreatePotentialUserMatchRequest;
import individualapplication.models.buddymatch.potentialusermatch.CreatePotentialUserMatchResponse;
import individualapplication.models.buddymatch.potentialusermatch.GetPotentialUserMatchesResponse;
import individualapplication.models.buddymatch.potentialusermatch.PotentialUserMatch;
import individualapplication.models.places.Place;
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
class PotentialMatchUsersImplTest {

    @Mock
    private  PotentialUserMatchRepository potentialUserMatchRepository;
    @Mock
    private  UserRepository userRepository;
    @Mock
    private  DeniedUserMatchRepository deniedUserMatchRepository;

    @Mock
    private PendingBuddyMatchRepository pendingBuddyMatchRepository;

    @InjectMocks
    private  PotentialMatchUsersImpl potentialMatchUsers;


    @Test
    void createPotentialUserMatchResponse_works(){
        UserEntity userEntity1 = UserEntity.builder().userName("Henkie").firstName("Test").lastName("Test").password("123")
                .gender(GenderEnum.MALE).email("test@gmail.com").birthday(LocalDate.of(2000, 12, 12)).build();
        UserEntity userEntity2 = UserEntity.builder().userName("Joe123").firstName("John").lastName("Test").password("123")
                .gender(GenderEnum.MALE).email("joe@gmail.com").birthday(LocalDate.of(2000, 12, 12)).build();

        User user1 = User.builder().userName("Henkie").firstName("Test").lastName("Test").password("123")
                .gender(GenderEnum.MALE).email("test@gmail.com").birthday(LocalDate.of(2000, 12, 12)).build();
        User user2 = User.builder().userName("Joe123").firstName("John").lastName("Test").password("123")
                .gender(GenderEnum.MALE).email("joe@gmail.com").birthday(LocalDate.of(2000, 12, 12)).build();

        CreatePotentialUserMatchRequest createPotentialUserMatchRequest = CreatePotentialUserMatchRequest.builder().userReceived(user1).userView(user2).matchScore(1.0).build();

        PotentialUserMatchEntity potentialUserMatch = PotentialUserMatchEntity.builder().id(0L).userReceived(userEntity1).userView(userEntity2).matchScore(1.0).build();

        Mockito.when(potentialUserMatchRepository.save(any(PotentialUserMatchEntity.class))).thenReturn(potentialUserMatch);
        Mockito.when(userRepository.findById(createPotentialUserMatchRequest.getUserReceived().getId())).thenReturn(Optional.ofNullable(userEntity1));
        Mockito.when(userRepository.findById(createPotentialUserMatchRequest.getUserView().getId())).thenReturn(Optional.ofNullable(userEntity2));

        CreatePotentialUserMatchResponse actualResult = potentialMatchUsers.createPotentialUserMatchResponse(createPotentialUserMatchRequest);
        CreatePotentialUserMatchResponse expectedResult = CreatePotentialUserMatchResponse.builder().id(0L).build();
        assertEquals(expectedResult, actualResult);
        verify(potentialUserMatchRepository).save(any(PotentialUserMatchEntity.class));

    }

    @Test
    void returnPotentialUserMatches_works(){
        PlaceEntity place = PlaceEntity.builder().id(0L).name("New York").build();
        BuddyMatchAlgoEntity matchAlgorithm = BuddyMatchAlgoEntity.builder().id(0L).name("Basic Matching").build();
        PreferenceEntity preference = PreferenceEntity.builder().id(0L).gender(GenderEnum.MALE).minAge(18L).maxAge(25L).place(place).build();
        UserEntity userEntity1 = UserEntity.builder().id(0L).userName("Henkie").firstName("Test").lastName("Test").password("123")
                .gender(GenderEnum.MALE).email("test@gmail.com").birthday(LocalDate.of(2000, 12, 12)).preference(preference).buddyMatchAlgo(matchAlgorithm).build();
        UserEntity userEntity2 = UserEntity.builder().id(1L).userName("Joe123").firstName("John").lastName("Test").password("123")
                .gender(GenderEnum.MALE).email("joe@gmail.com").birthday(LocalDate.of(2000, 12, 12)).preference(preference).buddyMatchAlgo(matchAlgorithm).build();
        UserEntity userEntity3 = UserEntity.builder().id(2L).userName("Joe123").firstName("test2").lastName("test2").password("123")
                .gender(GenderEnum.MALE).email("test2@gmail.com").birthday(LocalDate.of(2000, 12, 12)).preference(preference).buddyMatchAlgo(matchAlgorithm).build();

        Mockito.when(userRepository.findAll())
                .thenReturn(List.of(userEntity1, userEntity2, userEntity3));
        Mockito.when(deniedUserMatchRepository.getDeniedUserMatchEntitiesByUserId(0L))
                .thenReturn(List.of(DeniedUserMatchEntity.builder().id(0L).user(userEntity3).denied_user(userEntity3).build()));
        Mockito.when(pendingBuddyMatchRepository.getPendingBuddyMatchEntitiesByUserReceivedId(0L))
                .thenReturn(List.of(PendingBuddyMatchEntity.builder().id(0L).fromUser(userEntity3).userReceived(userEntity3).build()));

        Place placeUser = Place.builder().id(0L).name("New York").build();
        Preference preferenceUser = Preference.builder().id(0L).gender(GenderEnum.MALE).minAge(18L).maxAge(25L).place(placeUser).build();
        MatchAlgorithm matchAlgorithm1 = MatchAlgorithm.builder().id(0L).name("Basic Matching").build();
        User user1 = User.builder().id(0L).userName("Henkie").firstName("Test").lastName("Test").password("123")
                .gender(GenderEnum.MALE).email("test@gmail.com").birthday(LocalDate.of(2000, 12, 12)).preference(preferenceUser).algoChoice(matchAlgorithm1).build();
        User user2 = User.builder().id(1L).userName("Joe123").firstName("John").lastName("Test").password("123")
                .gender(GenderEnum.MALE).email("joe@gmail.com").birthday(LocalDate.of(2000, 12, 12)).preference(preferenceUser).algoChoice(matchAlgorithm1).build();


        PotentialUserMatch potentialUserMatch = PotentialUserMatch.builder().matchScore(0.0).userReceived(user1).userView(user2).build();

        List<PotentialUserMatch> actualResult = potentialMatchUsers.returnPotentialUserMatches(user1);
        List<PotentialUserMatch> expectedResult = List.of(potentialUserMatch);

        assertEquals(expectedResult, actualResult);
    }

    @Test
    void getPotentialUserMatchesByReceivedId_Works(){
        PlaceEntity place = PlaceEntity.builder().id(0L).name("New York").build();
        BuddyMatchAlgoEntity matchAlgorithm = BuddyMatchAlgoEntity.builder().id(0L).name("Basic Matching").build();
        PreferenceEntity preference = PreferenceEntity.builder().id(0L).gender(GenderEnum.MALE).minAge(18L).maxAge(25L).place(place).build();
        UserEntity userEntity1 = UserEntity.builder().id(0L).userName("Henkie").firstName("Test").lastName("Test").password("123")
                .gender(GenderEnum.MALE).email("test@gmail.com").birthday(LocalDate.of(2000, 12, 12)).preference(preference).buddyMatchAlgo(matchAlgorithm).build();
        UserEntity userEntity2 = UserEntity.builder().id(1L).userName("Joe123").firstName("John").lastName("Test").password("123")
                .gender(GenderEnum.MALE).email("joe@gmail.com").birthday(LocalDate.of(2000, 12, 12)).preference(preference).buddyMatchAlgo(matchAlgorithm).build();

        PotentialUserMatchEntity potentialUserMatch = PotentialUserMatchEntity.builder().userReceived(userEntity1).userView(userEntity2).id(0L).matchScore(0.0).build();

        Place placeUser = Place.builder().id(0L).name("New York").build();
        Preference preferenceUser = Preference.builder().id(0L).gender(GenderEnum.MALE).minAge(18L).maxAge(25L).place(placeUser).build();
        MatchAlgorithm matchAlgorithm1 = MatchAlgorithm.builder().id(0L).name("Basic Matching").build();
        User user1 = User.builder().id(0L).userName("Henkie").firstName("Test").lastName("Test").password("123")
                .gender(GenderEnum.MALE).email("test@gmail.com").birthday(LocalDate.of(2000, 12, 12)).preference(preferenceUser).algoChoice(matchAlgorithm1).build();
        User user2 = User.builder().id(1L).userName("Joe123").firstName("John").lastName("Test").password("123")
                .gender(GenderEnum.MALE).email("joe@gmail.com").birthday(LocalDate.of(2000, 12, 12)).preference(preferenceUser).algoChoice(matchAlgorithm1).build();

        PotentialUserMatch potentialUserMatch1 = PotentialUserMatch.builder().userReceived(user1).userView(user2).matchScore(0.0).id(0L).build();

        Mockito.when(potentialUserMatchRepository.getPotentialUserMatchEntitiesByUserReceivedId(0L))
                .thenReturn(List.of(potentialUserMatch));

        GetPotentialUserMatchesResponse actualResult = potentialMatchUsers.getPotentialUserMatchesByReceivedId(0L);
        GetPotentialUserMatchesResponse expectedResult = GetPotentialUserMatchesResponse.builder().potentialUserMatches(List.of(potentialUserMatch1)).build();

        assertEquals(expectedResult, actualResult);
        verify(potentialUserMatchRepository).getPotentialUserMatchEntitiesByUserReceivedId(0L);
    }

    @Test
    void deleteAllPotentialUserMatchByReceivedUserId_Works() {
        Long receivedUserId = 1L;

        Mockito.doNothing().when(potentialUserMatchRepository).deleteAllByUserReceivedId(receivedUserId);

        potentialMatchUsers.deleteAllPotentialUserMatchByReceivedUserId(receivedUserId);

        Mockito.verify(potentialUserMatchRepository).deleteAllByUserReceivedId(receivedUserId);
    }

    @Test
    void deletePotentialUsersMatch_Works() {
        Long receivedUserId = 1L;

        Mockito.doNothing().when(potentialUserMatchRepository).deleteById(receivedUserId);

        potentialMatchUsers.deletePotentialUsersMatch(receivedUserId);

        Mockito.verify(potentialUserMatchRepository).deleteById(receivedUserId);
    }
}

