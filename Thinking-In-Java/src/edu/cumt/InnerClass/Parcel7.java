package edu.cumt.InnerClass;

/**
 * Created by gaufung on 09/06/2017.
 */
class Content{}
public class Parcel7 {
    public Content contents() {
        return new Content() { // Insert a class definition
            private int i = 11;
            public int value() { return i; }
        }; // Semicolon required in this case
    }
    public static void main(String[] args) {
        Parcel7 p = new Parcel7();
        Content c = p.contents();
    }
}
