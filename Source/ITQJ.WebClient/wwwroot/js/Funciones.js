$(document).ready(() => {




    $("#Editar").css({
        visibility: "hidden",
        position: "absolute",
        top: "0px"
    }); 

});

function ScrollUp() {

    window.scroll({
        top: 0,
        behavior: 'smooth'
   });

}

function ChangePorcentage(id, inID, chId, AID)
{
    var input, A, check, label;

    A = $("#" + AID);
    input = document.getElementById(inID);
    check = document.getElementById(chId);
    label = document.getElementById(id)

    label.innerHTML = document.getElementById(inID).value + "%";

    if (input.value > 0)
    {
        check.checked = true;

        A.css({
            backgroundColor: "gray"
        });

    }
    else if (input.value <= 0)
    {
        check.checked = false;

        A.css({
            backgroundColor: "#f1f1f1"
        });

    }

}

function Check(id, inID, chId, AID)
{
    debugger;

    var input, A, check;

    A = $("#" + AID);
    input = document.getElementById(inID)
    check = document.getElementById(chId)

    if (check.checked == false)
    {
        input.value = 50;
        ChangePorcentage(id, inID, chId);
        check.checked = true;
      
        A.css({
            backgroundColor: "gray"
        });

    }
    else {
        input.value = 0;
        ChangePorcentage(id, inID, chId);
        check.checked = false;

        A.css({
            backgroundColor: "#f1f1f1"
        });
    }
    
   
}

function Checked(id, inID, chId, AID) {

    debugger;

    var input, A, check;

    A = $("#" + AID);
    input = document.getElementById(inID)
    check = document.getElementById(chId)
    
    ChangePorcentage(id, inID, chId);
    check.checked = true;
    
    A.css({
        backgroundColor: "gray"
    });

 }

function ProjectOver(proId)
{
    $("#" + proId).css({
        boxShadow: "2px 2px 6px #4e4e55"
    });
}

function ProjectDown(proId)
{
    $("#" + proId).css({
        boxShadow: "0px 0px 0px transparent"
    });
}


function MaxPostulantOff(CheckClose, MaxPas, CheckPostulant, InputClose) {

    debugger;

    var checkn, number;
    var checkd, date;

    checkn = CheckPostulant;
    date = InputClose;
    checkd = CheckClose;
    number = MaxPas;


    if (checkd.checked == true) {
        number.value = 50;
        $("#MaxPastilants").css({ pointerEvents: "none" });
        document.getElementById("MaxPastilants").disabled = false;
    }


    if (checkn.checked == true) {
        defaultDate = date.defaultValue;
        date.defaultValue = "3000-01-01";
        $("#InputCloseDate").css({ pointerEvents: "none" });
        document.getElementById("InputCloseDate").disabled = false;
    }

}


function MaxPostulant(CheckClose, MaxPas)
{

    var check,number;

    check = CheckClose;
    number = MaxPas;


    if (check.checked == true)
    {
        number.value = 50;
        $("#MaxPastilants").css({ pointerEvents: "none" });
        document.getElementById("MaxPastilants").disabled = true;
    }
    else
    {
        number.value = 0;
        $("#MaxPastilants").css({ pointerEvents: "painted" });
        document.getElementById("MaxPastilants").disabled = false;
    }

}

var defaultDate;
function ChecClose(CheckPostulant, InputClose)
{
    var check, date;

    check = CheckPostulant;
    date = InputClose;
    

    if (check.checked == true)
    {
        defaultDate = date.defaultValue;
        date.defaultValue = "3000-01-01";
        $("#InputCloseDate").css({ pointerEvents: "none" });
        document.getElementById("InputCloseDate").disabled = true;
    }
    else
    {
        date.defaultValue = defaultDate;
        $("#InputCloseDate").css({ pointerEvents: "painted" }); 
        document.getElementById("InputCloseDate").disabled = false;
    }

}





