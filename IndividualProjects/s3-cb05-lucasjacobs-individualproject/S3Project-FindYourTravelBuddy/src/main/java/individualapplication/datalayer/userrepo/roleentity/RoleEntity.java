package individualapplication.datalayer.userrepo.roleentity;

import individualapplication.datalayer.userrepo.UserEntity;
import individualapplication.models.user.RoleEnum;
import lombok.*;

import javax.persistence.*;
import javax.validation.constraints.NotNull;

@Entity
@Table(name = "role")
@Data
@Builder
@AllArgsConstructor
@NoArgsConstructor
public class RoleEntity {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "id")
    private Long id;

    @ManyToOne
    @JoinColumn(name = "user_id")
    @ToString.Exclude
    @EqualsAndHashCode.Exclude
    private UserEntity user;

    @NotNull
    @Column(name = "name")
    @Enumerated(EnumType.STRING)
    private RoleEnum name;
}
