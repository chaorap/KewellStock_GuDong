import tushare
from selenium import webdriver
from bs4 import BeautifulSoup
import pandas as pd
import numpy as np
import sqlite3
import time
import datetime
import sys
import re

def hasNumbers(inputString):
    return bool(re.search(r'\d', inputString))

def ReadStockGuDongNumber(Stock_Number, name, totals, outstanding, reservedPerShare, esp, perundp):
    try:
        driver.get('http://vip.stock.finance.sina.com.cn/corp/go.php/vCI_StockHolderAmount/code/' + str(Stock_Number) + '/type/amount.phtml')
        #driver.get('http://vip.stock.finance.sina.com.cn/corp/go.php/vCI_StockHolderAmount/code/300627/type/amount.phtml')
        #driver.save_screenshot('11.png')  # 截取全屏，并保存
        pageSource = driver.page_source
        soup = BeautifulSoup(pageSource, 'lxml')

        SessionName=",Name,totals,outstanding,reservedPerShare,esp,perundp) values("
        sql="insert into Gudong(" + "StockNumber" + SessionName
        sql=sql+ Stock_Number + ", '" +name+ "','" +str(totals)+ "','" +str(outstanding)+ "','" +str(reservedPerShare)+ "','" +str(esp)+ "','" +str(perundp) +"')"
        #print(sql)
        cu.execute(sql)

        df = pd.DataFrame(columns = [0, 1, 2]) #创建一个空的dataframe
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
                    if hasNumbers(number) == False:
                        number = 0
                elif cnt == 2:
                    percent = 0#td.getText()
                    df.loc[cntt] = [date,number,percent]
                    cntt+=1
                    cnt=0
                else:
                    pass
                cnt+=1
        print(df)
        #计算每期的减少百分比
        print(cntt)
        if cntt > 0:
            for i in df.index:
                if i == 0:
                    pass
                else:
                    if int(df.loc[i, 1])==0:
                        df.loc[i, 1] = df.loc[i-1, 1]
            for i in range(cntt-1, -1, -1):
                if i == (cntt-1):
                    df.loc[i, 2] = 0 
                else:
                    this = int(df.loc[i, 1])
                    next = int(df.loc[i+1, 1])
                    cgg = (this-next)*100/next
                    print("%d====%d----%d---%f"%(i, this,next,cgg))
                    df.loc[i, 2] = cgg
        print(df)
        ReturnValue=1
    except Exception as e:
        print(e)
        ReturnValue=0
    return ReturnValue

driver = webdriver.PhantomJS("phantomjs.exe")
DB_Name = "db\AStock_" +  datetime.datetime.now().strftime('%Y-%m-%d_%H_%M_%S') + ".sqlite"
cx = sqlite3.connect(DB_Name)
cu=cx.cursor()
cu.execute("create table Gudong (StockNumber integer primary key, Name nvarchar(10),\
                                                                totals float,\
                                                                outstanding float,\
                                                                reservedPerShare float,\
                                                                esp float,\
                                                                perundp float,\
                                                                SDate1 date, SNumber1 integer, SPercent1 float,\
                                                                SDate2 date, SNumber2 integer, SPercent2 float,\
                                                                SDate3 date, SNumber3 integer, SPercent3 float,\
                                                                SDate4 date, SNumber4 integer, SPercent4 float,\
                                                                SDate5 date, SNumber5 integer, SPercent5 float,\
                                                                SDate6 date, SNumber6 integer, SPercent6 float,\
                                                                SDate7 date, SNumber7 integer, SPercent7 float,\
                                                                SDate8 date, SNumber8 integer, SPercent8 float,\
                                                                SDate9 date, SNumber9 integer, SPercent9 float,\
                                                                SDate10 date, SNumber10 integer, SPercent10 float,\
                                                                SDate11 date, SNumber11 integer, SPercent11 float,\
                                                                SDate12 date, SNumber12 integer, SPercent12 float,\
                                                                SDate13 date, SNumber13 integer, SPercent13 float,\
                                                                SDate14 date, SNumber14 integer, SPercent14 float,\
                                                                SDate15 date, SNumber15 integer, SPercent15 float,\
                                                                SDate16 date, SNumber16 integer, SPercent16 float,\
                                                                SDate17 date, SNumber17 integer, SPercent17 float,\
                                                                SDate18 date, SNumber18 integer, SPercent18 float,\
                                                                SDate19 date, SNumber19 integer, SPercent19 float,\
                                                                SDate20 date, SNumber20 integer, SPercent20 float)")    

print("开始读取所有股票基本信息(PhantomJS-新浪财经)-----开始")
BaseInfo = 0
BaseInfo = tushare.get_stock_basics()
count = len(BaseInfo)
if count == 0:
	print("无法读取股票基本信息。。。，退出")
elif count>0:
	print("开始读取所有股票股东信息信息,总数:%d"%len(BaseInfo))
		
	for i in range(0,count-1):
		retry = 1
		result = 0

		while retry <= 3 :
			print("%d/%d %s %s try%d %d%%"%((i+1),(count),(BaseInfo.index[i]),BaseInfo.iloc[i,0],retry,((i+1)*100/count)))
			result = ReadStockGuDongNumber(BaseInfo.index[i],BaseInfo.iloc[i,0],BaseInfo.iloc[i,5],BaseInfo.iloc[i,4],BaseInfo.iloc[i,10],BaseInfo.iloc[i,11],BaseInfo.iloc[i,16])
			if result == 1:
				retry = 4
			else:
				retry += 1        