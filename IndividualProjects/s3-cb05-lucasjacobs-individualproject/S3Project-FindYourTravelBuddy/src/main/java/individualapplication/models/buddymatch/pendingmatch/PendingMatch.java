package individualapplication.models.buddymatch.pendingmatch;

import individualapplication.models.user.User;
import lombok.AllArgsConstructor;
import lombok.Builder;
import lombok.Data;
import lombok.NoArgsConstructor;

@Data
@Builder
@NoArgsConstructor
@AllArgsConstructor
public class PendingMatch {
    private Long id;
    private User fromUserId;
    private User receivedUserId;
}
