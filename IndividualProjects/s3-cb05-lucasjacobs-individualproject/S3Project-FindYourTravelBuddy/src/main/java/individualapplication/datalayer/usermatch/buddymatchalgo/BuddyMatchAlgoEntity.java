package individualapplication.datalayer.usermatch.buddymatchalgo;

import lombok.AllArgsConstructor;
import lombok.Builder;
import lombok.Data;
import lombok.NoArgsConstructor;

import javax.persistence.*;
import javax.validation.constraints.NotNull;

@Entity
@Table(name = "buddy_match_algorithms")
@Data
@Builder
@AllArgsConstructor
@NoArgsConstructor
public class BuddyMatchAlgoEntity {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "id")
    private Long id;

    @NotNull
    @Column(name = "name")
    private String name;

}
