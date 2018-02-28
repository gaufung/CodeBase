package edu.cumt.Generic;

import java.util.ArrayList;
import java.util.List;

/**
 * Created by gaufung on 12/06/2017.
 */

class Share<T>{
    static int i = 0;
}
public class StaticVariable {
    public static void main(String[] args){
//        Share<Integer> shareInt = new Share<>();
//        Share<Double> shareDouble = new Share<>();
//        shareInt.i++;
//        System.out.println(shareDouble.i);

    }
    public static void inspect(List<Object> list){
        for(Object obj:list)
            System.out.println(obj);
        list.add(1);
    }

    public static void test(){
        List<String> strs = new ArrayList<>();
//        inspect(strs);
    }


}
