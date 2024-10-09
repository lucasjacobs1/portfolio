package individualapplication.datalayer.usermatch.potential;

import individualapplication.datalayer.userrepo.UserEntity;
import lombok.AllArgsConstructor;
import lombok.Builder;
import lombok.Data;
import lombok.NoArgsConstructor;

import javax.persistence.*;
import javax.validation.constraints.NotNull;

@Entity
@Table(name = "potential_user_matches")
@Data
@Builder
@AllArgsConstructor
@NoArgsConstructor
public class PotentialUserMatchEntity {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "id")
    private Long id;

    @NotNull
    @OneToOne
    @JoinColumn(name = "user_received_id")
    private UserEntity userReceived;

    @NotNull
    @OneToOne
    @JoinColumn(name = "user_view_id")
    private UserEntity userView;

    @NotNull
    @Column(name = "match_score")
    private double matchScore;
}
