package org.iecas.pda.io.file;

import org.apache.log4j.Logger;
import org.apache.log4j.PropertyConfigurator;
import org.apache.poi.ss.usermodel.Cell;
import org.apache.poi.ss.usermodel.CellType;
import org.apache.poi.ss.usermodel.Row;
import org.apache.poi.xssf.usermodel.XSSFSheet;
import org.apache.poi.xssf.usermodel.XSSFWorkbook;
import org.iecas.pda.io.Co2Reader;
import org.iecas.pda.model.Co2;

import java.io.File;
import java.io.FileInputStream;
import java.io.IOException;
import java.util.ArrayList;
import java.util.Hashtable;
import java.util.List;
import java.util.Map;

/**
 * Created by gaufung on 27/06/2017.
 */
public class Co2FileReader implements Co2Reader {

    private static final int ROW_START = 2;
    private static final int ROW_END = 31;
    private static final int COLUMN_START = 1;
    private static final int COLUMN_END = 17;
    private static final int NAME_COLUMN_INDEX = 0;

    private static final Map<String,Integer> SHEET_MAP = new Hashtable<>();
    private static Logger log = Logger.getLogger(Co2Reader.class);


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
    public List<Co2> read(String year) throws Exception{
        if(workbook==null){
            log.error("Cannot open the excel");
            throw new NullPointerException("cannot open the excel");
        }
        log.info(String.format("Reading the %s year co2",year));
        int sheetIndex = SHEET_MAP.get(year);
        XSSFSheet sheet = workbook.getSheetAt(sheetIndex);
        List<Co2> result = new ArrayList<>(32);
        for(int i = ROW_START;i<=ROW_END;i++){
            log.info(String.format("Reading the %d row",i+1));
            result.add(parseCo2(sheet.getRow(i)));
        }
        return result;
    }


    private Co2 parseCo2(Row row){
        Cell cell = row.getCell(NAME_COLUMN_INDEX);
        String name = cell.getStringCellValue().trim();
        List<Double> co2s = new ArrayList<>(32);
        for(int i = COLUMN_START; i <=COLUMN_END;i++){
            log.info(String.format("Reading the %d cell",i+1));
            cell = row.getCell(i);
            if(cell.getCellTypeEnum() == CellType.NUMERIC){
                co2s.add(cell.getNumericCellValue());
            }else if (cell.getCellTypeEnum()==CellType.STRING){
                co2s.add(Double.parseDouble(cell.getStringCellValue()));
            }else{
                log.error(String.format("error: the %d cell is not numerical",i+1));
                throw new IllegalArgumentException("co2 is not numerical");
            }
        }
        double sum = co2s.stream().mapToDouble(i->i).sum();
        co2s.add(sum);
        return new Co2(name, co2s);
    }

    public Co2FileReader(String filePath) throws IOException{
        workbook = new XSSFWorkbook(new FileInputStream(new File(filePath)));
    }
}
