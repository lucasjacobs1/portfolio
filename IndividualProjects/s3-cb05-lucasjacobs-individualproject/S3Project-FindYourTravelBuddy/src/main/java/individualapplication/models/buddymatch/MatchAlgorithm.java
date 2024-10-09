package individualapplication.models.buddymatch;

import individualapplication.logiclayer.matchingbuddies.factory.FactoryMatchingBuddy;
import individualapplication.logiclayer.matchingbuddies.MatchAlgorithms;
import individualapplication.models.buddymatch.potentialusermatch.PotentialUserMatch;
import lombok.AllArgsConstructor;
import lombok.Builder;
import lombok.Data;
import lombok.NoArgsConstructor;

import java.util.List;

@Data
@Builder
@NoArgsConstructor
@AllArgsConstructor
public class MatchAlgorithm {
    private Long id;
    private String name;
    private List<PotentialUserMatch> potentialUserMatch;

    public MatchAlgorithms validateMatchAlgorithm(){
        return FactoryMatchingBuddy.returnMatchAlgorithm(this.id.intValue());
    }
}
