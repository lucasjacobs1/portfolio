package individualapplication.logiclayer.user;

import individualapplication.models.buddymatch.UpdateMatchAlgorithmRequest;
import individualapplication.models.user.*;
import individualapplication.models.user.gender.GenderEnum;

import java.util.Optional;

public interface UserAdmin {
    CreateUserResponse createUser(CreateUserRequest request);
    GetUsersResponse getUsers();
    void deleteUser(Long user);
    void updateUser(UpdateUserRequest request);

    GetUsersResponse getUsersByGender(GenderEnum genderEnum);
    Optional<User> getUserById(Long id);
    void updateAlgorithmChoice(UpdateMatchAlgorithmRequest request, Long id);

}
