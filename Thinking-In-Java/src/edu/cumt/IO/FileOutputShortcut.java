package edu.cumt.IO;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.PrintWriter;
import java.io.StringReader;

/**
 * Created by gaufung on 14/06/2017.
 */
public class FileOutputShortcut {
    static String file = "FileOutputShortcut.out";
    public static void main(String[] args) throws IOException{
        BufferedReader in = new BufferedReader(
                new StringReader(BufferedInputFile.read("./src/edu/cumt/IO/FileOutputShortcut.java"))
        );
        PrintWriter out = new PrintWriter(file);
        int lineCount = 1;
        String s;
        while((s=in.readLine())!=null)
            out.println(lineCount++ + ": "+s);
        out.close();
        System.out.println(BufferedInputFile.read(file));
    }
}
