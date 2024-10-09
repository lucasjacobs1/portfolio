package individualapplication.controller;

import individualapplication.configuration.security.isauthenticated.IsAuthenticated;
import individualapplication.logiclayer.complain.ComplainAdmin;
import individualapplication.models.complain.CreateComplainRequest;
import individualapplication.models.complain.CreateComplainResponse;
import individualapplication.models.complain.GetComplainsResponse;
import lombok.AllArgsConstructor;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import javax.validation.Valid;

@RestController
@RequestMapping("/complains")
@AllArgsConstructor
@CrossOrigin("http://localhost:3000/")
public class ComplainController {
    private final ComplainAdmin complainAdmin;

    @IsAuthenticated
    @PostMapping()
    public ResponseEntity<CreateComplainResponse> createComplain(@RequestBody @Valid CreateComplainRequest request) {
        CreateComplainResponse response = complainAdmin.createComplain(request);
        return ResponseEntity.status(HttpStatus.CREATED).body(response);
    }

    @GetMapping
    public ResponseEntity<GetComplainsResponse> getAllComplains() {
        GetComplainsResponse response = complainAdmin.getComplains();
        return ResponseEntity.ok().body(response);
    }

}
