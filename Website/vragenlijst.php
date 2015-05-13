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
       header('Location: voltooide_vragenlijst.php');
       $id=$_GET["id"];
       $waarden = array();
       // The data to send to the API
       for ($i = 0; $i <= 52; $i++) {
                array_push($waarden, $_SESSION["alle_antwoorden"][$i]);
        }
        
        //API Url
$url = 'http://finahback.azurewebsites.net/api/Vraags';
 
//Initiate cURL.
$ch = curl_init($url);
 
//The JSON data.
$jsonData = array(
    'rapportId' => $id,
    'vraag1' => $waarden[0],
    'vraag2' => $waarden[1],
    'vraag3' => $waarden[2],
    'vraag4' => $waarden[3],
    'vraag5' => $waarden[4],
    'vraag6' => $waarden[5],
    'vraag7' => $waarden[6],
    'vraag8' => $waarden[7],
    'vraag9' => $waarden[8],
    'vraag10' => $waarden[9],
    'vraag11' => $waarden[10],
    'vraag12' => $waarden[11],
    'vraag13' => $waarden[12],
    'vraag14' => $waarden[13],
    'vraag15' => $waarden[14],
    'vraag16' => $waarden[15],
    'vraag17' => $waarden[16],
    'vraag18' => $waarden[17],
    'vraag19' => $waarden[18],
    'vraag20' => $waarden[19],
    'vraag21' => $waarden[20],
    'vraag22' => $waarden[21],
    'vraag23' => $waarden[22],
    'vraag24' => $waarden[23],
    'vraag25' => $waarden[24],
    'vraag26' => $waarden[25],
    'vraag27' => $waarden[26],
    'vraag28' => $waarden[27],
    'vraag29' => $waarden[28],
    'vraag30' => $waarden[29],
    'vraag31' => $waarden[30],
    'vraag32' => $waarden[31],
    'vraag33' => $waarden[32],
    'vraag34' => $waarden[33],
    'vraag35' => $waarden[34],
    'vraag36' => $waarden[35],
    'vraag37' => $waarden[36],
    'vraag38' => $waarden[37],
    'vraag39' => $waarden[38],
    'vraag40' => $waarden[39],
    'vraag41' => $waarden[40],
    'vraag42' => $waarden[41],
    'vraag43' => $waarden[42],
    'vraag44' => $waarden[43],
    'vraag45' => $waarden[44],
    'vraag46' => $waarden[45],
    'vraag47' => $waarden[46],
    'vraag48' => $waarden[47],
    'vraag49' => $waarden[48],
    'vraag50' => $waarden[49],
    'vraag51' => $waarden[50],
    'vraag52' => $waarden[51],
    'vraag53' => $waarden[52]
);
 
//Encode the array into JSON.
$jsonDataEncoded = json_encode($jsonData);

 
//Tell cURL that we want to send a POST request.
curl_setopt($ch, CURLOPT_POST, 1);
 
//Attach our encoded JSON string to the POST fields.
curl_setopt($ch, CURLOPT_POSTFIELDS, $jsonDataEncoded);
 
//Set the content type to application/json
curl_setopt($ch, CURLOPT_HTTPHEADER, array('Content-Type: application/json')); 
 
//Execute the request
$result = curl_exec($ch);
        
        
        
        
        
        
        
        


       
       
       
       
