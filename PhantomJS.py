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