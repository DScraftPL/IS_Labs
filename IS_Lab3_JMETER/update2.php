<?php
$servername = "localhost";
$username = "sakila2";
$password = "pass";
$database = "sakila";
$conn = new mysqli($servername, $username, $password, $database);
if ($conn->connect_error) {
    die("Database connection failed: " . $conn->connect_error);
}
echo "Databse connected successfully, username " . $username . "<br><br>";
    //$id = isset($_POST['id']) ? intval($_POST['id']) : 0;
    //$value = isset($_POST['value']) ? $_POST['value'] : '';
    $id = 1;
    $value = "test_value";
    $sql = "UPDATE film_text SET title = '{$value}' WHERE film_id = {$id}";
    if($conn->query($sql)){
        echo "query passed";
    } else {
        echo "query failure";
    }
    $conn->close();
?>