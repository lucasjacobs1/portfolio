package individualapplication.logiclayer;

import java.util.regex.Pattern;

public class UserHelper {
    private UserHelper(){}


    public static Boolean validateEmail(String email){
        if(email == null){
            return false;
        }
        else{
            try{
                String emailRegex = "^[a-zA-Z0-9_!#$%&'*+/=?`{|}~^.-]+@[a-zA-Z0-9.-]+$";
                Pattern pat = Pattern.compile(emailRegex);
                //checks if the string input email, is valid to the regular expression.
                return pat.matcher(email).matches();
            }
            catch(Exception ex){
                return false;
            }
        }

    }

}
