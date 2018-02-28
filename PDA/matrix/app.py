'''
the application of the matrix
'''
import xlrd
import matplotlib.pyplot as plt
from config import *
from model import Dmu
# plt.rcParams['text.usetex']=True

# # Place the command in the text.latex.preamble using rcParams
# plt.rcParams['text.latex.preamble']=r'\makeatletter \newcommand*{\rom}[1]{\bfseries\expandafter\@slowromancap\romannumeral #1@} \makeatother'

plt.xkcd()

def split(func):
    def _wrapper(*args, **kw):
        dmus = func(*args, **kw)
        return ([item for item in dmus if item.dpei <= 3.33 and item.dyct <= 3.33],
                [item for item in dmus if item.dpei > 3.33 and item.dyct <= 3.33],
                [item for item in dmus if item.dpei > 3.33 and item.dyct > 3.33],
                [item for item in dmus if item.dpei <= 3.33 and item.dyct > 3.33])
    return _wrapper

@split
def read_data():
    workbook = xlrd.open_workbook(XLS_FILE_NAME)
    sheet = workbook.sheets()[SHEET_NO]
    dmus = []
    for row_index in range(ROW_FROM, ROW_TO+1):
        row = sheet.row_values(row_index)[COLUMN_FROM:COLUMN_TO+1]
        dmus.append(Dmu(row[0], float(row[1]), float(row[2])))
    return dmus


def _write_dmus(dmus, color=None, marker=None):
    name = [item.name for item in dmus]
    dpeis = [item.dpei for item in dmus]
    dpcts = [item.dyct for item in dmus]
    plt.scatter(dpeis,dpcts, c=color, marker=marker,zorder=2)

def _generate_dict(dmus):
    dmu_dict = {}
    for dmu in dmus:
        dmu_dict[dmu.name]=[dmu.dpei, dmu.dyct]
    return dmu_dict

