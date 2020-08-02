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

function ProjectDown(proId) {
    $("#" + proId).css({
        boxShadow: "0px 0px 0px transparent"
    });
}
