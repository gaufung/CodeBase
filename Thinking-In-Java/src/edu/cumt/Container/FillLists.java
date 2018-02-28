package edu.cumt.Container;

/**
 * Created by gaufung on 12/06/2017.
 */
import java.util.*;
class StringAddress{
    private String s;
    public StringAddress(String s){this.s=s;}

    @Override
    public String toString() {
        return String.format("%s %s", super.toString(),s);
    }
}
public class FillLists {
    public static void main(String[] args){
        List<StringAddress> list = new ArrayList<>(
                Collections.nCopies(4, new StringAddress("Hello"))
        );
        System.out.println(list);
        Collections.fill(list, new StringAddress("World!"));
        System.out.println(list);
    }
}
