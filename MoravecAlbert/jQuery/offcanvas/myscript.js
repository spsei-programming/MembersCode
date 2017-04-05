$(function() {
    $("h2:even").css("color", "red");
    $("h2:odd").css("color", "blue");

    $(".list-group-item:gt(2)").hide();

    $(".jumbotron").hide();

    $(".navbar-brand").text("Offcanvas");
    
    $(".toggle-btn").data("state", "shown");
    $(".toggle-btn").text("Hide");
    $(".toggle-btn").click(function() {
        var btn = $(this);
        $(this).parent().siblings("p").slideToggle("slow", function(btn) {
            if (btn.data("state") === "shown") {
                btn.data("state", "hide");
                btn.text("Show");
            } else {
                btn.data("state", "shown");
                btn.text("Hide");
            }
        }(btn));
    });
});