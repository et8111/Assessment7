$(document).ready(function () {
    function RSVPlink() {
        window.location.replace("~/View/Home/RSVP");
    }
});

function COMON() {
    if (document.getElementById("AttendanceDate").value == "" || document.getElementById("AttendanceDate").value == null ) {
        document.getElementById("AttendanceDate").focus();
        alert("date Sucks");
    }
}

function check() {
    if (document.getElementById("attendence").checked == false)
        $("#div2").slideUp();
    else
        $("#div2").slideDown();
    document.getElementById("date1").setAttribute("name", "date1");
    if (document.getElementById("div2").style.display) {
        var temp = document.getElementsByTagName("input");
        for (var i = 1; i < temp.length-1; i++)
            temp[i].value = "";
        temp[temp.length - 1].checked = false;
        $("#div1").slideUp();
        document.getElementById("date").checked = false;
        document.getElementById("date1").checked = false;
        document.getElementById("plusOne").checked = false;
    }
}


function validate() {
    //first name
    if (document.getElementById("FirstName").value == "") {
        document.getElementById("FirstName").focus();
        alert("first name sucks");
        return false;
    }
    //last name
    if (document.getElementById("LastName").value == "") {
        document.getElementById("LastName").focus();
        alert("last name sucks");
        return false;
    }
    //email
    if (document.getElementById("EmailAddress").value == "") {
        document.theForm.email.focus();
        alert("Email Sucks");
        return false;
    }
    if (document.getElementById("AttendanceDate").value != "2018-12-16" || document.getElementById("AttendanceDate").value != "2018-12-15") {
        document.theForm.email.focus();
        alert("date Sucks");
        return false;
    }
    return (true);

}

function validate1() {
    //first name
    if (document.getElementById("Name").value == "") {
        document.getElementById("Name").focus();
        alert("first name sucks");
        return false;
    }
    if (document.getElementById("Phone").value.length != 10) {
        alert("Phone sucks");
        return false;
    }
    if (document.getElementById("Phone").value == "") {
        document.getElementById("Phone").focus();
        alert("Phone sucks");
        return false;
    }
    //email
    if (document.getElementById("Dish").value == "") {
        document.theForm.email.focus();
        alert("need a dish yo...");
        return false;
    }
    return (true);
}

function GOTcheck() {
    var e = document.getElementById("GoTCharacter");
    var strUser = e.options[e.selectedIndex].value;
    if (strUser == "Select Character")
        return false;
    else
        return true;
}