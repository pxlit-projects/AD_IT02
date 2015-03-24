<!DOCTYPE html>
<html>
<head>
    <title>Finah - vragenlijst</title>
    <meta charset="UTF-8">
    <!-- Mobiel vriendelijke viewport -->
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <!-- css file -->
    <link href="css/main.css" rel="stylesheet" type="text/css"/>
</head>
<body>
    <?php
$servername = "localhost";
$username = "root";
$password = "";
$dbname = "project";

// Create connection
$conn = new mysqli($servername, $username, $password, $dbname);
// Check connection
if ($conn->connect_error) {
     die("Connection failed: " . $conn->connect_error);
} 

$sql = "SELECT vraag_id, vraag_thema, vraag FROM vragenlijst";
$result = $conn->query($sql);

if ($result->num_rows > 0) {
     // output data of each row
    $alle_vragen = array();
     while($row = $result->fetch_assoc()) {
        echo "<br> id: ". $row["vraag_id"]. " - thema: ". $row["vraag_thema"]. " - vraag:" . $row["vraag"] . "<br>";
        /*array_merge($alle_vragen, array($row["vraag_id"]=>"vraag°id",row["vraag_thema"]=>"vraag_thema",row["vraag"]=>"vraag"));*/
        /* $row["vraag_id"] $row["vraag_thema"] $row["vraag"] */
     }
} else {
     echo "0 results";
}
$conn->close();
?>
    <p><?php echo($alle_vragen[0]["vraag_thema"]);?></p>
    <p><?php echo($alle_vragen["vraag"]);?></p>
    <img />
    <p>Hoe ervaart u dit onderdeel?</p>
    <button type="button">Verloopt naar wens?</button>
    <button type="button">Probleem - niet hinderlijk?</button>
    <button type="button">Probleem - hinderlijk voor client?</button>
    <button type="button">Probleem - hinderlijk voor mantelzorger?</button>
    <button type="button">Probleem - hinderlijk voor beide</button>
    
    
    <p>Willen cliënt/mantelzorger dat hieraan gewerkt wordt?</p>
    <button type="button?">Ja?</button>
    <button type="button?">Nee?</button>
    
    <div id="knoppen">
        <form action="#" class="knop_l">
        <input type="image" src="image/vorige.png" alt="Submit" >
        </form>
        <p class="label_m">Pagina<?php ?>/<?php ?></p>
        <form action="#" class="knop_r">
        <input type="image" src="image/volgende.png" alt="Submit" >
        </form>
    </div>
</body>
</html>
