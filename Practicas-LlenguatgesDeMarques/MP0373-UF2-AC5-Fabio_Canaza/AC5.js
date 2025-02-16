let clickIzquierdo = 0;
let clickDerecho = 0;
let hoverContador = 0;
let teclaContador = 0;
let gContador = 0;
let contadorLista = 0;

window.onload = function() {
    let escudoSnk = document.querySelector('.logo');
    escudoSnk.addEventListener('click', rojoClickIzquierdo);
    escudoSnk.addEventListener('contextmenu', azulClickDerecho);
    escudoSnk.addEventListener('mouseenter', MousePorEncima);

    document.addEventListener('keydown', gestionarTecles);

    let botonCrear = document.querySelector('#botonCrear');
    botonCrear.addEventListener('click', anadirElemento);

    crearTarjeta(user);
}


function rojoClickIzquierdo() {
    clickIzquierdo++;
    document.querySelector('#rojo').textContent = clickIzquierdo;
}

function azulClickDerecho(event) {
    event.preventDefault(); 
    clickDerecho++;
    document.querySelector('#azul').textContent = clickDerecho;
}

function MousePorEncima() {
    hoverContador++;
    document.querySelector('#verde').textContent = hoverContador;
}

function gestionarTecles(event) {
    teclaContador++;
    document.querySelector('#naranja').textContent = teclaContador;
    document.querySelector('#amarillo').textContent = event.key;

    if (event.key === "g" || event.key === "G") {
        gContador++;
        document.querySelector('#lila').textContent = gContador;
    }
}

function anadirElemento() {
    let nuevoElemento = document.createElement('li');

    nuevoElemento.innerHTML = "Aquest és l’element " + contadorLista + " de la llista";
    contadorLista++;

    let llista = document.querySelector('#llista');
    llista.append(nuevoElemento);
}

let user = {
    nombre: "Roberto", 
    apellido: "Heras", 
    edad: 35, 
    aficiones: ["escalada", " sushi", " papiroflexia"] 
}

function crearTarjeta(user) {
    let tarjeta = document.createElement('div');
    tarjeta.classList.add('user-tarjeta');

    let nombre = document.createElement('h2');
    nombre.innerHTML = user.nombre + " " + user.apellido;
    tarjeta.append(nombre);

    let edad = document.createElement('p');
    edad.innerHTML = "Edad: " + user.edad + " años";
    tarjeta.append(edad);

    let aficionesTitle = document.createElement('h3');
    aficionesTitle.innerHTML = "Aficiones";
    tarjeta.append(aficionesTitle);

    let aficiones = document.createElement('ul');
    for (let aficion of user.aficiones) {
        let li = document.createElement('li');
        li.innerHTML = aficion.charAt(0).toUpperCase() + aficion.slice(1);
        aficiones.append(li);
    }
    tarjeta.append(aficiones);

    document.querySelector('#tarjeta').append(tarjeta);
}

let filosofos = [ 
    { 
    nombre: "Platón", 
    imagen: 
"https://acortar.link/CoZusG", 
    pais: "Grecia", 
    corriente: "Idealismo", 
    arma: "Dialéctica" 
    }, 
    { 
        nombre: "Aristóteles", 
        imagen: 
"https://acortar.link/g7XuHY", 
        pais: "Grecia", 
        corriente: "Naturalismo", 
        arma: "Lógica" 
    },
    { 
        nombre: "Descartes", 
        imagen: 
"https://acortar.link/dNgMzt", 
        pais: "Francia", 
        corriente: "Racionalismo", 
        arma: "Meditación" 
    }, 
    { 
        nombre: "Kant", 
        imagen: 
"https://i.pinimg.com/736x/20/89/7f/20897f915acb5124893a278c395382ed.jpg", 
        pais: "Alemania", 
        corriente: "Trascendentalismo", 
        arma: "Crítica", 
    }, 
    { 
        nombre: "Hume", 
        imagen: 
"https://acortar.link/FRI7x", 
        pais: "Escocia", 
        corriente: "Empirismo", 
        arma: "Escepticismo"         
    } 
]

function crearTarjetaFilos() {
    let container = document.querySelector('#filosofosContainer');

    container.innerHTML = '';

    for (let filosofo of filosofos) {
        let card = document.createElement('div');
        card.className = 'filosof-card';

        let img = document.createElement('img');
        img.src = filosofo.imagen;
        img.alt = `Retrat de ${filosofo.nombre}`;
        img.className = 'filosof-img';

        let nom = document.createElement('h1');
        nom.innerHTML = filosofo.nombre;

        let pais = document.createElement('p');
        pais.innerHTML = `<strong>País:</strong> ${filosofo.pais}`;

        let corrent = document.createElement('p');
        corrent.innerHTML = `<strong>Corrent:</strong> ${filosofo.corriente}`;

        let arma = document.createElement('p');
        arma.innerHTML = `<strong>Arma:</strong> ${filosofo.arma}`;

        card.append(img, nom, pais, corrent, arma);
        container.append(card);
    };
}

document.querySelector('#botonCrearTarjetas').addEventListener('click', crearTarjetaFilos);