var n = 0;
var list = document.getElementsByClassName("membre");

function suivante () {
	var nmax = list.length;
	list[n].style.display = "none";
	if (n == nmax-1) {
		list[0].style.display = "block";
		n = 0;
	}
	else {
		list[n+1].style.display = "block";
		n++;
	}
}

function precedente () {
	var nmax = list.length;
	list[n].style.display = "none";
	if (n == 0) {
		list[nmax-1].style.display = "block";
		n = nmax-1;
	}
	else {
		list[n-1].style.display = "block";
		n--;
	}
}
