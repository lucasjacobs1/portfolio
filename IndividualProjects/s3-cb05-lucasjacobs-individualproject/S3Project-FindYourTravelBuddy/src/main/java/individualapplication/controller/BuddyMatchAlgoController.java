package individualapplication.controller;

import individualapplication.configuration.security.isauthenticated.IsAuthenticated;
import individualapplication.datalayer.usermatch.buddymatchalgo.BuddyMatchAlgoEntity;
import individualapplication.logiclayer.matchingbuddies.buddymatchalgo.BuddyMatchAlgoAdmin;
import individualapplication.models.buddymatch.GetBuddyMatchAlgosResponse;
import lombok.AllArgsConstructor;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import javax.annotation.security.RolesAllowed;

@RestController
@RequestMapping("/BuddyMatchAlgo")
@AllArgsConstructor
@CrossOrigin("http://localhost:3000/")
public class BuddyMatchAlgoController {
    private final BuddyMatchAlgoAdmin buddyMatchAlgoAdmin;

    @IsAuthenticated
    @RolesAllowed({"ROLE_ADMIN", "ROLE_USER"})
    @GetMapping
    public ResponseEntity<GetBuddyMatchAlgosResponse> getAllBuddyAlgo() {
        GetBuddyMatchAlgosResponse response = buddyMatchAlgoAdmin.getAllAlgorithmsOfBuddy();
        return ResponseEntity.ok().body(response);
    }

    @IsAuthenticated
    @RolesAllowed({"ROLE_ADMIN", "ROLE_USER"})
    @GetMapping("getAlgoName/{name}")
    public ResponseEntity<BuddyMatchAlgoEntity> getByName(@PathVariable String name) {
        BuddyMatchAlgoEntity response = buddyMatchAlgoAdmin.getByName(name);
        return ResponseEntity.ok().body(response);
    }


}
