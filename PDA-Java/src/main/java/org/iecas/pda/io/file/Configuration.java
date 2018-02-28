package org.iecas.pda.io.file;

import com.sun.tools.corba.se.idl.InterfaceGen;
import org.apache.log4j.PropertyConfigurator;

import javax.lang.model.element.Name;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

/**
 * Created by gaufung on 02/08/2017.
 */
class Configuration {

    public static Map<String, Integer[]> Co2AndEnergyRows;

    public static Map<String, Integer> ProductionRows;

    public static List<String> Names;

    public static Integer Production_Column_Start = 1;
    public static Integer Production_Column_End = 3;

    public static Integer Co2_Energy_Column_Start = 1;
    public static Integer Co2_Energy_Column_End = 9;
    static {
        Co2AndEnergyRows=new HashMap<>();
        Co2AndEnergyRows.put("2006",new Integer[]{11,23,35});
        Co2AndEnergyRows.put("2007",new Integer[]{10,22,34});
        Co2AndEnergyRows.put("2008",new Integer[]{9,21,33});
        Co2AndEnergyRows.put("2009",new Integer[]{8,20,32});
        Co2AndEnergyRows.put("2010",new Integer[]{7,19,31});
        Co2AndEnergyRows.put("2011",new Integer[]{6,18,30});
        Co2AndEnergyRows.put("2012",new Integer[]{5,17,29});
        Co2AndEnergyRows.put("2013",new Integer[]{4,16,28});
        Co2AndEnergyRows.put("2014",new Integer[]{3,15,27});
        Co2AndEnergyRows.put("2015",new Integer[]{2,14,26});

        //
        ProductionRows = new HashMap<>();
        ProductionRows.put("2006",10);
        ProductionRows.put("2007",9);
        ProductionRows.put("2008",8);
        ProductionRows.put("2009",7);
        ProductionRows.put("2010",6);
        ProductionRows.put("2011",5);
        ProductionRows.put("2012",4);
        ProductionRows.put("2013",3);
        ProductionRows.put("2014",2);
        ProductionRows.put("2015",1);

        //
        Names = new ArrayList<>();
        Names.add("杭州");
        Names.add("温州");
        Names.add("绍兴");
    }
}
