<?php
include 'includes/header.php';
if (isset($_POST['submit'])){
	//Validate form data when submitted
	$errors=array(); //An array to store any feedback messages to the user
	if (empty($_POST['firstname']))
        $errors['first'] = 'First name is required:<br>';
    else
        $firstname = trim($_POST['firstname']);

    if (empty($_POST['lastname']))
        $lastname = NULL;
    else
        $lastname = trim($POST['lastname']);

    $valid_email = filter_input(INPUT_POST, 'email', FILTER_VALIDATE_EMAIL);
    if ($valid_email)
        $email = trim($valid_email);
    else
        $errors['email'] = 'You must enter a valid email address:<br>';


    $pw1 = trim($_POST['pw1']);
	$pw2 = trim($_POST['pw2']);
    // Check for a password:
    if (empty($pw1) || empty($pw2))
        $errors['missingpw']='Please enter your desired password twice:<br>';
    elseif ($pw1 !== $pw2)
    $errors['mismatch']='Those passwords do not match. Try again:<br>';
    else $password = $pw1;

	if (!$errors){ //Add user to the database and exit
		require_once '../mysqli_connect.php';
        $sql = "SELECT UserName FROM Users WHERE UserName = ?";
        $statement = mysqli_prepare($db_conn, $sql);
        //bind parameter: i - integer, d - double, s - string, b -blob
        //one letter for each ? in the query string
        mysqli_stmt_bind_param($statement, 's', $email);
        mysqli_stmt_execute($statement);
        mysqli_stmt_store_result($statement);
        mysqli_stmt_fetch($statement);
        if(mysqli_stmt_num_rows($statement)==1){ //It found the email address in the DB
            echo "This email address is already in use. <br>Please login or use another email address:<br>";
        }
        else { //email not found, add user
            $sql2 = "INSERT INTO Users (UserName, Password) VALUES (?, ?)";
            $statement2 = mysqli_prepare($db_conn, $sql2);
             //bind parameter: i - integer, d - double, s - string, b -blob
             //one letter for each ? in the query string
             mysqli_stmt_bind_param($statement2, 'ss', $email, $password);
             mysqli_stmt_execute($statement2);
             mysqli_stmt_store_result($statement2);
             mysqli_stmt_fetch($statement2);
             if (mysqli_stmt_affected_rows($statement2)==1) {//It ran OK
                //retreive the autoincrement value assigned to the new user UID
                $last_id = mysqli_insert_id($db_conn);
                $sql3 = "INSERT INTO UserDetails (UID, FirstName, LastName) VALUES (?, ?, ?)";
                $statement3 = mysqli_prepare($db_conn, $sql3);
                 //bind parameter: i - integer, d - double, s - string, b -blob
                 //one letter for each ? in the query string
                 mysqli_stmt_bind_param($statement3, 'iss', $last_id, $firstname, $lastname);
                 mysqli_stmt_execute($statement3);
                 mysqli_stmt_store_result($statement3);
                 mysqli_stmt_fetch($statement3);
                 if(mysqli_stmt_affected_rows($statement3)==1){
                 	echo "<h3>User was successfully added!</h3>";
                 }
				 else {
					 echo "<h3>We are not able to add this data right now. Please try again later.</h3>";
				 }
			}
        }
		exit;
    } //end !$errors
} //end if submit
?>

    <!-- Page Content -->
    <main class="container">
        <div class="panel panel-default">
          <div class="panel-heading">
			Please create an account to Share Your Travels
		  </div>
          <div class="panel-body">
		  <!-- Registration form displaying error messages if needed and including sticky, valid input upon redisplay -->
            <form action="register.php" method="post">
            <?php
				if ($errors) {
                	echo'<strong>Please correct the following:</strong';
            	}
			?>
			  <fieldset>
				<p>
					<?php if (isset($errors['firstname'])) echo '<strong'.$errors['firstname'].'</strong>';
					?>
                  <label>First Name: <br>
					  <input name="firstname" type="text" <?php if (isset($firstname)) echo 'value="' . htmlspecialchars($firstname) . '"';?> >
				  </label>
                </p>
                <p>
                  <label>Last Name: <br>
                    <input name="lastname" type="text" <?php if (isset($lastname)) echo 'value="' . htmlspecialchars($lastname) . '"';?>
                  </label>
                </p>
                <p>
<?php if (isset($errors['email'])) echo '<strong'.$errors['email'].'</strong>';?>
                 <label>Email: <br>
                   <input name="email" type="text" <?php if (isset($email)) echo 'value="' . htmlspecialchars($email) . '"';?>
                 </label>
               </p>
                <p>
<?php if (isset($errors['pw1'])) echo '<strong'.$errors['pw1'].'</strong>';?>
                  <label>Password: <br>
                    <input name="pw1" type="password">
                  </label>
                </p>
                <p>
<?php if (isset($errors['pw2'])) echo '<strong'.$errors['pw2'].'</strong>';?>
                  <label>Confirm Password: <br>
                    <input name="pw2" type="password">
                  </label>
               </p>


				<p>
				  <input name="submit" type="submit" value="Register">
				</p>
			  </fieldset>
			</form>
          </div>
        </div>
    </main>
    <?php include "includes/footer.php"; ?>
