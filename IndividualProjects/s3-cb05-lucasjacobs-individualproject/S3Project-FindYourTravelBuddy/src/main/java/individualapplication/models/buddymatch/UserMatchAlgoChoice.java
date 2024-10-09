package individualapplication.models.buddymatch;

import lombok.AllArgsConstructor;
import lombok.Builder;
import lombok.Data;
import lombok.NoArgsConstructor;

@Data
@Builder
@NoArgsConstructor
@AllArgsConstructor
public class UserMatchAlgoChoice {
    private Long id;
    private Long userId;
    private Long matchAlgoId;
}
