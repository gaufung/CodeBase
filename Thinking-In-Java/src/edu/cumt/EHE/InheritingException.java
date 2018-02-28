package edu.cumt.EHE;

/**
 * Created by gaufung on 10/06/2017.
 */

class SimpleException extends Exception{}
public class InheritingException {
    public void f() throws SimpleException{
        System.out.println("Exception from the f()");
        throw new SimpleException();
    }
    public static void main(String[] args){
        InheritingException ie = new InheritingException();
        try {
            ie.f();
        }catch (SimpleException e){
          System.out.println("Catch it");
            //System.err.println("Catch it");
        }
    }
}
