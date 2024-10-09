package individualapplication.datalayer.userrepo.preferencerepo;
import individualapplication.datalayer.placerepo.PlaceEntity;
import individualapplication.models.user.gender.GenderEnum;
import lombok.AllArgsConstructor;
import lombok.Builder;
import lombok.Data;
import lombok.NoArgsConstructor;

import javax.persistence.*;
import javax.validation.constraints.NotNull;

@Entity
@Table(name = "preferences")
@Data
@Builder
@AllArgsConstructor
@NoArgsConstructor
public class PreferenceEntity {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "id")
    private Long id;

    @NotNull
    @Column(name = "min_age")
    private Long minAge;

    @NotNull
    @Column(name = "max_age")
    private Long maxAge;

    @NotNull
    @ManyToOne
    @JoinColumn(name = "place_travel_id")
    private PlaceEntity place;

    @NotNull
    @Column(name = "gender")
    private GenderEnum gender;



}
