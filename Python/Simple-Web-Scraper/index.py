import time
from urllib.request import urlopen
from bs4 import BeautifulSoup

html = urlopen("https://www.dotabuff.com/players/66296404/matches?enhance=overview&page=1")

time.sleep(1)

res = BeautifulSoup(html.read(),"html.parser")


print(res.title)