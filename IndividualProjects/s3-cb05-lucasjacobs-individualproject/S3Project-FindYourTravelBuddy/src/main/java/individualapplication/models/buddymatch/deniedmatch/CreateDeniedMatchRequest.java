package individualapplication.models.buddymatch.deniedmatch;

import lombok.AllArgsConstructor;
import lombok.Builder;
import lombok.Data;
import lombok.NoArgsConstructor;

@Data
@Builder
@NoArgsConstructor
@AllArgsConstructor
public class CreateDeniedMatchRequest {
    private Long userId;
    private Long deniedUserId;
}
