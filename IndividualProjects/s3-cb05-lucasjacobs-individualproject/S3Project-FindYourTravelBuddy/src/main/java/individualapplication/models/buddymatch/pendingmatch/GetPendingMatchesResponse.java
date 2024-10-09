package individualapplication.models.buddymatch.pendingmatch;

import lombok.AllArgsConstructor;
import lombok.Builder;
import lombok.Data;
import lombok.NoArgsConstructor;

import java.util.List;

@Data
@Builder
@AllArgsConstructor
@NoArgsConstructor
public class GetPendingMatchesResponse {
    List<PendingMatch> pendingUserMatches;
}
