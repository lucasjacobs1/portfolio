package individualapplication.logiclayer.matchingbuddies.deniedusers;

import individualapplication.models.buddymatch.deniedmatch.CreateDeniedMatchRequest;
import individualapplication.models.buddymatch.deniedmatch.CreateDeniedMatchResponse;

public interface DeniedUsersAdmin {
    CreateDeniedMatchResponse save(CreateDeniedMatchRequest request);
}
