console.log("ENTROU ALUNO")

var NomeAluno = document.getElementById("NomeAluno");
var validName = false;

var spanValidation = document.getElementById("SpanCpfAluno");
let cpf = document.getElementById("cpf");
var validCpf = false;

var matricula = document.getElementById("matricula");
var validMatricula = false;

let btn = document.querySelector('#btn');

NomeAluno.addEventListener('input', validar);
cpf.addEventListener('input', validar);
matricula.addEventListener('input', validar);

function validaNome() {
    if (NomeAluno.value == '') {
        NomeAluno.style.borderColor = '#CA1C2A';
        NomeAluno.focus();

    } else if (NomeAluno.value.length < 3 || NomeAluno.value.length >= 60) {
    NomeAluno.style.borderColor = '#CA1C2A';
    validName = false;
    } else {
    NomeAluno.style.borderColor = '#008000';
    validName = true;
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

//function validaCpf(cpf) {
//    var regex = /^\d{3}\.\d{3}\.\d{3}-\d{2}$/;
//    return regex.test(email);
//}

function validaMatricula() {

if (matricula.value == '') {
    matricula.style.borderColor = '#CA1C2A';
    matricula.focus();

} else if (matricula.value.length < 1 || matricula.value.length >= 7) {
    matricula.style.borderColor = '#CA1C2A';
    validMatricula = false;

} else {
    matricula.style.borderColor = '#008000';
    validMatricula = true;
}

}

///*FUNÇÃO QUE IDENTIFICA SE O CAMPO ESTÁ VÁLIDO E DE ACORDO COM OS REQUISITOS PARA VERIFICAR SE EXISTE O CPF*/
function validaCpf(retorno) {

    if (retorno == true) {
        spanValidation.innerHTML = " ";
        cpf.style.borderColor = ' #008000';
        validCpf = true;
   
    } else {
        spanValidation.innerHTML = "CPF inválido!";
        cpf.style.borderColor = ' #CA1C2A';
        
        validCpf = false;
    }

    return validCpf;
}


//verifica se existe ou não
function TestaCPF(strCPF) {

    str = strCPF.replace('.', '').replace('.', '').replace('-', '');
    var cpfmask = str;
    var Soma;
    var Resto;
    Soma = 0;

    if (cpfmask == "00000000000" || cpfmask == "11111111111" || cpfmask == "22222222222" || cpfmask == "33333333333" || cpfmask == "44444444444" || cpfmask == "55555555555" || cpfmask == "66666666666" || cpfmask == "77777777777" || cpfmask == "88888888888" || cpfmask == "99999999999")
        return false;

    for (i = 1; i <= 9; i++) Soma = Soma + parseInt(cpfmask.substring(i - 1, i)) * (11 - i);
    Resto = (Soma * 10) % 11;

    if ((Resto == 10) || (Resto == 11)) Resto = 0;
    if (Resto != parseInt(cpfmask.substring(9, 10))) return false;

    Soma = 0;
    for (i = 1; i <= 10; i++) Soma = Soma + parseInt(cpfmask.substring(i - 1, i)) * (12 - i);
    Resto = (Soma * 10) % 11;

    if ((Resto == 10) || (Resto == 11)) Resto = 0;
    if (Resto != parseInt(cpfmask.substring(10, 11))) return false;
    return true;

}

function validar() {

    if (validName && validMatricula) {
        respSucesso.style.color = '#000'
        respSucesso.style.fontSize = '0.8rem'
        respErro.innerHTML = ''

        btn.disabled = false
        btn.style.cursor = 'pointer'

    } else {
        respErro.style.fontSize = '0.8rem'
        respErro.style.color = '#000'
        respErro.style.marginTop = '5px'
        respSucesso.innerHTML = ''
        respErro.innerHTML = '*Preencha todos os campos corretamente'

        btn.disabled = true
        btn.style.cursor = 'no-drop'
    }

}