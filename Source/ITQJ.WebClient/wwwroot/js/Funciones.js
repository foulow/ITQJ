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

function MaxPostulant(CheckClose, MaxPas)
{
    debugger;
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
