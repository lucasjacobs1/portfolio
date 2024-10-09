package individualapplication.models.user.preferences;

import individualapplication.models.places.Place;
import individualapplication.models.user.gender.GenderEnum;
import lombok.AllArgsConstructor;
import lombok.Builder;
import lombok.Data;
import lombok.NoArgsConstructor;

@Data
@Builder
@NoArgsConstructor
@AllArgsConstructor
public class Preference {
    private Long id;
    private Long minAge;
    private Long maxAge;
    private Place place;
    private GenderEnum gender;
}
