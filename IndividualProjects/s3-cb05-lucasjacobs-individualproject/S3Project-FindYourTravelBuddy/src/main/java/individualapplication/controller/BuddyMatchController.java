package individualapplication.controller;

import individualapplication.configuration.security.isauthenticated.IsAuthenticated;
import individualapplication.logiclayer.matchingbuddies.matches.MatchAdmin;
import individualapplication.models.AccessToken;
import individualapplication.models.buddymatch.acceptedmatch.BuddyMatch;
import individualapplication.models.buddymatch.acceptedmatch.CreateMatchRequest;
import individualapplication.models.buddymatch.acceptedmatch.CreateMatchResponse;
import individualapplication.models.buddymatch.acceptedmatch.GetMatchesResponse;
import lombok.AllArgsConstructor;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import javax.annotation.security.RolesAllowed;
import javax.validation.Valid;
import java.util.Optional;

@RestController
@RequestMapping("/match")
@AllArgsConstructor
@CrossOrigin("http://localhost:3000/")
public class BuddyMatchController {
    private final MatchAdmin matchAdmin;
    private AccessToken accessToken;


    @IsAuthenticated
    @RolesAllowed({"ROLE_ADMIN", "ROLE_USER"})
    @PostMapping()
    public ResponseEntity<CreateMatchResponse> createUser(@RequestBody @Valid CreateMatchRequest request) {
        CreateMatchResponse response = matchAdmin.createMatchResponse(request);
        return ResponseEntity.status(HttpStatus.CREATED).body(response);
    }

    @IsAuthenticated
    @RolesAllowed({"ROLE_ADMIN", "ROLE_USER"})
    @GetMapping("/filterById")
    public ResponseEntity<GetMatchesResponse> getPendingUserMatchesByReceivedUserId(){
        GetMatchesResponse pendingMatches = matchAdmin.getAllByUserLoggedInId(accessToken.getId());
        if(pendingMatches == null){
            return ResponseEntity.notFound().build();
        }
        return ResponseEntity.ok().body(pendingMatches);

    }

    @IsAuthenticated
    @GetMapping("{id}")
    public ResponseEntity<BuddyMatch> getMatchById(@PathVariable Long id){
        Optional<BuddyMatch> match = matchAdmin.findMatchById(id);
        if(match.isEmpty()){
            return ResponseEntity.notFound().build();
        }
        return ResponseEntity.ok().body(match.get());
    }
}
