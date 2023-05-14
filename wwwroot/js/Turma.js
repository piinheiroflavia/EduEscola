console.log("ENTROU Unidade")

var turma = document.getElementById("turma");
var validTurma = false;

let btn = document.querySelector('#btn');
btn.disabled = true
turma.addEventListener('input', validar);

function validaUnidade() {
    if (turma.value == '') {
        turma.style.borderColor = '#CA1C2A';
        turma.focus();
    } else if (turma.value.length < 2 || turma.value.length >= 60) {
        turma.style.borderColor = '#CA1C2A';
        validTurma = false;
    } else {
        turma.style.borderColor = '#008000';
        validTurma = true;
    }
}

function validar() {

    if (validTurma == true) {
        respSucesso.style.color = '#000'
        respSucesso.style.fontSize = '0.8rem'
        respErro.innerHTML = ''

        btn.disabled = false

    } else {
        respErro.style.fontSize = '0.8rem'
        respErro.style.color = '#000'
        respErro.style.marginTop = '5px'
        respSucesso.innerHTML = ''
        respErro.innerHTML = '*Preencha todos os campos corretamente'
        btn.disabled = true
    }
}