package individualapplication.logiclayer;

import individualapplication.logiclayer.matchingbuddies.MatchAlgorithms;
import individualapplication.logiclayer.matchingbuddies.algorithms.BasicMatchingAlgorithm;
import individualapplication.logiclayer.matchingbuddies.algorithms.NoPreferenceMatchingAlgorithm;
import individualapplication.logiclayer.matchingbuddies.algorithms.StandardMatchAlgorithm;
import individualapplication.logiclayer.matchingbuddies.factory.FactoryMatchingBuddy;
import lombok.AllArgsConstructor;
import org.junit.jupiter.api.Test;
import org.junit.jupiter.api.extension.ExtendWith;
import org.mockito.junit.jupiter.MockitoExtension;
import org.springframework.stereotype.Service;

import static org.assertj.core.api.Fail.fail;
import static org.junit.jupiter.api.Assertions.assertEquals;
import static org.junit.jupiter.api.Assertions.assertTrue;

@ExtendWith(MockitoExtension.class)
@AllArgsConstructor
@Service
class FactoryMatchingBuddyTest {


    @Test
    void matchAlgorithm_equals_basicMatchingAlgorithm_Works(){
        MatchAlgorithms matchAlgorithm = FactoryMatchingBuddy.returnMatchAlgorithm(0);
        assertTrue(matchAlgorithm instanceof BasicMatchingAlgorithm);

        // Test with algorithmId = 1
        matchAlgorithm = FactoryMatchingBuddy.returnMatchAlgorithm(1);
        assertTrue(matchAlgorithm instanceof StandardMatchAlgorithm);

        // Test with algorithmId = 2
        matchAlgorithm = FactoryMatchingBuddy.returnMatchAlgorithm(2);
        assertTrue(matchAlgorithm instanceof NoPreferenceMatchingAlgorithm);

        // Test with algorithmId = 3, it should throw IllegalArgumentException
        try {
            matchAlgorithm = FactoryMatchingBuddy.returnMatchAlgorithm(3);
            fail("Expected an IllegalArgumentException to be thrown");
        } catch (IllegalArgumentException e) {
            assertEquals("this should not happen", e.getMessage());
        }



    }
}
