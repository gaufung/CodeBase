import numpy as np
import matplotlib.pyplot as plt
import xlrd
from config import SHEET_INDEX, ROW_START, ROW_END, COLUMN_START, COLUMN_END,FILE_NAME
from model import Unit
plt.rcParams['font.family']='Calibri'

def read_data():
    workbook = xlrd.open_workbook(FILE_NAME)
    sheet = workbook.sheets()[0]
    result = []
    for row_idx in range(ROW_START,ROW_END+1):
        row = sheet.row_values(row_idx)[COLUMN_START:COLUMN_END+1]
        result.append(Unit(row[0], float(row[1]), float(row[2]), row[3]))
    return result

def _print(data):
    for item in data:
        print(item.name,item.yct,item.pei, item.color)

def _bottom(data, current_idx, is_yct=True):
    pass

def stack_values(data1, data2):
    result1 = [0.0]
    result2 = [0.0]
    for item1,item2 in zip(data1, data2):
        result1.append(result1[-1]+item1.yct)
        result2.append(result2[-1]+item2.pei)
    return result1, result2

def draw():
    row_data = read_data()
    data_by_yct = sorted(row_data, key=lambda unit: unit.yct, reverse=True)
    data_by_pei = sorted(row_data, key=lambda unit: unit.pei, reverse=True)
    stack1, stack2 = stack_values(data_by_yct, data_by_pei)
    index = 0.5
    bw = 0.5
    
    plt.axis([0,3,0,100])
    plt.plot([0,4],[2,2],'-')
    for idx,item in enumerate(data_by_yct):
        plt.bar(index, np.array([item.yct]), bw, color=item.color, edgecolor='None',
                label=item.name, bottom=stack1[idx])
    for idx,item in enumerate(data_by_pei):
        plt.bar(index +1, np.array([item.pei]), bw, color=item.color, edgecolor='None',
                bottom=stack2[idx])
    plt.legend(loc='right', ncol=1, fontsize=5.5, frameon=False)
    #decorate
    x_ticks = [0.75, 1.75]
    x_label = [r"$D_{YCT}$", r"$D_{PEI}$"]

    y_ticks = np.arange(0,101,10)
    y_labels = np.array([str(item) for item in y_ticks])
    
    plt.ylabel('Percentage (%)')
    plt.xticks(x_ticks, x_label, fontsize=12)
    plt.yticks(y_ticks, y_labels)
    gca = plt.gca()
    gca.xaxis.set_ticks_position('bottom')
    gca.yaxis.set_ticks_position('left')
    gca.yaxis.set_ticks_position('left')
    gca.spines['right'].set_color('none')
    plt.show()
if __name__ == '__main__':
    draw()