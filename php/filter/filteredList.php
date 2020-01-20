<?php
include 'includes/header.php';
require_once '../mysqli_connect.php';

/* Populate the select list with continents from the db */
//Write the SQL query as a PHP string
$sqlCon="SELECT * from Continents ORDER BY ContinentName";

//Execute the query using the current db connection
$allContinents = mysqli_query($db_conn, $sqlCon);

//Fetch the results as an associative array
mysqli_fetch_all($allContinents, MYSQLI_ASSOC);


/* Populate the select list with countries from the db */
$sqlCountry="SELECT * from Countries ORDER BY CountryName";
$allCountries = mysqli_query($db_conn, $sqlCountry);
mysqli_fetch_all($allCountries, MYSQLI_ASSOC);




//Determine if filter applied before displaying images
if (isset($_GET['continent']) && !empty($_GET['continent']) ) {
	$continent = $_GET['continent'];
  $sqlImages = "SELECT * FROM ImageDetails where ContinentCode='$continent'";
}
// see if we should filter by a country
else if (isset($_GET['country']) && !empty($_GET['country'])) {
	$country = $_GET['country'];
  $sqlImages = "SELECT * FROM ImageDetails where CountryCodeISO='$country'";
}
else if (isset($_GET['title']) && ! empty($_GET['title'])) {
	$title=$_GET['title'];
  $sqlImages = "SELECT * FROM ImageDetails where Title LIKE '%$title%'";
}
else {
  $sqlImages = "SELECT * FROM ImageDetails LIMIT 0, 16";
}
//Retrieve images based on the $sqlImages string
$images = mysqli_query($db_conn, $sqlImages);
mysqli_fetch_all($images, MYSQLI_ASSOC);
?>

    <!-- Page Content -->
    <main class="container">
        <div class="panel panel-default">
          <div class="panel-heading">Filters: Choose to view images by either Continent or Country</div>
          <div class="panel-body">
            <form action="filteredList.php" method="get" class="form-horizontal">
              <div class="form-inline">
              <select name="continent" class="form-control">
                <option value="0">Select Continent</option>
                <?php foreach($allContinents as $con) {
                  echo '<option value="' . $con['ContinentCode'] . '">' . $con['ContinentName'] . '</option>';
                } ?>
              </select>

              <select name="country" class="form-control">
                <option value="0">Select Country</option>
                <?php foreach($allCountries as $country) {
                  echo '<option value="' . $country['ISO'] . '">' . $country['CountryName'] . '</option>';
                }
				?>
              </select>
              <input type="text"  placeholder="Search title" class="form-control" name="title">
              <button type="submit" class="btn btn-primary">Filter</button>
              </div>
            </form>

          </div>
        </div>

		<!--Display filtered images -->
		<ul class="caption-style-2">
		<?php foreach ($images as $img) {   ?>
			   <li>
            <a href="imgDetail.php?id=<?php echo $img['ImageID']; ?>" class="img-responsive">
    				<img src="images/square-medium/<?php echo $img['Path']; ?>" alt="<?php echo $img['Title']; ?>">
    				<div class="caption">
    					<div class="blur"></div>
    					<div class="caption-text">
    						<p><?php echo $img['Title']; ?></p>
    					</div>
    				</div>
            </a>
			  </li>
          <?php } ?>
       </ul>


    </main>

    <?php include "includes/footer.php"; ?>
