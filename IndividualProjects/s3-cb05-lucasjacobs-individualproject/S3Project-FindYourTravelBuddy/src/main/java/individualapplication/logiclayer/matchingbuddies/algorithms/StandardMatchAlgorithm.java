package individualapplication.logiclayer.matchingbuddies.algorithms;

import individualapplication.logiclayer.matchingbuddies.MatchAlgorithms;
import individualapplication.models.buddymatch.MatchAlgorithm;
import individualapplication.models.buddymatch.potentialusermatch.PotentialUserMatch;


import java.time.LocalDate;
import java.time.temporal.ChronoUnit;
import java.util.ArrayList;
import java.util.List;

public class StandardMatchAlgorithm implements MatchAlgorithms {
    public List<PotentialUserMatch> getUserList(MatchAlgorithm matchAlgorithm) {
        List<PotentialUserMatch> userMatches = new ArrayList<>();
        for (int i = 0; i < matchAlgorithm.getPotentialUserMatch().size(); i++) {
            double score = 0;
            LocalDate localDate = LocalDate.now();
            Long getViewUserAge = ChronoUnit.YEARS.between(matchAlgorithm.getPotentialUserMatch().get(i).getUserView().getBirthday(), localDate);
            if (matchAlgorithm.getPotentialUserMatch().get(i).getUserReceived().getPreference().getMinAge() <= getViewUserAge && matchAlgorithm.getPotentialUserMatch().get(i).getUserReceived().getPreference().getMaxAge() >= getViewUserAge) {
                score += 0.50;

            }
            if (matchAlgorithm.getPotentialUserMatch().get(i).getUserReceived().getPreference().getGender().equals(matchAlgorithm.getPotentialUserMatch().get(i).getUserView().getGender())) {
                score += 0.25;
            }
            if (matchAlgorithm.getPotentialUserMatch().get(i).getUserReceived().getPreference().getPlace().equals(matchAlgorithm.getPotentialUserMatch().get(i).getUserView().getPreference().getPlace())) {
                score += 0.25;
            }
            if (score == 1) {
                matchAlgorithm.getPotentialUserMatch().get(i).setMatchScore(score);
                userMatches.add(matchAlgorithm.getPotentialUserMatch().get(i));
            }
        }
        return userMatches;
    }
}
