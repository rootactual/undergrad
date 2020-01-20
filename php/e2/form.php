<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8">
    <title>Form</title>
</head>

<body style="width:50%;">
    <form method="post" action="table.php">

        <fieldset>
        <legend>Two drop-down lists for Exam2</legend>
        <br><br>

        <label>Continent:<br>
            <select name="continent">
                <option>Pick a continent</option>
<?php
    $continents = array("Asia","Africa","Europe","North America","Oceania","South America");
    foreach($continents as $c) {
        echo '<option value="' . $c . '">' . $c . '</option>';
    }

?>
            </select>
        </label>
        <br><br><br>

        <label>Country:<br>
            <select name='country'>
                <option>Pick a country</option>
<?php
require_once '../mysqli_connect.php';

$sql = "SELECT DISTINCT Country FROM UserDetails ORDER BY Country ASC";
$statement = mysqli_prepare($db_conn, $sql);
mysqli_stmt_execute($statement);
mysqli_stmt_store_result($statement);
if(mysqli_stmt_num_rows($statement)>=1) {
        mysqli_stmt_bind_result($statement, $country);
        while (mysqli_stmt_fetch($statement))
                echo "\t\t\t\t<option>" . $country . "</option>\n";
}

?>
if (isset($POST['submit'])){
    $count = trim($_POST['country']);
    $cont = trim($_POST['continent']);
}
            </select>
        </label>
        <br><br><br>

        <input type="submit">

        </fieldset>
    </form>
</body>
</html>
