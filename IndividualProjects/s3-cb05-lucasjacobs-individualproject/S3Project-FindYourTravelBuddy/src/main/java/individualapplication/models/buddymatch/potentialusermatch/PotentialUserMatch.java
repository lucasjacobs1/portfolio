package individualapplication.models.buddymatch.potentialusermatch;

import individualapplication.models.user.User;
import lombok.AllArgsConstructor;
import lombok.Builder;
import lombok.Data;
import lombok.NoArgsConstructor;

@Data
@Builder
@NoArgsConstructor
@AllArgsConstructor
public class PotentialUserMatch {
    private Long id;
    private User userReceived;
    private User userView;
    private Double matchScore;

}
