
function clickCircPassions(val) {

    var Passions = document.getElementById("feelGood.Passions").value;

    Passions = appendArray(Passions, val);

    document.getElementById("feelGood.Passions").value = Passions;
}

function clickCircTalents(val) {
    var Talents = document.getElementById("feelGood.Talents").value;

    Talents = appendArray(Talents, val);

    document.getElementById("feelGood.Talents").value = Talents;
}

function clickCircKnowledge(val) {
    var Knowledge = document.getElementById("feelGood.Knowledge").value;

    Knowledge = appendArray(Knowledge, val);

    document.getElementById("feelGood.Knowledge").value = Knowledge;
}

function clickCircPeople(val) {
    var People = document.getElementById("doGood.People").value;

    People = appendArray(People, val);

    document.getElementById("doGood.People").value = People;
}

function clickCircPlanet(val) {
    var Planet = document.getElementById("doGood.Planet").value;

    Planet = appendArray(Planet, val);

    document.getElementById("doGood.Planet").value = Planet;
}

function clickCircProsperity(val) {
    var Prosperity = document.getElementById("doGood.Prosperity").value;

    Prosperity = appendArray(Prosperity, val);

    document.getElementById("doGood.Prosperity").value = Prosperity;
}

function clickCircAction(val) {
    var Action = document.getElementById("beGood.Action").value;

    Action = appendArray(Action, val);

    document.getElementById("beGood.Action").value = Action;
}

function clickBeGoodPassions(val) {
    var BeGoodPassions = document.getElementById("beGood.Passions").value;

    BeGoodPassions = appendArray(BeGoodPassions, val);

    document.getElementById("beGood.Passions").BeGoodPassions = BeGoodPassions;
}

function clickCircBeGoodKnowledge(val) {
    var Knowledge = document.getElementById("beGood.Knowledge").value;

    Knowledge = appendArray(Knowledge, val);

    document.getElementById("beGood.Knowledge").value = Knowledge;
}

function appendArray(array, val) {

    if (array === undefined || array.length == 0) {
        array = val;
    }
    else {
        /*Already added - remove it

        if (Passions.indexOf(val) > -1) {
            Passions.splice(array.indexOf(val), 1);
        }
        //not added - add it
        else {
            Passions.join(',')
            Passions.push(val);
            }*/

        array = array + "," + val;
    }

    return array;

    console.log(array);
}
