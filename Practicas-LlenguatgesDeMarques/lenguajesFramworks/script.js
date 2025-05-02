delButtons = document.querySelectorAll('.delButton');

for(let button of delButtons){
    button.addEventListener('click',deleteBook);
}

async function deleteBook(event){
    // Envio al servidor el id a borrar
    let url = "./deleteBook.php";
    let id = event.target.id;
    // alert(`Libro ${id} borrado`)

    let payload = new FormData();
    payload.append("id",id);
    
    let options = {
        method: "POST",
        body: payload
    };
    let response = await fetch(url,options);
    location.reload();
}