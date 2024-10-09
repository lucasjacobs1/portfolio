package individualapplication.logiclayer.matchingbuddies;

import individualapplication.datalayer.usermatch.buddymatchalgo.BuddyMatchAlgoRepository;
import individualapplication.datalayer.usermatch.deniedusermatch.DeniedUserMatchEntity;
import individualapplication.datalayer.usermatch.deniedusermatch.DeniedUserMatchRepository;
import individualapplication.datalayer.usermatch.pendingusermatch.PendingBuddyMatchEntity;
import individualapplication.datalayer.usermatch.pendingusermatch.PendingBuddyMatchRepository;
import individualapplication.datalayer.usermatch.potential.PotentialUserMatchEntity;
import individualapplication.datalayer.usermatch.potential.PotentialUserMatchRepository;
import individualapplication.datalayer.userrepo.UserEntity;
import individualapplication.datalayer.userrepo.UserRepository;
import individualapplication.logiclayer.execptions.ApiRequestException;
import individualapplication.logiclayer.user.UserConverter;
import individualapplication.models.buddymatch.MatchAlgorithm;
import individualapplication.models.buddymatch.potentialusermatch.CreatePotentialUserMatchRequest;
import individualapplication.models.buddymatch.potentialusermatch.CreatePotentialUserMatchResponse;
import individualapplication.models.buddymatch.potentialusermatch.GetPotentialUserMatchesResponse;
import individualapplication.models.buddymatch.potentialusermatch.PotentialUserMatch;
import individualapplication.models.user.User;
import lombok.AllArgsConstructor;
import org.springframework.stereotype.Service;

import javax.transaction.Transactional;
import java.util.ArrayList;
import java.util.List;
import java.util.Optional;

@Service
@AllArgsConstructor
public class PotentialMatchUsersImpl implements PotentialMatchUsersAdmin {
    private final PotentialUserMatchRepository userMatchRepository;
    private final UserRepository userRepository;
    private final BuddyMatchAlgoRepository buddyMatchAlgoRepository;
    private final DeniedUserMatchRepository deniedUserMatchRepository;

    private final PendingBuddyMatchRepository pendingBuddyMatchRepository;

    public CreatePotentialUserMatchResponse createPotentialUserMatchResponse(CreatePotentialUserMatchRequest request) {
        PotentialUserMatchEntity potentialUserMatch = savePotentialUserMatch(request);

        return CreatePotentialUserMatchResponse.builder()
                .id(potentialUserMatch.getId())
                .build();
    }

    public PotentialUserMatchEntity savePotentialUserMatch(CreatePotentialUserMatchRequest request) {
        PotentialUserMatchEntity potentialUserMatch = PotentialUserMatchEntity.builder()
                .userReceived(userRepository.findById(request.getUserReceived().getId()).orElseThrow())
                .userView(userRepository.findById(request.getUserView().getId()).orElseThrow())
                .matchScore(request.getMatchScore())
                .build();
        return userMatchRepository.save(potentialUserMatch);
    }

    public List<PotentialUserMatch> returnPotentialUserMatches(User user) {
        List<PotentialUserMatch> potentialUserMatches = new ArrayList<>();
        List<User> getUsers = userRepository.findAll()
                .stream()
                .map(UserConverter::convert)
                .toList();

        List<PendingBuddyMatchEntity> getPendingUsers = pendingBuddyMatchRepository.getPendingBuddyMatchEntitiesByUserReceivedId(user.getId());

        List<DeniedUserMatchEntity> deniedUsers = deniedUserMatchRepository.getDeniedUserMatchEntitiesByUserId(user.getId());

        for (int i = 0; i < getUsers.size(); i++) {
            boolean isUnique = true;
            for(int j = 0; j < getPendingUsers.size(); j++){
                if(getPendingUsers.get(j).getUserReceived().getId().equals(getUsers.get(i).getId())){
                    isUnique= false;
                }
            }

            for(int h = 0; h < deniedUsers.size(); h++){
                if(deniedUsers.get(h).getDenied_user().getId().equals(getUsers.get(i).getId())){
                    isUnique = false;
                }
            }

            if(isUnique && !user.getId().equals(getUsers.get(i).getId())) {
                potentialUserMatches.add(PotentialUserMatch.builder()
                        .userReceived(user)
                        .userView(getUsers.get(i))
                        .matchScore(0.0)
                        .build());
            }
        }
        return potentialUserMatches;
    }

    @Override
    public void getPotentialUserMatchesForPerson(User user) {
        MatchAlgorithms matchAlgorithms;
        Optional<UserEntity> optionalUserEntity = userRepository.findById(user.getId());
        if(optionalUserEntity.isPresent()){
            UserEntity userEntity = optionalUserEntity.get();
            MatchAlgorithm matchAlgorithm = MatchAlgoConverter.convert(buddyMatchAlgoRepository.findById(userEntity.getBuddyMatchAlgo().getId()).orElseThrow());
            matchAlgorithm.setPotentialUserMatch(returnPotentialUserMatches(user));

            matchAlgorithms = matchAlgorithm.validateMatchAlgorithm();
            List<PotentialUserMatch> potentialUserMatches = matchAlgorithms.getUserList(matchAlgorithm);
            for (int i = 0; i < potentialUserMatches.size(); i++) {
                createPotentialUserMatchResponse(new CreatePotentialUserMatchRequest(potentialUserMatches.get(i).getUserReceived(), potentialUserMatches.get(i).getUserView(), potentialUserMatches.get(i).getMatchScore()));
            }
        }
        else{
            throw new ApiRequestException("User not found");
        }

    }

    @Override
    public GetPotentialUserMatchesResponse getPotentialUserMatchesByReceivedId(Long id){
        final GetPotentialUserMatchesResponse response = new GetPotentialUserMatchesResponse();
        List<PotentialUserMatch> potentialUserMatches = userMatchRepository.getPotentialUserMatchEntitiesByUserReceivedId(id)
                .stream().map(PotentialMatchUsersConverter::convert).toList();
        response.setPotentialUserMatches(potentialUserMatches);
        return response;
    }

    @Override
    public void deletePotentialUsersMatch(long id) {
        this.userMatchRepository.deleteById(id);
    }

    @Override
    @Transactional
    public void deleteAllPotentialUserMatchByReceivedUserId(Long id){
        this.userMatchRepository.deleteAllByUserReceivedId(id);
    }
}
