package individualapplication.logiclayer.matchingbuddies.deniedusers;

import individualapplication.datalayer.usermatch.deniedusermatch.DeniedUserMatchEntity;
import individualapplication.datalayer.usermatch.deniedusermatch.DeniedUserMatchRepository;
import individualapplication.datalayer.userrepo.UserRepository;
import individualapplication.models.buddymatch.deniedmatch.CreateDeniedMatchRequest;
import individualapplication.models.buddymatch.deniedmatch.CreateDeniedMatchResponse;
import lombok.AllArgsConstructor;
import org.springframework.stereotype.Service;

@Service
@AllArgsConstructor
public class DeniedUsersAdminImpl implements DeniedUsersAdmin{
    private final DeniedUserMatchRepository deniedUserMatchRepository;
    private final UserRepository userRepository;
    @Override
    public CreateDeniedMatchResponse save(CreateDeniedMatchRequest request){
        DeniedUserMatchEntity deniedUserMatch = DeniedUserMatchEntity.builder()
                .user(userRepository.findById(request.getUserId()).orElseThrow())
                .denied_user(userRepository.findById(request.getDeniedUserId()).orElseThrow())
                .build();

        deniedUserMatchRepository.save(deniedUserMatch);

        return CreateDeniedMatchResponse.builder()
                .id(deniedUserMatch.getId())
                .build();
    }
}
