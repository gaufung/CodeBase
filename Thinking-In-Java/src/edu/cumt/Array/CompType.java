package edu.cumt.Array;


import java.util.*;

/**
 * Created by gaufung on 12/06/2017.
 */
public class CompType  implements Comparable<CompType>{
    int i ;
    int j ;
    private static int count = 1;
    public CompType(int n1, int n2){
        i = n1;
        j = n2;
    }

    @Override
    public String toString() {
        String result = String.format("[i= %d, j= %d]",i,j);
        if(count++ % 3 == 0)
            result += "\n";
        return result;
    }

    @Override
    public int compareTo(CompType o) {
        return i<o.i ? -1:(i==o.i? 0:1);
    }

    public static void main(String[] args){
        CompType[] a ={
                new CompType(1,2),
                new CompType(3,1),
                new CompType(1,3),
                new CompType(4,2)
        };
        System.out.println("before sorting");
        System.out.println(Arrays.toString(a));
        System.out.println("after sorting");
        Arrays.sort(a, Collections.reverseOrder());
        System.out.println(Arrays.toString(a));
    }
}