function Cancelar()
{

    $("#Editar").css({
        visibility: "hidden",
        position: "absolute",
        top: "0px"
    }); 


    $("#presentar").css({
        visibility: "visible",
        position: "initial"
    }); 
}

function Edit()
{

    $("#Editar").css({
        visibility: "visible",
        position: "initial"
    }); 

    $("#presentar").css({
        visibility: "hidden",
        position: "absolute",
        top:"0px"
    }); 

}

var active = false;
function Sandwich() {

    if (active == false)
    {

        $(".navegador").css({ height: "300px" });

        $("#navbarSupportedContent1").css({
            display: "block"
        });

        $(".menu").css({
            position: "absolute",
            left: "10px",
            top: "60px"
        });

        active = true;

    }
    else
    {

        $(".navegador").css({ height: "65px" });

        $(".menu").css({
            position: "relatove",
            right: "20px",
            top: "20px"
        });

        $("#navbarSupportedContent1").css({
            display: "none"
        });

        active = false;
    }
      
}

var _with = 0;
function Resize()
{
    if (active == true) {

        _with = $(".boddy").width();

        if (_with => 1300)
        {
            $(".navegador").css({ height: "65px" });

            $(".menu").css({
                position: "relatove",
                right: "20px",
                top: "20px"
            });

            active = false;

            $("#navbarSupportedContent1").css({
                display: "none"
            });

        }

    }

}


