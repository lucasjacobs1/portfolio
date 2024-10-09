package individualapplication.logiclayer.matchingbuddies.algorithms;

import individualapplication.logiclayer.matchingbuddies.MatchAlgorithms;
import individualapplication.models.buddymatch.MatchAlgorithm;
import individualapplication.models.buddymatch.potentialusermatch.PotentialUserMatch;

import java.util.ArrayList;
import java.util.List;

public class NoPreferenceMatchingAlgorithm implements MatchAlgorithms {
    public List<PotentialUserMatch> getUserList(MatchAlgorithm matchAlgorithm) {
        List<PotentialUserMatch> userMatches = new ArrayList<>();
        for (int i = 0; i < matchAlgorithm.getPotentialUserMatch().size(); i++) {

            matchAlgorithm.getPotentialUserMatch().get(i).setMatchScore(1.0);
            userMatches.add(matchAlgorithm.getPotentialUserMatch().get(i));
        }
        return userMatches;
    }
}
