<?php

	$servername = "mysql.hostinger.com.br";
	$username = "u695866113_root";
	$password = "Senha@88";
	$dbname = "u695866113_rpgjv";

	// Create connection
	$conn = mysqli_connect($servername, $username, $password, $dbname);

	// Check connection
	if (!$conn) {
		die("Connection failed: " . mysqli_connect_error());
	}
	$sql = "SELECT * FROM `BattleSpaceShip` WHERE `UserID`='" . $_GET["UserID"] . "'";
	$result = mysqli_query($conn, $sql);
	
	if (mysqli_num_rows($result) > 0) {
		while($row = mysqli_fetch_assoc($result)) {
			echo "Senha=" . $row["Senha"]. ";";
		}
	} else {
		echo "error";
	}
	

mysqli_close($conn);
?>