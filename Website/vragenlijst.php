<!DOCTYPE html>
<?php
    /* CONNECTIE DATABASE */
session_start();
    
    /* TELLER INSTELLEN */
    if (isset($_POST['teller'])) {
        // TODO valideer dat teller een getal is
        $teller = $_POST['teller'];
    }else{
        $teller = 0;
    }

    //2 einde vragenlijst
    if($teller == 52){
        // volledige gegevens doorsturen naar database   
        header('Location: voltooide_vragenlijst.php');
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

        $waarden = array();
        for ($i = 0; $i <= 52; $i++) {
                array_push($waarden, $_SESSION["alle_antwoorden"][$i]);
        }
        print_r($waarden);
        $sql2 = "INSERT INTO antwoorden(vraag_1, vraag_2, vraag_3, vraag_4, vraag_5, vraag_6, vraag_7, vraag_8, vraag_9, vraag_10, vraag_11, vraag_12, vraag_13, vraag_14, vraag_15, vraag_16, vraag_17, vraag_18, vraag_19, vraag_20, vraag_21, vraag_22, vraag_23, vraag_24, vraag_25, vraag_26, vraag_27, vraag_28, vraag_29, vraag_30, vraag_31, vraag_32, vraag_33, vraag_34, vraag_35, vraag_36, vraag_37, vraag_38, vraag_39, vraag_40, vraag_41, vraag_42, vraag_43, vraag_44, vraag_45, vraag_46, vraag_47, vraag_48, vraag_49, vraag_50, vraag_51, vraag_52, vraag_53) VALUES($waarden[0], $waarden[1], $waarden[2], $waarden[3], $waarden[4], $waarden[5], $waarden[6], $waarden[7], $waarden[8], $waarden[9], $waarden[10], $waarden[11], $waarden[12], $waarden[13], $waarden[14], $waarden[15], $waarden[16], $waarden[17], $waarden[18], $waarden[19], $waarden[20], $waarden[21], $waarden[22], $waarden[23], $waarden[24], $waarden[25], $waarden[26], $waarden[27], $waarden[28], $waarden[29], $waarden[30], $waarden[31], $waarden[32], $waarden[33], $waarden[34], $waarden[35], $waarden[36], $waarden[37], $waarden[38], $waarden[39], $waarden[40], $waarden[41], $waarden[42], $waarden[43], $waarden[44], $waarden[45], $waarden[46], $waarden[47], $waarden[48], $waarden[49], $waarden[50], $waarden[51], $waarden[52] )";              // Mee bezig !!!
        $result = $conn->query($sql2);
        $conn->close();
    }

    if(isset($_SESSION["alle_vragen"])){
        // voor 1x vragen inteladen
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
    
    /* Where the magic happens */
    if (isset($_SESSION["alle_antwoorden"])){
        //
    }else{
        $_SESSION["alle_antwoorden"] = new SplFixedArray(53);
    }

    $antwoord = "";
    $antwoordJN = "";
    echo($teller);
    if (isset($_POST['richting'])) {
        $richting = $_POST['richting'];
        if ($richting === 'Volgende') {
            if (isset($_POST['antwoord'])){
                $antwoord = $_POST['antwoord'];
                //if(isset($_POST['antwoordJN'])){
                $antwoordJN = $_POST['antwoordJN'];
                //}
                $_SESSION["alle_antwoorden"][(integer)$teller] = $antwoord." ".$antwoordJN;
                //antwoord en antwoorJN terug op 0 *****  werkt nog niet 
                unset($_POST['antwoord']);
                unset($_POST['antwoordJN']);
                var_dump($_SESSION["alle_antwoorden"]);                
                //print($antwoord);
            }
            $teller += 1;
            
        } else if($richting === 'Vorige') {
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
                }
                
                function keuzejanee($l){
                        var z = document.getElementsByClassName("antwoordJN");
                        var b = z[$l].value;
                        document.getElementById("antwoordJN").value = b;
                }
            </script>
            <div id="toonKnoppen">
                <p>Willen cliënt/mantelzorger dat hieraan gewerkt wordt?</p>
                <button type="button" class="antwoordJN" value="Ja" onclick=keuzejanee(1)>Ja?</button>
                <button type="button" class="antwoordJN" value="Nee" onclick=keuzejanee(2)>Nee?</button>
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
