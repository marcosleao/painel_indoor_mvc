// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function testeApi() {

    var url = 'https://graph.microsoft.com/v1.0/me/sendMail'

    var login = {
        userName: "marcos.leao",
        password: "@"
    };


    //var url = 'https://apisgt.cni.org.br:8253/integrations/v3.0.0/categoriaProdutos';

    //var token = 'fd40eed0-3bb3-35f2-839e-d8d58a5cae36';

    var token = 'EwCIA8l6BAAUO9chh8cJscQLmU+LSWpbnr0vmwwAAQ83mUYc43ElGm5h3eU7caMpfsm4jTNUeBqJIuGzMFlJ2S7aOTsLBzF2JkmzhNdsnfJOg7yBlDZINnz+ty0xxPFwvQvxzsPD9mJ9gkZ0bY//BPXetGStntsCjTM+9B1bYVOywrq8dW3iO2lHFet0j4zRH4pENKq2kU+k3LteRIl6LDuC2XupAJHa4G6VK5bQJ+86qsROfMj78gn4hjS6J5NxurfTUwBVUkVIdPpmUbM2WUCT8GkO6GkrkXhrYE6zDA2fFdZoSnquD8CowilYj5aDOwv35aUoYcex0edbNrXUqxd3p5pEpRmk7b/QNQJgi2MoSXy89qLOJyzs1Swl5ZcDZgAACAT478n5xCrrWALgU3AbdaNm/rfdJJI8+U6E+ah+VabO77OYjlFtLq2b7jfHRVwCa/Gp5s0LrZfuNuwSL4mpneNnYa/5IpWgpw/85tVjNEkp67IsBjlB2KB8QpBA+kW0Mn/bOoF2vrNCKCCi0Dr+xLladk3Jdob1aCaw+vR9yNe9dLcdFmTyClQ/wSCA1rpFZ8RvlSh0hhsu1CpY1qrYzXiQ2j3yn7yEzKHIohnLFqIszriP3BomEcMOcuaAiWcrgxn5Vu4/H7d6MAu0HYpAFuePpL0cT/WkTwClIWTJHBMFmTeOhMyOScpL8Uhb91wqGNPnsewMB9f/eaJIgAe3q3O0mTY+2dIkhHg7xnhsJHY+b37pfOBAV2TX2Vziwa1RgdWU6sYJvzfOc3KqJ8UOT/K1Zc+tyS2kEg/H55iyv8uoF8gA+AkgiJ6APxW3/DeLEqP70SZSuy3ni4AQxTomff48A2gOvxHmO0aTx6B/+bblvrTgC7a6+Cn4bfAtiix6WlKlRpnGfnuOK1FUpUoOBV25js0d+A7Fn2kYwVRS35XmuHVSU6sLjm3Fm8o5lFDLd3pY53cUk9KHfStNeAwIQ+ixf2dML7UoMoKKgllC4J24GB1WXMtswGhHy96ha7cvbsIE5UgiPEVvh6DumxoGJhqJhAmDzUMn6lJRE1GJLv0LgoOIbEDmkWar12IrIrtjwlBrNJQ7IYT50IHHcfaQ/gXc8c7bXrFgEeYITZe7BQ0HRPw5us7363vpx+DimkcpRqzSBU9j2cXrAac2tC/37JDQpjUd3BUwxKMi1ktIgW18re6SAg==';

    var mailBody = {
        message: {
            subject: "Meet for lunch?",
            body: {
                contentType: "Text",
                content: "The new cafeteria is open."
            },
            toRecipients: [
                {
                    emailAddress: {
                        address: "marcos.leao@sesisenaimt.ind.br"
                    }
                }
            ]
        }
    };

    var request = new XMLHttpRequest();

    request.open("POST", url, true);

    //request.open("GET", url, true);

    //request.setRequestHeader("Authorization", "Bearer " + token);

    //request.setRequestHeader("cache-control", "private");

    //request.setRequestHeader("client-request-id", "3ed9341c-4657-d6c7-fcd0-bf5b873b1e4a");

   // request.setRequestHeader("content-length", "356");

    request.setRequestHeader("content-type", "application/json");

    //request.setRequestHeader("request-id", "f997b1b8-0d3f-4418-922b-2259ee8ef1a5");

    request.setRequestHeader("Authorization", token);

    request.setRequestHeader("Body", mailBody);

    request.send();

    request.onreadystatechange = function () {

        if (request.readyState == 4 && request.status == 200) {

            var response = JSON.parse(request.responseText);

            console.log(response);
            // handle data as needed... 

        }
    }
}

//e=> valor base (checked ou não)
//l=> lista de elementos a serem marcados
function selecionarTudo(e, l) {

    var itens = document.querySelectorAll('input[name="' + l + '"]');

    for (var i = 0; i < itens.length; i++) {

        itens[i].checked = e.checked;
    }
}

function msgErro(message) {

    new PNotify({

        title: 'Erro!',

        text: message,

        type: 'error',

        styling: 'bootstrap3'

    });
}

function msgSucesso(message) {

    new PNotify({

        title: 'Ok!',

        text: message,

        type: 'success',

        styling: 'bootstrap3'

    });
}
