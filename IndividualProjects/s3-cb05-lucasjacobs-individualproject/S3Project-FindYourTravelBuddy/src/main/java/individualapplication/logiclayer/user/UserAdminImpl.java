package individualapplication.logiclayer.user;

import individualapplication.datalayer.placerepo.PlaceEntity;
import individualapplication.datalayer.usermatch.buddymatchalgo.BuddyMatchAlgoEntity;
import individualapplication.datalayer.usermatch.buddymatchalgo.BuddyMatchAlgoRepository;
import individualapplication.datalayer.userrepo.preferencerepo.PreferenceEntity;
import individualapplication.datalayer.userrepo.preferencerepo.PreferenceRepository;
import individualapplication.datalayer.userrepo.roleentity.RoleEntity;
import individualapplication.datalayer.userrepo.roleentity.RoleRepository;
import individualapplication.datalayer.userrepo.UserEntity;
import individualapplication.datalayer.userrepo.UserRepository;
import individualapplication.logiclayer.UserHelper;
import individualapplication.logiclayer.execptions.InvalidBirthdayException;
import individualapplication.logiclayer.execptions.InvalidEmailException;
import individualapplication.logiclayer.execptions.InvalidUsernameException;
import individualapplication.models.buddymatch.UpdateMatchAlgorithmRequest;
import individualapplication.models.user.*;
import individualapplication.models.user.gender.GenderEnum;
import lombok.AllArgsConstructor;
import org.springframework.security.crypto.password.PasswordEncoder;
import org.springframework.stereotype.Service;

import javax.transaction.Transactional;
import java.time.LocalDate;
import java.util.List;
import java.util.Optional;
import java.util.Set;

@Service
@AllArgsConstructor
public class UserAdminImpl implements UserAdmin {
    private final UserRepository userRepository;
    private final PreferenceRepository preferenceRepository;
    private final RoleRepository roleRepository;

    private final PasswordEncoder passwordEncoder;

    private final BuddyMatchAlgoRepository buddyMatchAlgoRepository;
    @Override
    @Transactional
    public CreateUserResponse createUser(CreateUserRequest request) {
        LocalDate oldEnough = LocalDate.now().minusYears(18);
        if (existsByUsername(request.getUserName())) {
            throw new InvalidUsernameException();
        } else if (request.getUserName().length() <= 2 || request.getUserName().length() >= 30) {
            throw new InvalidUsernameException();
        } else if (request.getFirstName().length() <= 2 || request.getFirstName().length() >= 30) {
            throw new IllegalArgumentException();
        } else if (request.getLastName().length() <= 2 || request.getLastName().length() >= 30) {
            throw new IllegalArgumentException();
        } else if (request.getBirthday().isAfter(oldEnough)) {
            throw new InvalidBirthdayException();
        } else if (Boolean.FALSE.equals(UserHelper.validateEmail(request.getEmail()))) {
            throw new InvalidEmailException();
        } else if(request.getPassword().length() <=3 || request.getPassword().length() >=30){
            throw new IllegalArgumentException();
        }
        else {
            UserEntity user = saveNewUser(request);

            return CreateUserResponse.builder()
                    .id(user.getId())
                    .build();
        }
    }

    private boolean existsByUsername(String username) {
        return userRepository.existsByUserName(username);
    }

    public UserEntity saveNewUser(CreateUserRequest request) {
        String encodedPassword = passwordEncoder.encode(request.getPassword());
        PreferenceEntity preference = PreferenceEntity.builder().minAge(18L).maxAge(75L).gender(request.getGender()).place(PlaceEntity.builder().id(6L).name("All").build()).build();

        preferenceRepository.save(preference);
        UserEntity user = UserEntity.builder()
                .firstName(request.getFirstName())
                .lastName(request.getLastName())
                .userName(request.getUserName())
                .birthday(request.getBirthday())
                .email(request.getEmail())
                .gender(request.getGender())
                .password(encodedPassword)
                .build();
        user.setUserRoles(Set.of(RoleEntity.builder().user(user).name(RoleEnum.USER).build()));
        user.setPreference(preference);
        user.setBuddyMatchAlgo(BuddyMatchAlgoEntity.builder().id(2L).name("No Preference Matching").build());
        return userRepository.save(user);

    }

    @Override
    public GetUsersResponse getUsers() {
        final GetUsersResponse response = new GetUsersResponse();
        List<User> users = userRepository.findAll()
                .stream()
                .map(UserConverter::convert)
                .toList();
        response.setUsers(users);

        return response;
    }

    @Override
    public GetUsersResponse getUsersByGender(GenderEnum genderEnum) {
        final GetUsersResponse response = new GetUsersResponse();
        List<UserEntity> usersFiltered = userRepository.getUserEntitiesByGender(genderEnum);
        List<User> users = usersFiltered.stream().map(UserConverter::convert).toList();
        response.setUsers(users);

        return response;
    }

    @Override
    public Optional<User> getUserById(Long id){

        User user = userRepository.findById(id).map(UserConverter:: convert).orElseThrow();

        UserRole userRole = RoleConverter.convert(roleRepository.getRoleEntityByUserId(user.getId()));
        user.setRoles(Set.of(userRole));
        return Optional.of(user);
    }

    @Override
    @Transactional
    public void deleteUser(Long id) {
        Optional<UserEntity> user = userRepository.findById(id);
        this.userRepository.deleteById(id);
        preferenceRepository.deleteById(user.orElseThrow().getPreference().getId());
    }

    @Override
    public void updateUser(UpdateUserRequest request) {
        if (Boolean.FALSE.equals(UserHelper.validateEmail(request.getEmail()))) {
            throw new InvalidEmailException();
        }
        else if (request.getUserName().length() <= 2 || request.getUserName().length() >= 30) {
            throw new InvalidUsernameException();
        } else {
            updateFields(request);
        }
    }

    private void updateFields(UpdateUserRequest updateUserRequest) {
        UserEntity user = userRepository.findById(updateUserRequest.getId()).orElseThrow();
        if(!updateUserRequest.getPassword().equals("")){
            String encodedPassword = passwordEncoder.encode(updateUserRequest.getPassword());
            user.setPassword(encodedPassword);
        }
        if(!updateUserRequest.getUserName().equals(user.getUserName()) && existsByUsername(updateUserRequest.getUserName())){
                throw new InvalidUsernameException();
        }
        user.setEmail(updateUserRequest.getEmail());
        user.setUserName(updateUserRequest.getUserName());

        userRepository.save(user);
    }

    @Override
    @Transactional
    public void updateAlgorithmChoice(UpdateMatchAlgorithmRequest request, Long id){

            UserEntity user = userRepository.findById(id).orElseThrow();
            BuddyMatchAlgoEntity buddy = buddyMatchAlgoRepository.findById(request.getId()).orElseThrow();
            user.setBuddyMatchAlgo(buddy);
            userRepository.save(user);

    }
}