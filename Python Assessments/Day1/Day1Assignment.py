#Patterns
#1
num=5
for i in range(num+1):
    print("*"*i)
#2
print("\n")  
for i in range(num+1):
    print("*"*(num-i))
print("\n")  
#3
for i in range(num,0,-1):
    print(" "*(num-i)+"*"*i)
print("\n")

#4
for i in range(num+1):
    print(" "*(num-i)+"*"*i)
print("\n")

#5
for i in range(num+1):
     print(" "*(num-i)+"* "*i)

#6     
data="python"
for i in range(len(data)+1):
    print(" "*(len(data)-i)+data[0:i])

#Factorial of a number
num1=int(input("enter the number:"))
fact=1
for i in range(num,0,-1):
    fact=fact*i
print(fact)

#Fibonocci Series
a=0
b=1
i=0
print("0 1",end=" ")
while(i<num):
    c=a+b
    print(c,end=" ")
    a=b
    b=c
    i=i+1

    



