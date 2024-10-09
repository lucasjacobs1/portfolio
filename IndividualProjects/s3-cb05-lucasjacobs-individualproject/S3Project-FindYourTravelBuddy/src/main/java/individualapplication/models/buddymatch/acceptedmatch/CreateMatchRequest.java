package individualapplication.models.buddymatch.acceptedmatch;

import individualapplication.models.user.User;
import lombok.AllArgsConstructor;
import lombok.Builder;
import lombok.Data;
import lombok.NoArgsConstructor;

@Data
@Builder
@NoArgsConstructor
@AllArgsConstructor
public class CreateMatchRequest {
    private User buddy1;
    private User buddy2;

}
