/**********************************************************************/
// INTRUCCIONES PARA ARRANCAR LA APLICACIÓN
/**********************************************************************/
// Instalar NodeJS (descarga web https://nodejs.org/)

// Una vez instalado NodeJS y reiniciado VSCODE:
    // Observar el fichero package.json
        // En él figuran, entre otras cosas, las dependencias del proyecto
        // En este caso: express, multer

// Ejecutar npm install para instalar dependencias

// Ejecutar npm start para arrancar la app

// En http://localhost:3000/ se levanta el cliente
// Las demás rutas sirven para procesar las peticiones (fetch) del cliente (API del backend)

// ATENCIÓN!!! En esta práctica sólo hay que modificar este archivo app.js 
// A disfrutar ;)

/**********************************************************************/
// SECCIÓN 1: AÑADIR USUARIO A LA BASE DE DATOS
/**********************************************************************/
// Para ello, debes extraer los datos del formulario para poder enviar una petición 'POST' al endpoint '/api/json' con un JSON de formato { name, email, ts: Date.now() }
/**********************************************************************/

document.getElementById('send-json').addEventListener('click', () => {
    // Tarea 1.1: Capturar los valores de nombre y email del formulario
    const name =    document.getElementById('json-name').value;
    const email =   document.getElementById('json-email').value;
    // Tarea 1.2: Mostrar el mensaje 'Enviando' en #json-res
    const resEl =   document.getElementById('json-res');
    resEl.textContent= 'Enviando';
    // Tarea 1.3: Preparar el objeto JSON a enviar (payload)
    const payload = {
        name,
        email,
        ts: Date.now()
    };
    // Tarea 1.4: Enviar el JSON al servidor usando fetch (método POST)
    fetch('/api/json', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(payload)             // adjuntar paylad stringificado
    })
        // Tarea 1.4: Mostrar la respuesta del servidor
        // a: extraer el JSON de la respuesta
        .then(resp => {
            if (!resp.ok) throw new Error('problemas')
            return resp.json()
        })
        // b. mostrar el contenido del JSON stringificado en resEl
        .then(data => {
            resEl.textContent = JSON.stringify(data, null, 2)
        })
        .catch(err => {
            resEl.textContent = 'Error: ' + err.message;
        });
});

/**********************************************************************/
// SECCIÓN 2: LISTAR USUARIOS ALMACENADOS EN LA BBDD
/**********************************************************************/
// Para ello deberás pedir los datos (GET) al endpoint '/api/list'
/**********************************************************************/

document.getElementById('refresh-list').addEventListener('click', function () {
    // Tarea 2.1: Al pulsar el botón, pedir la lista al servidor
    const status = document.getElementById('list-status');
    const table = document.querySelector('#user-table tbody');
    status.textContent = 'Cargando...';
    fetch('/api/list')
        .then(resp => {
            if (!resp.ok) throw new Error ('Error')
            return resp.json();
        })
        .then(data => {
            // Tarea 2.2: Limpiar la tabla y mostrar mensaje de carga
            table.innerHTML = '';          ;
            if (!data.length) {
                status.textContent = 'No hay datos.';
                return;
            }
            // Tarea 2.3: Recorrer los datos y crear filas para cada usuario
            // Tarea 2.4: Mostrar el número de ficheros asociados
            data.forEach(user => {
                const tr = document.createElement('tr');
                tr.innerHTML = `
                    <td>${user.name}</td>
                    <td>${user.email}</td>
                    <td>${user.files ? user.files.length : 0}</td>
                `;
                table.appendChild(tr);
            });
            status.textContent = '';
        })
        .catch(err => {
            status.textContent = 'Error: ' + err.message;
        });
});

/**********************************************************************/
// SECCIÓN 3: SUBIR AL SERVIDOR UN FICHERO ASOCIADO A UN CORREO
/**********************************************************************/
// Para ello, deberás enviar una petición al endpoint '/api/form'. Esta vez enviaremos los datos del formulario, no en formato JSON, sino en formato FormData, que permite enviar ficheros con mucha más facilidad
/**********************************************************************/

