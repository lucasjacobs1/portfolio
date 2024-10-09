package individualapplication.controller;

import individualapplication.configuration.security.isauthenticated.IsAuthenticated;
import individualapplication.logiclayer.user.UserAdmin;
import individualapplication.models.AccessToken;
import individualapplication.models.buddymatch.UpdateMatchAlgorithmRequest;
import individualapplication.models.user.*;
import individualapplication.models.user.gender.GenderEnum;
import lombok.AllArgsConstructor;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import javax.annotation.security.RolesAllowed;
import javax.validation.Valid;
import java.util.Optional;

@RestController
@RequestMapping("/users")
@AllArgsConstructor
@CrossOrigin("http://localhost:3000/")
public class UserController {

    private final UserAdmin userAdmin;


    private AccessToken accessToken;

    @PostMapping()
    public ResponseEntity<CreateUserResponse> createUser(@RequestBody @Valid CreateUserRequest request) {
        CreateUserResponse response = userAdmin.createUser(request);
        return ResponseEntity.status(HttpStatus.CREATED).body(response);
    }


    @IsAuthenticated
    @RolesAllowed({"ROLE_ADMIN"})
    @GetMapping
    public ResponseEntity<GetUsersResponse> getAllUsers() {
        GetUsersResponse response = userAdmin.getUsers();
        return ResponseEntity.ok().body(response);
    }

    @IsAuthenticated
    @RolesAllowed({"ROLE_ADMIN"})
    @GetMapping("{Gender}")
    public ResponseEntity<GetUsersResponse> getAllUsersByGender(@PathVariable(value = "Gender") final GenderEnum genderEnum){
        GetUsersResponse filteredUsers = userAdmin.getUsersByGender(genderEnum);
        if(filteredUsers.getUsers().isEmpty()){
            return ResponseEntity.notFound().build();
        }
        return ResponseEntity.ok().body(filteredUsers);

    }

    @IsAuthenticated
    @RolesAllowed({"ROLE_ADMIN"})
    @DeleteMapping("{id}")
    public ResponseEntity<Void> deleteUser(@PathVariable Long id) {
        userAdmin.deleteUser(id);
        return ResponseEntity.noContent().build();
    }

    @IsAuthenticated
    @RolesAllowed({"ROLE_ADMIN"})
    @PutMapping("{userId}")
    public ResponseEntity<Void> updateUser(@PathVariable Long userId,
                                           @RequestBody @Valid UpdateUserRequest request){
        request.setId(userId);
        userAdmin.updateUser(request);
        return ResponseEntity.noContent().build();
    }

    @IsAuthenticated
    @GetMapping("/filterById")
    public ResponseEntity<User> getUserById(){
        Optional<User> filteredUser = userAdmin.getUserById(accessToken.getId());
        if(filteredUser.isEmpty()){
            return ResponseEntity.notFound().build();
        }
        return ResponseEntity.ok().body(filteredUser.get());
    }


    @IsAuthenticated
    @RolesAllowed({"ROLE_ADMIN", "ROLE_USER"})
    @PutMapping("/updateMatching")
    public ResponseEntity<Void> updateAlgorithm(@RequestBody @Valid UpdateMatchAlgorithmRequest request){
        userAdmin.updateAlgorithmChoice(request, accessToken.getId());
        return ResponseEntity.noContent().build();
    }


}