def draw():
    dmus_left_bottom, dmus_right_bottom, dmus_right_top, dmus_left_top = read_data()
    # draw point
    _write_dmus(dmus_left_bottom, '#76EE00','^')
    _write_dmus(dmus_right_bottom, '#EE4000','2')
    _write_dmus(dmus_right_top, '#4F94CD','o')
    _write_dmus(dmus_left_top, '#DAA520','s')

    #decoration
    plt.xlim(-0.5, 10.5)
    plt.ylim(-0.5, 10.5)
    plt.plot([-0.5, 10], [3.33,3.33], '--', c='k', linewidth=0.8)
    plt.plot([3.33,3.33],[0, 10.5], '--', c='k', linewidth=0.8)

    plt.text(3.33, -0.25, s='3.33', ha='center', va='center', fontsize=9)
    plt.text(10.3, 3.33, s='3.33', ha='center', va='center', rotation=90,fontsize=9)

    # annotations
    for dmu in dmus_right_top:
        plt.text(dmu.dpei+0.3, dmu.dyct+0.32, s=dmu.name, ha='center', va='center',fontsize=9)
    for dmu in dmus_left_top:
        plt.text(dmu.dpei-0.3, dmu.dyct+0.32, s=dmu.name, ha='center', va='center', fontsize=9)
    #draw right_bottom
    dmu_dict = _generate_dict(dmus_right_bottom)
    plt.text(dmu_dict['Hunan'][0]+0.3,dmu_dict['Hunan'][1]-0.32, s='Hunan', 
             ha='center', va='center', fontsize=9)
    plt.text(dmu_dict['Guizhou'][0]+0.3,dmu_dict['Guizhou'][1]-0.32, s='Guizhou', 
             ha='center', va='center', fontsize=9)
    plt.text(dmu_dict['Jilin'][0]+0.3,dmu_dict['Jilin'][1]-0.3, s='Jilin', 
             ha='center', va='center', fontsize=9)
    plt.text(dmu_dict['Anhui'][0]+0.5,dmu_dict['Anhui'][1]-0.05, s='Anhui', 
             ha='center', va='center', fontsize=9)
    plt.text(dmu_dict['Guangxi'][0]+0.2,dmu_dict['Guangxi'][1]-0.32, s='Guangxi', 
             ha='center', va='center', fontsize=9)
    plt.text(dmu_dict['Zhejiang'][0]+0.2,dmu_dict['Zhejiang'][1]-0.05, s='Zhejiang', 
             ha='left', va='center', fontsize=9)
    # draw left bottom
    dmu_dict.clear()
    dmu_dict = _generate_dict(dmus_left_bottom)
    plt.text(dmu_dict['Hainan'][0]+0.4,dmu_dict['Hainan'][1]-0.35, s='Hainan', 
             ha='center', va='center', fontsize=9)
    plt.text(dmu_dict['Beijing'][0]+0.4,dmu_dict['Beijing'][1]-0.35, s='Beijing', 
             ha='center', va='center', fontsize=9)
    plt.text(dmu_dict['Qinghai'][0]-0.1, dmu_dict['Qinghai'][1]-0.2, s='Qinghai',
             ha='right', va='center', fontsize=9)
    plt.text(dmu_dict['Shanghai'][0]-0.1, dmu_dict['Shanghai'][1]-0.5, s='Shanghai',
              ha='center', va='center', fontsize=9)
    plt.plot([dmu_dict['Shanghai'][0],dmu_dict['Shanghai'][0]-0.1],
             [dmu_dict['Shanghai'][1], dmu_dict['Shanghai'][1]-0.4],
             '-',
             c='k',linewidth=0.5,zorder=1)
    plt.text(dmu_dict['Xinjiang'][0]-0.1, dmu_dict['Xinjiang'][1]+0.4, s='Xinjiang',
             ha='center', va='center', fontsize=9)
    plt.text(dmu_dict['Ningxia'][0]-0.1, dmu_dict['Ningxia'][1]+0.35, s='Ningxia',
             ha='center', va='center', fontsize=9)
    plt.text(dmu_dict['Tianjin'][0]+.4, dmu_dict['Tianjin'][1]+0.25, s='Tianjin',
             ha='center', va='center', fontsize=9)
    plt.text(dmu_dict['Gansu'][0]+0.45, dmu_dict['Gansu'][1]+0.1, s='Gansu',
            ha='center', va='center', fontsize=9)
    plt.text(dmu_dict['Shannxi'][0]+0.1, dmu_dict['Shannxi'][1]+0.4, s='Shannxi',
             ha='center', va='center', fontsize=9)
    plt.text(dmu_dict['Fujian'][0]+0.3, dmu_dict['Fujian'][1]+0.5, s='Fujian',
             ha='left', va='center', fontsize=9)
    plt.plot([dmu_dict['Fujian'][0], dmu_dict['Fujian'][0]+0.5],
             [dmu_dict['Fujian'][1], dmu_dict['Fujian'][1]+0.4], 
             '-',
             c='k',linewidth=0.5,zorder=1)
    plt.text(dmu_dict['Yunnan'][0], dmu_dict['Yunnan'][1]+0.15, s='Yunnan',
              ha='left', va='center', fontsize=9)
    plt.text(dmu_dict['Chongqing'][0]-0.2, dmu_dict['Chongqing'][1]-0.4, s='Chongqing',
              ha='left', va='center', fontsize=9)
    plt.text(dmu_dict['Heilongjiang'][0]+0.1, dmu_dict['Heilongjiang'][1]-0.7, s='Heilongjiang',
                ha='left', va='center', fontsize=9)
    plt.text(dmu_dict['Jiangxi'][0]-0.1, dmu_dict['Jiangxi'][1]-1, s='Jiangxi',
                ha='left', va='center', fontsize=9)
    plt.plot([dmu_dict['Heilongjiang'][0], dmu_dict['Heilongjiang'][0]+0.4],
             [dmu_dict['Heilongjiang'][1], dmu_dict['Heilongjiang'][1]-0.55],
             '-',c='k',linewidth=0.5, zorder=1)
    plt.plot([dmu_dict['Jiangxi'][0], dmu_dict['Jiangxi'][0]+0.2],
             [dmu_dict['Jiangxi'][1], dmu_dict['Jiangxi'][1]-0.9],
             '-',c='k',linewidth=0.5, zorder=1)
    plt.show()


if __name__ == '__main__':
    draw()
