package edu.cumt.Annotation;

/**
 * Created by gaufung on 14/06/2017.
 */

import java.lang.annotation.*;
@Target(ElementType.METHOD)
@Retention(RetentionPolicy.RUNTIME)
@interface  Test{}

public class Testable {
    public void execute(){
        System.out.println("Executing...");
    }
    @Test void testExecute(){
        execute();
    }
}
