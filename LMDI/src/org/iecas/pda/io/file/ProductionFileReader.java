package org.iecas.pda.io.file;

import org.apache.log4j.Logger;
import org.apache.log4j.PropertyConfigurator;
import org.apache.poi.ss.usermodel.Cell;
import org.apache.poi.ss.usermodel.CellType;
import org.apache.poi.ss.usermodel.Row;
import org.apache.poi.xssf.usermodel.XSSFSheet;
import org.apache.poi.xssf.usermodel.XSSFWorkbook;
import org.iecas.pda.io.ProductionReader;
import org.iecas.pda.model.Production;

import java.io.File;
import java.io.FileInputStream;
import java.io.IOException;
import java.util.*;

/**
 * @author Gau Fung
 * @email gaufung@outlook.com
 * @see Production
 */
public class ProductionFileReader implements ProductionReader {

    private static final int ROW_START = 3;
    private static final int ROW_END = 32;
    private static final int NAME_COLUMN_INDEX = 0;
    private static final Map<String,Integer> COLUMNS = new HashMap<>();
    private static Logger log = Logger.getLogger(ProductionFileReader.class);
    static{
        COLUMNS.put("2006",1);
        COLUMNS.put("2007",2);
        COLUMNS.put("2008",3);
        COLUMNS.put("2009",4);
        COLUMNS.put("2010",5);
        COLUMNS.put("2011",6);
        COLUMNS.put("2012",7);
        COLUMNS.put("2013",8);
        COLUMNS.put("2014",9);
        PropertyConfigurator.configure("./resources/log4j.properties");
    }
    private XSSFWorkbook workbook;

    @Override
    public List<Production> read(String year) throws Exception{
        if(workbook==null) {
            log.error(String.format("Cannot open the excel"));
            throw new NullPointerException("Cannot open the excel");
        }
        log.info(String.format("Reading the %s year", year));
        XSSFSheet spreadSheet = workbook.getSheetAt(0);
        int colIndex = COLUMNS.get(year);
        List<Production> result = new ArrayList<>(32);
        for(int i = ROW_START;i<=ROW_END;i++){
            log.info(String.format("Reading the %d row", i+1));
            result.add(parseProduction(spreadSheet.getRow(i),colIndex));
        }
        return result;
    }

    private Production parseProduction(Row row, int colIndex){
        Cell cell = row.getCell(NAME_COLUMN_INDEX);
        String name = cell.getStringCellValue().trim();
        cell = row.getCell(colIndex);
        double production;
        if(cell.getCellTypeEnum()== CellType.STRING){
            production = Double.parseDouble(cell.getStringCellValue().trim());
        }else  if(cell.getCellTypeEnum()==CellType.NUMERIC){
            production = cell.getNumericCellValue();
        }else{
            log.error(String.format("Column: %d is not numerical",colIndex+1));
            throw new IllegalArgumentException("production is not numerical");
        }
        return new Production(name,production);
    }

    public ProductionFileReader(String filePath) throws IOException{
        workbook = new XSSFWorkbook(new FileInputStream(new File(filePath)));
    }

}
