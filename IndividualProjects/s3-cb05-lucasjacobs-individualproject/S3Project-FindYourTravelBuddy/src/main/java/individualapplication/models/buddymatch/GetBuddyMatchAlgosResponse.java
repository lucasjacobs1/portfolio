package individualapplication.models.buddymatch;

import lombok.AllArgsConstructor;
import lombok.Builder;
import lombok.Data;
import lombok.NoArgsConstructor;

import java.util.List;
@Data
@Builder
@AllArgsConstructor
@NoArgsConstructor
public class GetBuddyMatchAlgosResponse {
    List<MatchAlgorithm> matchAlgorithms;
}
