"use strict";

//var connection = new signalR.HubConnectionBuilder().withUrl("http://10.52.29.236:8082/ComandosRemotos").build();
//É necessário habilitar no IIS o Protocolo WebSocket
const connection = new signalR.HubConnectionBuilder()
    .withUrl("../ComandosRemotos")
    .configureLogging(signalR.LogLevel.Information)
    .build();


document.getElementById("playVideo").disabled = true;
document.getElementById("reloadPage").disabled = true;

// Inject YouTube API script
var tag = document.createElement('script');

//tag.src = "https://www.youtube.com/iframe_api";

tag.src = "//www.youtube.com/player_api";

var firstScriptTag = document.getElementsByTagName('script')[0];

firstScriptTag.parentNode.insertBefore(tag, firstScriptTag);

var player;
//Chama a função de play do video
connection.on("Play", function () {


    // create the global player from the specific iframe (#video)
    player = new YT.Player('videoYouTube', {
        //height: '360',
        //width: '640',
        //videoId: 'gqUxxo28Fmo',
        events: {

            // call this function when player is ready to use
            'onReady': onPlayerReady,
            'onStateChange': onPlayerStateChange
        }
    });
});
//Inicia o play do video
function onPlayerReady(event) {

    event.target.playVideo();
}


function volumeVideo(vlm) {

    player.setVolume(vlm);

}

//Chama a função Reload
connection.on("Reload", function () {

    window.location.reload();

});

connection.start().then(function () {

    console.log("SignalR Connected.");

    document.getElementById("playVideo").disabled = false;

    document.getElementById("reloadPage").disabled = false;

}).catch(function (err) {

    return console.error(err.toString());

});

//Ao clicar no item
document.getElementById("playVideo").addEventListener("click", function (event) {

    connection.invoke("PlayYouTubeVideo").catch(function (err) {

        return console.error(err.toString());

    });

    event.preventDefault();
});

//Ao alterar no item
document.getElementById("volumeYTVideo").addEventListener("change", function (event) {

    connection.invoke("volumeYTVideo").catch(function (err) {

        return console.error(err.toString());

    });

    event.preventDefault();
});


//Ao clicar no item
document.getElementById("reloadPage").addEventListener("click", function (event) {

    connection.invoke("ReloadPage").catch(function (err) {

        return console.error(err.toString());

    });

    event.preventDefault();
});