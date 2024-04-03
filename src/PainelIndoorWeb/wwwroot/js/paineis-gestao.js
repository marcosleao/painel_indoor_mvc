"use strict";

async function pesquisarMonitores(page, registro) {

    const url = '../paineis/inicio';
    //inicia a batta de progresso
    NProgress.start();
    //captura o formulário
    const formulario = document.getElementById('frm-pesquisa');
    //cria novo objeto
    const formData = new FormData(formulario);

    //se for filtro de registro específico, acrescenta os dados do mesmo ao formulário de pesquisa
    //esse item é utilizado para filtrar um item em tela assim que ele é cadastrado
    const filtro = {
        id: registro?.id,
        paginaAtual: page
    };

    if (registro != null) {
        formData.append(filtro);
    }

    //chamo a action que retornará a partialView (visão parcial de dados)
    fetch(url, {
        method: 'POST',
        body: formData
    })
        .then(response => {
            if (!response.ok) {
                throw new Error('Erro ao carregar a PartialView');
            }
            return response.text();
        })
        .then(data => {
            // Inserir a PartialView na div com o id 'minhaPartialDiv'
            document.getElementById("lista-monitores").innerHTML = data;
        })
        .catch(error => {
            console.error('Erro:', error);
        });

    NProgress.done();

}

async function obterMonitorPorId(id, page) {

    const url = '../paineis/painel-por-id';
    NProgress.start();
    var form = document.getElementById("frm-alterar-monitor");

    const filtro = {
        id: id,
        pagina: page
    };

    const queryString = new URLSearchParams(filtro).toString();

    try {

        const response = await fetch(`${url}?${queryString}`, {
            method: 'GET'
        });

        if (!response.ok) {
            msgErro("");
        }

        const responseData = await response.json();

        form.Id.value = responseData.monitor.id;
        form.Descricao.value = responseData.monitor.descricao;
        //form.CodFilial.value = responseData.monitor.codFilial;
        //form.TipoConteudo.value = responseData.monitor.tipoConteudo;
        form.Pagina.value = responseData.page;
        form.IsEnabled[0].checked = responseData.monitor.isEnabled;
        NProgress.done();
        $("#alterar-monitor").modal("show");

    } catch (error) {
        console.error('Erro:', error);
    }
}

function alterarMonitor() {

    //Chamar a validação JQuery para validação 'client side'
    var validator = $("#frm-alterar-monitor").validate().form();

    //Se inválido, encerra a função
    if (!validator)
        return null;

    //Capturo o formulário + seus elementos
    const objForm = document.forms["frm-alterar-monitor"];

    var monitor = new FormData(objForm);

    //var url = '../monitores/alterar-monitor';

    $('#alterar-monitor').modal('hide');

    NProgress.start();

    var xhttp = new XMLHttpRequest();

    xhttp.onreadystatechange = function () {

        if (xhttp.readyState == XMLHttpRequest.DONE) {

            NProgress.done();

            var result = JSON.parse(xhttp.responseText);

            if (xhttp.status == 200) {

                //Atualiza a lista 
                pesquisarMonitores(objForm.Pagina.value, result);

            }
            else if (xhttp.status == 400) {

                msgErro(result.mensagem);

            } else {

                console.log(xhttp);
            }
        }
    };

    xhttp.open('POST', objForm.action, true);

    //Passo o Token de validação da requisição
    xhttp.setRequestHeader("X-CSRF-TOKEN", objForm.__RequestVerificationToken.value);

    xhttp.send(monitor);

}

