package edu.cumt.TI;

/**
 * Created by gaufung on 11/06/2017.
 */
class Candy{
    static {
        System.out.println("Loading Candy");
    }
}
class Gum{
    static{
        System.out.println("Loading Gum");
    }
}
class Cookie{
    static{
        System.out.println("Cookie");
    }
}

public class SweatShop {
    public static void main(String[] args){
        System.out.println("Inside main");
        new Candy();
        try {
            Class cls = Class.forName("edu.cumt.TI.Gum");
        }catch(ClassNotFoundException e){
            System.out.println("Couldn't find Gum");
        }
        System.out.println("After class.forName(\"Gum\")");
        new Cookie();
        System.out.println("After creating Cookie");
    }
}
