#-*- coding:utf-8 -*-
'''
export pei and yct ri
'''
import sys
sys.path.append('..')
from PDA_Industry.DataRead import read_dmus
import xlrd
import PDA_Industry.config as config
import PDA_Industry.LMDI as LMDI
import logging
from xlwt import *
import math
import operator
import PDA_Industry.Algorithm as Algorithm
import numpy as np
import pandas as pd
from PDA_Industry.SinglePeriodAAM import Spaam
from PDA_Industry.MultiPeriodAAM import Mpaam

logging.basicConfig(level=logging.ERROR)

class AppLmdi(object):
    '''
    the class of lmdi
    '''
    def __init__(self):
        dmus_2006 = read_dmus(config.PRO_2006_COL, config.SHEET_2006)
        dmus_2007 = read_dmus(config.PRO_2007_COL, config.SHEET_2007)
        dmus_2008 = read_dmus(config.PRO_2008_COL, config.SHEET_2008)
        dmus_2009 = read_dmus(config.PRO_2009_COL, config.SHEET_2009)
        dmus_2010 = read_dmus(config.PRO_2010_COL, config.SHEET_2010)
        dmus_2011 = read_dmus(config.PRO_2011_COL, config.SHEET_2011)
        dmus_2012 = read_dmus(config.PRO_2012_COL, config.SHEET_2012)
        dmus_2013 = read_dmus(config.PRO_2013_COL, config.SHEET_2013)
        dmus_2014 = read_dmus(config.PRO_2014_COL, config.SHEET_2014)
        self.lmdi_2006_2007 = LMDI.Lmdi(dmus_2006, dmus_2007, '2006-2007')
        self.lmdi_2007_2008 = LMDI.Lmdi(dmus_2007, dmus_2008, '2007-2008')
        self.lmdi_2008_2009 = LMDI.Lmdi(dmus_2008, dmus_2009, '2008-2009')
        self.lmdi_2009_2010 = LMDI.Lmdi(dmus_2009, dmus_2010, '2009-2010')
        self.lmdi_2010_2011 = LMDI.Lmdi(dmus_2010, dmus_2011, '2010-2011')
        self.lmdi_2011_2012 = LMDI.Lmdi(dmus_2011, dmus_2012, '2011-2012')
        self.lmdi_2012_2013 = LMDI.Lmdi(dmus_2012, dmus_2013, '2012-2013')
        self.lmdi_2013_2014 = LMDI.Lmdi(dmus_2013, dmus_2014, '2013-2014')
        self.spaam_2006_2007 = Spaam(dmus_2006, dmus_2007, '2006-2007')
        self.spaam_2007_2008 = Spaam(dmus_2007, dmus_2008, '2007-2008')
        self.spaam_2008_2009 = Spaam(dmus_2008, dmus_2009, '2008-2009')
        self.spaam_2009_2010 = Spaam(dmus_2009, dmus_2010, '2009-2010')
        self.spaam_2010_2011 = Spaam(dmus_2010, dmus_2011, '2010-2011')
        self.spaam_2011_2012 = Spaam(dmus_2011, dmus_2012, '2011-2012')
        self.spaam_2012_2013 = Spaam(dmus_2012, dmus_2013, '2012-2013')
        self.spaam_2013_2014 = Spaam(dmus_2013, dmus_2014, '2013-2014')
        self.mpaam_2006_2014 = Mpaam([dmus_2006, dmus_2007, dmus_2008, dmus_2009,
                                      dmus_2010, dmus_2011, dmus_2012, dmus_2013,
                                      dmus_2014], '2006-2014')
        self.mpaam_2006_2007 = Mpaam([dmus_2006, dmus_2007], '2006-2007')
        self.mpaam_2006_2008 = Mpaam([dmus_2006, dmus_2007, dmus_2008], '2006-2008')
        self.province_names = self.lmdi_2006_2007.province_names
    def write_mulit_ri(self):
        result = self.mpaam_2006_2014.ri_yct()
        print result
        print(sum(result))
    def _write_column(self, sheet, column, values):
        '''
        write a column
        '''
        row = 0
        for value in values:
            sheet.write(row, column, value)
            row += 1
    def write_ri(self, filename):
        workbook = Workbook(encoding='utf8')
        sheet = workbook.add_sheet('yct_ri')
        self._write_yct_ri(sheet,'ryct')
        sheet = workbook.add_sheet('pei_ri')
        self._write_yct_ri(sheet,'rpei')
        workbook.save(filename)
    def _write_yct_ri(self,sheet, attrname):
        self._write_column(sheet, 0, ['province']+self.province_names)
        #getattr(self.lmdi_2007_2008,attrname)()
        self._write_column(sheet, 1, [self.spaam_2006_2007.name]+getattr(self.spaam_2006_2007,attrname)())
        self._write_column(sheet, 2, [self.spaam_2007_2008.name]+getattr(self.spaam_2007_2008,attrname)())
        self._write_column(sheet, 3, [self.spaam_2008_2009.name]+getattr(self.spaam_2008_2009,attrname)())
        self._write_column(sheet, 4, [self.spaam_2009_2010.name]+getattr(self.spaam_2009_2010,attrname)())
        self._write_column(sheet, 5, [self.spaam_2010_2011.name]+getattr(self.spaam_2010_2011,attrname)())
        self._write_column(sheet, 6, [self.spaam_2011_2012.name]+getattr(self.spaam_2011_2012,attrname)())
        self._write_column(sheet, 7, [self.spaam_2012_2013.name]+getattr(self.spaam_2012_2013,attrname)())
        self._write_column(sheet, 8, [self.spaam_2013_2014.name]+getattr(self.spaam_2013_2014,attrname)())
if __name__ == '__main__':
    app = AppLmdi()
    #app.write_ri('ri.xls')
    app.write_mulit_ri()