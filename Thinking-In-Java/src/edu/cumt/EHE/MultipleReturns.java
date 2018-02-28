package edu.cumt.EHE;

/**
 * Created by gaufung on 10/06/2017.
 */
public class MultipleReturns {
    public static void f(int i){
        System.out.println("Initialization and require clean up");
        try {
            if(i==1){
                System.out.println("Point 1");
                return;
            }
            if(i==2){
                System.out.println("Point 2");
                return;
            }
            if(i==3){
                System.out.println("Point 3");
                return;
            }
        }finally {
            System.out.println("Perform clean up");
        }
    }
    public static void main(String[] args){
        for (int i = 1; i <=4; i++) {
            f(i);
        }
    }
}