function RangeStar(star) {

    debugger;

    var _star = document.getElementsByClassName(star);

    // primary
    var primary = document.createElement("div");
    primary.className += "prima";

    var _primary = $('.prima');
    _primary.css({ display: "block", position: "relative"});

    //segun1
    var segun1 = document.createElement("div");
    segun1.className += "segu1";

    var _segun1 = $('.segu1');
    _segun1.css({ display: "inline-block", position: "relative" });

    //img1
    var img1_s1 = document.createElement("img");
    img1_s1.id = "HalfStar1";
    img1_s1.width = "@SizeStarsX";
    img1_s1.height = "@SizeStarsY";
    img1_s1.src = "~/Image/star_half_empty.png";
    img1_s1.className += "img1s1";

    var _img1_s1 = $('.img1s1');
    _img1_s1.css({ visibility: "hidden", position: "relative", top: "0px", left: "0px" });
    document.body.insertBefore(_mg1_s1, _segun1); 

    //img2
    var img2_s1 = document.createElement("img"); 
    img2_s1.id = "FullStar1";
    img2_s1.width = "@SizeStarsX";
    img2_s1.height = "@SizeStarsY";
    img2_s1.src = "~/Image/star_filled.png";
    img2_s1.className += "img2s1";

    var _img2_s1 = $('.img2s1');
    _img2_s1.css({ visibility: "hidden", position: "absolute", top: "0px", left: "0px"  });
    document.body.insertBefore(_segun1, primary); 

    document.body.insertBefore(_mg2_s1, segun1); 

    //segun2
    var segun2 = document.createElement("div");
    segun2.className += "segu2";

    var _segun2 = $('.segu2');
    _segun2.css({ display: "inline-block", position: "relative" });

    //img1
    var img1_s2 = document.createElement("img");
    img1_s2.id = "HalfStar2";
    img1_s2.width = "@SizeStarsX";
    img1_s2.height = "@SizeStarsY";
    img1_s2.src = "~/Image/star_half_empty.png";
    img1_s2.className += "img1s2";

    var _img1_s2 = $('.img1s2');
    _img1_s2.css({ visibility: "hidden", position: "relative", top: "0px", left: "0px" });
    document.body.insertBefore(_mg1_s2, segun2); 

    //img2
    var img2_s2 = document.createElement("img");
    img2_s2.id = "FullStar2";
    img2_s2.width = "@SizeStarsX";
    img2_s2.height = "@SizeStarsY";
    img2_s2.src = "~/Image/star_filled.png";
    img2_s2.className += "img2s2";

    var _img2_s2 = $('.img2s2');
    _img2_s2.css({ visibility: "hidden", position: "absolute", top: "0px", left: "0px" });
    document.body.insertBefore(_mg2_s2, segun2); 

    document.body.insertBefore(_segun2, primary); 

    //segun3
    var segun3 = document.createElement("div");
    segun3.className += "segu3";

    var _segun3 = $('.segu3');
    _segun3.css({ display: "inline-block", position: "relative" });

    //img1
    var img1_s3 = document.createElement("img");
    img1_s3.id = "HalfStar3";
    img1_s3.width = "@SizeStarsX";
    img1_s3.height = "@SizeStarsY";
    img1_s3.src = "~/Image/star_half_empty.png";
    img1_s3.className += "img1s3";

    var _img1_s3 = $('.img1s3');
    _img1_s3.css({ visibility: "hidden", position: "relative", top: "0px", left: "0px" });
    document.body.insertBefore(_mg1_s3, segun3); 

    //img2
    var img2_s3 = document.createElement("img");
    img2_s3.id = "FullStar3";
    img2_s3.width = "@SizeStarsX";
    img2_s3.height = "@SizeStarsY";
    img2_s3.src = "~/Image/star_filled.png";
    img2_s3.className += "img2s3";

    var _img2_s3 = $('.img2s3');
    _img2_s3.css({ visibility: "hidden", position: "absolute", top: "0px", left: "0px" });
    document.body.insertBefore(_mg2_s3, segun3);

    document.body.insertBefore(_segun3, primary); 

    //segun4
    var segun4 = document.createElement("div");
    segun4.className += "segu4";

    var _segun4 = $('.segu1');
    _segun4.css({ display: "inline-block", position: "relative" });

    //img1
    var img1_s4 = document.createElement("img");
    img1_s4.id = "HalfStar4";
    img1_s4.width = "@SizeStarsX";
    img1_s4.height = "@SizeStarsY";
    img1_s4.src = "~/Image/star_half_empty.png";
    img1_s4.className += "img1s4";

    var _img1_s4 = $('.img1s4');
    _img1_s4.css({ visibility: "hidden", position: "relative", top: "0px", left: "0px" });
    document.body.insertBefore(_mg1_s4, segun4); 

    //img2
    var img2_s4 = document.createElement("img");
    img2_s4.id = "FullStar4";
    img2_s4.width = "@SizeStarsX";
    img2_s4.height = "@SizeStarsY";
    img2_s4.src = "~/Image/star_filled.png";
    img2_s4.className += "img2s4";

    var _img2_s4 = $('.img2s4');
    _img2_s4.css({ visibility: "hidden", position: "absolute", top: "0px", left: "0px" });
    document.body.insertBefore(_mg2_s4, segun4);

    document.body.insertBefore(_segun4, primary); 

    //segun5
    var segun5 = document.createElement("div");
    segun5.className += "segu5";

    var _segun5 = $('.segu5');
    _segun5.css({ display: "inline-block", position: "relative" });

    //img1
    var img1_s5 = document.createElement("img");
    img1_s5.id = "HalfStar5";
    img1_s5.width = "@SizeStarsX";
    img1_s5.height = "@SizeStarsY";
    img1_s5.src = "~/Image/star_half_empty.png";
    img1_s5.className += "img1s5";

    var _img1_s5 = $('.img1s5');
    _img1_s5.css({ visibility: "hidden", position: "relative", top: "0px", left: "0px" });
    document.body.insertBefore(_mg1_s5, segun5);

    //img2
    var img2_s5 = document.createElement("img");
    img2_s5.id = "FullStar5";
    img2_s5.width = "@SizeStarsX";
    img2_s5.height = "@SizeStarsY";
    img2_s5.src = "~/Image/star_filled.png";
    img2_s5.className += "img2s5";

    var _img2_s5 = $('.img2s5');
    _img2_s5.css({ visibility: "hidden", position: "absolute", top: "0px", left: "0px" });
    document.body.insertBefore(_mg2_s5, segun5);

    document.body.insertBefore(_segun5, primary); 

    var range = document.createElement("div");
    range.className += "rang";

    var _range = $('.rang');
    _range.css({ display: "block", border: "1px dotted red", borderRadius: "10px", width: "100%"});

    var input = document.createElement("input"); 
    input.onchange = "ActiveStar()";
    input.id = "RangoStar";
    input.value = "0"
    input.name = "Stars";
    input.type = "range";
    input.max = "100";
    input.min = "0";
    input.class = "form-control-range";

    document.body.insertBefore(input, _range);

    document.body.insertBefore(_range, _primary); 

    document.body.insertBefore(_primary, _star); 
}

