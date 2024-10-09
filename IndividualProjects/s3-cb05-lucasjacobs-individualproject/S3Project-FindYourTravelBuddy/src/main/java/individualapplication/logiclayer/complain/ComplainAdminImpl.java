package individualapplication.logiclayer.complain;

import individualapplication.datalayer.complainrepo.ComplainEntity;
import individualapplication.datalayer.complainrepo.ComplainRepository;
import individualapplication.datalayer.complainrepo.complainsubject.ComplainSubjectRepository;
import individualapplication.datalayer.userrepo.UserRepository;
import individualapplication.models.complain.Complain;
import individualapplication.models.complain.CreateComplainRequest;
import individualapplication.models.complain.CreateComplainResponse;
import individualapplication.models.complain.GetComplainsResponse;
import lombok.AllArgsConstructor;
import org.springframework.stereotype.Service;

import javax.transaction.Transactional;
import java.util.List;

@Service
@AllArgsConstructor
public class ComplainAdminImpl implements ComplainAdmin {
    private ComplainRepository complainRepository;
    private ComplainSubjectRepository complainSubjectRepository;
    private UserRepository userRepository;

    @Override
    @Transactional
    public CreateComplainResponse createComplain(CreateComplainRequest request){
        ComplainEntity preference = saveComplain(request);

        return CreateComplainResponse.builder()
                .id(preference.getId())
                .build();
    }

    private ComplainEntity saveComplain(CreateComplainRequest complainRequest){
        ComplainEntity complainEntity = ComplainEntity.builder()
                .complainer(userRepository.findById(complainRequest.getComplainerId()).orElseThrow())
                .accused(userRepository.findById(complainRequest.getAccusedId()).orElseThrow())
                .context(complainRequest.getContext())
                .complainSubject(complainSubjectRepository.findById(complainRequest.getSubjectId()).orElseThrow())
                .build();
        return complainRepository.save(complainEntity);
    }

    @Override
    public GetComplainsResponse getComplains() {
        final GetComplainsResponse response = new GetComplainsResponse();
        List<Complain> users = complainRepository.findAll()
                .stream()
                .map(ComplainConverter::convert)
                .toList();
        response.setComplains(users);

        return response;
    }


}
