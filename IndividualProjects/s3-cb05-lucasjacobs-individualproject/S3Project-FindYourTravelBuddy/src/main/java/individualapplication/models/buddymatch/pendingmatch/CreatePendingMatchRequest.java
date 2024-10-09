package individualapplication.models.buddymatch.pendingmatch;

import lombok.AllArgsConstructor;
import lombok.Builder;
import lombok.Data;
import lombok.NoArgsConstructor;

@Data
@Builder
@NoArgsConstructor
@AllArgsConstructor
public class CreatePendingMatchRequest {
    private Long fromUserId;
    private Long receivedUserId;
}
