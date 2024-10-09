package individualapplication.models.user;

import individualapplication.models.user.gender.GenderEnum;
import lombok.AllArgsConstructor;
import lombok.Builder;
import lombok.Data;
import lombok.NoArgsConstructor;

import java.time.LocalDate;

@Data
@Builder
@NoArgsConstructor
@AllArgsConstructor
public class CreateUserRequest {
    private String firstName;
    private String lastName;
    private String userName;
    private String email;
    private GenderEnum gender;
    private LocalDate birthday;
    private String password;
    private RoleEnum role;
}
