package individualapplication.logiclayer.complain.complainsubject;

import individualapplication.datalayer.complainrepo.complainsubject.ComplainSubjectRepository;
import individualapplication.models.complain.complainsubject.ComplainSubject;
import individualapplication.models.complain.complainsubject.GetComplainsSubjectResponse;
import lombok.AllArgsConstructor;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
@AllArgsConstructor
public class ComplainSubjectAdminImpl implements ComplainSubjectAdmin {
    private final ComplainSubjectRepository complainSubjectRepository;

    @Override
    public GetComplainsSubjectResponse getComplainSubjects(){
        final GetComplainsSubjectResponse response = new GetComplainsSubjectResponse();
        List<ComplainSubject> complainSubjects = complainSubjectRepository.findAll()
                .stream().map(ComplainSubjectConverter :: convert)
                .toList();

        response.setComplainSubjects(complainSubjects);

        return response;
    }

}
