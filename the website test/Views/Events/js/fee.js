$(document).ready(function(){  
  $(".search").click(function(){
  $(".search").hide("fast",function(){$(".form-control").show(),$(".button").show()});
});
  $(function(){
  var winH    = $(window).height(),
    upperH  = $('.upper-bar').innerHeight(),
    navH    = $('.nav-bar').innerHeight();
$(".Event-cover").height(winH-(upperH+navH));
$(".Event-cover").width($(window).width());
});
$(document).ready(function() {
$('.mdb-select').materialSelect();
});
})