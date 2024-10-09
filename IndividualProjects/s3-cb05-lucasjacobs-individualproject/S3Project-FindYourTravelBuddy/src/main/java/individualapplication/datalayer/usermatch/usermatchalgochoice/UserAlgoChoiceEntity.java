package individualapplication.datalayer.usermatch.usermatchalgochoice;

import individualapplication.datalayer.usermatch.buddymatchalgo.BuddyMatchAlgoEntity;
import individualapplication.datalayer.userrepo.UserEntity;
import lombok.AllArgsConstructor;
import lombok.Builder;
import lombok.Data;
import lombok.NoArgsConstructor;

import javax.persistence.*;
import javax.validation.constraints.NotNull;

@Entity
@Table(name = "user_match_algorithm_choice")
@Data
@Builder
@AllArgsConstructor
@NoArgsConstructor
public class UserAlgoChoiceEntity {
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
    @JoinColumn(name = "match_algorithm_id")
    private BuddyMatchAlgoEntity buddyMatchAlgo;


}
