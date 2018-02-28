package edu.cumt.IC;

/**
 * Created by gaufung on 08/06/2017.
 */

class Book{
    boolean checkOut = false;
    Book(boolean checkOut){
        this.checkOut = checkOut;
    }
    void checkIn(){
        this.checkOut = false;
    }

    @Override
    protected void finalize() throws Throwable {
        if(checkOut){
            System.out.println("Error: Checkout out");
        }
    }
}

public class TerminationConditon {
    public static void main(String[] args){
        Book novel = new Book(true);
        novel.checkIn();
        new Book(true);
        System.gc();
    }
}

