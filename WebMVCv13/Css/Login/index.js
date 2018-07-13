$('.message a').click(function(){
    $('.frm').animate({ height: "toggle", opacity: "toggle" }, "slow");
    $('.MessEr').hide();
    document.getElementById("username").placeholder = "Enter Username";
});