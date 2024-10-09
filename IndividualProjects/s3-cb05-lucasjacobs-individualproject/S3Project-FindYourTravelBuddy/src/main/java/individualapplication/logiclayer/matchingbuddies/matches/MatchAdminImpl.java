package individualapplication.logiclayer.matchingbuddies.matches;

import individualapplication.datalayer.usermatch.matches.MatchEntity;
import individualapplication.datalayer.usermatch.matches.MatchRepository;
import individualapplication.datalayer.userrepo.UserRepository;
import individualapplication.logiclayer.user.RoleConverter;
import individualapplication.logiclayer.user.UserConverter;
import individualapplication.models.buddymatch.acceptedmatch.BuddyMatch;
import individualapplication.models.buddymatch.acceptedmatch.CreateMatchRequest;
import individualapplication.models.buddymatch.acceptedmatch.CreateMatchResponse;
import individualapplication.models.buddymatch.acceptedmatch.GetMatchesResponse;
import individualapplication.models.user.User;
import individualapplication.models.user.UserRole;
import lombok.AllArgsConstructor;
import org.springframework.stereotype.Service;

import java.util.List;
import java.util.Optional;
import java.util.Set;

@Service
@AllArgsConstructor
public class MatchAdminImpl implements MatchAdmin {
    private final MatchRepository matchRepository;
    private final UserRepository userRepository;

    @Override
    public CreateMatchResponse createMatchResponse(CreateMatchRequest request){
        MatchEntity pendingBuddyMatchEntity = savePendingUser(request);

        return CreateMatchResponse.builder()
                .id(pendingBuddyMatchEntity.getId())
                .build();
    }

    public MatchEntity savePendingUser(CreateMatchRequest request){
        MatchEntity matchBuddy = MatchEntity.builder()
                .buddy1(userRepository.findById(request.getBuddy1().getId()).orElseThrow())
                .buddy2(userRepository.findById(request.getBuddy2().getId()).orElseThrow()).build();

        return matchRepository.save(matchBuddy);

    }

    @Override
    public GetMatchesResponse getAllByUserLoggedInId(Long id){
        final GetMatchesResponse response = new GetMatchesResponse();
        List<BuddyMatch> getAllById = matchRepository.getAllByBuddy1_IdOrBuddy2_Id(id,id)
                .stream()
                .map(MatchConverter::convert)
                .toList();
        response.setBuddyMatches(getAllById);
        return response;
    }

    @Override
    public Optional<BuddyMatch> findMatchById(Long id){
        BuddyMatch buddyMatch = matchRepository.findById(id).map(MatchConverter::convert).orElseThrow();
        return Optional.of(buddyMatch);


    }


}
