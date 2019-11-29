
li=[{"Product_id":"101",
"Name":"Laptop",
"Category":"ELectronics",
"Brand":"HP",
"Cost":500000,
"Rating":8.9,
"Discount":30
},
{"Product_id":"102",
"Name":"Mobile",
"Category":"Electronics",
"Brand":"Oneplus",
"Cost":30000,
"Rating":9.1,
"Discount":20},
{"Product_id":"103",
"Name":"Dress",
"Category":"Clothing",
"Brand":"Zara",
"Cost":3000,
"Rating":9.1,
"Discount":40},
{"Product_id":"104",
"Name":"Shoes",
"Category":"Clothing",
"Brand":"Nike",
"Cost":5000,
"Rating":8.5,
"Discount":20},
{"Product_id":"105",
"Name":"Shirt",
"Category":"Clothing",
"Brand":"LV",
"Cost":4000,
"Rating":7.3,
"Discount":40}
]
choice=int(input("enter choice:1.Sort \t2.Filter"))
if(choice==1):
    inp=int(input("enter \n1.sort by cost low to high \n2.sort by cost  \nhigh to low3.sort by rating \n4.sort by discount low to high \n5.sort by discount high to low \n"))
    sorting=[["Cost",False],["Cost",True],["Rating",True],["Discount",False],["Discount",True]]
    li.sort(key=(lambda el:el[sorting[inp-1][0]]),reverse=sorting[inp-1][1])
    for i in li:
                  print("Name:{Name},Brand:{Brand},Catagory:{Category},Cost:{Cost},Rating:{Rating},Discount:{Discount}".format(**i))
elif(choice==2):
    inp=int(input("enter \n1.Filter by catagory \n2.Filter by Name \n3.Filter by Brand\n"))
    filtering=["Category","Name","Brand"]
    inp1=input("enter the filter")
    li1=filter(lambda el:el[filtering[inp-1]]==inp1,li)
    for i in li1:
        print("Name:{Name},Brand:{Brand},Catagory:{Category},Cost:{Cost},Rating:{Rating},Discount:{Discount}".format(**i))
else:
    print("invalid input")
