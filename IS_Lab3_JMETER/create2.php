<?php
$servername = "localhost";
$username = "sakila2";
$password = "pass";
$database = "sakila";
$conn = new mysqli($servername, $username, $password, $database);
if ($conn->connect_error) {
    die("Database connection failed: " . $conn->connect_error);
}
echo "Database connected successfully, username " . $username . "<br><br>";
$value1 = isset($_POST['value1']) ? $_POST['value1'] : '';
$value2 = isset($_POST['value2']) ? $_POST['value2'] : '';
$value3 = isset($_POST['value3']) ? $_POST['value3'] : '';
$value4 = isset($_POST['value4']) ? $_POST['value4'] : '';
$sql = "CREATE TABLE IF NOT EXISTS test_table (id INT AUTO_INCREMENT PRIMARY KEY, name VARCHAR(50) NOT NULL)";
if($conn->query($sql)){
    echo "query passed";
} else {
    echo "query failure";
}
$sql = "INSERT INTO test_table (name) VALUES ('$value1')";
if($conn->query($sql)){
    echo "query passed";
} else {
    echo "query failure";
}
$sql = "INSERT INTO test_table (name) VALUES ('$value2')";
if($conn->query($sql)){
    echo "query passed";
} else {
    echo "query failure";
}
$sql = "INSERT INTO test_table (name) VALUES ('$value3')";
if($conn->query($sql)){
    echo "query passed";
} else {
    echo "query failure";
}
$sql = "INSERT INTO test_table (name) VALUES ('$value4')";
if($conn->query($sql)){
    echo "query passed";
} else {
    echo "query failure";
}
$conn->close();
?>