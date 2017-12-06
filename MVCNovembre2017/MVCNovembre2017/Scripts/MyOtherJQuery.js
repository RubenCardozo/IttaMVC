$(document).ready(function () {
    //*************************************
    //Ajax
    //*************************************

    $("#serial").click(
        function () {
        console.log($("form").serialize());
    });

    $.ajaxSetup({
        type: "GET",
        dataType: "json",
        timeout: 1000,
        cache: false,
        error: function (value, status, error) {
            console.log(status + " - " + error);
        },
        complete: function (value, status) {
            console.log("TAF!");
        }
    })


    $("#ajax").click(
        function () {
            $.ajax(
                {
                    url: "/Home/Lapins",
                    type: "GET",
                    data: { nom: "bugs" },//request params
                    dataType: "json",
                    sucess: function (value, status) {
                        console.log(value);
                        $("#Nom").val(value.nom);
                        $("#Prenom").val(value.prenom);
                        var d = new Date(value.dateNaissance);
                        $("#DateNaissance").val(d.toLocaleDateString("fr-ch"));
                    },
                    error: function (value, status, error) {
                        console.log(status +" - "+ error);
                    },
                    complete: function (value, status) {
                        console.log("TAF!");
                    }
                });
            
        }
    );



    //*********************************
    //Button Test
    //*********************************


    $("button[type='button']").click(
        function () {
            console.log($("input#Id").val());
        })
    $("form").submit(function (event) {
        if ($("#Prenom").val().toUpperCase() == 'NORRIS') {
            var s = $("span[data-valmsg-for='Prenom']")[0];
            $(s).remove();
            var st = s.outerHTML;
            $(st.replace("Prenom", "_Prenom")
                .replace("field-validation-valid", "field-validation-error"))
                .text('essaie Maurice!').insertAfter($("#Prenom"));
            event.preventDefault();
        }
    });
    $("form").validate({
        rules: {
            Prenom: {
                required: true,
                minlength: 1,
                regex:'[a-zA-Z -]+'
            },
        },
        messages: {
            Prenom: "Veuillez fournir un prénom"
        }
    });
});