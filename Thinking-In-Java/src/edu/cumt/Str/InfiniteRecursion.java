package edu.cumt.Str;

import java.util.*;

/**
 * Created by gaufung on 10/06/2017.
 */
public class InfiniteRecursion {

    @Override
    public String toString() {
        return "InfiniteRecursion address" + super.toString() + "\n";
    }
    public static void main(String[] args){
        List<InfiniteRecursion> v = new ArrayList<>();
        for (int i = 0; i < 10; i++) {
            v.add(new InfiniteRecursion());
        }
        System.out.println(v);
    }
}
