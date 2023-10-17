
        // Agregar un evento click a los enlaces "Completado"
    $(".completar-tarea").click(function () {
        completarTarea($(this)); //utilizamos este controlador de eventos de clic para que ejecute esta
            //función cuando se haga clic en cualquiera de los elementos que tenga como clase completar-tarea
        });

    function completarTarea(enlace) {
            var tareaId = enlace.attr("asp-route-id");
    $.ajax({
        type: "POST", // método HTTP adecuado para elcontrolador
    url: "/Tarea/Completar/" + tareaId, // ruta del controlador
    success: function () {
        // La solicitud se completó con éxito

        //aqui si quiero puedo recargar la pagina, pero igual seria redundante porque eso
        // se realiza en segundo plano a través de la solicitud AJAX,
        //en caso de que se requiere el codigo para forzar la recarga se utilizaria
        // location.reload();
    },
    error: function (xhr, status, error) {
        // Manejar errores si es necesario
        console.log("Error al completar la tarea: " + error);
                }
            });
        }