document.getElementById('send-form').addEventListener('click', function (e) {
    e.preventDefault();
    const form = document.getElementById('form-formdata');
    const resEl = document.getElementById('form-res');
    resEl.textContent = 'Enviando...';

    // Tarea 3.1: Validar que el email existe en la bbdd
    const email = document.getElementById('form-email').value;
    fetch('/api/list')
        .then(resp => resp.json())
        .then(users => {
            const userExists = users.some(u => u.email === email);
            if (!userExists) {
                resEl.textContent = 'El email no está registrado.';
                throw new Error('Email no registrado');
            }
            // Tarea 3.2: Si existe, enviar el archivo
            const formData = new FormData(form)
            return fetch('/api/form', {
                method: 'POST',
                body: formData        // Adjuntar objeto FormData de #form-formdata
            });
        })
        // Tarea 3.3: Mostrar la respuesta del servidor
        .then(resp => {
            if (!resp.ok) throw new Error('eRror')
            return resp.json()
        })
        .then(data => {
            resEl.textContent = JSON.stringify(data, null, 2);
        })
        .catch(err => {
            if (err.message !== 'Email no registrado')
                resEl.textContent = 'Error: ' + err.message;
        });
});

/**********************************************************************/
// SECCIÓN 4: EDITAR NOMBRE ASOCIADO A CORREO
/**********************************************************************/
// Para ello, deberás montar una sección extra (añadirla al HTML) para poder enviar una petición 'POST' al endpoint '/api/edit-name' con un JSON de formato { email, newName }
/**********************************************************************/

document.getElementById('edit-name-btn').addEventListener('click', ()=>{
    const email = document.querySelector('#edit-email').value;
    const newName = document.querySelector('#edit-newName').value;
    const status = document.querySelector('#edit-name-status');

    status.textContent = '';

    fetch('api/edit-name',{
        method: 'POST',
        headers: {'Content-Type':'application/json'},
        body: JSON.stringify({email, newName})
    })
    .then(resp => {
        return resp.json();
    })
    .then(data =>{
        status.textContent = ''
    })
})

/**********************************************************************/
// SECCIÓN 5: DESCARGAR EL ARCHIVO MÁS GRANDE DEL SERVIDOR
/**********************************************************************/
// Para ello, deberás hacer una petición al endpoint '/api/download-largest'. Se debe implementar la funcionalidad de visor del progreso de descarga
/**********************************************************************/
// ESTA SECCIÓN SE PROPORCIONA YA IMPLEMENTADA, A MODO DE DEMOSTRACIÓN
/**********************************************************************/

document.getElementById('download-largest').addEventListener('click', function () {
    // Tarea 5.1: Al pulsar el botón, inicializamos DOM
    const progress = document.getElementById('download-progress');
    const status = document.getElementById('download-status');
    progress.value = 0;
    progress.style.display = 'inline-block';
    status.textContent = '';

    // Realizamos la petición
    fetch('/api/download-largest')
        .then(resp => {
            // Si hay error en la respuesta:
            if (!resp.ok) throw new Error('No se pudo descargar el archivo');

            // Si no hay error en la respuesta:
            // Extraemos el tamaño del archivo de los header de la respuesta (campo: 'content-length')
            const total = resp.headers.get('content-length');
            // Extraemos el tamaño del archivo de los header de la respuesta (campo: 'content-disposition')
            const filename = resp.headers.get('content-disposition')?.split('filename=')[1]?.replace(/"/g, '') || 'archivo';

            // Inicializamos las variables que controlarán la descarga
            let loaded = 0;
            const reader = resp.body.getReader();
            const chunks = [];

            // Tarea 5.2: Leer el stream y actualizar progreso
            read();

            // ATEENCIÓN! La función read es recursiva: se llama a sí misma (esto hace que se vayan leyendo fragmentos de archivo hasta que la descarga esté completada)
            function read() {
                return reader.read()
                    .then(({ done, value }) => {
                        if (done) {
                            //  Al terminar la descarga, crear enlace de descarga
                            const blob = new Blob(chunks);
                            const url = URL.createObjectURL(blob);
                            const a = document.createElement('a');
                            a.href = url;
                            a.download = decodeURIComponent(filename);
                            document.body.appendChild(a);
                            a.click();
                            a.remove();
                            URL.revokeObjectURL(url);
                            progress.style.display = 'none';
                            status.textContent = 'Descarga completada';
                            return;
                        }
                        // A medida que se va realizando la descarga, se procesa cada fragmento de archivo (chunks) y se actualiza el proceso de descarga (loaded)
                        chunks.push(value);
                        loaded += value.length;
                        if (total) progress.value = Math.round(loaded / total * 100);

                        // Llamamos a la función de manera recursiva para que se invoque el métode read del objeto Reader hasta que la descarga se haya completado
                        read();
                    });
            }
        })
        .catch(err => {
            progress.style.display = 'none';
            status.textContent = 'Error: ' + err.message;
        });
});