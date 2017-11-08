import urllib.request
from bs4 import BeautifulSoup
import time
import datetime
import sqlite3
import os
import tushare
from selenium import webdriver
from selenium.common.exceptions import NoSuchElementException
from selenium.webdriver.common.keys import Keys

def ReadStockGuDongNumber(Stock_Number,name,totals,outstanding,reservedPerShare,esp,perundp):
	ReturnValue = 1
	try:
		#weburl = "http://www.yidiancangwei.com/gudong/renshu_awdwad.html"
		weburl = "http://www.yidiancangwei.com/gudong/renshu_" + Stock_Number + ".html"
		#print("%s"%weburl)

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

		#print(Stock_Number + ':')
		for idx, tr in enumerate(soup.find_all('tr')):
			if idx == 1:
				tds = tr.find_all('td')
				GD_Date = tds[0].contents[0].strip()
				GD_Number = tds[1].contents[0].strip()
				GD_Change = tds[2].contents[0].strip()
				if GD_Change == "-" or GD_Change == "":
					GD_Change="0"
				SessionName=",SDate" + str(idx) + ",SNumber" + str(idx) + ",SPercent" + str(idx) + ",Name,totals,outstanding,reservedPerShare,esp,perundp) values("
				sql="insert into Gudong(" + "StockNumber" + SessionName
				sql=sql+ Stock_Number + ", '" + GD_Date +"','"+GD_Number+"','"+GD_Change.rstrip("%")+ "','" +name+ "','" +str(totals)+ "','" +str(outstanding)+ "','" +str(reservedPerShare)+ "','" +str(esp)+ "','" +str(perundp) +"')"
				#print(sql)
				cu.execute(sql)
				#print('   ' + GD_Date + '   ' + GD_Number + '   ' + GD_Change)
			elif idx>=2 and idx<=20:
				tds = tr.find_all('td')
				GD_Date = tds[0].contents[0].strip()
				GD_Number = tds[1].contents[0].strip()
				GD_Change = tds[2].contents[0].strip()
				if GD_Change == "-" or GD_Change == "":
					GD_Change="0"
				SessionName=",SDate" + str(idx) + ",SNumber" + str(idx) + ",SPercent" + str(idx) + ") values("
				sql="update Gudong set " + "SDate" + str(idx) + "='" + GD_Date
				sql=sql+"', SNumber" + str(idx) + "=" + GD_Number
				sql=sql+", SPercent" + str(idx) + "=" + GD_Change.rstrip("%")
				sql=sql+ " where StockNumber = " + Stock_Number
				#print(sql)
				cu.execute(sql)
			cx.commit()
	except urllib.error.HTTPError as e:
		print(Stock_Number + " " + name + "Error Code: ", e.code)
		ReturnValue=0
	except urllib.error.URLError as e:
		print(Stock_Number + " " + name +"Error: Cannot connect to server")
		ReturnValue=0
	except Exception as e:
		print(Stock_Number + " " + name + "Error: " + str(e))
		ReturnValue=0
	return ReturnValue
	
UseSelenium = 0

if UseSelenium == 1:
	chromedriver = "K:\KewellStock_GuDong\chromedriver.exe"
	os.environ["webdriver.chrome.driver"] = chromedriver
	browser = webdriver.Chrome(chromedriver)

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

print("开始读取所有股票基本信息-----开始")
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

		
		
													
	# BaseStock = 600000
	# for i in range(0,999):
		# ReadStockGuDongNumber(str(BaseStock + i))

	# BaseStock = 601000
	# for i in range(0,999):
		# ReadStockGuDongNumber(str(BaseStock + i))
		
	# BaseStock = 0
	# for i in range(0,999):
		# ReadStockGuDongNumber("000%03d"%(BaseStock + i))
		
	# BaseStock = 2000
	# for i in range(0,999):
		# ReadStockGuDongNumber("00%04d"%(BaseStock + i))
		
	# BaseStock = 300000
	# for i in range(0,999):
		# ReadStockGuDongNumber(str(BaseStock + i))

	
	
	
	