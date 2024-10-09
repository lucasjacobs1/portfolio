package individualapplication.datalayer.usermatch.deniedusermatch;

import individualapplication.datalayer.userrepo.UserEntity;
import lombok.AllArgsConstructor;
import lombok.Builder;
import lombok.Data;
import lombok.NoArgsConstructor;

import javax.persistence.*;
import javax.validation.constraints.NotNull;

@Entity
@Table(name = "denied_user_matches")
@Data
@Builder
@AllArgsConstructor
@NoArgsConstructor
public class DeniedUserMatchEntity {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "id")
    private Long id;

    @NotNull
    @OneToOne
    @JoinColumn(name = "user_id")
    private UserEntity user;

    @NotNull
    @OneToOne
    @JoinColumn(name = "denied_user_id")
    private UserEntity denied_user;
}
