package individualapplication.logiclayer.matchingbuddies.buddymatchalgo;

import individualapplication.datalayer.usermatch.buddymatchalgo.BuddyMatchAlgoEntity;
import individualapplication.datalayer.usermatch.buddymatchalgo.BuddyMatchAlgoRepository;
import individualapplication.logiclayer.matchingbuddies.MatchAlgoConverter;
import individualapplication.models.buddymatch.GetBuddyMatchAlgosResponse;
import individualapplication.models.buddymatch.MatchAlgorithm;
import lombok.AllArgsConstructor;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
@AllArgsConstructor
public class BuddyMatchAlgoImpl implements BuddyMatchAlgoAdmin {

    private BuddyMatchAlgoRepository buddyMatchAlgoRepository;

    @Override
    public GetBuddyMatchAlgosResponse getAllAlgorithmsOfBuddy(){
        final GetBuddyMatchAlgosResponse response = new GetBuddyMatchAlgosResponse();
        List<MatchAlgorithm> matchAlgorithms = buddyMatchAlgoRepository.findAll()
                .stream()
                .map(MatchAlgoConverter::convert)
                .toList();
        response.setMatchAlgorithms(matchAlgorithms);
        return response;
    }

    @Override
    public BuddyMatchAlgoEntity getByName(String name){
        return buddyMatchAlgoRepository.findByName(name);
    }

}
