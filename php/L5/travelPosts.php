<?php require 'includes/header.php'; include 'includes/functions.php'; ?>
    <main class="container">
        <div class="row">
            <aside class="col-md-2">
            
            <?php include 'includes/left-nav.php';?>
            
            <div class="col-md-10">
                <div class="jumbotron" id="postJumbo">
                    <h1>Posts</h1>
                    <p>Read other travellers &39; posts ... or create your own.</p>
                    <p><a class="btn btn-warning btn-lg">Learn more &raquo;</a></p>
                </div>        
      
                 <div class="postlist">
                   <div class="row">
                       <div class="col-md-4"> 
                          <a href="post.php?id=1" class=""><img src="images/8710320515.jpg" alt="Ekklisia Agii Isidori church" class="img-responsive"></a>
                       </div>
                       <div class="col-md-8"> 
                          <h2>Ekklisia Agii Isidori Church</h2>
                          <div class="details">
                            Posted by <a href="user.php?id=2">Leonie Kohler</a>
                            <span class="pull-right">2/8/2017</span>
                            <p class="ratings"><?php echo constructRating(3); ?> 15 Reviews</p>
                        </div>
                          <p class="excerpt">
                          At the end of the hot climb up to the top Lycabettus Hill you are greeted with
                              the oasis that is the Ekklisia Agii Isidori church.
                          </p>
                          <p class="pull-right"><a href="post.php?id=1" class="btn btn-primary btn-sm">Read more</a></p>
                       </div>
                   </div>  <!-- /.row -->
                   <hr>

                   <div class="row">
                       <div class="col-md-4"> 
                          <a href="post.php?id=3" class=""><img src="images/8710247776.jpg" alt="Santorini Sunset" class="img-responsive"></a>
                       </div>
                       <div class="col-md-8"> 
                          <h2>Santorini Sunset</h2>
                          <div class="details">
                            Posted by <a href="user.php?id=5">Frantisek  Wichterlova</a>
                            <span class="pull-right">9/9/2017</span>
                            <p class="ratings"><?php echo constructRating(5);?> 38 Reviews</p>
                        </div>
                          <p class="excerpt">
                          Every evening as the sun sets in Fira, it seems that everyone who is not drinking or eating is rushing with their camera to the most picturesque locations in order to capture that famous Aegean sunset. 
                          </p>
                          <p class="pull-right"><a href="post.php?id=3" class="btn btn-primary btn-sm">Read more</a></p>
                       </div>
                   </div>   <!-- /.row -->
                   <hr>

                   <div class="row">
                       <div class="col-md-4"> 
                          <a href="post.php?id=9" class=""><img src="images/8710289254.jpg" alt="Looking towards Fira" class="img-responsive"></a>
                       </div>
                       <div class="col-md-8"> 
                          <h2>Looking towards Fira</h2>
                          <div class="details">
                            Posted by <a href="user.php?id=13">Edward Francis</a> 
                            <span class="pull-right">10/19/2017</span>
                            <p class="ratings"> <?php echo constructRating(2); ?> 3 Reviews</p>
                        </div>
                          <p class="excerpt">
                          The steamer Mongolia, belonging to the Peninsular and Oriental Company, built of iron, of two thousand eight hundred tons burden, and five hundred horse-power, was due at eleven o'clock a.m. on Wednesday, the 9th of October, at Suez. 
                          </p>
                          <p class="pull-right"><a href="post.php?id=9" class="btn btn-primary btn-sm">Read more</a></p>
                       </div>
                   </div>   <!-- /.row -->
                   <hr>
                                          
                 </div>   <!-- end postlist -->         
                            
            </div>  <!-- end col-md-10 -->
        </div>   <!-- end row -->
    </main>
<?php include 'includes/footer.php'; ?>
