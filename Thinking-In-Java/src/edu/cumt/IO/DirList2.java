package edu.cumt.IO;

import java.io.File;
import java.io.FilenameFilter;
import java.util.regex.Pattern;

/**
 * Created by gaufung on 12/06/2017.
 */
public class DirList2 {
    public static FilenameFilter filter(final String regex){
        return new FilenameFilter() {
            private Pattern pattern = Pattern.compile(regex);
            @Override
            public boolean accept(File dir, String name) {
                return pattern.matcher(name).matches();
            }
        };
    }
    public static void main(String[] args){
        File path = new File("./src/edu/cumt/Container");
        String[] list = path.list(filter(".*\\.java"));
        for(String diritem:list)
            System.out.println(diritem);
    }

}
