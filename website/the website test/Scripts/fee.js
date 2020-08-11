$(document).ready(function(){  
  $(".search").click(function(){
  $(".search").hide("fast",function(){$(".form-control").show(),$(".button").show()});
});

 $(function(){
    var winH    = $(window).height(),
        upperH  = $('.upper-bar').innerHeight(),
        navH    = $('.nav-bar').innerHeight();
    $(".History-cover").height(winH-(upperH+navH));
    $(".History-cover").width($(window).width());
});
  
})