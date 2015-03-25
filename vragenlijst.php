<!DOCTYPE html>
<?php
    /* CONNECTIE DATABASE */
    $servername = "localhost";
    $username = "root";
    $password = "";
    $dbname = "project";

    // Maak connectie
    $conn = new mysqli($servername, $username, $password, $dbname);
    // Nagaan of connectie is gelukt
    if ($conn->connect_error) {
        die("Connection failed: " . $conn->connect_error);
    } 
    
    /* DATABASE UITLEZEN EN IN ARRAY STEKEN */
    $sql = "SELECT vraag_id, vraag_thema, vraag FROM vragenlijst";
    $result = $conn->query($sql);

    $alle_vragen = array();
    while($row = $result->fetch_assoc()) {
        array_push($alle_vragen, array($row["vraag_id"], $row["vraag_thema"], $row["vraag"]));
    }
    $conn->close();

    /* TELLER INSTELLEN */
    $teller = 0;
    if (isset($_POST['teller'])) {
        // TODO valideer dat teller een getal is
        $teller = $_POST['teller'];
    }
    if (isset($_POST['richting'])) {
        $richting = $_POST['richting'];
        if ($richting === 'volgende') {
            //1
            $teller += 1;
            if($teller == 53){
                header('Location: voltooide_vragenlijst.php');
            }
            //2
            // gedrukte knoppen doorsturen naar database antwoorden
            
        } elseif ($richting === 'vorige') {
            $teller -= 1;
            if ($teller == -1){
                $teller = 0;
        }
    }
    }
?>
<html>
<head>
    <title>Finah - vragenlijst</title>
    <meta charset="UTF-8">
    
    <!-- Mobiel vriendelijke viewport -->
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    
    <!-- css file -->
    <link href="css/main.css" rel="stylesheet" type="text/css"/>
    <link href="css/jquery-ui.css" rel="stylesheet" type="text/css"/>
    
    <!-- script tags -->
    <script type="text/javascript" src="jquery/jquery.js"></script>
    <script type="text/javascript" src="jquery/jquery-ui.js"></script>
    
    <script>
        // nodig voor progressbar
        function progress(vraag, $element) {
            var progressBarWidth = (vraag+1)/53 * $element.width();
            $element.find('div').animate({ width: progressBarWidth }, 500).html(vraag+1 + "/53&nbsp;");
        }
        
        //nodig voor ja en nee knoppen te verbergen
        window.onload=function(){
            document.getElementById("toonKnoppen").style.display='none';
        }
    </script>  
</head>
<body>
    <div id="progressbar"><div></div></div>
    <script>progress(<?php echo $teller; ?>, $('#progressbar'));</script>
    
    <p><?php echo($alle_vragen[$teller][1]);?></p>
    <p><?php echo($alle_vragen[$teller][2]);?></p>
    <img id="foto_midden" src="image/foto/<?php echo $teller;?>.jpg"/>
    <p>Hoe ervaart u dit onderdeel?</p>
    <form method="POST">
        <input type="button" value="Verloopt naar wens?" onclick="opslaan" />
        <input type="button" value="Probleem - niet hinderlijk?" onclick="opslaan" />
        <input type="button" value="Probleem - hinderlijk voor client?" onclick="showKnoppen()" />
        <input type="button" value="Probleem - hinderlijk voor mantelzorger?" onclick="showKnoppen()" />
        <input type="button" value="Probleem - hinderlijk voor beide" onclick="showKnoppen()" />
        
        <!-- nodig voor het tonen van ja en nee knoppen -->
        <script>
            function showKnoppen(){
                document.getElementById("toonKnoppen").style.display='block';
            }
        </script>
        <div id="toonKnoppen">
            <p>Willen cliënt/mantelzorger dat hieraan gewerkt wordt?</p>
            <input type="button" value="Ja?" />
            <input type="button" value="Nee?" />
        </div>
        
        <input type="hidden" name="teller" value="<?php echo htmlspecialchars($teller);?>" />
        
        <div id="knoppen">
            <input type="submit" class="knop_l" name="richting" value="vorige" />
            <input type="submit" class="knop_r" name="richting" value="volgende" />
        </div>
    </form>
</body>
</html>
