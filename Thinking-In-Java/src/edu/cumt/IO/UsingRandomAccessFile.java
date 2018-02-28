package edu.cumt.IO;

import java.io.IOException;
import java.io.RandomAccessFile;

/**
 * Created by gaufung on 14/06/2017.
 */
public class UsingRandomAccessFile {
    static String file = "rtest.dat";
    static void display() throws IOException{
        RandomAccessFile rf = new RandomAccessFile(file, "r");
        for (int i = 0; i < 7; i++) {
            System.out.println(String.format("Value %d: + %f",i,rf.readDouble()));
        }
        System.out.println(rf.readUTF());
        rf.close();
    }
    public static void main(String[] args) throws IOException{
        RandomAccessFile rf = new RandomAccessFile(file,"rw");
        for (int i = 0; i < 7; i++) {
            rf.writeDouble(i*Math.sqrt(2));
        }
        rf.writeUTF("The end of the file");
        rf.close();
        display();
        rf = new RandomAccessFile(file,"rw");
        rf.seek(5*8);
        rf.writeDouble(47.0001);
        rf.close();

        display();
    }
}
