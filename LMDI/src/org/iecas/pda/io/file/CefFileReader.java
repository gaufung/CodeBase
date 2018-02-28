package org.iecas.pda.io.file;
import org.apache.log4j.Logger;
import org.apache.log4j.PropertyConfigurator;
import org.apache.poi.hssf.usermodel.HSSFSheet;
import org.apache.poi.hssf.usermodel.HSSFWorkbook;
import org.apache.poi.ss.usermodel.Cell;
import org.apache.poi.ss.usermodel.CellType;
import org.apache.poi.ss.usermodel.Row;

import java.io.File;
import java.io.FileInputStream;
import java.io.IOException;
import java.util.*;
/**
 * Created by gaufung on 29/06/2017.
 */
public class CefFileReader implements org.iecas.pda.io.CefReader{

    private static Logger log = Logger.getLogger(CefFileReader.class);

    private static String file = "./resources/cef.xls";

    private static int ROW_START = 1;
    private static int ROW_END = 30;


    private static Map<Integer, Double> CEF = new HashMap<>();

    private static Map<String, Integer> SHEET_INDEX = new HashMap<>();

    private static double HEAT_STANDARD_COAL_COEFFICIENT = 0.0341;
    private static double ELECTRIC_STANDARD_COAL_COEFFICIENT = 1.229;

