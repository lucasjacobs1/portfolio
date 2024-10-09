package individualapplication.controller;

import individualapplication.configuration.security.isauthenticated.IsAuthenticated;
import individualapplication.logiclayer.user.preferences.PreferenceAdmin;
import individualapplication.models.AccessToken;
import individualapplication.models.user.preferences.CreatePreferenceRequest;
import individualapplication.models.user.preferences.CreatePreferenceResponse;
import individualapplication.models.user.preferences.UpdatePreferenceRequest;
import lombok.AllArgsConstructor;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import javax.annotation.security.RolesAllowed;
import javax.validation.Valid;

@RestController
@RequestMapping("/preferences")
@AllArgsConstructor
@CrossOrigin("http://localhost:3000/")
public class PreferenceController {
    private final PreferenceAdmin preferenceAdmin;
    private AccessToken accessToken;


    @PostMapping()
    public ResponseEntity<CreatePreferenceResponse> createPreference(@RequestBody @Valid CreatePreferenceRequest request) {
        CreatePreferenceResponse response = preferenceAdmin.createPreference(request);
        return ResponseEntity.status(HttpStatus.CREATED).body(response);
    }


    @IsAuthenticated
    @RolesAllowed({"ROLE_ADMIN", "ROLE_USER"})
    @PutMapping()
    public ResponseEntity<Void> updatePreference(@RequestBody @Valid UpdatePreferenceRequest request){
        preferenceAdmin.updatePreferences(request, accessToken.getId());
        return ResponseEntity.noContent().build();
    }
}
