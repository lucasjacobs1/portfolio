package individualapplication.controller;

import individualapplication.configuration.security.isauthenticated.IsAuthenticated;
import individualapplication.logiclayer.matchingbuddies.deniedusers.DeniedUsersAdmin;
import individualapplication.models.buddymatch.deniedmatch.CreateDeniedMatchRequest;
import individualapplication.models.buddymatch.deniedmatch.CreateDeniedMatchResponse;
import lombok.AllArgsConstructor;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import javax.annotation.security.RolesAllowed;
import javax.validation.Valid;

@RestController
@RequestMapping("/deniedUser")
@AllArgsConstructor
@CrossOrigin("http://localhost:3000/")
public class DeniedUserController {
    private final DeniedUsersAdmin deniedUsersAdmin;


    @IsAuthenticated
    @RolesAllowed({"ROLE_ADMIN", "ROLE_USER"})
    @PostMapping()
    public ResponseEntity<CreateDeniedMatchResponse> addDeniedUser(@RequestBody @Valid CreateDeniedMatchRequest request) {
        CreateDeniedMatchResponse response = deniedUsersAdmin.save(request);
        return ResponseEntity.status(HttpStatus.CREATED).body(response);
    }
}
