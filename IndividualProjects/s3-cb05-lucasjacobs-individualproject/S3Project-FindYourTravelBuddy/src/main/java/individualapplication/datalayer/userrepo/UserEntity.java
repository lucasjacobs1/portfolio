package individualapplication.datalayer.userrepo;

import individualapplication.datalayer.usermatch.buddymatchalgo.BuddyMatchAlgoEntity;
import individualapplication.datalayer.userrepo.preferencerepo.PreferenceEntity;
import individualapplication.datalayer.userrepo.roleentity.RoleEntity;
import individualapplication.models.user.gender.GenderEnum;
import lombok.AllArgsConstructor;
import lombok.Builder;
import lombok.Data;
import lombok.NoArgsConstructor;

import javax.persistence.*;
import javax.validation.constraints.NotNull;
import java.time.LocalDate;
import java.util.Set;

@Entity
@Table(name = "user")
@Data
@Builder
@AllArgsConstructor
@NoArgsConstructor
public class UserEntity {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "id")
    private Long id;

    @NotNull
    @Column(name = "first_name")
    private String firstName;

    @NotNull
    @Column(name = "last_name")
    private String lastName;

    @NotNull
    @Column(name = "username")
    private String userName;

    @NotNull
    @Column(name = "email")
    private String email;

    @NotNull
    @Column(name = "gender")
    private GenderEnum gender;

    @NotNull
    @Column(name = "birthday")
    private LocalDate birthday;

    @NotNull
    @Column(name = "password")
    private String password;

    @OneToMany(mappedBy = "user", cascade = CascadeType.ALL, fetch = FetchType.EAGER, orphanRemoval = true)
    private Set<RoleEntity> userRoles;

    @OneToOne
    @JoinColumn(name= "preference_id")
    private PreferenceEntity preference;

    @OneToOne
    @JoinColumn(name="match_algorithm_id ")
    private BuddyMatchAlgoEntity buddyMatchAlgo;






}
