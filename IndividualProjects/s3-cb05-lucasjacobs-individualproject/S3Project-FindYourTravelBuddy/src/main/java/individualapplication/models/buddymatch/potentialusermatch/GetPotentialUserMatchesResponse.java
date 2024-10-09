package individualapplication.models.buddymatch.potentialusermatch;

import lombok.AllArgsConstructor;
import lombok.Builder;
import lombok.Data;
import lombok.NoArgsConstructor;

import java.util.List;

@Data
@Builder
@AllArgsConstructor
@NoArgsConstructor
public class GetPotentialUserMatchesResponse {
    private List<PotentialUserMatch> potentialUserMatches;
}
