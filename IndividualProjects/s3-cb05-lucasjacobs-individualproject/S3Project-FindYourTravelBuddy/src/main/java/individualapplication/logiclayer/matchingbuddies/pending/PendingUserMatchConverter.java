package individualapplication.logiclayer.matchingbuddies.pending;

import individualapplication.datalayer.usermatch.pendingusermatch.PendingBuddyMatchEntity;
import individualapplication.logiclayer.user.UserConverter;
import individualapplication.models.buddymatch.pendingmatch.PendingMatch;

public class PendingUserMatchConverter {
    private PendingUserMatchConverter(){}

    public static PendingMatch convert(PendingBuddyMatchEntity request){
        return PendingMatch.builder()
                .id(request.getId())
                .fromUserId(UserConverter.convert(request.getFromUser()))
                .receivedUserId(UserConverter.convert(request.getUserReceived()))
                .build();
    }
}
