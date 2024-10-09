package individualapplication.logiclayer.matchingbuddies;

import individualapplication.models.buddymatch.potentialusermatch.GetPotentialUserMatchesResponse;
import individualapplication.models.user.User;

public interface PotentialMatchUsersAdmin {
    void getPotentialUserMatchesForPerson(User user);
    GetPotentialUserMatchesResponse getPotentialUserMatchesByReceivedId(Long id);
    void deletePotentialUsersMatch(long id);
    void deleteAllPotentialUserMatchByReceivedUserId(Long id);
}