/*        // volledige gegevens doorsturen naar database   
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
        
        //OPLETTEN de ID moet dus nog vervangen worden met het ID dat ik moet krijgen van de applicatie!!!!
        $waarden = array();
        for ($i = 0; $i <= 52; $i++) {
                array_push($waarden, $_SESSION["alle_antwoorden"][$i]);
        }
        $sql2 = "INSERT INTO antwoorden(vraag_1, vraag_2, vraag_3, vraag_4, vraag_5, vraag_6, vraag_7, vraag_8, vraag_9, vraag_10, vraag_11, vraag_12, vraag_13, vraag_14, vraag_15, vraag_16, vraag_17, vraag_18, vraag_19, vraag_20, vraag_21, vraag_22, vraag_23, vraag_24, vraag_25, vraag_26, vraag_27, vraag_28, vraag_29, vraag_30, vraag_31, vraag_32, vraag_33, vraag_34, vraag_35, vraag_36, vraag_37, vraag_38, vraag_39, vraag_40, vraag_41, vraag_42, vraag_43, vraag_44, vraag_45, vraag_46, vraag_47, vraag_48, vraag_49, vraag_50, vraag_51, vraag_52, vraag_53) VALUES('$waarden[0]', '$waarden[1]', '$waarden[2]', '$waarden[3]', '$waarden[4]', '$waarden[5]', '$waarden[6]', '$waarden[7]', '$waarden[8]', '$waarden[9]', '$waarden[10]', '$waarden[11]', '$waarden[12]', '$waarden[13]', '$waarden[14]', '$waarden[15]', '$waarden[16]', '$waarden[17]', '$waarden[18]', '$waarden[19]', '$waarden[20]', '$waarden[21]', '$waarden[22]', '$waarden[23]', '$waarden[24]', '$waarden[25]', '$waarden[26]', '$waarden[27]', '$waarden[28]', '$waarden[29]', '$waarden[30]', '$waarden[31]', '$waarden[32]', '$waarden[33]', '$waarden[34]', '$waarden[35]', '$waarden[36]', '$waarden[37]', '$waarden[38]', '$waarden[39]', '$waarden[40]', '$waarden[41]', '$waarden[42]', '$waarden[43]', '$waarden[44]', '$waarden[45]', '$waarden[46]', '$waarden[47]', '$waarden[48]', '$waarden[49]', '$waarden[50]', '$waarden[51]', '$waarden[52]' )";
        $result = $conn->query($sql2);
        $conn->close();
  */
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
    if (isset($_POST['richting'])) {
        $richting = $_POST['richting'];
        if ($richting === 'Volgende') {
            if (isset($_POST['antwoord'])){
                $antwoord = $_POST['antwoord'];
                //if(isset($_POST['antwoordJN'])){
                $antwoordJN = $_POST['antwoordJN'];
                //}
                $_SESSION["alle_antwoorden"][(integer)$teller] = $antwoord." ".$antwoordJN;
                //      antwoord en antwoorJN terug op 0 
                $antwoord = '';
                $antwoordJN = '';
                //var_dump($_SESSION["alle_antwoorden"]);                
            }
            $teller += 1;
            
        } else if($richting === 'Vorige') {
            if (isset($_POST['antwoord'])){
                $antwoord = $_POST['antwoord'];
                //if(isset($_POST['antwoordJN'])){
                $antwoordJN = $_POST['antwoordJN'];
                //}
                $_SESSION["alle_antwoorden"][(integer)$teller] = $antwoord." ".$antwoordJN;
                //      antwoord en antwoorJN terug op 0 
                $antwoord = '';
                $antwoordJN = '';
                //var_dump($_SESSION["alle_antwoorden"]);                
            }
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
    <script src="//code.jquery.com/jquery-1.11.3.min.js"></script>
    
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
            <button type="button" class="antwoord" value="0" onclick="showKnoppen(0)">Verloopt naar wens?</button>
            <button type="button" class="antwoord" value="1" onclick="showKnoppen(1)">Probleem - niet hinderlijk?</button>
            <button type="button" class="antwoord" value="2" onclick="showKnoppen(2)">Probleem - hinderlijk voor client?</button>
            <button type="button" class="antwoord" value="3" onclick="showKnoppen(3)">Probleem - hinderlijk voor mantelzorger?</button>
            <button type="button" class="antwoord" value="4" onclick="showKnoppen(4)">Probleem - hinderlijk voor beide</button>
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
                    var k = document.getElementsByClassName("antwoordJN");
                    var m = k[$l].value;
                    document.getElementById("antwoordJN").value = m;
                }
            </script>
            <div id="toonKnoppen">
                <p>Willen cliënt/mantelzorger dat hieraan gewerkt wordt?</p>
                <button type="button" class="antwoordJN" value="0" onclick=keuzejanee(0)>Ja</button>
                <button type="button" class="antwoordJN" value="1" onclick=keuzejanee(1)>Nee</button>
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
