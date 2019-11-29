import os
import re
dir = "C:/Users/arelekar/Documents/python/Directory"
for root, dirs, files in os.walk(dir):
    for file in files:
        if file.endswith('.log'):
            fo=open(file,"r")
            data=fo.read()
            pattern='[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+'
            matches=re.findall(pattern,data)
            if(matches):
                for match in matches:
                    print(match)
            else:
                print("none found")



