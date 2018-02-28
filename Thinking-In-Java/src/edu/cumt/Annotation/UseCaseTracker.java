package edu.cumt.Annotation;

import java.lang.reflect.Method;
import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

/**
 * Created by gaufung on 14/06/2017.
 */
public class UseCaseTracker {
    public static void trackUsecases(List<Integer> useCases, Class<?> cl){
        for(Method m:cl.getDeclaredMethods()){
            UseCase[] ucs = m.getAnnotationsByType(UseCase.class);
            if(ucs!=null && ucs.length!=0){
                UseCase uc = ucs[0];
                System.out.println(String.format("Found Use Case: %d %s", uc.id(),uc.descipition()));
            }
        }
        for(int i: useCases){
            System.out.println(String.format("Warning: Missing use case- %d", i));
        }
    }
    public static void main(String[] args){
        List<Integer> useCases = new ArrayList<>();
        Collections.addAll(useCases,47,48,49,50);
        trackUsecases(useCases,PasswordUtil.class);
    }
}
