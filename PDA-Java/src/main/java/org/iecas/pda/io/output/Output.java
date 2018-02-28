package org.iecas.pda.io.output;

import org.apache.poi.ss.usermodel.Row;
import org.apache.poi.ss.usermodel.Sheet;
import org.apache.poi.ss.usermodel.Workbook;
import org.apache.poi.xssf.usermodel.XSSFWorkbook;
import org.iecas.pda.LMDI;
import org.iecas.pda.MultiPeriodAAM;
import org.iecas.pda.SinglePeriodAAM;

import java.io.FileOutputStream;
import java.lang.reflect.Method;
import java.util.*;
/**
 * Created by gaufung on 02/08/2017.
 */
public class Output {
    public static void exportLmdis(LMDI[] lmdis,String filePath) throws Exception{
        Workbook workbook = new XSSFWorkbook();
        for (LMDI lmdi : lmdis){
            Sheet sheet = workbook.createSheet(lmdi.getName());
            Row row =sheet.createRow(0);
            row.createCell(0).setCellValue("name");
            row.createCell(1).setCellValue("Emx");
            row.createCell(2).setCellValue("Rei");
            row.createCell(3).setCellValue("Ros");
            row.createCell(4).setCellValue("Gdp");
            List<Double> emx = lmdi.emx();
            List<Double> rei= lmdi.rei();
            List<Double> ros = lmdi.ros();
            List<Double> gdp = lmdi.gdp();
            for(int i=0;i<lmdi.getProvinceCount();i++){
                row = sheet.createRow(i+1);
                row.createCell(0).setCellValue(lmdi.provinceNames().get(i));
                row.createCell(1).setCellValue(emx.get(i));
                row.createCell(2).setCellValue(rei.get(i));
                row.createCell(3).setCellValue(ros.get(i));
                row.createCell(4).setCellValue(gdp.get(i));
            }
        }
        workbook.write(new FileOutputStream(filePath));
    }
    public static void exportSingleAMM(SinglePeriodAAM[] spaams,String filePath) throws Exception{
        Workbook workbook =new XSSFWorkbook();
        exportSingleAAM(spaams,"emx",workbook);
        exportSingleAAM(spaams,"rei",workbook);
        exportSingleAAM(spaams,"ros",workbook);
        exportSingleAAM(spaams,"gdp",workbook);
        workbook.write(new FileOutputStream(filePath));

    }
    private static void exportSingleAAM(SinglePeriodAAM[] spaams,String indexName, Workbook workbook)
            throws Exception{
        Sheet sheet = workbook.createSheet(indexName);
        Row row =sheet.createRow(0);
        row.createCell(0).setCellValue("Name");
        row.createCell(1).setCellValue("2007");
        row.createCell(2).setCellValue("2008");
        row.createCell(3).setCellValue("2009");
        row.createCell(4).setCellValue("2010");
        row.createCell(5).setCellValue("2011");
        row.createCell(6).setCellValue("2012");
        row.createCell(7).setCellValue("2013");
        row.createCell(8).setCellValue("2014");
        row.createCell(9).setCellValue("2015");
        //write_provinces_names
        List<String> names = spaams[0].getLmdi().provinceNames();
        for(int i =0; i<names.size();i++){
            sheet.createRow(i+1).createCell(0).setCellValue(names.get(i));
        }
        int column =1;
        for(SinglePeriodAAM spaam:spaams){
            Class<?> cls = SinglePeriodAAM.class;
            Method method = cls.getMethod(String.format("%sAttributions",indexName));
            List<Double> list = (List<Double>)method.invoke(spaam);
            for(int i =0; i<list.size();i++){
                sheet.getRow(i+1).createCell(column).setCellValue(list.get(i));
            }
            column++;
        }
    }


    public static void exportMultiAAM(MultiPeriodAAM mpaams, String filePath) throws Exception{

        Workbook workbook =new XSSFWorkbook();
        exportMultiAAM(mpaams,"emx",workbook);
        exportMultiAAM(mpaams,"rei",workbook);
        exportMultiAAM(mpaams,"ros",workbook);
        exportMultiAAM(mpaams,"gdp",workbook);
        workbook.write(new FileOutputStream(filePath));
    }
    private static void exportMultiAAM(MultiPeriodAAM mpaams, String indexName, Workbook workbook) throws Exception{
//        Sheet sheet = workbook.createSheet(indexName);
//        Class<?> cls = MultiPeriodAAM.class;
//        Method method = cls.getMethod(indexName);
//        List<Double> list = (List<Double>)method.invoke(mpaams);
//        int row =0;
//        for(int i=0;i<list.size();i++){
//            sheet.createRow(row).createCell(0).setCellValue(list.get(i));
//            row++;
//        }
        Sheet sheet = workbook.createSheet(indexName);
        List<Double> list;
        if(indexName=="emx")
            list = mpaams.emx();
        else if(indexName=="rei")
            list = mpaams.rei();
        else if(indexName=="ros")
            list  = mpaams.ros();
        else
            list = mpaams.gdp();
        int row =0;
        for(int i=0;i<list.size();i++){
            sheet.createRow(row).createCell(0).setCellValue(list.get(i));
            row++;
        }
    }
}
