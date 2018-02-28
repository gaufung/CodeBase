package edu.cumt.Generic;

/**
 * Created by gaufung on 12/06/2017.
 */
class Fruit{}
class Apple extends  Fruit{}
class Jonathan extends Apple{}
class Orange extends Fruit{}
public class CovariantArray {
    public static void main(String[] arg){
        Fruit[] fruits = new Fruit[10];//[10];
        fruits[0] = new Apple();
        fruits[1] = new Jonathan();
        try {
            fruits[0] = new Fruit();
        }catch (Exception e){
            System.out.println(e);
        }
        try {
            fruits[0] = new Orange();
        }catch (Exception e){
            System.out.println(e);
        }
    }
}
