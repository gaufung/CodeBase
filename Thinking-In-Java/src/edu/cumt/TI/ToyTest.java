package edu.cumt.TI;

/**
 * Created by gaufung on 11/06/2017.
 */
interface HasBatteries{}
interface Waterproof{}
interface Shoots{}
interface Metal{}

class Toy{
    Toy(){
        System.out.println("Construct Toy Instance");
    }
    Toy(int i){}
}
class FancyToy extends Toy implements HasBatteries, Waterproof, Shoots,Metal{
    FancyToy(){

    }
    FancyToy(int i){
        super(i);
    }
}
public class ToyTest {
    static void printInfo(Class cls){
        System.out.printf("Class name: %s, is interface [ %s ] \n", cls.getName(), cls.isInterface());
        System.out.printf("Simple name： %s\n", cls.getSimpleName());
        System.out.printf("Canonical name: %s\n", cls.getCanonicalName());
    }
    public static void main(String[] args) throws Exception{
        //printClassInfo();
        printGenericClassInfo();
    }

    private static void printGenericClassInfo() throws Exception{
        Class<FancyToy> ftClass = FancyToy.class;
        FancyToy fancyToy = ftClass.newInstance();
        Class<? super FancyToy> up = ftClass.getSuperclass();
        up.newInstance();

    }

    private static void printClassInfo() {
        Class cls = null;
        try {
            cls = Class.forName("edu.cumt.TI.FancyToy");
        }catch (ClassNotFoundException e){
            System.out.println("Couldn't load class");
        }
        printInfo(cls);
        for(Class face:cls.getInterfaces()){
            printInfo(face);
        }
        Class up = cls.getSuperclass();
        Object obj=null;
        try {
            obj = up.newInstance();
        }catch (InstantiationException e){
            System.out.println("Cannot instantiation");
        }catch (IllegalAccessException e){
            System.out.println("Cannot access");
        }
    }
}
