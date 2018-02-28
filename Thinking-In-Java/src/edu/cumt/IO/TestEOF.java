package edu.cumt.IO;

import java.io.BufferedInputStream;
import java.io.DataInputStream;
import java.io.FileInputStream;
import java.io.IOException;

/**
 * Created by 高峰 on 14/06/2017.
 */
public class TestEOF {
    public static void main(String[] args) throws IOException{
        DataInputStream in = new DataInputStream(
                new BufferedInputStream(
                        new FileInputStream("./src/edu/cumt/IO/TestEOF.java")
                )
        );
        while(in.available()!=0){
            System.out.println((char)in.readByte());
        }
    }
}
