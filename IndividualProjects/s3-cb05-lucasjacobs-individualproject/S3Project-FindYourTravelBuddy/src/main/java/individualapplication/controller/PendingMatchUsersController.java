package individualapplication.controller;

import individualapplication.configuration.security.isauthenticated.IsAuthenticated;
import individualapplication.logiclayer.matchingbuddies.pending.PendingUserMatchAdmin;
import individualapplication.models.AccessToken;
import individualapplication.models.buddymatch.pendingmatch.CreatePendingMatchRequest;
import individualapplication.models.buddymatch.pendingmatch.CreatePendingMatchResponse;
import individualapplication.models.buddymatch.pendingmatch.GetPendingMatchesResponse;
import lombok.AllArgsConstructor;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import javax.annotation.security.RolesAllowed;
import javax.validation.Valid;

@RestController
@RequestMapping("/PendingMatchUser")
@AllArgsConstructor
@CrossOrigin("http://localhost:3000/")
public class PendingMatchUsersController {
    private PendingUserMatchAdmin pendingUserMatchAdmin;
    private AccessToken accessToken;

    @IsAuthenticated
    @RolesAllowed({"ROLE_ADMIN", "ROLE_USER"})
    @PostMapping()
    public ResponseEntity<CreatePendingMatchResponse> createUser(@RequestBody @Valid CreatePendingMatchRequest request) {
        CreatePendingMatchResponse response = pendingUserMatchAdmin.createPendingUserMatchResponse(request);
        return ResponseEntity.status(HttpStatus.CREATED).body(response);
    }

    @IsAuthenticated
    @RolesAllowed({"ROLE_ADMIN", "ROLE_USER"})
    @DeleteMapping("{id}")
    public ResponseEntity<Void> deletePending(@PathVariable Long id) {
        pendingUserMatchAdmin.deletePendingById(id);
        return ResponseEntity.noContent().build();
    }

    @IsAuthenticated
    @RolesAllowed({"ROLE_ADMIN", "ROLE_USER"})
    @GetMapping("/filterById")
    public ResponseEntity<GetPendingMatchesResponse> getPendingUserMatchesByReceivedUserId(){
        GetPendingMatchesResponse pendingMatches = pendingUserMatchAdmin.getAllByUserReceivedId(accessToken.getId());
        if(pendingMatches == null){
            return ResponseEntity.notFound().build();
        }
        return ResponseEntity.ok().body(pendingMatches);

    }

}
