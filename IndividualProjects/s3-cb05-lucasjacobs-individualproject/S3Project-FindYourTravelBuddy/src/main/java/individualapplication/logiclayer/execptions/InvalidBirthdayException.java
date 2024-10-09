package individualapplication.logiclayer.execptions;

import org.springframework.http.HttpStatus;
import org.springframework.web.server.ResponseStatusException;

public class InvalidBirthdayException extends ResponseStatusException {
    public InvalidBirthdayException(){
        super(HttpStatus.BAD_REQUEST, "You need to be at least 18 years old");
    }
}