function ActiveStar() {

    debugger;

    var value = document.getElementById('RangoStar').value;

    if (value <= 9) {
        $("#HalfStar1").css({ visibility: "hidden" });
        $("#FullStar1").css({ visibility: "hidden" });
        $("#HalfStar2").css({ visibility: "hidden" });
        $("#FullStar2").css({ visibility: "hidden" });
        $("#HalfStar3").css({ visibility: "hidden" });
        $("#FullStar3").css({ visibility: "hidden" });
        $("#HalfStar4").css({ visibility: "hidden" });
        $("#FullStar4").css({ visibility: "hidden" });
        $("#HalfStar5").css({ visibility: "hidden" });
        $("#FullStar5").css({ visibility: "hidden" });
    }

    else if (value >= 10 && value <= 19) {
        $("#HalfStar1").css({ visibility: "visible" });

        $("#FullStar1").css({ visibility: "hidden" });
        $("#HalfStar2").css({ visibility: "hidden" });
        $("#FullStar2").css({ visibility: "hidden" });
        $("#HalfStar3").css({ visibility: "hidden" });
        $("#FullStar3").css({ visibility: "hidden" });
        $("#HalfStar4").css({ visibility: "hidden" });
        $("#FullStar4").css({ visibility: "hidden" });
        $("#HalfStar5").css({ visibility: "hidden" });
        $("#FullStar5").css({ visibility: "hidden" });
    }

    else if (value >= 20 && value <= 29) {
        $("#FullStar1").css({ visibility: "visible" });

        $("#HalfStar1").css({ visibility: "hidden" });
        $("#HalfStar2").css({ visibility: "hidden" });
        $("#FullStar2").css({ visibility: "hidden" });
        $("#HalfStar3").css({ visibility: "hidden" });
        $("#FullStar3").css({ visibility: "hidden" });
        $("#HalfStar4").css({ visibility: "hidden" });
        $("#FullStar4").css({ visibility: "hidden" });
        $("#HalfStar5").css({ visibility: "hidden" });
        $("#FullStar5").css({ visibility: "hidden" });
    }

    else if (value >= 30 && value <= 39) {
        $("#FullStar1").css({ visibility: "visible" });

        $("#HalfStar2").css({ visibility: "visible" });

        $("#HalfStar1").css({ visibility: "hidden" });
        $("#FullStar2").css({ visibility: "hidden" });
        $("#HalfStar3").css({ visibility: "hidden" });
        $("#FullStar3").css({ visibility: "hidden" });
        $("#HalfStar4").css({ visibility: "hidden" });
        $("#FullStar4").css({ visibility: "hidden" });
        $("#HalfStar5").css({ visibility: "hidden" });
        $("#FullStar5").css({ visibility: "hidden" });
    }

    else if (value >= 40 && value <= 49) {
        $("#FullStar1").css({ visibility: "visible" });

        $("#FullStar2").css({ visibility: "visible" });

        $("#HalfStar1").css({ visibility: "hidden" });
        $("#HalfStar2").css({ visibility: "hidden" });
        $("#HalfStar3").css({ visibility: "hidden" });
        $("#FullStar3").css({ visibility: "hidden" });
        $("#HalfStar4").css({ visibility: "hidden" });
        $("#FullStar4").css({ visibility: "hidden" });
        $("#HalfStar5").css({ visibility: "hidden" });
        $("#FullStar5").css({ visibility: "hidden" });
    }

    else if (value >= 50 && value <= 59) {
        $("#FullStar1").css({ visibility: "visible" });
        $("#FullStar2").css({ visibility: "visible" });

        $("#HalfStar3").css({ visibility: "visible" });

        $("#HalfStar1").css({ visibility: "hidden" });
        $("#HalfStar2").css({ visibility: "hidden" });
        $("#FullStar3").css({ visibility: "hidden" });
        $("#HalfStar4").css({ visibility: "hidden" });
        $("#FullStar4").css({ visibility: "hidden" });
        $("#HalfStar5").css({ visibility: "hidden" });
        $("#FullStar5").css({ visibility: "hidden" });
    }

    else if (value >= 60 && value <= 69) {
        $("#FullStar1").css({ visibility: "visible" });
        $("#FullStar2").css({ visibility: "visible" });

        $("#FullStar3").css({ visibility: "visible" });

        $("#HalfStar1").css({ visibility: "hidden" });
        $("#HalfStar2").css({ visibility: "hidden" });
        $("#HalfStar3").css({ visibility: "hidden" });
        $("#HalfStar4").css({ visibility: "hidden" });
        $("#FullStar4").css({ visibility: "hidden" });
        $("#HalfStar5").css({ visibility: "hidden" });
        $("#FullStar5").css({ visibility: "hidden" });
    }

    else if (value >= 70 && value <= 79) {
        $("#FullStar1").css({ visibility: "visible" });
        $("#FullStar2").css({ visibility: "visible" });
        $("#FullStar3").css({ visibility: "visible" });

        $("#HalfStar4").css({ visibility: "visible" });

        $("#HalfStar1").css({ visibility: "hidden" });
        $("#HalfStar2").css({ visibility: "hidden" });
        $("#HalfStar3").css({ visibility: "hidden" });
        $("#FullStar4").css({ visibility: "hidden" });
        $("#HalfStar5").css({ visibility: "hidden" });
        $("#FullStar5").css({ visibility: "hidden" });
    }

    else if (value >= 80 && value <= 89) {
        $("#FullStar1").css({ visibility: "visible" });
        $("#FullStar2").css({ visibility: "visible" });
        $("#FullStar3").css({ visibility: "visible" });

        $("#FullStar4").css({ visibility: "visible" });

        $("#HalfStar1").css({ visibility: "hidden" });
        $("#HalfStar2").css({ visibility: "hidden" });
        $("#HalfStar3").css({ visibility: "hidden" });
        $("#HalfStar4").css({ visibility: "hidden" });
        $("#HalfStar5").css({ visibility: "hidden" });
        $("#FullStar5").css({ visibility: "hidden" });
    }

    else if (value >= 90 && value <= 99) {
        $("#FullStar1").css({ visibility: "visible" });
        $("#FullStar2").css({ visibility: "visible" });
        $("#FullStar3").css({ visibility: "visible" });
        $("#FullStar4").css({ visibility: "visible" });

        $("#HalfStar5").css({ visibility: "visible" });

        $("#HalfStar1").css({ visibility: "hidden" });
        $("#HalfStar2").css({ visibility: "hidden" });
        $("#HalfStar3").css({ visibility: "hidden" });
        $("#HalfStar4").css({ visibility: "hidden" });
        $("#FullStar5").css({ visibility: "hidden" });
    }

    else if (value == 100) {

        $("#FullStar1").css({ visibility: "visible" });
        $("#FullStar2").css({ visibility: "visible" });
        $("#FullStar3").css({ visibility: "visible" });
        $("#FullStar4").css({ visibility: "visible" });
        $("#FullStar5").css({ visibility: "visible" });

        $("#HalfStar1").css({ visibility: "hidden" });
        $("#HalfStar2").css({ visibility: "hidden" });
        $("#HalfStar3").css({ visibility: "hidden" });
        $("#HalfStar4").css({ visibility: "hidden" });
        $("#HalfStar5").css({ visibility: "hidden" });
    }
}