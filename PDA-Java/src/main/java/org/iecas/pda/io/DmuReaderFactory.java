package org.iecas.pda.io;

import org.iecas.pda.io.db.Co2DbReader;
import org.iecas.pda.io.db.EnergyDbReader;
import org.iecas.pda.io.db.ProductionDbReader;
import org.iecas.pda.io.file.Co2FileReader;
import org.iecas.pda.io.file.EnergyFileReader;
import org.iecas.pda.io.file.ProductionFileReader;
import org.iecas.pda.model.Co2;
import org.iecas.pda.model.Dmu;
import org.iecas.pda.model.Energy;
import org.iecas.pda.model.Production;

import java.util.ArrayList;
import java.util.List;

/**
 * Created by gaufung on 27/06/2017.
 */
public class DmuReaderFactory implements DmuReader {


    private EnergyReader energyReader;
    private ProductionReader productionReader;
    private Co2Reader co2Reader;

    @Override
    public List<Dmu> read(String year) throws Exception{
        List<Energy> energies = this.energyReader.read(year);
        List<Production> productions = this.productionReader.read(year);
        List<Co2> co2s = this.co2Reader.read(year);
        List<Dmu> dmus = new ArrayList<>();
        for(int i =0, length =energies.size();i<length;i++){
            Energy energy = energies.get(i);
            Co2 co2 = co2s.get(i);
            for(int j=0;j<energy.size();j++){
                if (energy.energyAt(j)==0.0){
                    co2.setCo2At(j,0.0);
                }
                if(co2.co2At(j)==0.0){
                    energy.setEnergyAt(j,0.0);
                }
            }
            energy.updatetotal();
            co2.updatetotal();
            dmus.add(new Dmu(energy,co2, productions.get(i)));
        }
        return dmus;
    }

    private DmuReaderFactory() throws Exception{
        this.energyReader = new EnergyDbReader();
        this.productionReader = new ProductionDbReader();
        this.co2Reader = new Co2DbReader();
    }

    private DmuReaderFactory(String filePath) throws Exception{
        this.energyReader = new EnergyFileReader(filePath);
        this.productionReader = new ProductionFileReader(filePath);
        this.co2Reader = new Co2FileReader(filePath);
    }

    public static DmuReader readerFromDB() throws Exception{
        return new DmuReaderFactory();
    }

    public static DmuReader readerFromFile(String filePath) throws Exception{
        return  new DmuReaderFactory(filePath);
    }



}
