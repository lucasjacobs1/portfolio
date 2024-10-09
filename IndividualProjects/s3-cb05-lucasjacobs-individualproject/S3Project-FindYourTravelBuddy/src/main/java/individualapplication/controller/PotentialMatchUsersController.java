package individualapplication.controller;

import individualapplication.configuration.security.isauthenticated.IsAuthenticated;
import individualapplication.logiclayer.matchingbuddies.PotentialMatchUsersAdmin;
import individualapplication.logiclayer.user.UserAdmin;
import individualapplication.models.AccessToken;
import individualapplication.models.buddymatch.potentialusermatch.GetPotentialUserMatchesResponse;
import individualapplication.models.user.User;
import lombok.AllArgsConstructor;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import javax.annotation.security.RolesAllowed;
import java.util.Optional;

@RestController
@RequestMapping("/PotentialMatchUsers")
@AllArgsConstructor
@CrossOrigin("http://localhost:3000/")
public class PotentialMatchUsersController {
    private final PotentialMatchUsersAdmin matchUsersAdmin;
    private final UserAdmin userAdmin;
    private AccessToken accessToken;



    //look in to get operation for adding and then receiving the matches.
    //have a look if parameter needs to be a Id and not object because now we have two logic
   // classes in one controller


    @IsAuthenticated
    @RolesAllowed({"ROLE_ADMIN", "ROLE_USER"})
   @GetMapping()
   public ResponseEntity<User> getPotentialUserMatchesMadeForPersonById(){
       Optional<User> filteredUser = userAdmin.getUserById(accessToken.getId());
       if(filteredUser.isEmpty()){
           return ResponseEntity.notFound().build();
       }
       else{
           matchUsersAdmin.getPotentialUserMatchesForPerson(filteredUser.orElseThrow());
       }
       return ResponseEntity.ok().body(filteredUser.get());
   }

    @IsAuthenticated
    @RolesAllowed({"ROLE_ADMIN", "ROLE_USER"})
    @GetMapping("/filterByReceivedId")
    public ResponseEntity<GetPotentialUserMatchesResponse> getPotentialUserMatchesByReceivedId(){
        GetPotentialUserMatchesResponse filteredMatch = matchUsersAdmin.getPotentialUserMatchesByReceivedId(accessToken.getId());
        if(filteredMatch == null){
            return ResponseEntity.notFound().build();
        }
        return ResponseEntity.ok().body(filteredMatch);

    }

    @IsAuthenticated
    @RolesAllowed({"ROLE_ADMIN", "ROLE_USER"})
    @DeleteMapping("{userMatchId}")
    public ResponseEntity<Void> deleteUser(@PathVariable int userMatchId) {
        matchUsersAdmin.deletePotentialUsersMatch(userMatchId);
        return ResponseEntity.noContent().build();
    }

    @IsAuthenticated
    @RolesAllowed({"ROLE_ADMIN", "ROLE_USER"})
    @DeleteMapping("/deleteAll")
    public ResponseEntity<Void> deleteAllByReceivedUserId() {
        matchUsersAdmin.deleteAllPotentialUserMatchByReceivedUserId(accessToken.getId());
        return ResponseEntity.noContent().build();
    }



}
