package edu.cumt.IO;

import java.io.PrintWriter;

/**
 * Created by gaufung on 14/06/2017.
 */
public class ChangeSystemOut {
    public static void main(String[] args){
        PrintWriter out = new PrintWriter(System.out, true);
        out.println("Hello world!");
    }
}