async function adicionarConteudoMonitor() {

    //Chamar a validação JQuery para validação 'client side'
    var validator = $("#frm-adicionar-conteudo").validate().form();

    //Se inválido, encerra a função
    if (!validator)
        return null;

    //Capturo o formulário + seus elementos
    const objForm = document.getElementById("frm-adicionar-conteudo");

    //var url = '../monitores/adicionar-conteudo';

    $('#adicionar-conteudo').modal('hide');

    NProgress.start();

    const conteudo = new FormData(objForm);

    console.log(conteudo);

    var xhttp = new XMLHttpRequest();

    xhttp.onreadystatechange = function () {

        if (xhttp.readyState == XMLHttpRequest.DONE) {

            NProgress.done();

            var result = JSON.parse(xhttp.responseText);

            if (xhttp.status == 200) {

                //Atualiza a lista 
                msgSucesso(result.mensagem);

                window.location.reload();

            }
            else if (xhttp.status == 400) {

                msgErro(result.mensagem);

            } else {

                console.log(xhttp);
            }
        }
    };

    xhttp.open('POST', objForm.action);

    //Passo o Token de validação da requisição
    xhttp.setRequestHeader("X-CSRF-TOKEN", objForm.__RequestVerificationToken.value);

    xhttp.send(conteudo);

}

function obterConteudoPorId(id) {

    var form = document.getElementById("frm-alterar-conteudo");

    var url = "../paineis/conteudo-por-id";

    var parametros = new FormData();

    parametros.append("Id", id);

    NProgress.start();

    var xhttp = new XMLHttpRequest();

    xhttp.onreadystatechange = function () {

        if (xhttp.readyState == XMLHttpRequest.DONE) {

            NProgress.done();

            console.log(xhttp);

            var result = JSON.parse(xhttp.responseText);

            if (xhttp.status == 200) {

                form.Id.value = result.id;

                form.MonitorId.value = result.monitorId;

                form.Descricao.value = result.descricao;

                form.Caminho.value = result.caminho;

                form.TempoExibicao.value = result.tempoExibicao;

                form.TempoExibicao.setAttribute(result.desabilitaTempoExibicao, result.desabilitaTempoExibicao);

                document.getElementById("div-caminho").setAttribute(result.ocultaCaminho, result.ocultaCaminho);

                document.getElementById("div-arquivo").setAttribute(result.ocultaUploadFile, result.ocultaUploadFile);

                document.getElementById("div-tempo-exibicao").setAttribute(result.ocultaTempoExibicao, result.ocultaTempoExibicao);

                form.TipoConteudo.value = result.tipoConteudo;

                form.IsEnabled[0].checked = result.isEnabled;

                form.Mudo[0].checked = result.mudo;

                form.AutoPlay[0].checked = result.autoPlay;

                form.Looping[0].checked = result.looping;

                $("#alterar-conteudo").modal("show");

            } else {

                msgErro(result.mensagem);
            }
        }
    };

    xhttp.open('POST', url);

    xhttp.send(parametros);
}

async function alterarConteudoMonitor() {

    //Chamar a validação JQuery para validação 'client side'
    var validator = $("#frm-alterar-conteudo").validate().form();

    //Se inválido, encerra a função
    if (!validator)
        return null;

    //Capturo o formulário + seus elementos
    var objForm = document.getElementById("frm-alterar-conteudo");

    //var url = '../monitores/alterar-conteudo';

    const conteudo = new FormData(objForm);

    $('#alterar-conteudo').modal('hide');

    NProgress.start();

    var xhttp = new XMLHttpRequest();

    xhttp.onreadystatechange = function () {

        if (xhttp.readyState == XMLHttpRequest.DONE) {

            NProgress.done();

            console.log(xhttp);

            if (xhttp.status == 200) {

                msgSucesso(JSON.parse(xhttp.responseText).mensagem);

                window.location.reload();

            }
            else if (xhttp.status == 400) {

                msgErro(JSON.parse(xhttp.responseText).mensagem);

            } else {

                console.log(xhttp);
            }
        }
    };

    //xhttp.open('POST', url);
    xhttp.open('POST', objForm.action);

    //Passo o Token de validação da requisição
    xhttp.setRequestHeader("X-CSRF-TOKEN", objForm.__RequestVerificationToken.value);

    xhttp.send(conteudo);

}

