function setReadableCode() {
    var circLabel = document.getElementById('circLabel');
    var circTicket = document.getElementById('circTicket');
    var circVecto = document.getElementById('circVecto');
    var interLabelTicket = document.getElementById('interLabelTicket');
    var interTicketVecto = document.getElementById('interTicketVecto');
    var interVectoLabel = document.getElementById('interVectoLabel');
    var interLabelTicketVecto = document.getElementById('interLabelTicketVecto');
}

function clickCircle(sCircle, category) {
    var circ = document.getElementById(sCircle);
    var category = document.getElementById(category);
    var inter2b = document.getElementById(sInter2b);
    var inter3 = document.getElementById(sInter3);

    var sColor = '';

    if (category == 'skills' && sCircle = 'circPeople') {
        document.getElementById("")
    }
    else {
        sColor = 'white';
    }

    circ.style.fill = sColor;
    inter2a.style.fill = sColor;
    inter2b.style.fill = sColor;
    inter3.style.fill = sColor;

    setReadableCode();
}

function clickCircPeople() {
    clickCircle('circPeople', 'skills');
}

function clickCircInnovation() {
    clickCircle('circInnovation', 'skills');
}

function clickCircLearning() {
    clickCircle('circLearning', 'passions');
}

function clickCircTravel() {
    clickCircle('circTravel', 'passions');
}

function clickCircSport() {
    clickCircle('circSport', 'passions');
}

function clickCircMusic() {
    clickCircle('circMusic', 'passions');
}


function clickIntersection2(sInter2, sInter3) {
    var inter2 = document.getElementById(sInter2);
    var inter3 = document.getElementById(sInter3);
    var sColor = '';

    if (inter2.style.fill == '' || inter2.style.fill == 'white') {
        sColor = 'yellow';
    }
    else {
        sColor = 'white';
    }

    inter2.style.fill = sColor;
    inter3.style.fill = sColor;

    setReadableCode();
}

function clickInterLabelTicket() {
    clickIntersection2('interLabelTicket', 'interLabelTicketVecto');
}

function clickInterTicketVecto() {
    clickIntersection2('interTicketVecto', 'interLabelTicketVecto');
}

function clickInterVectoLabel() {
    clickIntersection2('interVectoLabel', 'interLabelTicketVecto');
}

function clickInterLabelTicketVecto() {
    var inter = document.getElementById('interLabelTicketVecto');
    var sColor = '';

    if (inter.style.fill == '' || inter.style.fill == 'white') {
        sColor = 'yellow';
    }
    else {
        sColor = 'white';
    }

    inter.style.fill = sColor;
    setReadableCode();
}
