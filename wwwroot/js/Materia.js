console.log("ENTROU Matéria")

var materia = document.getElementById("materia");
var validMateria = false;

let btn = document.querySelector('#btn');
btn.disabled = true
materia.addEventListener('input', validar);

function validaNomeMat() {
    if (materia.value == '') {
        materia.style.borderColor = '#CA1C2A';
        materia.focus();
    } else if (materia.value.length < 3 || materia.value.length >= 60) {
        materia.style.borderColor = '#CA1C2A';
        validMateria = false;
    } else {
        materia.style.borderColor = '#008000';
        validMateria = true;
    }
}

function validar() {

    if (validMateria == true) {
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