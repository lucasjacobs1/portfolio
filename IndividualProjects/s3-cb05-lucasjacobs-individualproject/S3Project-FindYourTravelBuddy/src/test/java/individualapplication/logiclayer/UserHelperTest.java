package individualapplication.logiclayer;

import org.junit.jupiter.api.Test;

import static org.junit.jupiter.api.Assertions.*;

class UserHelperTest {
    @Test
    void EmailValidatorWithWrongEmail_Works(){
        //arrange
        String email = null;

        //act
        var checkEmail = UserHelper.validateEmail(email);

        //assert
        assertFalse(checkEmail);
    }

    @Test
    void EmailValidatorWithCorrectEmail_Works(){
        //arrange
        String email = "test@test.com";

        //act
        var checkEmail = UserHelper.validateEmail(email);

        //assert
        assertTrue(checkEmail);
    }

}