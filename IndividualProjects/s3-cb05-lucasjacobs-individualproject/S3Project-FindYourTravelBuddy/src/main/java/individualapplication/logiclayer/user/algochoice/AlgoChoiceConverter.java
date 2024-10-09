package individualapplication.logiclayer.user.algochoice;

import individualapplication.datalayer.usermatch.buddymatchalgo.BuddyMatchAlgoEntity;
import individualapplication.models.buddymatch.MatchAlgorithm;

public class AlgoChoiceConverter {
    private AlgoChoiceConverter(){}

    public static MatchAlgorithm convert(BuddyMatchAlgoEntity buddyMatchAlgo){
        return MatchAlgorithm.builder()
                .id(buddyMatchAlgo.getId())
                .name(buddyMatchAlgo.getName())
                .build();

    }
}
