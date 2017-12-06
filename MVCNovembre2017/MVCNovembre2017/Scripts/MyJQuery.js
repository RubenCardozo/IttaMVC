
$(document).ready(function () {

    var divs = $("div");
    divs
        .html(
        function(index, text){
            return text.toUpperCase();
           })

        .click(function () {
        console.log(this.innerHTML);//$this.text()
        });


    console.log($("div").text());

    $("#div1").addClass("red");
    $("div.red").append(" en rouge");
    $("div").addClass("redtext");//3ème div de la page
    $("div > p").css("border", "2px solid black")//les p enfants directs des div

    $("div:eq(3) > div:first-child").css("border", "2px solid blue")//Premier div enfant direct du 3ème div du doc

    $("div:eq(3) > div:odd").css("border", "2px solid pink")
    $("div:eq(3) > div:odd").click(
        function () {
            $(this).fadeToggle(1000, "swing", function () {
                $(this).fadeToggle(1000, function () {
                    //$(this).fadeToggle(1000);
                });
            });    
        });
    $("div:eq(3)").append("<div>nouvelle</div>");
    $("<div>").text("nouvelle 2").css("border", "2px solid pink").appendTo($("div:eq(3)"));
    $("<div>").text("nouvelle 3").css("border", "4px solid violet").insertAfter($("div:eq(3)"));
    $("<div>:eq(3)").wrap($("<div>").css("border","4px solid darkgreen"));
});