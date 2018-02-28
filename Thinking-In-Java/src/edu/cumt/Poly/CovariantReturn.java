package edu.cumt.Poly;

/**
 * Created by gaufung on 09/06/2017.
 */
class Grain{
    @Override
    public String toString() {
//        return super.toString();
        return "Grain";
    }
}
class Wheat extends Grain{
    @Override
    public String toString() {
        return "Wheat";
    }
}
class Mill{
    Grain process(){
        return new Grain();
    }
}
class WheatMill extends Mill{
    @Override
    Grain process() {
        return new Wheat();
    }
}

public class CovariantReturn {

    public static void main(String[] args){
        Mill m = new Mill();
        Grain g = m.process();
        System.out.println(g);
        m = new WheatMill();
        g = m.process();
        System.out.println(g);
    }
}
