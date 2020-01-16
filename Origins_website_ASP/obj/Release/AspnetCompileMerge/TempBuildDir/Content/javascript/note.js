


var done = false;

var star = new Array();
star[0] = new Image();
star[0].src = "/Content/image/star0.png";
star[1] = new Image();
star[1].src = "/Content/image/star1.png";

function noter (level) {
	if (done) {
		return false;
	}

	for (var i=1; i<6; i++) {
		document.getElementById('_'+i).src = (level<i)?star[0].src:star[1].src; 
	}

	document.getElementById('rate').value = level;
}

function valider (level) {
	done = true;
	document.getElementById('rate').value = level;
}

function zero () {
	done = false;
	for (var i=1; i<6; i++) {
		document.getElementById('_'+i).src = star[0].src; 
	}
}

/* fonction pour le texte area */

function enleve () {
	var texte = document.getElementById('opinion');

    if (texte.innerHTML == "Votre avis...") {
        texte.innerHTML = "";
	}
}

function remets () {
	var texte = document.getElementById('opinion');

    if (texte.innerHTML == "") {
        texte.innerHTML = "Votre avis...";
	}
}

function enleveen() {
    var texte = document.getElementById('opinion');

    if (texte.innerHTML == "Your opinion...") {
        texte.innerHTML = "";
    }
}

function remetsen() {
    var texte = document.getElementById('opinion');

    if (texte.innerHTML == "") {
        texte.innerHTML = "Your opinion...";
    }
}


function afficheform () {
	var form = document.getElementById('formavis');
	form.style.display = "block";
}

