import tushare
from selenium import webdriver
from bs4 import BeautifulSoup
import pandas as pd
import numpy as np

print("开始读取所有股票基本信息-----开始")
BaseInfo = 0
BaseInfo = tushare.get_stock_basics()
count = len(BaseInfo)
df = pd.DataFrame(
    columns = [
        "StockNumber", 
        "Name", 
        "totals",
        "outstanding",
        "reservedPerShare",
        "esp",
        "perundp",
        "SDate1", "SNumber1", "SPercent1",
        "SDate2", "SNumber2", "SPercent2",
        "SDate3", "SNumber3", "SPercent3",
        "SDate4", "SNumber4", "SPercent4",
        "SDate5", "SNumber5", "SPercent5",
        "SDate6", "SNumber6", "SPercent6",
        "SDate7", "SNumber7", "SPercent7",
        "SDate8", "SNumber8", "SPercent8",
        "SDate9", "SNumber9", "SPercent9",
        "SDate10", "SNumber10", "SPercent10",
        "SDate11", "SNumber11", "SPercent11",
        "SDate12", "SNumber12", "SPercent12",
        "SDate13", "SNumber13", "SPercent13",
        "SDate14", "SNumber14", "SPercent14",
        "SDate15", "SNumber15", "SPercent15",
        "SDate16", "SNumber16", "SPercent16",
        "SDate17", "SNumber17", "SPercent17",
        "SDate18", "SNumber18", "SPercent18",
        "SDate19", "SNumber19", "SPercent19",
        "SDate20", "SNumber20", "SPercent20"
        ]
    )

if count == 0:
	print("无法读取股票基本信息。。。，退出")
elif count>0:
	print("开始读取所有股票股东信息信息,总数:%d"%len(BaseInfo))

def 读取新浪股东人数(股票编号, 股票名称, 总股本, 流通股本, 每股公积金, 每股收益, 每股未分配):
    driver = webdriver.PhantomJS("phantomjs.exe")
    try:
        driver.get('http://vip.stock.finance.sina.com.cn/corp/go.php/vCI_StockHolderAmount/code/' + str(股票编号) + '/type/amount.phtml')
        #driver.save_screenshot('11.png')  # 截取全屏，并保存
        pageSource = driver.page_source
        soup = BeautifulSoup(pageSource, 'lxml')

        df = pd.DataFrame(columns = ["Date", "Number", "Percent"]) #创建一个空的dataframe
        cntt=0
        tables = soup.findAll(id='Table1')
        tab = tables[0]
        for tr in tab.findAll('tr'):
            cnt=0
            for td in tr.findAll('td'):
                if cnt == 0:
                    date = td.getText()
                elif cnt == 1:
                    number = td.getText()
                elif cnt == 2:
                    percent = td.getText()
                    df.loc[cntt] = [date,number,percent]
                    cntt+=1
                    cnt=0
                else:
                    pass
                cnt+=1
        print(df)
    except Exception as e:
        print(e)