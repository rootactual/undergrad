<!DOCTYPE html>
<html lang="en">
	<head >
	   <meta charset="utf-8">
	   <title>IT-Shirts</title>
	</head>
	<body>
		<h1>Your IT-Shirt Order:</h1>
		<h2>Form data received</h2>
		<?php
			$name = $_POST["name"];
			$address = $_POST["address"];
			$size = $_POST["size"];
			$qty = $_POST["qty"];
			$rush = $_POST["rush"];

			echo "Customer: " . $name . "<br>";
			echo "Address: " . $address . "<br>";
			echo "Size: " . $size . "<br>";
			echo "Quantity: " . $qty . "<br>";
			if(isset($_POST["rush"])){
				echo "rush order";
			}

		?>
	</body>
</html>
