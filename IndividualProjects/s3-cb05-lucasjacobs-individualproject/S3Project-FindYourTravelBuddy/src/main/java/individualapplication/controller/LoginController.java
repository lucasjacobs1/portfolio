package individualapplication.controller;

import individualapplication.logiclayer.execptions.ApiRequestException;
import individualapplication.logiclayer.login.LoginAdmin;
import individualapplication.models.LoginRequest;
import individualapplication.models.LoginResponse;
import lombok.AllArgsConstructor;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import javax.validation.Valid;


@RestController
@RequestMapping("/login")
@AllArgsConstructor
@CrossOrigin(origins = "http://localhost:3000/", allowedHeaders = "*")
public class LoginController {
    private final LoginAdmin loginAdmin;

    @PostMapping
    public ResponseEntity<Object> login(@RequestBody @Valid LoginRequest loginRequest) {
        try{
            LoginResponse loginResponse = loginAdmin.login(loginRequest);
            return ResponseEntity.ok(loginResponse);
        }
        catch (ApiRequestException e){
            return ResponseEntity.badRequest().body(e);
        }
    }


}
