package edu.cumt.Str;

import java.io.*;
/**
 * Created by gaufung on 10/06/2017.
 */
public class SimpleRead {
    public static BufferedReader input = new BufferedReader(
            new StringReader("Sir Robin of Camelot\n22 1.61803"));
    public static void main(String[] args){
        try {
            System.out.println("What's your name?");
            String name = input.readLine();
            System.out.println(name);
            System.out.println("How old are you? What's your favorite double?");
            System.out.println("Input <age> <double>");
            String number = input.readLine();
            String[] numArray = number.split(" ");
            int age = Integer.parseInt(numArray[0]);
            double favourite = Double.parseDouble(numArray[1]);
            System.out.format("Hi %s. \n", name);
            System.out.printf("In 5 years you will be %d. \n", age);
            System.out.printf("My favourite is %f.", favourite/2.0);

        }catch (IOException e){
            System.err.println("I/O Exception");
        }
    }
}
