from selenium import webdriver
from bs4 import BeautifulSoup

driver = webdriver.PhantomJS("phantomjs.exe")
try:
    driver.get('http://vip.stock.finance.sina.com.cn/corp/go.php/vCI_StockHolderAmount/code/601126/type/amount.phtml')
    #driver.save_screenshot('11.png')  # 截取全屏，并保存
    pageSource = driver.page_source
    soup = BeautifulSoup(pageSource,'lxml')

    tables = soup.find(id='table1')  
    tab = tables[5]  
    for tr in tab.findAll('tr'):  
        for td in tr.findAll('td'):  
            print(td.getText())
        print
except Exception as e:
    print(e)