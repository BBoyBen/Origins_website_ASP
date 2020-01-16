
function afficherToutesLesActus () {
	var actus = document.getElementsByClassName('actualite');
	for (var i=0; i<actus.length; i++) {
		actus[i].style.display = 'block';
	}
	document.getElementById('pasactus').style.display = "none";
}

function cacherToutesLesActus () {
	var actus = document.getElementsByClassName('actualite');
	for (var i=0; i<actus.length; i++) {
		actus[i].style.display = 'none';
	}
	document.getElementById('pasactus').style.display = 'block';
}

function affichActusParClass (classe) {
	var actus = document.getElementsByClassName(classe);
	cacherToutesLesActus();
	if (actus.length > 0) {
		for (var i=0; i<actus.length; i++) {
			actus[i].style.display = 'block';
		}
		document.getElementById('pasactus').style.display = 'none';
	}
}

/* Choix de comment on veux afficher les actualités */

document.getElementById('choixafficher').addEventListener('change', function() {
	var select = document.getElementById('choixafficher');
	var choixtype = document.getElementsByClassName('affichactus')[1];
	var datedebut = document.getElementsByClassName('affichactus')[2];

	switch(select.options[select.selectedIndex].value) {
		case 'tout':
			choixtype.style.display = 'none';
			datedebut.style.display = 'none';
			afficherToutesLesActus();
			break;
		case 'type':
			choixtype.style.display = 'block';
			datedebut.style.display = 'none';
			affichActusParClass(document.getElementById('choixtype').options[document.getElementById('choixtype').selectedIndex].value);
			break;
		case 'date':
			choixtype.style.display = 'none';
			datedebut.style.display = 'block';
			break;
		default:
			choixtype.style.display = 'none';
			datedebut.style.display = 'none';
			afficherToutesLesActus();
			break;
	}
});

/* choix du type dactu */

document.getElementById('choixtype').addEventListener('change', function() {
	var select = document.getElementById('choixtype');

	switch(select.options[select.selectedIndex].value) {
		case 'spectacle':
			affichActusParClass('spectacle');
			break;
		case 'video':
			affichActusParClass('video');
			break;
		case 'evenement':
			affichActusParClass('evenement');
			break;
		case 'cours':
			affichActusParClass('cours');
			break;
		case 'autre':
			affichActusParClass('autre');
			break;
		default:
			afficherToutesLesActus();
			break;
	}
});


/* afficher les actus depuis un date */

document.getElementById('datedebut').addEventListener('change', function() {
	var datelimite = document.getElementById('datedebut').valueAsDate;
	var listeactus = document.getElementsByClassName('actualite');
	var listedate = document.getElementsByClassName('dateactu');

	if (datelimite == null) {
		afficherToutesLesActus();
	}

	var nbractusaffich = 0;

	console.log(datelimite.getDate());
	console.log(datelimite.getMonth());
	console.log(datelimite.getFullYear());

	cacherToutesLesActus();
	var annee, mois, jour, date;
	for (var i=0; i<listeactus.length; i++) {
		annee = listedate[i].dataset.annee;
		mois = listedate[i].dataset.mois;
		jour = listedate[i].dataset.jour;
		date = new Date(annee,mois,jour);

		if (datelimite.getFullYear() < date.getFullYear()) {
			listeactus[i].style.display = 'block';
			nbractusaffich++;
		}
		else if (datelimite.getFullYear()==date.getFullYear() && datelimite.getMonth()+1<date.getMonth()) {
			listeactus[i].style.display = 'block';
			nbractusaffich++;
		}
		else if (datelimite.getFullYear()==date.getFullYear() && datelimite.getMonth()+1==date.getMonth() && datelimite.getDate()<=date.getDate()) {
			listeactus[i].style.display = 'block';
			nbractusaffich++;
		}
	}
	if (nbractusaffich != 0) {
		document.getElementById('pasactus').style.display = 'none';
	}
});
