package edu.cumt.EnumType;

import java.util.*;
import java.text.*;

/**
 * Created by gaufung on 14/06/2017.
 */
public enum  ConstantSpecificMethod {
    DATA_TIME{
        String getInfo(){
            return DateFormat.getDateInstance().format(new Date());
        }
    },
    CLASS_PATH{
        String getInfo(){
            return System.getenv("CLASSPATH");
        }
    },
    VERSION{
        String getInfo(){
            return System.getProperty("java.version");
        }
    };
    abstract String getInfo();
    public static void main(String[] args){
        for(ConstantSpecificMethod csm:values()){
            System.out.println(csm.getInfo());
        }
    }
}
