package individualapplication.logiclayer.execptions;

public class ApiRequestException extends RuntimeException {
    public ApiRequestException(String message){
        super(message);
    }
}
