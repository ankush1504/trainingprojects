function proceednext() {
    var userre = /^[A-Za-z0-9]{5,12}$/;
    var user1 = document.getElementById("userid").value;
    var usertest = userre.test(user1);
    console.log(usertest);

    var pass1, pass2;
    var passre = /^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*\W).{7,12}$/;
    pass1 = document.getElementById("pass").value;
    pass2 = document.getElementById("conpass").value;
    var passtest = passre.test(pass1);
    var passtest1 = passre.test(pass2);
    console.log(passtest);
    var passwordtest = ((pass1 == pass2) && (passtest == true));

    var namere = /^[A-Za-z]{5,12}$/;
    var name1 = document.getElementById("name").value;
    var nametest = namere.test(name1);

    var zipre = /^[0-9]{5,10}$/;
    var zip1 = document.getElementById("zcode").value;
    var ziptest = zipre.test(zip1);

    mailenter = document.getElementById("emailid").value;
    var mailre = /^[A-Za-z0-9.-_]{4,}@[A-Za-z0-9]{1,}\.[a-z]{2,3}$/;
    var mailtest = mailre.test(mailenter);

   
    // var yrentered = new Date(enteryr).getFullYear();
    // var yrpresent = new Date().getFullYear();
    // var yrdiff = yrpresent - yrentered;
    var enteryr = document.getElementById("dob").value;
    var yrenteredtime = new Date(enteryr).getTime();
    var yrpresenttime = new Date().getTime();
    var yrdifftime=(yrpresenttime-yrenteredtime)/(1000*60*60*24*365);
    

    if (usertest == false) {
        alert("enter valid userid");
    }
    else if (passwordtest == false) {
        alert("enter valid password");
    }
    else if (nametest == false) {
        alert("enter valid name");
    }
    else if (mailtest == false) {
        alert("enter valid email id");
    }
    else if(ziptest ==false)
    {
        alert("enter valid zipcode")
    }
    else if (yrdifftime < 18) {
        //document.getElementById("dob").disabled = true;
        alert("age should be above 18");
    }
    else {
        alert("registration complete")
    }

}
