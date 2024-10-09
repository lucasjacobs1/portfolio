package individualapplication.models.complain;
import individualapplication.models.complain.complainsubject.ComplainSubject;
import individualapplication.models.user.User;
import lombok.AllArgsConstructor;
import lombok.Builder;
import lombok.Data;
import lombok.NoArgsConstructor;


@Data
@Builder
@NoArgsConstructor
@AllArgsConstructor
public class Complain {
    private Long id;
    private User complainerId;
    private User accusedId;
    private String context;
    private ComplainSubject subjectId;
}
