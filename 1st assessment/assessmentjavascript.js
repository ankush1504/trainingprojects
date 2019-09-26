function proceednext() {
    // var namere=/^[A-Z][a-z]{3,}\s[A-Z][a-z]{3,}/;
    var userre = /^[A-Za-z0-9]{5,12}$/;
    var user1 = document.getElementById("userid").value;
    var usertest = userre.test(user1);
    console.log(usertest);



    //console.log(ntestfinal);
    var user, pass1, pass2;
    var passform = /^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*\W).{7,12}$/;
    pass1 = document.getElementById("pass").value;
    pass2 = document.getElementById("conpass").value;
    var passtest = passform.test(pass1);
    var passtest2 = passform.test(pass2);
    console.log(passtest);
    var passwordtest = ((pass1 == pass2) && (passtest == true));

    var namere = /^[A-Za-z]{5,12}$/;
    var name1 = document.getElementById("name").value;
    var ntest = namere.test(name1);

    var zipre = /^[0-9]{5,10}$/;
    var zip1 = document.getElementById("zcode").value;
    var ziptest = zipre.test(zip1);

    vmail = document.getElementById("emailid").value;
    var rmail = /^[A-Za-z0-9.-_]{4,}@[A-Za-z0-9]{1,}\.[a-z]{2,3}$/;
    var fmail = rmail.test(vmail);

    var enteryr = document.getElementById("dob").value;
    var yr1 = new Date(enteryr).getFullYear();
    var yr = new Date().getFullYear();
    var yrdiff;

    yrdiff = yr - yr1;

    //console.log(yr1, yr, yrdiff);



    if (usertest == false) {
        alert("enter valid userid");
    }
    else if (passwordtest == false) {
        alert("enter valid password");
    }
    else if (ntest == false) {
        alert("enter valid name");
    }
    else if (fmail == false) {
        alert("enter valid email id");
    }
    else if(ziptest ==false)
    {
        alert("enter valid zipcode")
    }
    else if (yrdiff < 18) {
        //document.getElementById("dob").disabled = true;
        alert("age should be above 18");
    }
    else {
        alert("registration complete")
    }

}
