package edu.cumt.IO;

import java.io.IOException;
import java.io.StringReader;

/**
 * Created by gaufung on 14/06/2017.
 */
public class MemoryInput {
    public static void main(String[] args) throws IOException{
        StringReader in = new StringReader(BufferedInputFile.read("./src/edu/cumt/IO/MemoryInput.java"));
        int c;
        while((c=in.read())!=-1){
            System.out.println((char)c);
        }
    }
}
