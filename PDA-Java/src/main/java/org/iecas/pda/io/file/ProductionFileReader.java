package org.iecas.pda.io.file;

import org.apache.poi.hssf.usermodel.HSSFWorkbook;
import org.apache.poi.ss.usermodel.Row;
import org.apache.poi.ss.usermodel.Sheet;
import org.apache.poi.ss.usermodel.Workbook;
import org.apache.poi.xssf.usermodel.XSSFWorkbook;
import org.iecas.pda.io.ProductionReader;
import org.iecas.pda.model.Production;

import java.io.FileInputStream;
import java.util.ArrayList;
import java.util.List;

/**
 * Created by gaufung on 02/08/2017.
 */
public class ProductionFileReader implements ProductionReader {
    private final String FILE_PATH;

    public ProductionFileReader(String filePath) {
        FILE_PATH = filePath;
    }

    public List<Production> read(String year) throws Exception{
        Workbook workbook = new XSSFWorkbook(new FileInputStream(FILE_PATH));
        Sheet sheet = workbook.getSheetAt(0);
        Row row = sheet.getRow(Configuration.ProductionRows.get(year));
        List<Production> productions = new ArrayList<>();
        for(int j=Configuration.Production_Column_Start;j<=Configuration.Production_Column_End;j++){
            productions.add(new Production(Configuration.Names.get(j-1),row.getCell(j).getNumericCellValue()));
        }
        workbook.close();
        return productions;
    }
}
