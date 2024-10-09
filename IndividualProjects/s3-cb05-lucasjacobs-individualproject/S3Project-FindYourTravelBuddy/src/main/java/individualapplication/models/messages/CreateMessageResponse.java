package individualapplication.models.messages;

import lombok.Builder;
import lombok.Data;

@Data
@Builder
public class CreateMessageResponse {
    private Long id;
}