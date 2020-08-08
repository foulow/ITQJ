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


$(document).ready(() => {
    document.getElementById('Lname').style.display = 'none';
    document.getElementById('Tname').style.display = 'none';
    document.getElementById('Lemail').style.display = 'none';
    document.getElementById('Temail').style.display = 'none';
    document.getElementById('Lnumero').style.display = 'none';
    document.getElementById('Tnumero').style.display = 'none';
    document.getElementById('Lling').style.display = 'none';
    document.getElementById('Tling').style.display = 'none';
    document.getElementById('Ldescripcion').style.display = 'none';
    document.getElementById('Tdescripcion').style.display = 'none';
    document.getElementById('bntGuardar').style.display = 'none';
    document.getElementById('bntCancelar').style.display = 'none';

});


function Cancelar()
{

    document.getElementById('Lname').style.display = 'none';
    document.getElementById('Tname').style.display = 'none';
    document.getElementById('Lemail').style.display = 'none';
    document.getElementById('Temail').style.display = 'none';
    document.getElementById('Lnumero').style.display = 'none';
    document.getElementById('Tnumero').style.display = 'none';
    document.getElementById('Lling').style.display = 'none';
    document.getElementById('Tling').style.display = 'none';
    document.getElementById('Ldescripcion').style.display = 'none';
    document.getElementById('Tdescripcion').style.display = 'none';
    document.getElementById('bntGuardar').style.display = 'none';
    document.getElementById('bntCancelar').style.display = 'none';

    document.getElementById('Mname').style.display = 'block';
    document.getElementById('Memail').style.display = 'block';
    document.getElementById('Mnumero').style.display = 'block';
    document.getElementById('Mling').style.display = 'block';
    document.getElementById('Mdescripcion').style.display = 'block';
    document.getElementById('bntEditar').style.display = 'block';
    

}

function Edit()
    {

    document.getElementById('Lname').style.display = 'inline';
    document.getElementById('Tname').style.display = 'inline';
    document.getElementById('Lemail').style.display = 'inline';
    document.getElementById('Temail').style.display = 'inline';
    document.getElementById('Lnumero').style.display = 'inline';
    document.getElementById('Tnumero').style.display = 'inline';
    document.getElementById('Lling').style.display = 'inline';
    document.getElementById('Tling').style.display = 'inline';
    document.getElementById('Ldescripcion').style.display = 'inline';
    document.getElementById('Tdescripcion').style.display = 'inline';
    document.getElementById('bntGuardar').style.display = 'inline';
    document.getElementById('bntCancelar').style.display = 'inline';

    document.getElementById('Mname').style.display = 'none';
    document.getElementById('Memail').style.display = 'none';
    document.getElementById('Mnumero').style.display = 'none';
    document.getElementById('Mling').style.display = 'none';
    document.getElementById('Mdescripcion').style.display = 'none';
    document.getElementById('bntEditar').style.display = 'none';
}