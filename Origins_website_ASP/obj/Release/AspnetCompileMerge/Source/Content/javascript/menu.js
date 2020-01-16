var afficher = 0;

function afficherMenu () {
	var menu = document.getElementById('menu');
	var lignehaut = document.getElementById('lignehaut');
	var lignemilieu = document.getElementById('lignemilieu');
	var lignebas = document.getElementById('lignebas');

	if (afficher == 0) {
		menu.style.display = 'block';
		lignehaut.style.transform = 'rotateZ(45deg)';
		lignemilieu.style.visibility = 'hidden';
		lignebas.style.transform = 'rotateZ(-45deg)';
		afficher = 1;
	}
	else {
		menu.style.display = 'none';
		lignehaut.style.transform = 'rotateZ(0)';
		lignemilieu.style.visibility = 'visible';
		lignebas.style.transform = 'rotateZ(0)';
		afficher = 0;
	}
}