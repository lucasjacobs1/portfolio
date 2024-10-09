package individualapplication.logiclayer.matchingbuddies.matches;

import individualapplication.datalayer.usermatch.matches.MatchEntity;
import individualapplication.logiclayer.user.UserConverter;
import individualapplication.models.buddymatch.acceptedmatch.BuddyMatch;

public class MatchConverter {
    private MatchConverter(){}

    public static BuddyMatch convert(MatchEntity request){
        return BuddyMatch.builder()
                .id(request.getId())
                .buddy1(UserConverter.convert(request.getBuddy1()))
                .buddy2(UserConverter.convert(request.getBuddy2()))
                .build();
    }
}
