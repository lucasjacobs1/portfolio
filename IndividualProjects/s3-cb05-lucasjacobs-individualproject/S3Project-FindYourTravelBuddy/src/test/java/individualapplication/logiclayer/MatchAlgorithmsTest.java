package individualapplication.logiclayer;

import individualapplication.datalayer.placerepo.PlaceEntity;
import individualapplication.datalayer.usermatch.buddymatchalgo.BuddyMatchAlgoEntity;
import individualapplication.datalayer.userrepo.UserEntity;
import individualapplication.datalayer.userrepo.preferencerepo.PreferenceEntity;
import individualapplication.logiclayer.matchingbuddies.MatchAlgorithms;
import individualapplication.logiclayer.matchingbuddies.algorithms.BasicMatchingAlgorithm;
import individualapplication.logiclayer.matchingbuddies.algorithms.NoPreferenceMatchingAlgorithm;
import individualapplication.logiclayer.matchingbuddies.algorithms.StandardMatchAlgorithm;
import individualapplication.models.buddymatch.MatchAlgorithm;
import individualapplication.models.buddymatch.potentialusermatch.PotentialUserMatch;
import individualapplication.models.places.Place;
import individualapplication.models.user.GetUsersResponse;
import individualapplication.models.user.User;
import individualapplication.models.user.gender.GenderEnum;
import individualapplication.models.user.preferences.Preference;
import lombok.AllArgsConstructor;
import org.junit.jupiter.api.Test;
import org.junit.jupiter.api.extension.ExtendWith;
import org.mockito.Mock;
import org.mockito.Mockito;
import org.mockito.junit.jupiter.MockitoExtension;
import org.springframework.stereotype.Service;

import java.time.LocalDate;
import java.util.List;

import static org.junit.jupiter.api.Assertions.assertEquals;
import static org.mockito.Mockito.verify;

@ExtendWith(MockitoExtension.class)
@AllArgsConstructor
@Service
class MatchAlgorithmsTest {


    @Test
    void BasicMatchingAlgorithm_Works(){

        Place placeUser = Place.builder().id(0L).name("New York").build();
        Preference preferenceUser = Preference.builder().id(0L).gender(GenderEnum.MALE).minAge(18L).maxAge(25L).place(placeUser).build();
        MatchAlgorithm matchAlgorithm1 = MatchAlgorithm.builder().id(0L).name("Basic Matching").build();
        User user1 = User.builder().userName("Henkie").firstName("Test").lastName("Test").password("123")
                .gender(GenderEnum.MALE).email("test@gmail.com").birthday(LocalDate.of(2000, 12, 12)).preference(preferenceUser).algoChoice(matchAlgorithm1).build();
        User user2 = User.builder().userName("Joe123").firstName("John").lastName("Test").password("123")
                .gender(GenderEnum.MALE).email("joe@gmail.com").birthday(LocalDate.of(2000, 12, 12)).preference(preferenceUser).algoChoice(matchAlgorithm1).build();

        PotentialUserMatch expectedMatch = PotentialUserMatch.builder().userView(user1).userReceived(user2).matchScore(1.0).build();
        PotentialUserMatch potentialUserMatch = PotentialUserMatch.builder().userView(user1).userReceived(user2).matchScore(0.0).build();
        MatchAlgorithm matchAlgorithm = MatchAlgorithm.builder().id(0L).name("test").potentialUserMatch(List.of(potentialUserMatch)).build();
        MatchAlgorithms matchAlgorithms = new BasicMatchingAlgorithm();


        List<PotentialUserMatch> actualResult = matchAlgorithms.getUserList(matchAlgorithm);
        List<PotentialUserMatch> expectedResult = List.of(expectedMatch);

        assertEquals(expectedResult, actualResult);

    }

