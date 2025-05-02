<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Document</title>
    <link rel="stylesheet" href="./styles.css">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.5.1/css/all.min.css">

</head>

<body>
    <?php
    $mysqli = new mysqli("localhost", "root", "", "lenguajes_frameworks");

    $consulta = $mysqli->query("SELECT * FROM lenguajes;");
    ?>

    <h1>LENGUAJES Y FRAMEWORKS</h1>

    <table>
        <tr>
            <th>nombre</th>
            <th>ambito</th>
            <th>popularidad</th>
            <th>    </th>
        </tr>
        <?php
        $num_filas = $consulta->num_rows;

        for ($i = 0; $i < $num_filas; $i++) {
            $fila = $consulta->fetch_assoc();
            echo "  <tr>
                        <td>$fila[nombre]</td>
                        <td>$fila[ambito]</td>
                        <td>$fila[popularidad]</td>
                        <td>
                            <button class='editButton'>
                                <i class='fa-solid fa-pen-to-square'></i>
                            </button>
                            <button class='delButton' id='$fila[id]'>
                                <i class='fa-solid fa-trash'></i>
                            </button>
                        </td>
                    </tr>";
        }
        ?>

    </table>
    <form action="./afegir.php" method="POST">
        <legend>AÑADE UN LENGUAJE AL CATALOGO</legend>
        <label>Nombre:</label><input type="text" name="nombre" id="nombre">
        <label>Ambito:</label><input type="text" name="ambito" id="ambito">
        <label>Popularidad:</label><input type="text" name="popularidad" id="popularidad">
        <input type="submit" value="ADD">
    </form>
</body>
<footer>
    <h1><a href="frameworks.php" class="enlace">FRAMEWORKS</a></h1>
</footer>
<style>
    .enlace{
    color: white;
    text-decoration: none;
    }

    .enlace:hover{
        color: #007bff;
    }
</style>
<script src="./script.js"></script>

</html>