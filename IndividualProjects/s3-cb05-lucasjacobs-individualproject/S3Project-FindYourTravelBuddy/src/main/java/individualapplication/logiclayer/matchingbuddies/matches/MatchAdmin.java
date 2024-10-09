package individualapplication.logiclayer.matchingbuddies.matches;

import individualapplication.models.buddymatch.acceptedmatch.BuddyMatch;
import individualapplication.models.buddymatch.acceptedmatch.CreateMatchRequest;
import individualapplication.models.buddymatch.acceptedmatch.CreateMatchResponse;
import individualapplication.models.buddymatch.acceptedmatch.GetMatchesResponse;

import java.util.Optional;

public interface MatchAdmin {
    CreateMatchResponse createMatchResponse(CreateMatchRequest request);
    GetMatchesResponse getAllByUserLoggedInId(Long id);
    Optional<BuddyMatch> findMatchById(Long id);
}
