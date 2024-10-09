package individualapplication.datalayer.usermatch.pendingusermatch;

import individualapplication.datalayer.userrepo.UserEntity;
import lombok.AllArgsConstructor;
import lombok.Builder;
import lombok.Data;
import lombok.NoArgsConstructor;

import javax.persistence.*;
import javax.validation.constraints.NotNull;

@Entity
@Table(name = "pending_buddy_match")
@Data
@Builder
@AllArgsConstructor
@NoArgsConstructor
public class PendingBuddyMatchEntity {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "id")
    private Long id;

    @NotNull
    @OneToOne
    @JoinColumn(name = "from_user_id")
    private UserEntity fromUser;

    @NotNull
    @OneToOne
    @JoinColumn(name = "received_user_id")
    private UserEntity userReceived;
}
