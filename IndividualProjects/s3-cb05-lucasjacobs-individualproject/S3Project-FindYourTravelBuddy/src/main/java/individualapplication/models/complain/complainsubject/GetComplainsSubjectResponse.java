package individualapplication.models.complain.complainsubject;

import lombok.AllArgsConstructor;
import lombok.Builder;
import lombok.Data;
import lombok.NoArgsConstructor;

import java.util.List;
@Data
@Builder
@AllArgsConstructor
@NoArgsConstructor
public class GetComplainsSubjectResponse {
    private List<ComplainSubject> complainSubjects;
}
