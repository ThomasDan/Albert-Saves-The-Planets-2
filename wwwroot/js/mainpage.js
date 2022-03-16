var vid = document.getElementById("video");
vid.playbackRate = 1;

document.getElementById("myButton").onclick = function() {
    location.href = "../prestory/prestory.html";
}

var nem = false;

function play() {
    var audio = document.getElementById("audio");
    if (nem) {
        audio.pause();
        nem = false;
    } else {
        audio.loop = true;
        audio.play();
        nem = true;
    }
}