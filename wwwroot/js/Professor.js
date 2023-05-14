console.log("ENTROU Professor")


//INÍCIO PÁGINA CADASTRO DO PROFESSOR

var NomeProf = document.getElementById("NomeProf");
var validName = false;

var email = document.getElementById("email");
var SpanEmailProfessor = document.getElementById("Email_Professor");
var validEmail = false;

var registroCR = document.getElementById("registroCR");
var SpanregistroCR = document.getElementById("SpanregistroCR");
var validCR = false;

let btn = document.querySelector('#btn');

//eventos da validação geral
NomeProf.addEventListener('input', validar);
email.addEventListener('input', validar);
registroCR.addEventListener('input', validar);



function validaNome() {
    if (NomeProf.value == '') {
        NomeProf.style.borderColor = '#CA1C2A';
        NomeProf.focus();
    } else if (NomeProf.value.length < 3 || NomeProf.value.length >= 60) {
        NomeProf.style.borderColor = '#CA1C2A';
        validName = false;
    } else {
        NomeProf.style.borderColor = '#008000';
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

function validaEmail(emaill) {

    let ev = /^([_a-zA-Z0-9-]+)(\.[_a-zA-Z0-9-]+)*@([a-zA-Z0-9-]+\.)+([a-zA-Z]{2,3})$/;

    if (email.value == '') {
        email.style.borderColor = ' #CA1C2A'
        email.focus();
        validEmail = false;
        //verifica se o email possui um @ e de 2 a 3 caracteres após o ponto

    } else if (!ev.test(emaill)) {

        email.style.borderColor = '#CA1C2A'
        SpanEmailProfessor.innerHTML = 'Email Inválido';
        SpanEmailProfessor.style.color = '#CA1C2A';
    } else {

        email.style.borderColor = ' #008000'
        validEmail = true;
    }
}

       //emailProfessor.style.content = "e5c9";

function validaRegistro() {
    if (registroCR.value == '') {

        registroCR.style.borderColor = '#CA1C2A';
        registroCR.focus();
        SpanregistroCR.innerHTML = "Preenchimento Obrigatório"

    } else if (registroCR.value.length < 8) {

        registroCR.style.borderColor = '#CA1C2A';
        validCR = false;

    } else {
        SpanregistroCR.innerHTML = ""
        registroCR.style.borderColor = '#008000';
        validCR = true;
    }
}


//validação geral com o evento input para veficar se cada campo está Preenchido com todos os requisitos solicitados
function validar() {

    if (validName && validEmail && validCR) {
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