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
	$sql = "SELECT * FROM `Partidas` WHERE `Player1` = ''";
	$result = mysqli_query($conn, $sql);
	
	if (mysqli_num_rows($result) > 0) {
		$sql = "UPDATE `Partidas` SET `Player1`= '".$_GET["UserID"]."' WHERE Player1 = '' ";
		if(mysqli_query($conn, $sql))
		{
			echo"You are already in game"; 
		}
	}
	else if(mysqli_num_rows($result) == 0)
	{
		$sql2 = "SELECT * FROM `Partidas` WHERE `Player1` != '' AND Player2 = '' ";
		if(mysqli_query($conn, $sql2) > 0)
		{
			$cmd = "UPDATE `Partidas` SET `Player2`= '".$_GET["UserID"]."' WHERE Player2 = ''";
		
			if(mysqli_query($conn, $cmd))
			{
				echo"You are already in game"; 
			}
			else{
				echo "Not found.";
			}
		}
	}
	else {
		if(mysqli_query($conn, "INSERT INTO `Partidas`(`id`, `Player1`, `Player2`, `Vencedor`) VALUES (NULL,'".$_GET["UserID"]."',NULL,NULL)"))
		{
			echo "Waiting for Players";
		}
		else
		{
			echo "Error";
		}
	}
	

mysqli_close($conn);
?>