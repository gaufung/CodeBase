package edu.cumt.Annotation;

import java.lang.annotation.*;
import java.util.List;

/**
 * Created by gaufung on 14/06/2017.
 */
@Target(ElementType.METHOD)
@Retention(RetentionPolicy.RUNTIME)
@interface UseCase{
    public int id();
    public String descipition() default "no description";
}
public class PasswordUtil {
    @UseCase(id = 47, descipition = "passwords must at least one numeric")
    public boolean validatePassword(String password){
        return password.matches("\\w*\\d\\w*");
    }
    @UseCase(id=48)
    public String encryptPassword(String password){
        return new StringBuilder(password).reverse().toString();
    }
    @UseCase(id = 49, descipition = "New Password can't equal previously used ones")
    public boolean checkForNewPassword(List<String> prevPasswords, String password){
        return !prevPasswords.contains(password);
    }
}
