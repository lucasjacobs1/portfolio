package individualapplication.logiclayer.matchingbuddies.buddymatchalgo;

import individualapplication.datalayer.usermatch.buddymatchalgo.BuddyMatchAlgoEntity;
import individualapplication.models.buddymatch.GetBuddyMatchAlgosResponse;

public interface BuddyMatchAlgoAdmin {
    GetBuddyMatchAlgosResponse getAllAlgorithmsOfBuddy();
    BuddyMatchAlgoEntity getByName(String name);
}
