package edu.cumt.IO;

import java.io.File;
import java.io.FilenameFilter;
import java.util.ArrayList;
import java.util.Iterator;
import java.util.List;
import java.util.regex.Pattern;

/**
 * Created by gaufung on 12/06/2017.
 */
public class Directionary {
    public static File[] local(File dir, final String regex){
        return dir.listFiles(new FilenameFilter() {
            private Pattern pattern = Pattern.compile(regex);
            @Override
            public boolean accept(File dir, String name) {
                return pattern.matcher(new File(name).getName()).matches();
            }
        });
    }
    public static File[] local(String path, final String regex){
        return local(new File(path), regex);
    }
    public static class  TreeInfo implements Iterable<File>{
        public List<File> files = new ArrayList<>();
        public List<File> dirs = new ArrayList<>();
        public Iterator<File> iterator(){
            return files.iterator();
        }
        private static String files2String(List<File> list){
            StringBuilder sb = new StringBuilder();
            for(File file : list){
                sb.append(file.getName()+"\n");
            }
            return sb.toString();
        }
        void addAll(TreeInfo other){
            files.addAll(other.files);
            dirs.addAll(other.files);
        }

        @Override
        public String toString() {
            return String.format("dirs: %s \n\n files: %s", files2String(dirs),files2String(files));
        }
    }
    public static TreeInfo walk(File start, String regex){
        return recurseDirs(start,regex);
    }

    public static TreeInfo walk(String start,String regex){
        return recurseDirs(new File(start),regex);
    }

    static TreeInfo recurseDirs(File startDir, String regex){
        TreeInfo result = new TreeInfo();
        for(File item:startDir.listFiles()){
            if(item.isDirectory()){
                result.dirs.add(item);
            }else{
                if(item.getName().matches(regex))
                    result.files.add(item);
            }
        }
        return result;
    }
    public static void main(String[] args){
        System.out.println(walk(".",".*\\.java"));
    }
}
