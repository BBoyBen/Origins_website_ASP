document.getElementById('VersionEn').addEventListener('change', function() {
	var anglais = document.getElementById('VersionEn');
	var elemangl = document.getElementsByClassName('versionangl');

	if (anglais.checked) {
		elemangl[0].style.display = "block";
		elemangl[1].style.display = "block";
	}
	else {
		elemangl[0].style.display = "none";
		elemangl[1].style.display = "none";
	}
});

var anglais = document.getElementById('VersionEn');

var numdimage = 0;
function ajouteruneimage () {
	var formimage = document.getElementById('ajoutimage');
    

	var labelimage = '<div class="elemajoutimage"><label for="fichierimage'+numdimage+'"> Choisir une image (env 650x500px)</label>';
	var inputimage = '<input type="file" name="fichierimage'+numdimage+'" id="fichierimage'+numdimage+'" required /><br/>';
	var labelalt = '<label for="altimage'+numdimage+'"> Texte alternatif: </label>';
	var inputalt = '<input type="text" name="altimage'+numdimage+'" id="altimage'+numdimage+'" required />';
	var labelaltangl = '<label for="altimageangl'+numdimage+'"> Texte alternatif anglais: </label>';
	var inputaltangl = '<input type="text" name="altimageangl'+numdimage+'" id="altimageangl'+numdimage+'" required />';
	numdimage++;

	if (anglais.checked)
		formimage.innerHTML += labelimage.concat(inputimage).concat(labelalt).concat(inputalt).concat(labelaltangl).concat(inputaltangl).concat("</div>");
	else
		formimage.innerHTML += labelimage.concat(inputimage).concat(labelalt).concat(inputalt).concat("</div>");

    document.getElementById('NombrePhoto').value = numdimage;
}

var numdevideo = 0;
function ajouterunevideo () {
	var formvideo = document.getElementById('ajoutvideo');

	var choixvimeo = '<div class="elemajoutvideo">Plateforme: <input type="radio" name="plat'+numdevideo+'" value="vimeo" id="vimeo'+numdevideo+'" checked /><label for="vimeo'+numdevideo+'"> Viméo </label>';
	var choixyt = '<input type="radio" name="plat'+numdevideo+'" value="youtube" id="youtube'+numdevideo+'" /><label for="youtube'+numdevideo+'"> YouTube </label><br/>';
	var lien = '<label for="lienvideo'+numdevideo+'"> Lien de la vidéo: </label><input type="text" name="lienvideo'+numdevideo+'" id="lienvideo'+numdevideo+'" required /></div>';
	numdevideo++;

    formvideo.innerHTML += choixvimeo.concat(choixyt).concat(lien);
    document.getElementById('NombreVideo').value = numdevideo;
}

var numdelien = 0;
function ajouterunlien () {
	var formlien = document.getElementById('ajoutlien');

	var textelien = '<div class="elemajoutlien"><label for="textelien'+numdelien+'">Texte du lien: </label><input type="text" name="textelien'+numdelien+'" id="textelien'+numdelien+'" required /><br/>';
	var textelienangl = '<label for="textelienangl'+numdelien+'">Texte du lien anglais: </label><input type="text" name="textelienangl'+numdelien+'" id="textelienangl'+numdelien+'" required /><br/>';
	var lien = '<label for="lienlien'+numdelien+'"> Lien: </label><input type="text" name="lienlien'+numdelien+'" id="lienlien'+numdelien+'" required /></div>';
	numdelien++;

	if (anglais.checked)
		formlien.innerHTML += textelien.concat(textelienangl).concat(lien);
	else
        formlien.innerHTML += textelien.concat(lien);
    document.getElementById('NombreLien').value = numdelien;
}