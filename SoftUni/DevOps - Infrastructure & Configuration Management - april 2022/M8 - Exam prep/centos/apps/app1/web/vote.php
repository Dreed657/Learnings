<?php 
  if (!isset($_POST['vote']))
    header('Location: index.php');

  require_once ('config.php');

  try
  {
    $connection = new PDO("mysql:host={$host};dbname={$database};charset=utf8", $user, $password);
    $query = $connection->query("INSERT INTO votecasts (voteoption) VALUES ('".$_POST['vote']."')");
    header('Location: result.php');
  }
  catch (PDOException $e) {
    die($e->getMessage());
  }
?>