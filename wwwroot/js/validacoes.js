
const options = {
    method: "GET",
    mode: "cors",
    caches: "default"
}

const cep = document.getElementById("cep")
cep.addEventListener("blur", (e) => {
    let Cep = document.getElementById("cep").value;
    console.log(Cep)
    let search = cep.value.replace("-", "")
    fetch(`https://viacep.com.br/ws/${search}/json/`, options).then((response) => {
        response.json().then(data => {
            console.log(data)
            document.getElementById("bairro").value = data.bairro;
            document.getElementById("ddd").value = data.ddd;
            document.getElementById("localidade").value = data.localidade;
            document.getElementById("logradouro").value = data.logradouro;
            document.getElementById("uf").value = data.uf;
            document.getElementById("numero").value = data.numero;

        })
    })
})

function enviar() {
    let bairro = document.getElementById("bairro").value;
    let ddd = document.getElementById("ddd").value;
    let localidade = document.getElementById("localidade").value;
    let logradouro = document.getElementById("logradouro").value;
    let uf = document.getElementById("uf").value;
    let json = {
        "bairro": bairro,
        "ddd": ddd,
        "localidade": localidade,
        "logradouro": logradouro,
        "uf": uf,
    }
    console.log(json)
}

function validarForm(){
    let CPF = document.getElementById("cep").value;
    if(!TestaCPF(CPF)){
        alert("CPF inválido , insira o cpf");
        return false;
    }
    return true;
}

function TestaCPF(CPF) {
    var Soma;
    var Resto;
    Soma = 0;
  if (CPF == "00000000000") return false;

  for (i=1; i<=9; i++) Soma = Soma + parseInt(CPF.substring(i-1, i)) * (11 - i);
  Resto = (Soma * 10) % 11;

    if ((Resto == 10) || (Resto == 11))  Resto = 0;
    if (Resto != parseInt(CPF.substring(9, 10)) ) return false;

  Soma = 0;
    for (i = 1; i <= 10; i++) Soma = Soma + parseInt(CPF.substring(i-1, i)) * (12 - i);
    Resto = (Soma * 10) % 11;

    if ((Resto == 10) || (Resto == 11))  Resto = 0;
    if (Resto != parseInt(CPF.substring(10, 11) ) ) return false;
    return true;
}






