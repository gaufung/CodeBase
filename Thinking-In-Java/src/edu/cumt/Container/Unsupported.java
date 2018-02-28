package edu.cumt.Container;

import java.util.*;

/**
 * Created by gaufung on 12/06/2017.
 */
public class Unsupported {
    static void test(String msg,List<String> list){
        System.out.println(String.format("---- %s ----",msg));
        Collection<String> c = list;
        Collection<String> subList = list.subList(1,8);
        // copy the sublist
        Collection<String> c2 = new ArrayList<>(subList);
        try{c.retainAll(c2);}catch (Exception e){
            System.out.println(String.format("retainAll() %s", e.toString()));
        }
        try{c.removeAll(c2);}catch (Exception e){
            System.out.println(String.format("removeAll() %s", e.toString()));
        }
        try { c.clear(); } catch(Exception e) {
            System.out.println("clear(): " + e);
        }
        try { c.add("X"); } catch(Exception e) {
            System.out.println("add(): " + e);
        }
        try { c.addAll(c2); } catch(Exception e) {
            System.out.println("addAll(): " + e);
        }
        try { c.remove("C"); } catch(Exception e) {
            System.out.println("remove(): " + e);
        }
        try {
            list.set(0, "X");
        } catch(Exception e) {
            System.out.println("List.set(): " + e);
        }
    }
    public static void main(String[] args){
        List<String> list =
                Arrays.asList("A B C D E F G H I J K L M ".split(" "));
        test("Modifiable Copy", new ArrayList<>(list));
        test("Arrays.asList()", list);
        test("unmodifyableList()", Collections.unmodifiableList(new ArrayList<>(list)));
    }
}
