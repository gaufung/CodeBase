package edu.cumt.Interfaces;

import edu.cumt.IC.InitialValues;

/**
 * Created by gaufung on 09/06/2017.
 */

interface Instruments{
    int VALUE=5;
    void play();
    void adjust();
}
class Winds implements Instruments{
    @Override
    public void play(){
        System.out.println("Winds");
    }
    @Override
    public void adjust(){

    }
}

class Brasses implements  Instruments{
    @Override
    public void adjust() {

    }

    @Override
    public void play() {
        System.out.println("Brasses");
    }
}
public class Music5 {
    public static void main(String[] args){
        Instruments[] instruments = {
                new Winds(),
                new Brasses()
        };
        for (Instruments i:instruments){
            i.play();
        }
    }
}
