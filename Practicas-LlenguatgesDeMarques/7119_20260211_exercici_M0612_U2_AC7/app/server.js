const express = require('express');
const multer = require('multer');
const path = require('path');
const fs = require('fs');

const app = express();
const PORT = process.env.PORT || 3000;

const uploadsDir = path.join(__dirname, 'uploads');
if (!fs.existsSync(uploadsDir)) fs.mkdirSync(uploadsDir);

// Configure multer storage to save with original filename
const storage = multer.diskStorage({
  destination: (req, file, cb) => {
    cb(null, uploadsDir);
  },
  filename: (req, file, cb) => {
    cb(null, file.originalname);
  }
});

const upload = multer({ storage });

app.use(express.json());
app.use(express.urlencoded({ extended: true }));

// Simple CORS for local dev (allows requests from live-server on different port)
app.use((req, res, next) => {
  res.header('Access-Control-Allow-Origin', '*');
  res.header('Access-Control-Allow-Methods', 'GET,POST,OPTIONS');
  res.header('Access-Control-Allow-Headers', 'Content-Type, Authorization');
  if (req.method === 'OPTIONS') return res.sendStatus(204);
  next();
});

app.use(express.static(path.join(__dirname, 'public')));

// Endpoint para editar el nombre asociado a un correo
app.post('/api/edit-name', (req, res) => {
  const { email, newName } = req.body;
  if (!email || !newName) return res.status(400).json({ message: 'Faltan datos.' });
  const dbPath = path.join(__dirname, 'db.json');
  let db = [];
  try {
    db = JSON.parse(fs.readFileSync(dbPath, 'utf8'));
  } catch (e) {}
  let updated = false;
  for (let user of db) {
    if (user.email === email) {
      user.name = newName;
      updated = true;
      break;
    }
  }
  if (updated) {
    fs.writeFileSync(dbPath, JSON.stringify(db, null, 2));
    return res.json({ message: 'Nombre actualizado correctamente.' });
  } else {
    return res.status(404).json({ message: 'Correo no encontrado.' });
  }
});

// Endpoint para listar los datos de la bbdd (sin timestamp)
app.get('/api/list', (req, res) => {
  const dbPath = path.join(__dirname, 'db.json');
  let db = [];
  try {
    db = JSON.parse(fs.readFileSync(dbPath, 'utf8'));
  } catch (e) {}
  // Excluir timestamp, incluir número de ficheros
  const data = db.map(({name, email, files}) => ({
    name,
    email,
    fileCount: Array.isArray(files) ? files.length : 0
  }));
  res.json(data);
});

app.post('/api/json', (req, res) => {
  // Guardar nombre y correo en db.json solo si el correo no existe
  const { name, email } = req.body;
  let added = false;
  let already = false;
  if (name && email) {
    const dbPath = path.join(__dirname, 'db.json');
    let db = [];
    try {
      db = JSON.parse(fs.readFileSync(dbPath, 'utf8'));
    } catch (e) {}
    if (db.some(u => u.email === email)) {
      already = true;
    } else {
      db.push({ name, email, ts: Date.now(), files: [] });
      fs.writeFileSync(dbPath, JSON.stringify(db, null, 2));
      added = true;
    }
  }
  res.json({
    received: req.body,
    message: added
      ? 'Usuario añadido correctamente.'
      : already
        ? 'El usuario ya existe, no se añadió.'
        : 'Faltan datos.'
  });
});

app.post('/api/form', upload.single('file'), (req, res) => {
  const file = req.file;
  const email = req.body.email;
  let updated = false;
  if (file && email) {
    const dbPath = path.join(__dirname, 'db.json');
    let db = [];
    try {
      db = JSON.parse(fs.readFileSync(dbPath, 'utf8'));
    } catch (e) {}
    for (let user of db) {
      if (user.email === email) {
        if (!Array.isArray(user.files)) user.files = [];
        user.files.push(file.originalname);
        updated = true;
        break;
      }
    }
    if (updated) fs.writeFileSync(dbPath, JSON.stringify(db, null, 2));
  }
  res.json({
    received: req.body,
    file: file ? { originalname: file.originalname, filename: file.filename, size: file.size } : null,
    message: updated ? 'FormData recibido y archivo registrado' : 'FormData recibido'
  });
});


// Ruta para servir el archivo más voluminoso de uploads/
app.get('/api/download-largest', (req, res) => {
  const dir = uploadsDir;
  fs.readdir(dir, (err, files) => {
    if (err || !files.length) return res.status(404).send('No files found');
    let largest = null;
    let maxSize = 0;
    files.forEach(f => {
      const filePath = path.join(dir, f);
      const stat = fs.statSync(filePath);
      if (stat.isFile() && stat.size > maxSize) {
        largest = f;
        maxSize = stat.size;
      }
    });
    if (!largest) return res.status(404).send('No files found');
    const filePath = path.join(dir, largest);
    res.setHeader('Content-Disposition', `attachment; filename="${encodeURIComponent(largest)}"`);
    res.setHeader('Content-Length', maxSize);
    res.sendFile(filePath);
  });
});

app.listen(PORT, () => console.log(`Server running on http://localhost:${PORT}`));
