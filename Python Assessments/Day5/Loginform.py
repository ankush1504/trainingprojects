from tkinter import*
import pymysql

def submit_it():
    db = pymysql.connect("localhost","root","","test" )
    cursor = db.cursor()
    cursor.execute("SELECT FIRST_NAME FROM USERS WHERE FIRST_NAME = %s;",entry_1.get()) 
    while cursor.fetchone() is not None:
        print("Valid Username") 
        cursor.execute("SELECT Email FROM USERS WHERE FIRST_NAME = %s;",entry_1.get())        
        if cursor.fetchone()[0]==entry_2.get():
            print("Password matched")
            break
        else:   
            print("Invalid Password!")
            break
    else:
        print("InValid Username") 
    db.commit()
    db.close()
        
    
    
root = Tk()
root.geometry('500x500')
root.title("Login Form")

label_0 = Label(root, text="Login Form",width=20,font=("bold", 20))
label_0.place(x=90,y=53)


label_1 = Label(root, text="Username",width=20,font=("bold", 10))
label_1.place(x=80,y=130)

entry_1 = Entry(root)
entry_1.place(x=240,y=130)

label_2 = Label(root, text="Password",width=20,font=("bold", 10))
label_2.place(x=68,y=180)

entry_2 = Entry(root)
entry_2.place(x=240,y=180)

Button(root, text='Submit',width=20,bg='brown',fg='white',command=submit_it).place(x=180,y=380)
# it is use for display the registration form on the window
root.mainloop()
