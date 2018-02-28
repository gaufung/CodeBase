package edu.cumt.Generic;

import java.util.*;

/**
 * Created by gaufung on 12/06/2017.
 */
public class ListOfInt {
    public static void main(String[] args){
        List<Integer> li = new ArrayList<Integer>();
        for (int i = 0; i < 5; i++) {
            li.add(i);
        }
        for(int i:li){
            System.out.println(i+" ");
        }
    }
}
