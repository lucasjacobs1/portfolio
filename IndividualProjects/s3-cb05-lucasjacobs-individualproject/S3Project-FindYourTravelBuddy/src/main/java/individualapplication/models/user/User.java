package individualapplication.models.user;

import individualapplication.models.buddymatch.MatchAlgorithm;
import individualapplication.models.user.gender.GenderEnum;
import individualapplication.models.user.preferences.Preference;
import lombok.AllArgsConstructor;
import lombok.Builder;
import lombok.Data;
import lombok.NoArgsConstructor;

import java.time.LocalDate;
import java.util.Set;

@Data
@Builder
@NoArgsConstructor
@AllArgsConstructor
public class User {
    private Long id;
    private String firstName;
    private String lastName;
    private String userName;
    private String email;
    private GenderEnum gender;
    private LocalDate birthday;
    private String password;
    private Set<UserRole> roles;
    private Preference preference;
    private MatchAlgorithm algoChoice;
}
