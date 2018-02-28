package edu.cumt.RT;

/**
 * Created by gaufung on 10/06/2017.


 */
class Car{
    String color;
    public Car(String c){
        this.color=c;
    }
}
public class ReferenceTest {
    static void f1(Car car){
        car.color="red";
    }
    static void f2(Car car){
        Car car2 = new Car("red");
        car=car2;
    }

}
