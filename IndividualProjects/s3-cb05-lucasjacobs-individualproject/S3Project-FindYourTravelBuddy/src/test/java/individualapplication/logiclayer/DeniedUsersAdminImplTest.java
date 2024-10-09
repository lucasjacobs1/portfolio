package individualapplication.logiclayer;

import individualapplication.datalayer.usermatch.deniedusermatch.DeniedUserMatchEntity;
import individualapplication.datalayer.usermatch.deniedusermatch.DeniedUserMatchRepository;
import individualapplication.datalayer.usermatch.potential.PotentialUserMatchEntity;
import individualapplication.datalayer.userrepo.UserEntity;
import individualapplication.datalayer.userrepo.UserRepository;
import individualapplication.logiclayer.matchingbuddies.deniedusers.DeniedUsersAdminImpl;
import individualapplication.models.buddymatch.deniedmatch.CreateDeniedMatchRequest;
import individualapplication.models.buddymatch.deniedmatch.CreateDeniedMatchResponse;
import individualapplication.models.buddymatch.potentialusermatch.CreatePotentialUserMatchRequest;
import individualapplication.models.buddymatch.potentialusermatch.CreatePotentialUserMatchResponse;
import individualapplication.models.user.User;
import individualapplication.models.user.gender.GenderEnum;
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

import static org.junit.jupiter.api.Assertions.assertEquals;
import static org.mockito.ArgumentMatchers.any;
import static org.mockito.Mockito.verify;

@ExtendWith(MockitoExtension.class)
@AllArgsConstructor
@Service
class DeniedUsersAdminImplTest {
    @Mock
    private UserRepository userRepository;

    @Mock
    private DeniedUserMatchRepository deniedUserMatchRepository;

    @InjectMocks
    private DeniedUsersAdminImpl deniedUsersAdmin;

    @Test
    void createDeniedUserMatchResponse_works(){
        UserEntity userEntity1 = UserEntity.builder().userName("Henkie").firstName("Test").lastName("Test").password("123")
                .gender(GenderEnum.MALE).email("test@gmail.com").birthday(LocalDate.of(2000, 12, 12)).build();
        UserEntity userEntity2 = UserEntity.builder().userName("Joe123").firstName("John").lastName("Test").password("123")
                .gender(GenderEnum.MALE).email("joe@gmail.com").birthday(LocalDate.of(2000, 12, 12)).build();

        User user1 = User.builder().userName("Henkie").firstName("Test").lastName("Test").password("123")
                .gender(GenderEnum.MALE).email("test@gmail.com").birthday(LocalDate.of(2000, 12, 12)).build();
        User user2 = User.builder().userName("Joe123").firstName("John").lastName("Test").password("123")
                .gender(GenderEnum.MALE).email("joe@gmail.com").birthday(LocalDate.of(2000, 12, 12)).build();

        CreateDeniedMatchRequest createDeniedMatchRequest = CreateDeniedMatchRequest.builder().userId(user1.getId()).deniedUserId(user2.getId()).build();

        DeniedUserMatchEntity deniedUserMatch = DeniedUserMatchEntity.builder().id(0L).user(userEntity1).denied_user(userEntity2).build();

        Mockito.when(deniedUserMatchRepository.save(any(DeniedUserMatchEntity.class))).thenReturn(deniedUserMatch);
        Mockito.when(userRepository.findById(createDeniedMatchRequest.getDeniedUserId())).thenReturn(Optional.ofNullable(userEntity1));
        Mockito.when(userRepository.findById(createDeniedMatchRequest.getUserId())).thenReturn(Optional.ofNullable(userEntity2));

        CreateDeniedMatchResponse actualResult = deniedUsersAdmin.save(createDeniedMatchRequest);
        CreateDeniedMatchResponse expectedResult = CreateDeniedMatchResponse.builder().build();
        assertEquals(expectedResult, actualResult);
        verify(deniedUserMatchRepository).save(any(DeniedUserMatchEntity.class));

    }

}
