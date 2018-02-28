package org.iecas.pda.io.file;

import org.apache.log4j.Logger;
import org.apache.log4j.PropertyConfigurator;
import org.apache.poi.ss.usermodel.Cell;
import org.apache.poi.ss.usermodel.CellType;
import org.apache.poi.ss.usermodel.Row;
import org.apache.poi.xssf.usermodel.XSSFSheet;
import org.apache.poi.xssf.usermodel.XSSFWorkbook;
import org.iecas.pda.io.EnergyReader;
import org.iecas.pda.model.Energy;

import java.io.File;
import java.io.FileInputStream;
import java.io.IOException;
import java.util.*;

/**
 * Created by gaufung on 27/06/2017.
 */
public class EnergyFileReader implements EnergyReader {

    private static final int ROW_START = 35;
    private static final int ROW_END = 64;
    private static final int COLUMN_START = 1;
    private static final int COLUMN_END = 17;
    private static final int NAME_COLUMN_INDEX = 0;

    private static final Map<String,Integer> SHEET_MAP = new Hashtable<>();

    private static Logger log = Logger.getLogger(EnergyReader.class);
    static{
        SHEET_MAP.put("2006",1);
        SHEET_MAP.put("2007",2);
        SHEET_MAP.put("2008",3);
        SHEET_MAP.put("2009",4);
        SHEET_MAP.put("2010",5);
        SHEET_MAP.put("2011",6);
        SHEET_MAP.put("2012",7);
        SHEET_MAP.put("2013",8);
        SHEET_MAP.put("2014",9);
        PropertyConfigurator.configure("./resources/log4j.properties");
    }


    private XSSFWorkbook workbook;


    @Override
    public List<Energy> read(String year) throws Exception{
        if(workbook==null){
            log.error("cannot open the excel");
            throw new NullPointerException("cannot open the excel");
        }
        log.info(String.format("Reading the %s year",year));
        int sheetIndex = SHEET_MAP.get(year);
        XSSFSheet sheet = workbook.getSheetAt(sheetIndex);
        List<Energy> result = new ArrayList<>(32);
        for(int i = ROW_START;i<=ROW_END;i++){
            log.info(String.format("Reading the %d row", i+1));
            result.add(parseEnergy(sheet.getRow(i)));
        }
        return result;
    }


    private Energy parseEnergy(Row row){
        Cell cell = row.getCell(NAME_COLUMN_INDEX);
        String name = cell.getStringCellValue().trim();
        List<Double> energies = new ArrayList<>(32);
        for(int i = COLUMN_START; i <=COLUMN_END;i++){
            log.info(String.format("Reading the %d cell", i));
            cell = row.getCell(i);
            if(cell.getCellTypeEnum() == CellType.NUMERIC){
                energies.add(cell.getNumericCellValue());
            }else if (cell.getCellTypeEnum()==CellType.STRING){
                energies.add(Double.parseDouble(cell.getStringCellValue()));
            }else {
                log.error(String.format("the %d cell is not numerical",i+1));
                throw new IllegalArgumentException("energy is not numerical");
            }
        }
        double sum = energies.stream().mapToDouble(i->i).sum();
        energies.add(sum);
        return new Energy(name, energies);
    }

    public EnergyFileReader(String filePath) throws IOException{
        workbook = new XSSFWorkbook(new FileInputStream(new File(filePath)));
    }
}
