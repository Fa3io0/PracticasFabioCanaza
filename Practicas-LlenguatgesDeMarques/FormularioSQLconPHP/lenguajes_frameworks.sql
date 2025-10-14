-- Crear la base de datos (opcional)
CREATE DATABASE IF NOT EXISTS lenguajes_frameworks;
USE lenguajes_frameworks;

-- Crear la tabla 'lenguajes'
CREATE TABLE lenguajes (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(100) NOT NULL,
    ambito VARCHAR(100) NOT NULL,
    popularidad ENUM('alta', 'media', 'baja') NOT NULL
);

-- Crear la tabla 'frameworks'
CREATE TABLE frameworks (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(100) NOT NULL,
    lenguaje INT NOT NULL,
    FOREIGN KEY (lenguaje) REFERENCES lenguajes(id)
);

-- Insertar registros en 'lenguajes'
INSERT INTO lenguajes (nombre, ambito, popularidad) VALUES
('JavaScript', 'Web', 'alta'),
('Python', 'Ciencia de datos', 'alta'),
('Java', 'Aplicaciones empresariales', 'alta'),
('C#', 'Aplicaciones de escritorio', 'media'),
('PHP', 'Web', 'media'),
('Ruby', 'Web', 'baja'),
('Go', 'Sistemas distribuidos', 'media'),
('C++', 'Videojuegos', 'media'),
('Swift', 'Aplicaciones móviles', 'media'),
('Kotlin', 'Aplicaciones móviles', 'media');

-- Insertar registros en 'frameworks'
INSERT INTO frameworks (nombre, lenguaje) VALUES
('React', 1),
('Django', 2),
('Spring', 3),
('.NET', 4),
('Laravel', 5),
('Ruby on Rails', 6),
('Gin', 7),
('Qt', 8),
('SwiftUI', 9),
('Ktor', 10);
