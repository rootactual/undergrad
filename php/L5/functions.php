<?php
    function constructRating($rating) {
        $imgTags = "";
        
        for ($i=0; $i < $rating; $i++) {
            $imgTags .= '<img src="images/star-gold.svg" atl="gold star" width="16">';
            }
    
        for ($i=$rating; $i < 5; $i++) {
            $imgTags .= '<img src="images/star-white.svg" alt="white star" width="16">';
        }
        return $imgTags;
    }
    ?>