    static{

        //initial the logger

        PropertyConfigurator.configure("./resources/log4j.properties");

        Map<String, Double> STANDARD_COAL_COEFFICIENT =new HashMap<>();
        // standard coal coefficient
        STANDARD_COAL_COEFFICIENT.put("原煤",0.7143);
        STANDARD_COAL_COEFFICIENT.put("洗精煤",0.900);
        STANDARD_COAL_COEFFICIENT.put("其他洗煤",0.2857);
        STANDARD_COAL_COEFFICIENT.put("型煤",0.5);
        STANDARD_COAL_COEFFICIENT.put("焦炭",0.9714);
        STANDARD_COAL_COEFFICIENT.put("焦炉煤气",5.714);
        STANDARD_COAL_COEFFICIENT.put("其他煤气",5.571);
        STANDARD_COAL_COEFFICIENT.put("原油",1.4286);
        STANDARD_COAL_COEFFICIENT.put("汽油",1.4714);
        STANDARD_COAL_COEFFICIENT.put("煤油",1.4714);
        STANDARD_COAL_COEFFICIENT.put("柴油",1.4571);
        STANDARD_COAL_COEFFICIENT.put("燃料油",1.4286);
        STANDARD_COAL_COEFFICIENT.put("液化石油气",1.7143);
        STANDARD_COAL_COEFFICIENT.put("炼厂干气",1.5714);
        STANDARD_COAL_COEFFICIENT.put("天然气",13.30);
//        STANDARD_COAL_COEFFICIENT.put("热力",0.0341);
//        STANDARD_COAL_COEFFICIENT.put("电力",1.2290);


        Map<String, Double> CO2_COEFFICIENT = new HashMap<>();
        // co2 coefficient
        CO2_COEFFICIENT.put("原煤",1.9779);
        CO2_COEFFICIENT.put("洗精煤",2.4921424);
        CO2_COEFFICIENT.put("其他洗煤",0.79114);
        CO2_COEFFICIENT.put("型煤",2.03853);
        CO2_COEFFICIENT.put("焦炭",0.3043);
        CO2_COEFFICIENT.put("焦炉煤气",7.426);
        CO2_COEFFICIENT.put("其他煤气",17.450);
        CO2_COEFFICIENT.put("原油",3.0651);
        CO2_COEFFICIENT.put("汽油",3.0149);
        CO2_COEFFICIENT.put("煤油",3.0795);
        CO2_COEFFICIENT.put("柴油",3.1605);
        CO2_COEFFICIENT.put("燃料油",3.2366);
        CO2_COEFFICIENT.put("液化石油气",3.1663);
        CO2_COEFFICIENT.put("炼厂干气",2.6495);
        CO2_COEFFICIENT.put("天然气",18.086);

        Map<String,Integer> ENERGY_TYPE_INDEX = new HashMap<>();

        ENERGY_TYPE_INDEX.put("原煤",1);
        ENERGY_TYPE_INDEX.put("洗精煤",2);
        ENERGY_TYPE_INDEX.put("其他洗煤",3);
        ENERGY_TYPE_INDEX.put("型煤",4);
        ENERGY_TYPE_INDEX.put("焦炭",5);
        ENERGY_TYPE_INDEX.put("焦炉煤气",6);
        ENERGY_TYPE_INDEX.put("其他煤气",7);
        ENERGY_TYPE_INDEX.put("原油",8);
        ENERGY_TYPE_INDEX.put("汽油",9);
        ENERGY_TYPE_INDEX.put("煤油",10);
        ENERGY_TYPE_INDEX.put("柴油",11);
        ENERGY_TYPE_INDEX.put("燃料油",12);
        ENERGY_TYPE_INDEX.put("液化石油气",13);
        ENERGY_TYPE_INDEX.put("炼厂干气",14);
        ENERGY_TYPE_INDEX.put("天然气",15);

        for(String key: ENERGY_TYPE_INDEX.keySet()){
            Integer value = ENERGY_TYPE_INDEX.get(key);
            CEF.put(value,CO2_COEFFICIENT.get(key)/STANDARD_COAL_COEFFICIENT.get(key));
        }

        SHEET_INDEX.put("2006",0);
        SHEET_INDEX.put("2007",1);
        SHEET_INDEX.put("2008",2);
        SHEET_INDEX.put("2009",3);
        SHEET_INDEX.put("2010",4);
        SHEET_INDEX.put("2011",5);
        SHEET_INDEX.put("2012",6);
        SHEET_INDEX.put("2013",7);
        SHEET_INDEX.put("2014",8);

    }
    @Override
    public  Double[][] read(String year) throws Exception{
        HSSFWorkbook workbook = new HSSFWorkbook(new FileInputStream(new File(file)));
        HSSFSheet sheet = workbook.getSheetAt(SHEET_INDEX.get(year));
        Double[][] result = new Double[ROW_END-ROW_START+1][];
        for(int i =ROW_START;i<=ROW_END;i++){
            Row row = sheet.getRow(i);
            try{
                result[i-ROW_START] = parseCef(row);
            }catch (IllegalArgumentException e){
                log.error(String.format("%s year %d row cannot parse",year, i+1));
            }

        }
        return result;
    }

    private static Double[] parseCef(Row row){
        Double[] cef = new Double[17];
        for(int i =1;i<=15;i++){
            cef[i-1]=CEF.get(i);
        }
        try{
            cef[15] = parseCell(row.getCell(1))/HEAT_STANDARD_COAL_COEFFICIENT;
            cef[16] = parseCell(row.getCell(2))/ELECTRIC_STANDARD_COAL_COEFFICIENT;
        }catch (IllegalArgumentException e){
            throw  e;
        }finally {
            return cef;
        }

    }
    private static Double parseCell(Cell cell){
        if(cell.getCellTypeEnum()==CellType.NUMERIC)
            return cell.getNumericCellValue();
        else if(cell.getCellTypeEnum()==CellType.STRING)
            return Double.parseDouble(cell.getStringCellValue());
        else
            throw new IllegalArgumentException("cell not numerical");
    }
    @Override
    public Map<String, Double[][]> read(String... years) throws Exception{
        Map<String, Double[][]> cefs = new HashMap<>();
        try{
            for(String year:years){
                cefs.put(year, read(year));
            }
        }catch (IOException e){
            log.error("Cannot open the read.xls");
        }finally {
            return cefs;
        }


    }
}
