package individualapplication.logiclayer.matchingbuddies.pending;

import individualapplication.datalayer.usermatch.pendingusermatch.PendingBuddyMatchEntity;
import individualapplication.datalayer.usermatch.pendingusermatch.PendingBuddyMatchRepository;
import individualapplication.datalayer.userrepo.UserRepository;
import individualapplication.models.buddymatch.pendingmatch.CreatePendingMatchRequest;
import individualapplication.models.buddymatch.pendingmatch.CreatePendingMatchResponse;
import individualapplication.models.buddymatch.pendingmatch.GetPendingMatchesResponse;
import individualapplication.models.buddymatch.pendingmatch.PendingMatch;
import lombok.AllArgsConstructor;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
@AllArgsConstructor
public class PendingUserMatchAdminImpl implements  PendingUserMatchAdmin {
    //add, getall, delete
    private final PendingBuddyMatchRepository pendingBuddyMatchRepository;
    private final UserRepository userRepository;

    @Override
    public CreatePendingMatchResponse createPendingUserMatchResponse(CreatePendingMatchRequest request){
        PendingBuddyMatchEntity pendingBuddyMatchEntity = savePendingUser(request);

        return CreatePendingMatchResponse.builder()
                .id(pendingBuddyMatchEntity.getId())
                .build();
    }

    public PendingBuddyMatchEntity savePendingUser(CreatePendingMatchRequest request){
        PendingBuddyMatchEntity pendingBuddyMatchEntity = PendingBuddyMatchEntity.builder()
                .fromUser(userRepository.findById(request.getFromUserId()).orElseThrow())
                .userReceived(userRepository.findById(request.getReceivedUserId()).orElseThrow()).build();

        return pendingBuddyMatchRepository.save(pendingBuddyMatchEntity);

    }

    @Override
    public void deletePendingById(Long id){
        pendingBuddyMatchRepository.deleteById(id);
    }

    @Override
    public GetPendingMatchesResponse getAllByUserReceivedId(Long id){
        final GetPendingMatchesResponse response = new GetPendingMatchesResponse();
        List<PendingMatch> getAllById = pendingBuddyMatchRepository.getPendingBuddyMatchEntitiesByUserReceivedId(id)
                .stream()
                .map(PendingUserMatchConverter::convert)
                .toList();
        response.setPendingUserMatches(getAllById);
        return response;
    }

}
