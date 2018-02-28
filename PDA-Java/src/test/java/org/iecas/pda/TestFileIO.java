package org.iecas.pda;

import junit.framework.TestCase;
import org.iecas.pda.io.DmuReader;
import org.iecas.pda.io.DmuReaderFactory;
import org.iecas.pda.model.Dmu;
import org.junit.Assert;

import java.util.List;


/**
 * Created by gaufung on 02/08/2017.
 */
public class TestFileIO extends TestCase {
    public void testDmus() throws Exception{
        String filePath="./src/main/resources/data.xlsx";
        DmuReader reader = DmuReaderFactory.readerFromFile(filePath);
        List<Dmu> dmus = reader.read("2006");
        Assert.assertEquals(dmus.size(),3);
        Dmu hangzhou = dmus.get(0);
        assertEquals(hangzhou.name(),"杭州");
        assertEquals(hangzhou.getProduction().getProduction(),34415068,0.001);
        assertEquals(hangzhou.getCo2().total(),8669.61871748966,0.0001);
        assertEquals(hangzhou.getEnergy().total(),2912.079666,0.0001);
    }
}
