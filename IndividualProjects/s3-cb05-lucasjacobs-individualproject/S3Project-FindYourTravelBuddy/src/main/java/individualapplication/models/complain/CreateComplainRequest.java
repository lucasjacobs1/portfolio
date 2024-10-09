package individualapplication.models.complain;
import lombok.AllArgsConstructor;
import lombok.Builder;
import lombok.Data;
import lombok.NoArgsConstructor;


@Data
@Builder
@NoArgsConstructor
@AllArgsConstructor
public class CreateComplainRequest {
    private Long complainerId;
    private Long accusedId;
    private String context;
    private Long subjectId;
}
