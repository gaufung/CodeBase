package edu.cumt.IO;

import java.io.*;

/**
 * Created by gaufung on 14/06/2017.
 */
public class StoringAndRecoveringData {
    public static void main(String[] args) throws IOException{
        DataOutputStream out = new DataOutputStream(
                new BufferedOutputStream(new FileOutputStream("Data.txt"))
        );
        out.writeInt(3);
        out.writeUTF("That was pi");
        out.writeDouble(1.41413);
        out.writeUTF("That was square root of 2");
        out.close();
        DataInputStream in = new DataInputStream(
                new BufferedInputStream(new FileInputStream("Data.txt"))
        );
        System.out.println(in.readInt());
        System.out.println(in.readUTF());
        System.out.println(in.readDouble());
        System.out.println(in.readUTF());
    }
}
