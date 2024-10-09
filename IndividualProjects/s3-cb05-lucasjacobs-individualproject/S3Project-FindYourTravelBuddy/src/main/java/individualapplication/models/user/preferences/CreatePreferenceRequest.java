package individualapplication.models.user.preferences;
import individualapplication.models.user.gender.GenderEnum;
import lombok.AllArgsConstructor;
import lombok.Builder;
import lombok.Data;
import lombok.NoArgsConstructor;

@Data
@Builder
@NoArgsConstructor
@AllArgsConstructor
public class CreatePreferenceRequest {
    private Long minAge;
    private Long maxAge;
    private Long placeId;
    private GenderEnum gender;
}
