package individualapplication.logiclayer;

import individualapplication.datalayer.placerepo.PlaceEntity;
import individualapplication.datalayer.usermatch.buddymatchalgo.BuddyMatchAlgoEntity;
import individualapplication.datalayer.usermatch.pendingusermatch.PendingBuddyMatchEntity;
import individualapplication.datalayer.usermatch.pendingusermatch.PendingBuddyMatchRepository;
import individualapplication.datalayer.usermatch.potential.PotentialUserMatchEntity;
import individualapplication.datalayer.userrepo.UserEntity;
import individualapplication.datalayer.userrepo.UserRepository;
import individualapplication.datalayer.userrepo.preferencerepo.PreferenceEntity;
import individualapplication.logiclayer.matchingbuddies.pending.PendingUserMatchAdminImpl;
import individualapplication.models.buddymatch.MatchAlgorithm;
import individualapplication.models.buddymatch.pendingmatch.CreatePendingMatchRequest;
import individualapplication.models.buddymatch.pendingmatch.CreatePendingMatchResponse;
import individualapplication.models.buddymatch.pendingmatch.GetPendingMatchesResponse;
import individualapplication.models.buddymatch.pendingmatch.PendingMatch;
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
class PendingUserMatchAdminImplTest {

    @Mock
    private PendingBuddyMatchRepository pendingBuddyMatchRepository;

    @Mock
    private UserRepository userRepository;

    @InjectMocks
    private PendingUserMatchAdminImpl pendingUserMatchAdmin;

    @Test
    void createPendingUserMatchResponse_works(){
        UserEntity userEntity1 = UserEntity.builder().userName("Henkie").firstName("Test").lastName("Test").password("123")
                .gender(GenderEnum.MALE).email("test@gmail.com").birthday(LocalDate.of(2000, 12, 12)).build();
        UserEntity userEntity2 = UserEntity.builder().userName("Joe123").firstName("John").lastName("Test").password("123")
                .gender(GenderEnum.MALE).email("joe@gmail.com").birthday(LocalDate.of(2000, 12, 12)).build();

        User user1 = User.builder().userName("Henkie").firstName("Test").lastName("Test").password("123")
                .gender(GenderEnum.MALE).email("test@gmail.com").birthday(LocalDate.of(2000, 12, 12)).build();
        User user2 = User.builder().userName("Joe123").firstName("John").lastName("Test").password("123")
                .gender(GenderEnum.MALE).email("joe@gmail.com").birthday(LocalDate.of(2000, 12, 12)).build();

        CreatePendingMatchRequest createPotentialUserMatchRequest = CreatePendingMatchRequest.builder().receivedUserId(user1.getId()).fromUserId(user2.getId()).build();

        PendingBuddyMatchEntity potentialUserMatch = PendingBuddyMatchEntity.builder().id(0L).userReceived(userEntity1).fromUser(userEntity2).build();

        Mockito.when(pendingBuddyMatchRepository.save(any(PendingBuddyMatchEntity.class))).thenReturn(potentialUserMatch);
        Mockito.when(userRepository.findById(createPotentialUserMatchRequest.getFromUserId())).thenReturn(Optional.ofNullable(userEntity1));
        Mockito.when(userRepository.findById(createPotentialUserMatchRequest.getReceivedUserId())).thenReturn(Optional.ofNullable(userEntity2));

        CreatePendingMatchResponse actualResult = pendingUserMatchAdmin.createPendingUserMatchResponse(createPotentialUserMatchRequest);
        CreatePendingMatchResponse expectedResult = CreatePendingMatchResponse.builder().id(0L).build();
        assertEquals(expectedResult, actualResult);
        verify(pendingBuddyMatchRepository).save(any(PendingBuddyMatchEntity.class));

    }
    @Test
    void getAllByUserReceivedId_Works(){
        PlaceEntity place = PlaceEntity.builder().id(0L).name("New York").build();
        BuddyMatchAlgoEntity matchAlgorithm = BuddyMatchAlgoEntity.builder().id(0L).name("Basic Matching").build();
        PreferenceEntity preference = PreferenceEntity.builder().id(0L).gender(GenderEnum.MALE).minAge(18L).maxAge(25L).place(place).build();
        UserEntity userEntity1 = UserEntity.builder().id(0L).userName("Henkie").firstName("Test").lastName("Test").password("123")
                .gender(GenderEnum.MALE).email("test@gmail.com").birthday(LocalDate.of(2000, 12, 12)).preference(preference).buddyMatchAlgo(matchAlgorithm).build();
        UserEntity userEntity2 = UserEntity.builder().id(1L).userName("Joe123").firstName("John").lastName("Test").password("123")
                .gender(GenderEnum.MALE).email("joe@gmail.com").birthday(LocalDate.of(2000, 12, 12)).preference(preference).buddyMatchAlgo(matchAlgorithm).build();

        PendingBuddyMatchEntity pendingBuddyMatchEntity = PendingBuddyMatchEntity.builder().userReceived(userEntity1).fromUser(userEntity2).id(0L).build();

        Place placeUser = Place.builder().id(0L).name("New York").build();
        Preference preferenceUser = Preference.builder().id(0L).gender(GenderEnum.MALE).minAge(18L).maxAge(25L).place(placeUser).build();
        MatchAlgorithm matchAlgorithm1 = MatchAlgorithm.builder().id(0L).name("Basic Matching").build();
        User user1 = User.builder().id(0L).userName("Henkie").firstName("Test").lastName("Test").password("123")
                .gender(GenderEnum.MALE).email("test@gmail.com").birthday(LocalDate.of(2000, 12, 12)).preference(preferenceUser).algoChoice(matchAlgorithm1).build();
        User user2 = User.builder().id(1L).userName("Joe123").firstName("John").lastName("Test").password("123")
                .gender(GenderEnum.MALE).email("joe@gmail.com").birthday(LocalDate.of(2000, 12, 12)).preference(preferenceUser).algoChoice(matchAlgorithm1).build();

        PendingMatch potentialUserMatch1 = PendingMatch.builder().receivedUserId(user1).fromUserId(user2).id(0L).build();

        Mockito.when(pendingBuddyMatchRepository.getPendingBuddyMatchEntitiesByUserReceivedId(0L))
                .thenReturn(List.of(pendingBuddyMatchEntity));

        GetPendingMatchesResponse actualResult = pendingUserMatchAdmin.getAllByUserReceivedId(0L);
        GetPendingMatchesResponse expectedResult = GetPendingMatchesResponse.builder().pendingUserMatches(List.of(potentialUserMatch1)).build();

        assertEquals(expectedResult, actualResult);
        verify(pendingBuddyMatchRepository).getPendingBuddyMatchEntitiesByUserReceivedId(0L);
    }

}
