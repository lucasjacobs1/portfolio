package individualapplication.logiclayer.matchingbuddies;

import individualapplication.models.buddymatch.MatchAlgorithm;
import individualapplication.models.buddymatch.potentialusermatch.PotentialUserMatch;

import java.util.List;

public interface MatchAlgorithms {
    List<PotentialUserMatch> getUserList(MatchAlgorithm matchAlgorithm);
}
