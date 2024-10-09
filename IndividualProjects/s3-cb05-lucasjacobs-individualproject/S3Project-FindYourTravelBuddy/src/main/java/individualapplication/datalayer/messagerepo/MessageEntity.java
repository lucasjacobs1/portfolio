package individualapplication.datalayer.messagerepo;

import individualapplication.datalayer.usermatch.matches.MatchEntity;
import individualapplication.datalayer.userrepo.UserEntity;
import lombok.AllArgsConstructor;
import lombok.Builder;
import lombok.Data;
import lombok.NoArgsConstructor;

import javax.persistence.*;
import javax.validation.constraints.NotNull;
import java.time.LocalDateTime;

@Entity
@Table(name = "message")
@Data
@Builder
@AllArgsConstructor
@NoArgsConstructor
public class MessageEntity {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "id")
    private Long id;

    @OneToOne
    @JoinColumn(name="buddy_match_id ")
    private MatchEntity buddyMatch;

    @NotNull
    @OneToOne
    @JoinColumn(name = "sender_user_id")
    private UserEntity sender;

    @NotNull
    @Column(name = "message_text")
    private String text;

    @NotNull
    @Column(name = "sent_dateTime")
    private LocalDateTime date;

}
