<?php
// RECIBIR DATOS FORMULARIO
$id = $_POST["id"];
// echo $id;

//BORRAR LIBRO EN BBDD
$mysqli = new mysqli("localhost", "root", "", "lenguajes_frameworks");
$consulta = $mysqli->query("DELETE FROM lenguajes WHERE id=$id;");

// REDIRECCIONAR A LISTA DE LIBROS
header(header: "Location: ./index.php");