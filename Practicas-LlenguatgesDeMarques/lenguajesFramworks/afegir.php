<?php
// RECIBIR DATOS FORMULARIO
$nombre = $_POST["nombre"];
$ambito= $_POST["ambito"];
$popularidad = $_POST["popularidad"];
// echo "$title, $author, $year";

//GUARDAR DATOS EN BBDD
$mysqli = new mysqli("localhost", "root", "", "lenguajes_frameworks");
$consulta = $mysqli->query("INSERT INTO lenguajes(nombre,ambito,popularidad)
VALUES('$nombre','$ambito','$popularidad');");

// REDIRECCIONAR A LISTA DE LIBROS
header("Location: ./index.php");