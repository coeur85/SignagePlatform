function initSlideShow(id) {
    $('#slide_' + id).carousel({
            interval: slideTime
        })
        .on('slid.bs.carousel', function() {
            curSlide = $('.active');
            if (id == 0) {
                var totalItems = $('#slide_' + id + ' .carousel-inner').children().length;
                var currentIndex = $('#slide_' + id + ' .active').index();
                console.log('t:' + totalItems + ',c:' + currentIndex);
                if (currentIndex == 0) {
                    console.log('slide show is over');
                    $('.carousel').carousel('pause');
                    playVideo();
                }
            }

            return;
        });

}





    $('#picturesContaier').slideUp();
    $('#bGomlaVideo').trigger('play');
    $('#videoContainer').show();


}


function playPics() {
    $('#picturesContaier').slideDown();
    $('.carousel').carousel('cycle');
    $('#videoContainer').hide();
    $('#bGomlaVideo').trigger('pause');
    $('#bGomlaVideo').currentTime = 0;

}