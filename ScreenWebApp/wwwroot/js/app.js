var pictureCycleCount = 0;
var sliderOnlyOnce = true;
var appInstance;

function initAppistance(appi) {
    appInstance = appi;
}



function addSliderEventMonitor() {
    $('#slide_0').on('slid.bs.carousel', function() {


        var totalItems = $('#slide_0 .carousel-inner').children().length;
        var currentIndex = $('#slide_0 .active').index();

        if (currentIndex == 0 && (pictureCycleCount == CycleTimesBeforeVideo)) {
            console.log('slide show is over');
            $('.carousel').carousel('pause');
            checkForUpdate(appInstance);
            playVideo();
            pictureCycleCount = 0;
        }
        if (currentIndex == (totalItems - 1)) {
            pictureCycleCount += 1;
            if (pictureCycleCount > CycleTimesBeforeVideo) {
                pictureCycleCount = CycleTimesBeforeVideo;
            }
        }
        console.log('t:' + totalItems + ',c:' + currentIndex + ",oc:" +
            CycleTimesBeforeVideo + ",cc:" + pictureCycleCount);


        return;
    });
}



function initSlideShow() {
    $('.carousel').carousel({
        interval: slideTime
    })
    console.log('init slide show');
    addSliderEventMonitor();
}



function checkForUpdate(instance) {
    appInstance = instance;
    instance.invokeMethodAsync('CheckForPicturesUpdate')
        .then(() => {
            console.log('the picture method was called from js');
        });
}


function playVideo() {
    document.getElementById('bGomlaVideo').load();
    $('#videoContainer').show();
    $('#picturesContaier').slideUp('slow');
    $('#bGomlaVideo').trigger('play');
}


function playPics(id) {
    $('#videoContainer').hide();
    $('#picturesContaier').slideDown();
    $('.carousel').carousel('cycle');
    $('#bGomlaVideo').trigger('pause');
    $('#bGomlaVideo').currentTime = 0;
    appInstance.invokeMethodAsync('CheckForVediosUpdate')
        .then(() => {
            console.log('the vedio method was called from js');
        });
}

function reLoadVideo(id) {
    document.getElementById(id).load();
    console.log('video has been reloaded');
}

function disposeSlider() {
    $('.carousel').carousel('dispose');
}


//document.body.style.cursor = 'none';