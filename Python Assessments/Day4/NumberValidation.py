number=input("enter the phone number:\n")
pattern='^[0-9]{10}$'
matches=re.match(pattern,number)
if matches:
    print("valid number")
else:
    print("invalid number")
