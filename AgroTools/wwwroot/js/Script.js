var container = document.getElementById('tipoResposta');
var select = document.getElementById('resposta');
var total = document.getElementById('total');
var todos = document.getElementById('todos');
var texto = document.getElementById('texto');
var pergunta = document.getElementsByClassName('quest-perguntas')[0];
var conteudo = document.getElementById('conteudo');
var TotalNames = [];

function TrocarResposta() {
    container.innerHTML = "";
    console.log(select.value);

    if (select.value == 1) {
        container.innerHTML = '<input class="resposta-text" placeholder="Digite sua resposta:" type="text" />';
    } else if (select.value == 2) {
        container.innerHTML = '<input type="button" value="Adicionar mais opções" class="btn-opcao" onclick="adicionarOpcao()"/>';
        container.innerHTML += '<div class="resposta-multi"> <div class="circle"></div><input value="Opção" type="text" /></div>';
    } else if (select.value == 3) {
        container.innerHTML = '<input type="button" value="Adicionar mais opções" class="btn-opcao" onclick="adicionarOpcao()"/>';
        container.innerHTML += '<div class="resposta-caixa"> <div class="quadrado"></div><input value="Opção" type="text" /></div>';
    }
}

function adicionarOpcao() {
    var div = document.createElement('div');
    div.innerHTML = "";
    if (select.value == 2) {
        div.setAttribute("class", "resposta-multi");
        div.innerHTML = '<div class="circle"></div><input value="Opção" type="text" />';
        container.appendChild(div);
    } else {
        div.setAttribute("class", "resposta-caixa");
        div.innerHTML = '<div class="quadrado"></div><input value="Opção" type="text" />';
        container.appendChild(div);
    }
}

function Delete() {
    texto.value = "";
    container.innerHTML = "";
    select.selectedIndex = 0;
}

function Atualizar() {
    document.getElementById('titulo').value = document.getElementById('titulo1').value;
    document.getElementById('descricao').value = document.getElementById('descricao1').value;
}

function DeletarDiv(e) {
    document.getElementById(e.id).remove();
    var index = TotalNames.indexOf(""+e.id+"");
    TotalNames.splice(index, 1);
    let str = "" + e.id;
    document.getElementsByClassName(e.id)[0].remove();
    let stri = ""
    for (var i = 0; i < TotalNames.length; i++) {
        stri += TotalNames[i] + ';';
    }
    todos.value = stri;
}

var num = 1;
function adicionarQuest() {
    var clone = conteudo.firstElementChild.cloneNode(true);
    var editar = clone.getElementsByClassName('editar')
    var question = editar[0].firstElementChild.value;
    if (question != '' && question != null && question != undefined) {
        var filho = clone.lastElementChild;
        filho.innerHTML = "";
        filho.innerHTML = '<div class="buttons-editar"><button onclick="DeletarDiv(Elemento' + num + ')"><i class="far fa-trash-alt"></i></button ></div >';
        clone.setAttribute("id", "Elemento" + num + "");
        var inputs = clone.getElementsByClassName('resposta-multi');
        var check = clone.getElementsByClassName('resposta-caixa');
        var texto = clone.getElementsByClassName('resposta-text');
        editar[0].firstElementChild.disabled = true;
        editar[0].lastElementChild.disabled = true;
        var btn = clone.getElementsByClassName('btn-opcao');
        var quest = document.createElement('input');

        quest.setAttribute("name", "Elemento" + num + "");
        quest.setAttribute("class", "Elemento" + num + "");


        if (select.value == 1) {
            texto[0].disabled = true;
            quest.value = 'Pergunta=' + question + '¥TipoResposta=' + select.value + '¥';
        } else if (select.value == 2) {
            btn[0].remove();
            let conct = "";
            for (var i = 0; i < inputs.length; i++) {
                let x = inputs[i].lastElementChild;
                x.disabled = true;
                conct += 'quest' + (i + 1) + '=' + x.value + '¥';
            }
            quest.value = 'Pergunta=' + question + '¥TipoResposta=' + select.value + '¥Quantidade=' + inputs.length + '¥' + conct;
        } else {
            btn[0].remove();
            let conct = "";
            for (var i = 0; i < check.length; i++) {
                console.log(check)
                let x = check[i].lastElementChild;
                x.disabled = true;
                conct += 'quest' + (i + 1) + '=' + x.value + '¥';
            }
            quest.value = 'Pergunta=' + question + '¥TipoResposta=' + select.value + '¥Quantidade=' + check.length + '¥' + conct;
        }

        console.log(quest.value);
        total.appendChild(quest);
        TotalNames.push('Elemento' + num + '');
        pergunta.appendChild(clone);
        let stri = ""
        for (var i = 0; i < TotalNames.length; i++) {
            stri += TotalNames[i] + ';';
        }
        todos.value = stri;
        num++;
        Delete();
    }
}


function Tabs(e) {
    var tablinks = document.getElementsByClassName("tablinks");

    if (e == true) {
        tablinks[0].removeAttribute('id');
        document.getElementById('respostas').style.display = 'none';
        document.getElementById('perguntas').style.display = 'block';
        tablinks[1].classList.remove("active");
        tablinks[0].classList.add("active");
    } else {
        tablinks[0].removeAttribute('id');
        document.getElementById('perguntas').style.display = 'none';
        document.getElementById('respostas').style.display = 'flex';
        tablinks[0].classList.remove("active");
        tablinks[1].classList.add("active");
    }
}

var respostas = [];
function SalvarResposta(e, item, tipo, idPergunta) {
    var todas = document.getElementById("todas");

    if (respostas.indexOf(item) > -1) {
    } else {
        respostas.push(item);
        var txt = "";
        for (var i = 0; i < respostas.length; i++) {
            txt += respostas[i] +";";
        }
        todas.value = txt;
    }


    if (tipo == 1) {
        document.getElementById(item).value = "Tipo=1¤IdQuest=" + idPergunta + "¤" + e.value;
    } else if (tipo == 2) {
        document.getElementById(item).value = "Tipo=2¤IdQuest=" + idPergunta + "¤"+ document.querySelector('input[name="' + item + '+id"]:checked').value + "¤";
    } else {
        var pacote = document.getElementsByName(item + "+id");
        var str = "";
        for (var i = 0; i < pacote.length; i++) {
            if (pacote[i].checked == true) {
                str += pacote[i].value + "¤";
            }
        }
        document.getElementById(item).value = "Tipo=3¤IdQuest=" + idPergunta + "¤" + str;
        console.log(str)
    }

}

function AbrirModal(evt, modalName) {
    var i, tabcontent;
    tabcontent = document.getElementsByClassName("modal-itens");
    for (i = 0; i < tabcontent.length; i++) {
        tabcontent[i].style.display = "none";
    }
    document.getElementById(modalName).style.display = "block";
}
