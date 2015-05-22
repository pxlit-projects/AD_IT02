<!DOCTYPE html>
<?php
session_start();
    $id=$_GET['id'];
    

$_SESSION['id'] = $id;
    ?>


<html>
<head>
    <title>Finah - inleiding</title>
    <meta charset="UTF-8">
    <!-- Mobiel vriendelijke viewport -->
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <!-- css file -->
    <link href="css/main.css" rel="stylesheet" type="text/css"/>
</head>
<body>
    <div id="content">
        <!-- <weet niet hoe de gegevens binnenkomen voor de naam -->
        <p>Beste meneer/mevrouw <?php /* echo $_POST(name)*/?>.</p>
        <p>Hier een korte inleiding over de enquete die we gaan afnemen.</p>
        <div>
            Lorem ipsum dolor sit amet, consectetur adipiscing elit. Pellentesque consequat augue urna, in porta lectus ullamcorper id. Sed ultricies molestie magna, nec velit. Nam ornare nulla at finibus dictum. Ut sagittis lorem nisi, id pharetra tellus egestas eu. Vestibulum ac nisi rhoncus libero tincidunt eleifend. Nullam non enim nec quam hendrerit fringilla. Duis vitae tristique urna. Nunc porttitor nec mi ac convallis. Aliquam id vulputate nibh, ut vehicula lorem. Proin in condimentum diam, at tincidunt felis. Cras ultricies metus fringilla sollicitudin consequat. Nunc et interdum ex, sit amet scelerisque eros. Aliquam elementum ut lorem non placerat. Nulla laoreet orci nec ex sagittis dictum.         
        </div>
        
         <form method="get" action="vragenlijst.php">
    <input type="hidden" name="id" value="id">
    <input type="submit" value="volgende">
</form>
       
</form>
    </div>
</body>
</html>