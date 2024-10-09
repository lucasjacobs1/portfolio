package individualapplication.datalayer.complainrepo;

import individualapplication.datalayer.complainrepo.complainsubject.ComplainSubjectEntity;
import individualapplication.datalayer.userrepo.UserEntity;
import lombok.AllArgsConstructor;
import lombok.Builder;
import lombok.Data;
import lombok.NoArgsConstructor;

import javax.persistence.*;
import javax.validation.constraints.NotNull;

@Entity
@Table(name = "complain")
@Data
@Builder
@AllArgsConstructor
@NoArgsConstructor
public class ComplainEntity {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "id")
    private Long id;

    @NotNull
    @OneToOne
    @JoinColumn(name = "complainer_user_id")
    private UserEntity complainer;

    @NotNull
    @OneToOne
    @JoinColumn(name = "accused_user_id")
    private UserEntity accused;

    @NotNull
    @Column(name = "context")
    private String context;

    @NotNull
    @ManyToOne
    @JoinColumn(name = "subject_id")
    private ComplainSubjectEntity complainSubject;







}
