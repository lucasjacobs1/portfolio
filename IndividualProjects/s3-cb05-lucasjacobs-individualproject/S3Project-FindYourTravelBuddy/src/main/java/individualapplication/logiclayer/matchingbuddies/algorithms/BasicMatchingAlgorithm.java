package individualapplication.logiclayer.matchingbuddies.algorithms;

import individualapplication.logiclayer.matchingbuddies.MatchAlgorithms;
import individualapplication.models.buddymatch.MatchAlgorithm;
import individualapplication.models.buddymatch.potentialusermatch.PotentialUserMatch;

import java.time.LocalDate;
import java.time.temporal.ChronoUnit;
import java.util.ArrayList;
import java.util.List;

public class BasicMatchingAlgorithm implements MatchAlgorithms {
    public List<PotentialUserMatch> getUserList(MatchAlgorithm matchAlgorithm) {
        List<PotentialUserMatch> userMatches = new ArrayList<>();
        for (int i = 0; i < matchAlgorithm.getPotentialUserMatch().size(); i++) {

            LocalDate localDate = LocalDate.now();
            Long getViewUserAge = ChronoUnit.YEARS.between(matchAlgorithm.getPotentialUserMatch().get(i).getUserView().getBirthday(), localDate);
            if (matchAlgorithm.getPotentialUserMatch().get(i).getUserReceived().getPreference().getMinAge() <= getViewUserAge && matchAlgorithm.getPotentialUserMatch().get(i).getUserReceived().getPreference().getMaxAge() >= getViewUserAge) {
                    matchAlgorithm.getPotentialUserMatch().get(i).setMatchScore(1.0);
                    userMatches.add(matchAlgorithm.getPotentialUserMatch().get(i));

            }
        }
        return userMatches;
    }

}
