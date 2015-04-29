<!DOCTYPE html>
<?php
    /* CONNECTIE DATABASE */

session_start();

    if(isset($_SESSION["alle_vragen"])){
        //
    }else{
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

    $_SESSION["alle_vragen"] = array();
    while($row = $result->fetch_assoc()) {
        array_push($_SESSION["alle_vragen"], array($row["vraag_id"], $row["vraag_thema"], $row["vraag"]));
    }
    $conn->close();
    }

    /* TELLER INSTELLEN */
    $teller = 0;
    if (isset($_POST['teller'])) {
        // TODO valideer dat teller een getal is
        $teller = $_POST['teller'];
    }
    
    
    if (isset($_SESSION["alle_antwoorden"])){
        
    }else{
        $_SESSION["alle_antwoorden"] = new SplFixedArray(53);
    }
    $antwoord = "";
    $antwoordJN = "";
    if (isset($_POST['richting'])) {
        $richting = $_POST['richting'];
        if ($richting === 'Volgende') {
            //1 opslaan vraag
            if (isset($_POST['antwoord'])){
                $antwoord = $_POST['antwoord'];
                $_SESSION["alle_antwoorden"][(integer)$teller] = $antwoord;
                
                var_dump($_SESSION["alle_antwoorden"]);
                // nodig voor antwoord weer leeg te maken
                $_POST['antwoord'] = null;
                print($antwoord);
            }/*else{
                $leeg= "leeg";
                var_dump($leeg);
            }*/
            $teller += 1;
            //2 einde vragenlijst
            if($teller == 53){
                // volledige gegevens doorsturen naar database   
                
                var_dump($_SESSION["alle_antwoorden"]);
                header('Location: voltooide_vragenlijst.php');               
            }
            
        } elseif ($richting === 'Vorige') {
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
    <div id="content">
        <div id="progressbar"><div></div></div>
        <script>progress(<?php echo $teller; ?>, $('#progressbar'));</script>

        <p><?php echo($_SESSION["alle_vragen"][$teller][1]);?></p>
        <p><?php echo($_SESSION["alle_vragen"][$teller][2]);?></p>
        <img id="foto_midden" src="image/foto/<?php echo $teller;?>.jpg"/>
        <p>Hoe ervaart u dit onderdeel?</p>
        <form method="POST" action="<?php echo $_SERVER['PHP_SELF']; ?>">
            <button type="button" class="antwoord" value="Verloopt naar wens?" onclick="showKnoppen(0)">Verloopt naar wens?</button>
            <button type="button" class="antwoord" value="Probleem - niet hinderlijk?" onclick="showKnoppen(1)">Probleem - niet hinderlijk?</button>
            <button type="button" class="antwoord" value="Probleem - hinderlijk voor client?" onclick="showKnoppen(2)">Probleem - hinderlijk voor client?</button>
            <button type="button" class="antwoord" value="Probleem - hinderlijk voor mantelzorger?" onclick="showKnoppen(3)">Probleem - hinderlijk voor mantelzorger?</button>
            <button type="button" class="antwoord" value="Probleem - hinderlijk voor beide" onclick="showKnoppen(4)">Probleem - hinderlijk voor beide</button>
            <!-- nodig voor het tonen van ja en nee knoppen -->
            <script>
                function showKnoppen($a){
                    if($a==2 || $a==3 || $a==4){
                        document.getElementById("toonKnoppen").style.display='block';
                    }else{
                        document.getElementById("toonKnoppen").style.display='none';
                    }
                    
                    var x = document.getElementsByClassName("antwoord");
                    var y = x[$a].value;
                    document.getElementById("antwoord").value = y;
                    
                    var z = document.getElementsByClassName("antwoordJN");
                    var a = z[$a].value;
                    document.getElementById("antwoordJN").value = a;
                    
                }
            </script>
            <div id="toonKnoppen">
                <p>Willen cliënt/mantelzorger dat hieraan gewerkt wordt?</p>
                <button type="button" id="antwoordJN" value="Ja" >Ja?</button>
                <button type="button" id="antwoordJN" value="Nee">Nee?</button>
            </div>
            <div id="knoppen">
                <input type="submit" class="knop_l" name="richting" value="Vorige" />
                <input type="submit" class="knop_r" name="richting" value="Volgende" />
            </div>
            
            <input type="hidden" id="antwoord" name="antwoord" value="<?php echo htmlspecialchars($antwoord)?>" />
            <input type="hidden" id="antwoordJN" name="antwoordJN" value="<?php echo htmlspecialchars($antwoordJN)?>" />
            <input type="hidden" name="teller" value="<?php echo htmlspecialchars($teller);?>" />
            
        </form>
    </div>
</body>
</html>
