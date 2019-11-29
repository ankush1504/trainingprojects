import urllib.request as urllib
from bs4 import BeautifulSoup
import re
import pymysql

data=urllib.urlopen('https://www.moneycontrol.com/').read()
soup = BeautifulSoup(data,'lxml')
x=0;
li1=[]


for i in soup.find_all("div",attrs={"id" :'tlSensex'}):
    for j in i.find_all("td"):
        print(j.string)
        li1.append(j.string)
  
for i in soup.find_all("div",attrs={"id" :'tlNifty'}):
    for j in i.find_all("td"):
        print(j.string)

for i in soup.find_all("div",attrs={"id" :'tgSensex'}):
    for j in i.find_all("td"):
        print(j.string)
  
for i in soup.find_all("div",attrs={"id" :'tgNifty'}):
    for j in i.find_all("td"):
        print(j.string)
        
db = pymysql.connect("localhost","root","","test" )
cursor = db.cursor()
print(li1)


'''cursor.execute("""CREATE TABLE SENSEXLOSECOMP (
         COMPANY  CHAR(30),
         PRICE  CHAR(20),
         CHANGE1 CHAR(20),  
         LOSS1 CHAR(20) ) """)'''

i=0
while i<(len(li1)-1):
    cursor.execute("""INSERT INTO SENSEXLOSECOMP
         VALUES (%s,%s,%s,%s)""",(li1[i],li1[i+1],li1[i+2],li1[i+3]))
    i=i+4
        
db.commit()
db.close()
