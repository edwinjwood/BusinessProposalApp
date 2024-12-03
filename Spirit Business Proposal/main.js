$.noConflict();
jQuery(document).ready(function ($) {
    $("#date1").datepicker();
});

function showData() {
    console.log("Jenkins is workingggggg");
    console.log("Jenkins is workingggggg");
    console.log("Jenkins is workingggggg RED");
    var e = document.getElementById("form_city");
    var val1 = e.options[e.selectedIndex].value;
    var txt = e.options[e.selectedIndex].text;
    console.log("Value Selected is = " + val1);
    console.log("Text Selected is = " + txt);
    if (val1 == "ashvile") {
        document.getElementById("cityimage").src = "img/Asheville_.jpg";
    }
    else if (val1 == "augusta") {
        document.getElementById("cityimage").src = "img/Augusta.jpg";
    }
    else if (val1 == "charlsetonsc") {
        document.getElementById("cityimage").src = "img/Charleston_.jpg";
    }
    else if (val1 == "charlsetonwv") {
        document.getElementById("cityimage").src = "img/Charleston WV.jpg";
    }
    else if (val1 == "charlotte") {
        document.getElementById("cityimage").src = "img/Charlotte_.jpg";
    }
    else if (val1 == "charlottesville") {
        document.getElementById("cityimage").src = "img/Charlottesville.jpg";
    }
    else if (val1 == "clarksburg") {
        document.getElementById("cityimage").src = "img/Clarksburg.jpg";
    }
    else if (val1 == "columbia") {
        document.getElementById("cityimage").src = "img/columbia.jpg";
    }
    else if (val1 == "durham") {
        document.getElementById("cityimage").src = "img/Durham.jpg";
    }
    else if (val1 == "frederick") {
        document.getElementById("cityimage").src = "img/Frederick MD.jpg";
    }
    else if (val1 == "greensboro") {
        document.getElementById("cityimage").src = "img/Greensboro.jpg";
    }
    else if (val1 == "greenvile") {
        document.getElementById("cityimage").src = "img/Greenville_.jpg";
    }
    else if (val1 == "hagerstown") {
        document.getElementById("cityimage").src = "img/Hagerstown MD.jpg";
    }
    else if (val1 == "harrisonburg") {
        document.getElementById("cityimage").src = "img/Harrisonburg.jpg";
    }
    else if (val1 == "huntington") {
        document.getElementById("cityimage").src = "img/Huntington.jpg";
    }
    else if (val1 == "leesburg") {
        document.getElementById("cityimage").src = "img/Leesburg.jpg";
    }
    else if (val1 == "lynchburg") {
        document.getElementById("cityimage").src = "img/Lynchburg.jpg";
    }
    else if (val1 == "morgantown") {
        document.getElementById("cityimage").src = "img/Morgantown.jpg";
    }
    else if (val1 == "norfolk") {
        document.getElementById("cityimage").src = "img/Norfolk.jpg";
    }
    else if (val1 == "parkersburg") {
        document.getElementById("cityimage").src = "img/Parkersburg WV.jpg";
    }
    else if (val1 == "pittsburg") {
        document.getElementById("cityimage").src = "img/Pittsburg.jpg";
    }
    else if (val1 == "raleigh") {
        document.getElementById("cityimage").src = "img/Raleigh_.jpg";
    }
    else if (val1 == "richmond") {
        document.getElementById("cityimage").src = "img/Richmond.jpg";
    }
    else if (val1 == "roanoke") {
        document.getElementById("cityimage").src = "img/Roanoke.jpg";
    }
    else if (val1 == "virginiabeach") {
        document.getElementById("cityimage").src = "img/Virginia Beach.jpg";
    }
    else if (val1 == "waynesboro") {
        document.getElementById("cityimage").src = "img/Waynesboro VA.jpg";
    }
    else if (val1 == "wilmington") {
        document.getElementById("cityimage").src = "img/Wilmington_.jpg";
    }
    else if (val1 = "fayetteville") {
        document.getElementById("cityimage").src = "img/Fayetteville.jpg";
    }
}

function addformpage() {
    var e = document.getElementById("form_page");
    var value_form = e.options[e.selectedIndex].value;
    var txt_ar2 = document.getElementById("objective2");
    var txt_ar3 = document.getElementById("objective3");
    var txt_ar4 = document.getElementById("objective4");
    console.log("Value Selected is = " + value_form);
    if (value_form == "1") {
        console.log(value_form);
        txt_ar2.style.display = "none";
        txt_ar3.style.display = "none";
        txt_ar4.style.display = "none";
    }
    else if (value_form == "2") {
        txt_ar2.style.display = "block";
        txt_ar3.style.display = "none";
        txt_ar4.style.display = "none";
    }
    else if (value_form == "3") {
        txt_ar2.style.display = "block";
        txt_ar3.style.display = "block";
        txt_ar4.style.display = "none";
    }
    else {
        txt_ar2.style.display = "block";
        txt_ar3.style.display = "block";
        txt_ar4.style.display = "block";
    }
}

function addImgpage() {
    console.log("Here inside the obj Image Panel");
    var e = document.getElementById("form_Img");
    var value_form = e.options[e.selectedIndex].value;
    console.log("Value Selected is = " + value_form);
    if (value_form == "1") {
        console.log(value_form);
        document.getElementById("div_img2").style.display = "none";
        document.getElementById("div_img3").style.display = "none";
        document.getElementById("div_img4").style.display = "none";
        document.getElementById("div_img5").style.display = "none";
    }
    else if (value_form == "2") {
        document.getElementById("div_img2").style.display = "block";
        document.getElementById("div_img3").style.display = "none";
        document.getElementById("div_img4").style.display = "none";
        document.getElementById("div_img5").style.display = "none";
    }
    else if (value_form == "3") {
        document.getElementById("div_img2").style.display = "block";
        document.getElementById("div_img3").style.display = "block";
        document.getElementById("div_img4").style.display = "none";
        document.getElementById("div_img5").style.display = "none";
    }
    else if (value_form == "4") {
        document.getElementById("div_img2").style.display = "block";
        document.getElementById("div_img3").style.display = "block";
        document.getElementById("div_img4").style.display = "block";
        document.getElementById("div_img5").style.display = "none";
    }
    else if (value_form == "5") {
        document.getElementById("div_img2").style.display = "block";
        document.getElementById("div_img3").style.display = "block";
        document.getElementById("div_img4").style.display = "block";
        document.getElementById("div_img5").style.display = "block";
     }
}

function SelectRef() {
    var e = document.getElementById("sup_ref");
    var value_form = e.options[e.selectedIndex].value;
    console.log(value_form);
    if (value_form == "3Ref") {
        Ref.style.display = "block";
        LSR.style.display = "none";
    }
    else {
        Ref.style.display = "block";
        LSR.style.display = "block";
    }
}


$("#Label2").change(function () {
    $("#Label2").css('color', 'green');
});

