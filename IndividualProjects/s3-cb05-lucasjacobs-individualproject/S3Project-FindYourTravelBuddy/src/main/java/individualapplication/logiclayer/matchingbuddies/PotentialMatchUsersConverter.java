package individualapplication.logiclayer.matchingbuddies;


import individualapplication.datalayer.usermatch.potential.PotentialUserMatchEntity;
import individualapplication.logiclayer.user.UserConverter;
import individualapplication.models.buddymatch.potentialusermatch.PotentialUserMatch;

public class PotentialMatchUsersConverter {
    private PotentialMatchUsersConverter(){}

    public static PotentialUserMatch convert(PotentialUserMatchEntity potentialUserMatch){
        return PotentialUserMatch.builder()
                .id(potentialUserMatch.getId())
                .userReceived((UserConverter.convert(potentialUserMatch.getUserReceived())))
                .userView(UserConverter.convert(potentialUserMatch.getUserView()))
                .matchScore(potentialUserMatch.getMatchScore())
                .build();
    }
}
