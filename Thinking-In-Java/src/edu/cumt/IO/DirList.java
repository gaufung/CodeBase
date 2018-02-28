package edu.cumt.IO;

import java.io.File;
import java.io.FilenameFilter;
import java.util.Arrays;
import java.util.regex.Pattern;

/**
 * Created by gaufung on 12/06/2017.
 */

public class DirList {
    static class DirFilter implements FilenameFilter{
        private Pattern pattern;
        public DirFilter(String regex){
            pattern = Pattern.compile(regex);
        }

        @Override
        public boolean accept(File dir, String name) {
            return pattern.matcher(name).matches();
        }
    }

    public static void main(String[] args){
        File path = new File("./src/edu/cumt/Container");
        String[] list = path.list(new DirFilter(".*\\.java"));
        Arrays.sort(list, String.CASE_INSENSITIVE_ORDER);
        for(String dirItem:list)
            System.out.println(dirItem);
    }
}
