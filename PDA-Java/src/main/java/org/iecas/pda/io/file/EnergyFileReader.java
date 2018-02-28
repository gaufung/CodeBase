package org.iecas.pda.io.file;

import org.apache.poi.hssf.usermodel.HSSFWorkbook;
import org.apache.poi.ss.usermodel.Row;
import org.apache.poi.ss.usermodel.Sheet;
import org.apache.poi.ss.usermodel.Workbook;
import org.apache.poi.xssf.usermodel.XSSFWorkbook;
import org.iecas.pda.io.EnergyReader;
import org.iecas.pda.model.Energy;

import java.io.FileInputStream;
import java.util.ArrayList;
import java.util.List;

/**
 * Created by gaufung on 02/08/2017.
 */
public class EnergyFileReader  implements EnergyReader{

    private final String FILE_PATH;

    public EnergyFileReader(String filePath) {
        FILE_PATH = filePath;
    }
    public List<Energy> read(String year) throws Exception{
        Workbook workbook = new XSSFWorkbook(new FileInputStream(FILE_PATH));
        Sheet sheet = workbook.getSheetAt(2);
        Integer[] rows = Configuration.Co2AndEnergyRows.get(year);
        List<Energy> energies = new ArrayList<>();
        for(int i=0;i<rows.length;i++){
            String name = Configuration.Names.get(i);
            Row row = sheet.getRow(rows[i]);
            List<Double> components = new ArrayList<>();
            for(int j = Configuration.Co2_Energy_Column_Start;j<=Configuration.Co2_Energy_Column_End;j++){
                components.add(row.getCell(j).getNumericCellValue());
            }
            double sum = components.stream().mapToDouble(item->item).sum();
            components.add(sum);
            energies.add(new Energy(name,components));
        }
        workbook.close();
        return energies;
    }

}
