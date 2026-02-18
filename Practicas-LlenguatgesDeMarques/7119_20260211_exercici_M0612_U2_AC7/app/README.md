# Demo POST con fetch (JSON y FormData)

Proyecto de ejemplo para usar en clase. Incluye un backend en Node/Express y un frontend estático que demuestra:

- Envío de JSON con `fetch` y `Content-Type: application/json`.
- Envío de `FormData` con `fetch` (multipart/form-data) incluyendo un archivo.

Instrucciones rápidas:

1. Instalar dependencias:

```powershell
npm install
```

2. Iniciar servidor:

```powershell
npm start
```

3. Abrir en el navegador:

http://localhost:3000

Endpoints:

- `POST /api/json` — acepta JSON y devuelve el objeto recibido.
- `POST /api/form` — acepta FormData (campo `file` para archivo) y devuelve campos y metadatos del archivo.

Explicación breve del frontend:

- `public/index.html` contiene un formulario para JSON y otro para FormData.
- `public/app.js` usa `fetch` para enviar los datos y mostrar la respuesta.
