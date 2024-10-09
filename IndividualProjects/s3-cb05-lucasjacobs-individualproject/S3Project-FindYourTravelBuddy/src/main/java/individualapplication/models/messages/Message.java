package individualapplication.models.messages;

import individualapplication.models.buddymatch.acceptedmatch.BuddyMatch;
import individualapplication.models.user.User;
import lombok.AllArgsConstructor;
import lombok.Builder;
import lombok.Data;
import lombok.NoArgsConstructor;

import java.time.LocalDateTime;

@Data
@Builder
@NoArgsConstructor
@AllArgsConstructor
public class Message {
    private Long id;
    private BuddyMatch buddyMatch;
    private User sender;
    private String text;
    private LocalDateTime dateTime;

}
