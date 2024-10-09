package individualapplication.logiclayer.matchingbuddies;

import individualapplication.datalayer.usermatch.buddymatchalgo.BuddyMatchAlgoEntity;
import individualapplication.models.buddymatch.MatchAlgorithm;

public class MatchAlgoConverter {
    private MatchAlgoConverter(){
    }

    public static MatchAlgorithm convert(BuddyMatchAlgoEntity buddyMatchAlgoEntity){
        return MatchAlgorithm.builder()
                .id(buddyMatchAlgoEntity.getId())
                .name(buddyMatchAlgoEntity.getName())
                .build();
    }
}
