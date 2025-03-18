<?php
$servername = "localhost";
$username = "sakila1";
$password = "pass";
$database = "sakila";
$conn = new mysqli($servername, $username, $password, $database);
if ($conn->connect_error) {
    die("Database connection failed: " . $conn->connect_error);
}
echo "Databse connected successfully, username " . $username . "<br><br>";
    $value = isset($_POST['value']) ? $_POST['value'] : '';
    $sql = "DELETE FROM test_table WHERE name = '$value'";
    if($conn->query($sql)){
        echo "query passed";
    } else {
        echo "query failure";
    }
    $conn->close();
?>