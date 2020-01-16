var nomCorrect = false;
var opinionCorrect = false;
var cguAccept = false;

document.getElementById('nom').addEventListener('input', function (e) {
    var erreur = document.getElementById("nomIncorrect");
    if (e.target.value.trim() == '') {
        erreur.innerHTML = "   Incorrect name";
        document.getElementById('poster').disabled = "disabled";
    }
    else {
        erreur.innerHTML = "";
        document.getElementById('poster').disabled = "";
    }
});

document.getElementById('opinion').addEventListener('input', function (e) {
    var erreur = document.getElementById("desIncorrect");
    if (e.target.value.trim() == '') {
        erreur.innerHTML = "   Thanks to let a little word.";
        document.getElementById('poster').disabled = "disabled";
    }
    else {
        erreur.innerHTML = "";
        document.getElementById('poster').disabled = "";
    }
});