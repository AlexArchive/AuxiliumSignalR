$(function () {
    $.connection.hub.url = "http://localhost:8080/signalr";
    var auxilium = $.connection.auxiliumHub;

    auxilium.client.addMessage = function (username, message) {
        $("#chat").append(username + ": " + message);
    };

    $("#connectForm").submit(function (event) {
        event.preventDefault();
        $("#connectButton").attr("disabled", "disabled");
        $("#username").attr("disabled", "disabled");
        $.connection.hub.start().done(function () {
            $("#sendButton").removeAttr("disabled");
            $("#message").removeAttr("disabled");
            $("#message").focus();
            $("#messageForm").submit(function (event) {
                event.preventDefault();
                auxilium.server.broadcast(
                    $("#username").val(),
                    $("#message").val() + "\r\n");
                $("#message").val("");
            });
        });
    });
});