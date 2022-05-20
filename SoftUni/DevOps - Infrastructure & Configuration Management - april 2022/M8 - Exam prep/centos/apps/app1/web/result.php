<h1>Voting Time! Which one you like most?</h1>
<h2>Results so far</h2>
<?php
require_once ('config.php');

try {
  $connection = new PDO("mysql:host={$host};dbname={$database};charset=utf8", $user, $password);
  $query = $connection->query("SELECT voteoption, COUNT(*) votecnt FROM votecasts GROUP BY voteoption ORDER BY 2 DESC");
  $voteoptions = $query->fetchAll();
  
  if (empty($voteoptions)) {
    echo "<tr><td>No data.</td></tr>\n";
  } else {
    print "<ol>\n";
    foreach ($voteoptions as $option) {
      print "<li>".$option['voteoption']." (".$option['votecnt'].")</li>\n";
    }
    print "</ol>\n";
  }
}
catch (PDOException $e) {
  print "<tr><td><div align='center'>\n";
  print "No connection to the database. Try again later. <a href=\"#\" onclick=\"document.getElementById('error').style = 'display: block;';\">Details</a><br/>\n";
  print "<span id='error' style='display: none;'><small><i>".$e->getMessage()." <a href=\"#\" onclick=\"document.getElementById('error').style = 'display: none;';\">Hide</a></i></small></span>\n";
  print "</div></td></tr>\n";
}
print "<small>Processed by ".gethostname()."</small>\n";
?>