    @Test
    void BasicMatchingAlgorithm_Age_Works(){

        Place placeUser = Place.builder().id(0L).name("New York").build();
        Preference preferenceUser = Preference.builder().id(0L).gender(GenderEnum.MALE).minAge(18L).maxAge(25L).place(placeUser).build();

        MatchAlgorithm matchAlgorithm1 = MatchAlgorithm.builder().id(0L).name("Basic Matching").build();
        User user1 = User.builder().userName("Henkie").firstName("Test").lastName("Test").password("123")
                .gender(GenderEnum.MALE).email("test@gmail.com").birthday(LocalDate.of(2000, 12, 12)).preference(preferenceUser).algoChoice(matchAlgorithm1).build();
        User user2 = User.builder().userName("Joe123").firstName("John").lastName("Test").password("123")
                .gender(GenderEnum.MALE).email("joe@gmail.com").birthday(LocalDate.of(2000, 12, 12)).preference(preferenceUser).algoChoice(matchAlgorithm1).build();

        PotentialUserMatch expectedMatch = PotentialUserMatch.builder().userView(user1).userReceived(user2).matchScore(1.0).build();
        PotentialUserMatch potentialUserMatch = PotentialUserMatch.builder().userView(user1).userReceived(user2).matchScore(0.0).build();
        MatchAlgorithm matchAlgorithm = MatchAlgorithm.builder().id(0L).name("test").potentialUserMatch(List.of(potentialUserMatch)).build();
        MatchAlgorithms matchAlgorithms = new BasicMatchingAlgorithm();


        List<PotentialUserMatch> actualResult = matchAlgorithms.getUserList(matchAlgorithm);
        List<PotentialUserMatch> expectedResult = List.of(expectedMatch);

        assertEquals(expectedResult, actualResult);

    }

    @Test
    void NoPreferenceMatchingAlgo_Works(){
        Place placeUser = Place.builder().id(0L).name("New York").build();
        Preference preferenceUser = Preference.builder().id(0L).gender(GenderEnum.MALE).minAge(18L).maxAge(25L).place(placeUser).build();
        MatchAlgorithm matchAlgorithm1 = MatchAlgorithm.builder().id(0L).name("Basic Matching").build();
        User user1 = User.builder().userName("Henkie").firstName("Test").lastName("Test").password("123")
                .gender(GenderEnum.MALE).email("test@gmail.com").birthday(LocalDate.of(2000, 12, 12)).preference(preferenceUser).algoChoice(matchAlgorithm1).build();
        User user2 = User.builder().userName("Joe123").firstName("John").lastName("Test").password("123")
                .gender(GenderEnum.MALE).email("joe@gmail.com").birthday(LocalDate.of(2000, 12, 12)).preference(preferenceUser).algoChoice(matchAlgorithm1).build();

        PotentialUserMatch expectedMatch = PotentialUserMatch.builder().userView(user1).userReceived(user2).matchScore(1.0).build();
        PotentialUserMatch potentialUserMatch = PotentialUserMatch.builder().userView(user1).userReceived(user2).matchScore(0.0).build();
        MatchAlgorithm matchAlgorithm = MatchAlgorithm.builder().id(0L).name("test").potentialUserMatch(List.of(potentialUserMatch)).build();
        MatchAlgorithms matchAlgorithms = new NoPreferenceMatchingAlgorithm();


        List<PotentialUserMatch> actualResult = matchAlgorithms.getUserList(matchAlgorithm);
        List<PotentialUserMatch> expectedResult = List.of(expectedMatch);

        assertEquals(expectedResult, actualResult);

    }

    @Test
    void StandardMatchAlgorithm_Works(){
        Place placeUser = Place.builder().id(0L).name("New York").build();
        Preference preferenceUser = Preference.builder().id(0L).gender(GenderEnum.MALE).minAge(18L).maxAge(25L).place(placeUser).build();
        MatchAlgorithm matchAlgorithm1 = MatchAlgorithm.builder().id(0L).name("Basic Matching").build();
        User user1 = User.builder().userName("Henkie").firstName("Test").lastName("Test").password("123")
                .gender(GenderEnum.MALE).email("test@gmail.com").birthday(LocalDate.of(2000, 12, 12)).preference(preferenceUser).algoChoice(matchAlgorithm1).build();
        User user2 = User.builder().userName("Joe123").firstName("John").lastName("Test").password("123")
                .gender(GenderEnum.MALE).email("joe@gmail.com").birthday(LocalDate.of(2000, 12, 12)).preference(preferenceUser).algoChoice(matchAlgorithm1).build();

        PotentialUserMatch expectedMatch = PotentialUserMatch.builder().userView(user1).userReceived(user2).matchScore(1.0).build();
        PotentialUserMatch potentialUserMatch = PotentialUserMatch.builder().userView(user1).userReceived(user2).matchScore(0.0).build();
        MatchAlgorithm matchAlgorithm = MatchAlgorithm.builder().id(0L).name("test").potentialUserMatch(List.of(potentialUserMatch)).build();
        MatchAlgorithms matchAlgorithms = new StandardMatchAlgorithm();


        List<PotentialUserMatch> actualResult = matchAlgorithms.getUserList(matchAlgorithm);
        List<PotentialUserMatch> expectedResult = List.of(expectedMatch);

        assertEquals(expectedResult, actualResult);

    }

}
