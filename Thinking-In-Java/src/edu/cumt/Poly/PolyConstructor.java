package edu.cumt.Poly;

/**
 * Created by gaufung on 09/06/2017.
 */

class Glyph{
    void draw(){
        System.out.println("Draw Glyph");
    }
    Glyph(){
        System.out.println("before Glyph");
        this.draw();
        System.out.println("after Glyph");
    }
}

class RoundGlyph extends Glyph{
    private int radius = 1;
    RoundGlyph(int r){
        this.radius=r;
        System.out.println("RoundGlyph radius + " + radius);
    }

    @Override
    void draw() {
        System.out.println("RoundGlyph radius + " + radius);
    }
}

public class PolyConstructor{
    public static void main(String[] args){
        new RoundGlyph(5);
    }
}
