package individualapplication.controller;

import individualapplication.configuration.security.isauthenticated.IsAuthenticated;
import individualapplication.datalayer.placerepo.PlaceEntity;
import individualapplication.logiclayer.places.PlaceAdmin;
import individualapplication.models.places.GetPlacesResponse;
import lombok.AllArgsConstructor;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import javax.annotation.security.RolesAllowed;

@RestController
@RequestMapping("/place")
@AllArgsConstructor
@CrossOrigin("http://localhost:3000/")
public class PlaceController {
    private final PlaceAdmin placeAdmin;

    @IsAuthenticated
    @RolesAllowed({"ROLE_ADMIN", "ROLE_USER"})
    @GetMapping
    public ResponseEntity<GetPlacesResponse> getAllPlaces() {
        GetPlacesResponse response = placeAdmin.getPlaces();
        return ResponseEntity.ok().body(response);
    }

    @IsAuthenticated
    @RolesAllowed({"ROLE_ADMIN", "ROLE_USER"})
    @GetMapping("{id}")
    public ResponseEntity<PlaceEntity> getById(@PathVariable Long id) {
        PlaceEntity response = placeAdmin.getById(id);
        return ResponseEntity.ok().body(response);
    }

    @IsAuthenticated
    @RolesAllowed({"ROLE_ADMIN", "ROLE_USER"})
    @GetMapping("getPlaceName/{name}")
    public ResponseEntity<PlaceEntity> getByName(@PathVariable String name) {
        PlaceEntity response = placeAdmin.getByName(name);
        return ResponseEntity.ok().body(response);
    }




}
