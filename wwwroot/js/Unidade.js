console.log("ENTROU Unidade")

var Endereco = document.getElementById("Endereco");
var validEndereco = false;

var NomeDiretor = document.getElementById("NomeDiretor");
var validDiretor = false;

var NomeUnidade = document.getElementById("NomeUnidade");
var validUnidade = false;
let btn = document.querySelector('#btn');

Endereco.addEventListener('input', validar);
NomeDiretor.addEventListener('input', validar);
NomeUnidade.addEventListener('input', validar);
btn.disabled = true

function validaUnidade() {
    if (NomeUnidade.value == '') {
        NomeUnidade.style.borderColor = '#CA1C2A';
        NomeUnidade.focus();
    } else if (NomeUnidade.value.length < 3 || NomeUnidade.value.length >= 60) {
        NomeUnidade.style.borderColor = '#CA1C2A';
        validUnidade = false;
    } else {
        NomeUnidade.style.borderColor = '#008000';
        validUnidade = true;
    }
}

function validaEndereco() {
    if (Endereco.value == '') {
        Endereco.style.borderColor = '#CA1C2A';
        Endereco.focus();
    } else if (Endereco.value.length < 3 || Endereco.value.length >= 60) {
        Endereco.style.borderColor = '#CA1C2A';
        validEndereco = false;
    } else {
        Endereco.style.borderColor = '#008000';
        validEndereco = true;
    }
}

function validaNomeD() {
    if (NomeDiretor.value == '') {
        NomeDiretor.style.borderColor = '#CA1C2A';
        NomeDiretor.focus();
    } else if (NomeDiretor.value.length < 3 || NomeDiretor.value.length >= 60) {
        NomeDiretor.style.borderColor = '#CA1C2A';
        validDiretor = false;
    } else {
        btn.disabled = false
        NomeDiretor.style.borderColor = '#008000';
        validDiretor = true;
    }
}

//função para verificar se o campo possui apenas acentos e letras
function ApenasLetras(e, t) {
    try {
        if (window.event) {
            var charCode = window.event.keyCode;
        } else if (e) {
            var charCode = e.which;
        } else {
            return true;
        }
        if (

            (charCode == 32) ||
            (charCode == 63) ||
            (charCode > 64 && charCode < 91) ||
            (charCode > 96 && charCode < 123) ||
            (charCode > 191 && charCode <= 255) // letras com acentos
        ) {
            return true;
        } else {
            return false;
        }
    } catch (err) {
        alert(err.Description);
    }
} 

function validar() {

    if (validEndereco && validDiretor && validUnidade) {
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