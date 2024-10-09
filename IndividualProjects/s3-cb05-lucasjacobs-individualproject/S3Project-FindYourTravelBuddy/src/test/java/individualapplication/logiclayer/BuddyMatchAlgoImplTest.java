package individualapplication.logiclayer;

import individualapplication.datalayer.usermatch.buddymatchalgo.BuddyMatchAlgoEntity;
import individualapplication.datalayer.usermatch.buddymatchalgo.BuddyMatchAlgoRepository;
import individualapplication.logiclayer.matchingbuddies.buddymatchalgo.BuddyMatchAlgoImpl;
import individualapplication.models.buddymatch.GetBuddyMatchAlgosResponse;
import individualapplication.models.buddymatch.MatchAlgorithm;
import lombok.AllArgsConstructor;
import org.junit.jupiter.api.Test;
import org.junit.jupiter.api.extension.ExtendWith;
import org.mockito.InjectMocks;
import org.mockito.Mock;
import org.mockito.Mockito;
import org.mockito.junit.jupiter.MockitoExtension;
import org.springframework.stereotype.Service;

import java.util.List;

import static org.junit.jupiter.api.Assertions.assertEquals;
import static org.mockito.Mockito.verify;

@ExtendWith(MockitoExtension.class)
@AllArgsConstructor
@Service
class BuddyMatchAlgoImplTest {

    @Mock
    private BuddyMatchAlgoRepository buddyMatchAlgoRepository;

    @InjectMocks
    private BuddyMatchAlgoImpl buddyMatchAlgo;

    @Test
    void getPlaces(){
        MatchAlgorithm matchAlgorithm = MatchAlgorithm.builder().id(0L).name("Normal").build();
        MatchAlgorithm matchAlgorithm1 = MatchAlgorithm.builder().id(1L).name("Nothing").build();

        BuddyMatchAlgoEntity buddyMatchAlgoEntity = BuddyMatchAlgoEntity.builder().id(0L).name("Normal").build();
        BuddyMatchAlgoEntity buddyMatchAlgoEntity1 = BuddyMatchAlgoEntity.builder().id(1L).name("Nothing").build();

        Mockito.when(buddyMatchAlgoRepository.findAll()).thenReturn(List.of(buddyMatchAlgoEntity, buddyMatchAlgoEntity1));
        GetBuddyMatchAlgosResponse actualResult = buddyMatchAlgo.getAllAlgorithmsOfBuddy();
        GetBuddyMatchAlgosResponse expectedResult = GetBuddyMatchAlgosResponse.builder().matchAlgorithms(List.of(matchAlgorithm, matchAlgorithm1)).build();

        assertEquals(expectedResult, actualResult);
        verify(buddyMatchAlgoRepository).findAll();
    }
}
