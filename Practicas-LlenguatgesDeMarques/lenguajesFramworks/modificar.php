<!-- <?php
// RECIBIR DATOS FORMULARIO
$id = $_POST["id"];
$nombre = $_POST["nombre"];
$ambito= $_POST["ambito"];
$popularidad = $_POST["popularidad"];
// echo $id;

//BORRAR LIBRO EN BBDD
$mysqli = new mysqli("localhost", "root", "", "lenguajes_frameworks");
$consultaNombre = $mysqli->query("UPDATE lenguajes SET nombre=$nombre WHERE id=$id;");
$consultaAmbito = $mysqli->query("UPDATE lenguajes SET ambito=$ambito WHERE id=$id;");
$consultaPopularidad = $mysqli->query("UPDATE lenguajes SET popularidad=$popularidad WHERE id=$id;");

// REDIRECCIONAR A LISTA DE LIBROS
header(header: "Location: ./index.php"); -->