package individualapplication.logiclayer.matchingbuddies.pending;

import individualapplication.models.buddymatch.pendingmatch.CreatePendingMatchRequest;
import individualapplication.models.buddymatch.pendingmatch.CreatePendingMatchResponse;
import individualapplication.models.buddymatch.pendingmatch.GetPendingMatchesResponse;

public interface PendingUserMatchAdmin {
    CreatePendingMatchResponse createPendingUserMatchResponse(CreatePendingMatchRequest request);
    void deletePendingById(Long id);
    GetPendingMatchesResponse getAllByUserReceivedId(Long id);
}
