from selenium import webdriver
from bs4 import BeautifulSoup
import pandas as pd
import numpy as np

driver = webdriver.PhantomJS("phantomjs.exe")
try:
    driver.get('http://vip.stock.finance.sina.com.cn/corp/go.php/vCI_StockHolderAmount/code/601126/type/amount.phtml')
    #driver.save_screenshot('11.png')  # 截取全屏，并保存
    pageSource = driver.page_source
    soup = BeautifulSoup(pageSource,'lxml')

#    table = soup.find(id='Table1').findAll('td')
#    for i in range(len(table)):
#        print(table[i].Text)

    df = pd.DataFrame(columns = ["Date", "Number", "Percent"]) #创建一个空的dataframe

    tables = soup.findAll(id='Table1')
    tab = tables[0]
    cnt=0
    for tr in tab.findAll('tr'):
        date = tr.findNext('td').getText()
        number = tr.findNext('td').getText()
        percent = tr.findNext('td').getText()
        df.loc[cnt] = [date,number,percent]
        cnt+=1
    print(df)
except Exception as e:
    print(e)