package edu.cumt.Interfaces;

/**
 * Created by gaufung on 09/06/2017.
 */

abstract class Instrument{
    private int i;
    public abstract void play();
    public String What(){
        return "Instrument";
    }
    public abstract void adjust();
}

class Wind extends Instrument{
    public void play(){
        System.out.println("Wind");
    }
    public void adjust(){

    }
}

class Brass extends Instrument{
    public void play(){
        System.out.println("Brass");
    }
    public void adjust(){}
}

public class Music {
    public static void main(String[] args){
        Instrument[] orchestras={
                new Wind(),
                new Brass()
        };
        for(Instrument orchestra:orchestras){
            orchestra.play();
        }
    }

}
