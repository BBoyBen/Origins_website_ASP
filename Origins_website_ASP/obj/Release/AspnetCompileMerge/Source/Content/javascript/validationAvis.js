var nomCorrect = false;
var opinionCorrect = false;
var cguAccept = false;

document.getElementById('nom').addEventListener('input', function (e) {
    var erreur = document.getElementById("nomIncorrect");
    if (e.target.value.trim() == '') {
        erreur.style.display = "block";
        nomCorrect = false;
        document.getElementById('poster').disabled = "disabled";
    }
    else {
        erreur.style.display = "none";
        nomCorrect = true;
        if (nomCorrect && opinionCorrect && cguAccept)
            document.getElementById('poster').disabled = "";
    }
});

document.getElementById('opinion').addEventListener('input', function (e) {
    var erreur = document.getElementById("desIncorrect");
    if (e.target.value.trim() == '') {
        erreur.style.display = "block";
        opinionCorrect = false;
        document.getElementById('poster').disabled = "disabled";
    }
    else {
        erreur.style.display = "none";
        opinionCorrect = true;
        if (nomCorrect && opinionCorrect && cguAccept)
            document.getElementById('poster').disabled = "";
    }
});

document.getElementById('valideCgu').addEventListener('change', function (e) {
    if (e.target.checked == true) {
        cguAccept = true;
        if (cguAccept && opinionCorrect && nomCorrect)
            document.getElementById('poster').disabled = "";
    }
    else {
        cguAccept = false;
        document.getElementById('poster').disabled = "disabled";
    }
});