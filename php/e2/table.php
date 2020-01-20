<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8">
    <title>Table</title>
    <style>
        table {
            border: 2px solid #AAAAAA;
            width: 50%;
        }
        tr:nth-child(even) {background-color: #BBBBBB;}
        th {background-color: #4488FF;}
        td {padding: 1px 1px 1px 20px;}
    </style>
</head>

<body>
<?php
if ($_GET['country'] == "Pick a country")
        echo "<h2>Not receiving a country value from form.php</h2>";
else {
        echo "<h2>Users from:  " . $_GET['country'] . "</h2>";

        require_once '../mysqli_connect.php';
    $sql = "SELECT FirstName, LastName, City FROM UserDetails WHERE Continent=continent, Country=country ORDER BY LastName ASC";
        $statement = mysqli_prepare($db_conn, $sql);

        mysqli_stmt_execute($statement);
        mysqli_stmt_store_result($statement);
        if(mysqli_stmt_num_rows($statement)>=1) {
                mysqli_stmt_bind_result($statement, $first, $last);
?>
    <table>
        <tr>
            <th>First name</th>
            <th>Last name</th>
            <th>City</th>
        </tr>
<?php           while (mysqli_stmt_fetch($statement)) { ?>
        <tr>
            <td><?php echo $first; ?></td>
            <td><?php echo $last; ?></td>

        </tr>
<?php
                }
        }
        else
                echo "<h2>No users found</h2>";
}
?>
    </table>
</body>
</html>
