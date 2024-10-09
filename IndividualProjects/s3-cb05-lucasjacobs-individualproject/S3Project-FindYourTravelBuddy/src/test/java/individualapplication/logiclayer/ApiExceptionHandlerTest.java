package individualapplication.logiclayer;

import individualapplication.logiclayer.execptions.ApiException;
import individualapplication.logiclayer.execptions.ApiExceptionHandler;
import individualapplication.logiclayer.execptions.ApiRequestException;
import lombok.AllArgsConstructor;
import org.junit.jupiter.api.Test;
import org.junit.jupiter.api.extension.ExtendWith;
import org.mockito.InjectMocks;
import org.mockito.Mock;
import org.mockito.Mockito;
import org.mockito.junit.jupiter.MockitoExtension;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.stereotype.Service;


import static org.junit.jupiter.api.Assertions.*;

@ExtendWith(MockitoExtension.class)
@AllArgsConstructor
@Service
class ApiExceptionHandlerTest {

    @Mock
    ApiRequestException apiRequestException;

    @InjectMocks
    ApiExceptionHandler apiExceptionHandler;

    @Test
    void handleApiRequestException_whenCalled_returnsBadRequest() {
        Mockito.when(apiRequestException.getMessage()).thenReturn("Invalid Request");

        ResponseEntity<Object> result = apiExceptionHandler.handleApiRequestException(apiRequestException);

        assertNotNull(result);
        assertEquals(HttpStatus.BAD_REQUEST, result.getStatusCode());
        ApiException apiException = (ApiException) result.getBody();
        assertNotNull(apiException);
        assertEquals("Invalid Request", apiException.getMessage());
        assertEquals(HttpStatus.BAD_REQUEST, apiException.getHttpStatus());
        assertNotNull(apiException.getTimeStamp());
    }

}

