<?php 

	$servername = "mysql.hostinger.com.br";
	$username = "u695866113_root";
	$password = "Senha@88";
	$dbname = "u695866113_rpgjv";

	$conn = mysqli_connect($servername, $username, $password, $dbname);

	if (!$conn) {
		die("Connection failed: " . mysqli_connect_error());
	}
	
	$sql = "SELECT * FROM `BattleSpaceShip` WHERE `UserID`= '" . $_POST["UserID"] . "'";
	$result = mysqli_query($conn, $sql);
	
	if (mysqli_num_rows($result) > 0) {
		echo "Nickname não disponível.";
	} 
	else {
		$sql = "INSERT INTO `BattleSpaceShip`(`UserID`, `Senha`) VALUES ('" . $_POST["UserID"] . "','" . $_POST["Senha"] . "')";
		
		if (mysqli_query($conn, $sql)) 
		{
			echo "Record updated successfully";
		}
		else 
		{
			echo "Error updating record: " . mysqli_error($conn);
		}
	}
	
		
?>