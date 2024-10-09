package individualapplication.logiclayer.execptions;

import org.springframework.http.HttpStatus;
import org.springframework.web.server.ResponseStatusException;

public class InvalidUsernameException extends ResponseStatusException {
    public InvalidUsernameException(){
        super(HttpStatus.BAD_REQUEST, "Username is not valid");
    }
}
