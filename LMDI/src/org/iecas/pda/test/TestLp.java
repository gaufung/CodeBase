package org.iecas.pda.test;

import junit.framework.TestCase;
import org.iecas.pda.io.DmuReader;
import org.iecas.pda.io.DmuReaderFactory;
import org.iecas.pda.lp.Dea;
import org.iecas.pda.lp.EtaMax;
import org.iecas.pda.lp.PhiMin;
import org.iecas.pda.lp.ReciprocalDea;
import org.iecas.pda.model.Dmu;
import org.junit.Before;

import java.util.List;

/**
 * Created by gaufung on 27/06/2017.
 * Test linear programming
 */
public class TestLp extends TestCase {
    private String filePath = "./resources/data.xlsx";

    private DmuReader reader;


    @Before
    public void setUp() throws Exception{
        //reader = DmuReaderFactory.readerFromFile(filePath);
        reader = DmuReaderFactory.readerFromDB();
    }


    public void testPhiMin() throws Exception{
        List<Dmu> dmus_2006 = reader.read("2006");
        Dea dea = new ReciprocalDea(new PhiMin(dmus_2006, dmus_2006));
        List<Double> result = dea.optimize();
        for(double value:result){
            System.out.print(String.format("%s \t",value));
        }
//        System.out.println();
//        List<Dmu> dmus_2007 = reader.read("2007");
//        dea = new ReciprocalDea(new PhiMin(dmus_2006,dmus_2007));
//        result = dea.optimize();
//        for(double value:result){
//            System.out.print(String.format("%s \t",value));
//        }
    }

    public void testEtaMax() throws Exception{
        List<Dmu> dmus_2006 = reader.read("2006");
        List<Dmu> dmus_2007 = reader.read("2007");
        Dea dea = new ReciprocalDea(new EtaMax(dmus_2006,dmus_2006));
        List<Double> result =dea.optimize();
        for(double value:result){
            System.out.print(String.format("%s \t",value));
        }
//        dea = new ReciprocalDea(new EtaMax(dmus_2006,dmus_2007));
//        result =dea.optimize();
//        for(double value:result){
//            System.out.print(String.format("%s \t", value));
//        }
    }
}
