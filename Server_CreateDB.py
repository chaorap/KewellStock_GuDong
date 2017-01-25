import urllib.request
from bs4 import BeautifulSoup
import time
import datetime
import sqlite3
import os
from selenium import webdriver
from selenium.common.exceptions import NoSuchElementException
from selenium.webdriver.common.keys import Keys

def ReadStockGuDongNumber(Stock_Number):
	try:
		#weburl = "http://www.yidiancangwei.com/gudong/renshu_awdwad.html"
		weburl = "http://www.yidiancangwei.com/gudong/renshu_" + Stock_Number + ".html"
		
		if UseSelenium == 1:
			browser.get(weburl)
			time.sleep(1)
			HtmlData = browser.page_source.encode('UTF-8').decode('UTF-8')
		elif UseSelenium == 0:
			webheader = {'User-Agent':'Mozilla/5.0 (Windows NT 6.1; WOW64; rv:23.0) Gecko/20100101 Firefox/23.0'} 
			req = urllib.request.Request(url=weburl, headers=webheader)  
			webPage=urllib.request.urlopen(req)
			HtmlData = webPage.read()
			HtmlData = HtmlData.decode('UTF-8')
			
		soup = BeautifulSoup(HtmlData,'lxml')

		print(Stock_Number + ':')
		for idx, tr in enumerate(soup.find_all('tr')):
			if idx == 1:
				tds = tr.find_all('td')
				GD_Date = tds[0].contents[0].strip()
				GD_Number = tds[1].contents[0].strip()
				GD_Change = tds[2].contents[0].strip()
				if GD_Change == "-":
					GD_Change="0"
				SessionName=",SDate" + str(idx) + ",SNumber" + str(idx) + ",SPercent" + str(idx) + ") values("
				sql="insert into Gudong(" + "StockNumber" + SessionName
				sql=sql+ Stock_Number + ", '" + GD_Date +"',"+GD_Number+","+GD_Change.rstrip("%")+")"
				print(sql)
				cu.execute(sql)
				#print('   ' + GD_Date + '   ' + GD_Number + '   ' + GD_Change)
			elif idx>=2 and idx<=10:
				tds = tr.find_all('td')
				GD_Date = tds[0].contents[0].strip()
				GD_Number = tds[1].contents[0].strip()
				GD_Change = tds[2].contents[0].strip()
				if GD_Change == "-":
					GD_Change="0"			
				SessionName=",SDate" + str(idx) + ",SNumber" + str(idx) + ",SPercent" + str(idx) + ") values("
				sql="update Gudong set " + "SDate" + str(idx) + "='" + GD_Date
				sql=sql+"', SNumber" + str(idx) + "=" + GD_Number
				sql=sql+", SPercent" + str(idx) + "=" + GD_Change.rstrip("%")
				sql=sql+ " where StockNumber = " + Stock_Number
				print(sql)
				cu.execute(sql)
			cx.commit()
	except urllib.error.HTTPError as e:
		print("Error Code: ", e.code);
	except urllib.error.URLError as e:
		print("Error: Cannot connect to server")
	#except:
	#	print("Error: Other error");
	
UseSelenium = 0

if UseSelenium == 1:
	chromedriver = "K:\KewellStock_GuDong\chromedriver.exe"
	os.environ["webdriver.chrome.driver"] = chromedriver
	browser = webdriver.Chrome(chromedriver)

DB_Name = "K:\KewellStock_GuDong\db\AStock_" +  datetime.datetime.now().strftime('%Y-%m-%d_%H_%M_%S') + ".sqlite"
cx = sqlite3.connect(DB_Name)
cu=cx.cursor()
cu.execute("create table Gudong (StockNumber integer primary key, SDate1 date, SNumber1 integer, SPercent1 float,\
																  SDate2 date, SNumber2 integer, SPercent2 float,\
																  SDate3 date, SNumber3 integer, SPercent3 float,\
																  SDate4 date, SNumber4 integer, SPercent4 float,\
																  SDate5 date, SNumber5 integer, SPercent5 float,\
																  SDate6 date, SNumber6 integer, SPercent6 float,\
																  SDate7 date, SNumber7 integer, SPercent7 float,\
																  SDate8 date, SNumber8 integer, SPercent8 float,\
																  SDate9 date, SNumber9 integer, SPercent9 float,\
																  SDate10 date, SNumber10 integer, SPercent10 float)")

BaseStock = 600000
for i in range(0,999):
	ReadStockGuDongNumber(str(BaseStock + i))

BaseStock = 601000
for i in range(0,999):
	ReadStockGuDongNumber(str(BaseStock + i))
	
BaseStock = 0
for i in range(0,999):
	ReadStockGuDongNumber("000%03d"%(BaseStock + i))
	
BaseStock = 2000
for i in range(0,999):
	ReadStockGuDongNumber("00%04d"%(BaseStock + i))
	
BaseStock = 300000
for i in range(0,999):
	ReadStockGuDongNumber(str(BaseStock + i))
	
	
	
	
	