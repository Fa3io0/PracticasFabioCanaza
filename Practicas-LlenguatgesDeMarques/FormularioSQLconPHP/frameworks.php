<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Document</title>
</head>
<body>
    <table>
        <tr>
            <th>id</th>
            <th>framework</th>
            <th>lenguaje</th>
        </tr>
        <tr>
            <?php
                $mysqli = new mysqli(hostname: "localhost", username: "root", password: "", database: "lenguajes_frameworks");
                $consulta = $mysqli->query(query: "SELECT frameworks.id, frameworks.nombre AS framework, lenguajes.nombre AS lenguaje
                FROM frameworks JOIN lenguajes ON frameworks.lenguaje = lenguajes.id");

                while ($fila = $consulta->fetch_assoc()){
                    echo "<tr>
                            <td>{$fila['id']}</td>
                            <td>{$fila['framework']}</td>
                            <td>{$fila['lenguaje']}</td>
                          </tr>";
                }
            ?>
        </tr>
    </table>
</body>
<footer>
    <h1><a href="index.php" class="enlace">LENGUAJES</a></h1>
</footer>
<style>
    /* estilos echos con gpt*/
    .enlace{
    color: white;
    text-decoration: none;
    }

    .enlace:hover{
        color: #ff1a75;
    }

    body {
        background: linear-gradient(to bottom, #1a001a, #330033);
        color: #e0d0ff;
        font-family: 'UnifrakturCook', cursive;
        padding: 40px;
        margin: 0;
    }

    h1 {
        text-align: center;
        color: #ff1a75;
        text-shadow: 2px 2px 10px #660033;
        font-size: 3em;
        margin-bottom: 30px;
    }

    table {
        width: 80%;
        margin: auto;
        border-collapse: collapse;
        background-color: rgba(20, 0, 30, 0.85);
        box-shadow: 0 0 30px #660033;
        border: 2px solid #8a0033;
    }

    th, td {
        padding: 15px 20px;
        text-align: center;
        border-bottom: 1px solid #4d0026;
        font-size: 1.2em;
    }

    th {
        background-color: #4d0026;
        color: #ffb3d9;
        letter-spacing: 2px;
        text-transform: uppercase;
    }

    tr:nth-child(even) {
        background-color: rgba(51, 0, 51, 0.6);
    }

    tr:hover {
        background-color: #8b004d;
        color: #fff;
        transform: scale(1.02);
        transition: 0.3s ease-in-out;
    }
</style>
</html>