package edu.cumt.RC;

/**
 * Created by gaufung on 08/06/2017.
 */
public class Circle extends Shape {
    @Override
    public void display() {
        System.out.println("This is circle");
        super.display();
    }
    public static void main(String[] args){
        Circle circle = new Circle();
        circle.display();
    }
}
