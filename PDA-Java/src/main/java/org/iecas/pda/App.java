package org.iecas.pda;

import org.iecas.pda.io.DmuReader;
import org.iecas.pda.io.DmuReaderFactory;
import org.iecas.pda.io.output.Output;
import org.iecas.pda.model.Dmu;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;
import java.util.SimpleTimeZone;

/**
 * Created by gaufung on 02/08/2017.
 */
public class App {
    public static void main(String[] args) throws Exception{

        //DmuReader reader= DmuReaderFactory.readerFromDB();
        DmuReader reader = DmuReaderFactory.readerFromFile("./src/main/resources/data.xlsx");
        List<Dmu> dmu_2006= reader.read("2006");
        List<Dmu> dmu_2007= reader.read("2007");
        List<Dmu> dmu_2008 = reader.read("2008");
        List<Dmu> dmu_2009 = reader.read("2009");
        List<Dmu> dmu_2010= reader.read("2010");
        List<Dmu> dmu_2011= reader.read("2011");
        List<Dmu> dmu_2012 = reader.read("2012");
        List<Dmu> dmu_2013 = reader.read("2013");
        List<Dmu> dmu_2014= reader.read("2014");
        List<Dmu> dmu_2015 = reader.read("2015");
//        Output.exportLmdis(new LMDI[]{
//                new LMDI(dmu_2006,dmu_2007,"2006-2007"),
//                new LMDI(dmu_2007,dmu_2008,"2007-2008"),
//                new LMDI(dmu_2008,dmu_2009,"2008-2009"),
//                new LMDI(dmu_2009,dmu_2010,"2009-2010"),
//                new LMDI(dmu_2010,dmu_2011,"2010-2011"),
//                new LMDI(dmu_2011,dmu_2012,"2011-2012"),
//                new LMDI(dmu_2012,dmu_2013,"2012-2013"),
//                new LMDI(dmu_2013,dmu_2014,"2013-2014"),
//                new LMDI(dmu_2014,dmu_2015,"2014-2015")
//        },"lmdi.xlsx");
//        LMDI lmdi = new LMDI(dmu_2006,dmu_2007,"2006-2007");
//        System.out.println(Arrays.toString(lmdi.emx().toArray()));
//        System.out.println(Arrays.toString(lmdi.ros().toArray()));
//        System.out.println(Arrays.toString(lmdi.rei().toArray()));
//        System.out.println(Arrays.toString(lmdi.gdp().toArray()));
//        SinglePeriodAAM spaam = SinglePeriodAAM.build(dmu_2006, dmu_2007,"2006-2007");
//        System.out.println(Arrays.toString(spaam.emxAttributions().toArray()));
//        System.out.println(Arrays.toString(spaam.rosAttributions().toArray()));
//        System.out.println(Arrays.toString(spaam.reiAttributions().toArray()));
//        System.out.println(Arrays.toString(spaam.gdpAttributions().toArray()));
        List<List<Dmu>> list = new ArrayList<>();
        list.add(dmu_2006);list.add(dmu_2007);
       // list.add(dmu_2008);
       // list.add(dmu_2009);
       // list.add(dmu_2010);
        //list.add(dmu_2011);
       // list.add(dmu_2012);
        //list.add(dmu_2013);
        //list.add(dmu_2014);
       // list.add(dmu_2015);
//        //list.add(dmu_2014);
        MultiPeriodAAM mpaam = new MultiPeriodAAM(list,"2006-2007");
        Output.exportMultiAAM(mpaam,"2006-2007.xlsx");

//        System.out.println(Arrays.toString(mpaam.emx().toArray()));
//        System.out.println(Arrays.toString(mpaam.rei().toArray()));
//        System.out.println(Arrays.toString(mpaam.ros().toArray()));
//        System.out.println(Arrays.toString(mpaam.gdp().toArray()));
//        Output.exportMultiAAM(mpaam,"2006-2014.xlsx");
//        Output.exportSingleAMM(new SinglePeriodAAM[]{
//                SinglePeriodAAM.build(dmu_2006,dmu_2007,"2006-2007"),
//                SinglePeriodAAM.build(dmu_2007,dmu_2008,"2007-2008"),
//                SinglePeriodAAM.build(dmu_2008,dmu_2009,"2008-2009"),
//                SinglePeriodAAM.build(dmu_2009,dmu_2010,"2009-2010"),
//                SinglePeriodAAM.build(dmu_2010,dmu_2011,"2010-2011"),
//                SinglePeriodAAM.build(dmu_2011,dmu_2012,"2011-2012"),
//                SinglePeriodAAM.build(dmu_2012,dmu_2013,"2012-2013"),
//                SinglePeriodAAM.build(dmu_2013,dmu_2014,"2013-2014"),
//                SinglePeriodAAM.build(dmu_2014,dmu_2015,"2014-2015"),
//
//        },"single.xlsx");
    }
}
