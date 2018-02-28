package org.iecas.pda.io.file;

import org.apache.poi.hssf.usermodel.HSSFWorkbook;
import org.apache.poi.ss.SpreadsheetVersion;
import org.apache.poi.ss.formula.udf.UDFFinder;
import org.apache.poi.ss.usermodel.*;
import org.apache.poi.xssf.usermodel.XSSFWorkbook;
import org.iecas.pda.io.Co2Reader;
import org.iecas.pda.model.Co2;
import sun.reflect.generics.reflectiveObjects.NotImplementedException;

import java.io.*;
import java.util.ArrayList;
import java.util.Iterator;
import java.util.List;

/**
 * Created by gaufung on 02/08/2017.
 */
public class Co2FileReader implements Co2Reader {

    private final String FILE_PATH;

    public Co2FileReader(String filePath) {
        FILE_PATH = filePath;
    }

    public List<Co2> read(String year) throws Exception {
        Workbook workbook = new XSSFWorkbook(new FileInputStream(FILE_PATH));
        Sheet sheet = workbook.getSheetAt(1);
        Integer[] rows = Configuration.Co2AndEnergyRows.get(year);
        List<Co2> co2s = new ArrayList<>();
        for(int i=0;i<rows.length;i++){
            String name = Configuration.Names.get(i);
            Row row = sheet.getRow(rows[i]);
            List<Double> components = new ArrayList<>();
            for(int j = Configuration.Co2_Energy_Column_Start;j<=Configuration.Co2_Energy_Column_End;j++){
                components.add(row.getCell(j).getNumericCellValue());
            }
            double sum = components.stream().mapToDouble(item->item).sum();
            components.add(sum);
            co2s.add(new Co2(name,components));
        }
        workbook.close();
        return co2s;
    }
}