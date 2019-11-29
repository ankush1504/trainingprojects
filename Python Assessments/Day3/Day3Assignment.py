class product:
    def __init__(self,productid,name,catagory,brand,cost,rating,discount):
        self.productid=productid
        self.name=name
        self.catagory=catagory
        self.brand=brand
        self.cost=cost
        self.rating=rating
        self.discount=discount
    def show(self):
        print("id:{0}, name:{1}, catagory:{2}, brand:{3}, cost:{4}, rating:{5}, discount:{6}".format(self.productid,self.name,self.catagory,self.brand,self.cost,self.rating,self.discount))
    def __str__(self,a):
        return self.a
p1=product(101,"Laptop","Electronics","HP",500000,8.9,30)
p2=product(102,"Mobile","Electronics","Moto",10000,8.0,50)
p3=product(103,"Dress","Clothong","USPA",2000,9.3,20)
p4=product(104,"Shirt","Clothing","Nike",1500,7.8,60)
p5=product(105,"trimmer","Electronics","philips",2500,9.5,10)
p=[p1,p2,p3,p4,p5]
print(p1.__dict__)
choice=int(input("enter 1.Sort\t 2.Filter"))
if(choice==1):
    inp=int(input("enter \n1.sort by cost low to high \n2.sort by cost high to low \n3.sort by rating \n4.sort by discount low to high \n5.sort by discount high to low \n"))

    sorting=[["cost",False],["cost",True],["rating",True],["discount",False],["discount",True]]
    p.sort(key=(lambda el:el.__dict__[sorting[inp-1][0]]),reverse=sorting[inp-1][1])
    for i in p:
           i.show()
elif(choice==2):
    inp=int(input("enter \n1.Filter by catagory \n2.Filter by Name \n3.Filter by Brand\n"))

    filtering=["catagory","name","brand"]
    inp1=input("enter the filter:")
    p1=filter(lambda el:el.__dict__[filtering[inp-1]]==inp1,p)
    for i in p1:
            i.show()
else:
    print("invalid input")


    






