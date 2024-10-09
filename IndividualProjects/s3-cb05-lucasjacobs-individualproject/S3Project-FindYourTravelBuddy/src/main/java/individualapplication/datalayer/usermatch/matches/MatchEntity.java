package individualapplication.datalayer.usermatch.matches;

import individualapplication.datalayer.userrepo.UserEntity;
import lombok.AllArgsConstructor;
import lombok.Builder;
import lombok.Data;
import lombok.NoArgsConstructor;

import javax.persistence.*;
import javax.validation.constraints.NotNull;

@Entity
@Table(name = "buddy_matches")
@Data
@Builder
@AllArgsConstructor
@NoArgsConstructor
public class MatchEntity {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "id")
    private Long id;

    @NotNull
    @OneToOne
    @JoinColumn(name = "buddy1_id")
    private UserEntity buddy1;

    @NotNull
    @OneToOne
    @JoinColumn(name = "buddy2_id")
    private UserEntity buddy2;
}
