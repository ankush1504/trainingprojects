def createwallet(balance,username,pin):
    def deposit(amount):
        nonlocal balance
        nonlocal username
        balance+=amount
        print("user:"+username+" "+"after depositing new balance:",balance)
    def spend(amount):
        nonlocal balance
        nonlocal username
        if(amount<balance):
            balance-=amount
            print("user:"+username+" "+"after withdrawal new balance:",balance)
        else:
            print("less balance")
    def show():
        nonlocal balance
        nonlocal username
        print("user:"+username+" "+"balance:",balance)
    def transfer(amount):
        nonlocal balance
        nonlocal username
        balance=balance-amount
        print("money transferred:")
        return amount
        
    return (deposit,spend,show,transfer)

dep=createwallet(200,"cust1")
dep[0](300)
dep[1](600)
dep[2]()

user2=createwallet(0,"cust2")
user2[0](dep[3](300))
user2[1](100)
user2[2]()


        


    
    
