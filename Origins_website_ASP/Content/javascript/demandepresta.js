/* alert("Ce formulaire utilise du javascript"); */

/* Choix structure */
document.getElementById('Structure_Type').addEventListener('change', function() {
    var select = document.getElementById('Structure_Type');

	if (select.options[select.selectedIndex].value == 'Particulier') {
		document.getElementsByClassName('elemstruc')[1].style.display = "none";
        document.getElementById('Structure_NomStructure').removeAttribute('required');
	}
	else {
		document.getElementsByClassName('elemstruc')[1].style.display = "block";
        document.getElementById('Structure_NomStructure').required = "required";
	}

});

/* Choix du pays */
document.getElementById('Structure_Pays').addEventListener('change', function() {
	var choixfrance = document.getElementById('paysfrance');
	var choixeu = document.getElementById('payseu');
	var choixautre = document.getElementById('paysautre');
	var select = document.getElementById('Structure_Pays');

	var codepostal = document.getElementById('Structure_CodePostal');
	var etat = document.getElementById('Structure_Etat');
	var villeeu = document.getElementById('Structure_VilleEU');
	var villeautre = document.getElementById('Structure_VilleAutre');

	if (select.options[select.selectedIndex].value == 'France') {
		choixfrance.style.display = "block";
		choixeu.style.display = "none";
		choixautre.style.display = "none";
		codepostal.required = "required";
		etat.removeAttribute("required");
		villeeu.removeAttribute("required");
		villeautre.removeAttribute("required");
	}
	else if (select.options[select.selectedIndex].value == 'EtatsUnis') {
		choixfrance.style.display = "none";
		choixeu.style.display = "flex";
		choixautre.style.display = "none";
		etat.required = "required";
		villeeu.required = "required";
		codepostal.removeAttribute("required");
		villeautre.removeAttribute("required");
	}
	else {
		choixfrance.style.display = "none";
		choixeu.style.display = "none";
		choixautre.style.display = "block";
		villeautre.required = "required";
		codepostal.removeAttribute("required");
		villeeu.removeAttribute("required");
		etat.removeAttribute("required");
	}
});

/* Choix de la prestation */
var choixrep = document.getElementById('choixrepresentation');
var choixst = document.getElementById('choixstage'); 
var datestage = document.getElementById('datestage');

document.getElementById('representation').onclick = function() {
	choixrep.style.display = "flex";
	choixst.style.display = "none";
	datestage.removeAttribute("required");
};
document.getElementById('stage').onclick = function() {
	choixrep.style.display = "none";
	choixst.style.display = "flex";
	datestage.required = "required";
};
document.getElementById('cours').onclick = function() {
	choixrep.style.display = "none";
	choixst.style.display = "none";
	datestage.removeAttribute("required");
};


var boutonvalider = document.getElementById('valider');
boutonvalider.disabled = "disabled";

/* Variable nécessaire à l'activation du bouton valider */
var nomvalide = false;
var prenomvalide = false;
var mailvalide = false;
var telvalide = false;
var cpvalide = false;
var cguvalide = false;

/* validation nom */
document.getElementById("Identite_Nom").addEventListener('input', function (e) {
    var champnom = document.getElementById("Identite_Nom");
    var erreurNom = document.getElementById("nomIncorrect");
    if (e.target.value.trim() == '') {
        champnom.style.borderColor = "red";
        erreurNom.innerHTML = "Nom incorrect !";
        nomvalide = false;
    }
    else {
        champnom.style.borderColor = "lightgrey";
        erreurNom.innerHTML = "";
        nomvalide = true;
    }
});

/* validation prenom */
document.getElementById("Identite_Prenom").addEventListener('input', function (e) {
    var champprenom = document.getElementById("Identite_Prenom");
    var erreurPrenom = document.getElementById("prenomIncorrect");
    if (e.target.value.trim() == '') {
        champprenom.style.borderColor = "red";
        erreurPrenom.innerHTML = "Prénom incorrect !";
        prenomvalide = false;
    }
    else {
        champprenom.style.borderColor = "lightgrey";
        erreurPrenom.innerHTML = "";
        prenomvalide = true;
    }
});

/* validation de l'email */
document.getElementById('Identite_Email').addEventListener('input', function(e) {
    var champmail = document.getElementById('Identite_Email');
    var erreurMail = document.getElementById('emailIncorrect');
	var regexMail = /.+@.+\..+/;
	if (regexMail.test(e.target.value)) {
        champmail.style.borderColor = "lightgrey";
        erreurMail.innerHTML = "";
		mailvalide = true;
	}
	else {
        champmail.style.borderColor = "red";
        erreurMail.innerHTML = "Email incorrect !";
		mailvalide = false;
	}
});

/* Validation du numéro de téléphone */
document.getElementById('Identite_Telephone').addEventListener('input', function(e) {
    var champtel = document.getElementById('Identite_Telephone');
    var erreurTel = document.getElementById("telephoneIncorrect");
    ///^0[1-68]([\.|\-|\s]*[0-9]{2}){4}$/
    var regexTel = new RegExp(/^(\+\d+(\s|-))?0\d(\s|-)?(\d{2}(\s|-)?){4}$/);
	if(regexTel.test(e.target.value)) {
        champtel.style.borderColor = "lightgrey";
        erreurTel.innerHTML = "";
		telvalide = true;
	}
	else {
        champtel.style.borderColor = "red";
        erreurTel.innerHTML = "Téléphone incorrect !";
		telvalide = false;
	}
});

/* Validation code postal */
document.getElementById('Structure_CodePostal').addEventListener('input', function(e) {
    var champcp = document.getElementById('Structure_CodePostal');
    var erreurCp = document.getElementById('cpIncorrect');
	var regexCp = new RegExp(/^(([0-8][0-9])|(9[0-5]))[0-9]{3}$/);
	if (regexCp.test(e.target.value)) {
        champcp.style.borderColor = "lightgrey";
        erreurCp.innerHTML = "";
		cpvalide = true;
	}
	else {
        champcp.style.borderColor = "red";
        erreurCp.innerHTML = "Code postal incorrect !";
		cpvalide = false;
	}
});

/* Validation CGU */
document.getElementById('valideCgu').addEventListener('change', function (e) {
    if (e.target.checked == true)
        cguAccept = true;
    else 
        cguAccept = false;
});


/* Actvation du bouton valider */
function afficherBouton () {
    var select = document.getElementById('Structure_Pays');
    if (prenomvalide && nomvalide && mailvalide && telvalide && cguvalide) {
        if ((select.options[select.selectedIndex].value == 'France') && cpvalide) {
            boutonvalider.disabled = "";
        }
        else {
            boutonvalider.disabled = "disabled";
        }
    }
	else {
		boutonvalider.disabled = "disabled";
	}
	setTimeout('afficherBouton()', 500);
}

window.onload = function () {
    afficherBouton();
    document.getElementById('Choix_Date').value = "2019-01-01";
}

