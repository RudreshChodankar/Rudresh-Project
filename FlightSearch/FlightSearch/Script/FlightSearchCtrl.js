$(document).ready(function () {
    AuthorizeToken();
});
function Clear() {
    $("#txtOrigin").val("");
    $("#txtDestination").val("");
    $("#txtAirlineCode").val("");
    $("#txtDeparture").val("");
    $("#flightresulttable").find("tr:not(:first)").remove();
}
function SearchFlight() {
    $("#flightresulttable").find("tr:not(:first)").remove();

    var bearer = sessionStorage.getItem("Token");

    var strAirlineCode = $("#txtAirlineCode").val();
    var strOrigin = $("#txtOrigin").val();
    var strDestination = $("#txtDestination").val();
    var dtDeparture = $("#txtDeparture").val();
    var id = 1;
    $.ajax({
        url: 'http://localhost:11159/api/Flight',
        type: 'GET',
        dataType: "json",
        data: { 'strAirlineCode': strAirlineCode, 'strOrigin': strOrigin, 'strDestination': strDestination, 'dtDeparture': dtDeparture },
        headers: { "Authorization": 'Bearer ' + bearer },
        success: function (data) {

            var datavalue = data;
            var tr;
            for (var i = 0; i < data.length; i++) {
                tr = $('<tr/>');
                tr.append("<td>" + data[i].airLine + "</td>");
                tr.append("<td>" + data[i].airLineCode + "</td>");
                tr.append("<td style='text-align: right'>" + data[i].flightNumber + "</td>");
                tr.append("<td>" + data[i].origin + "</td>");
                tr.append("<td style='text-align: right'>" + data[i].availableSeats + "</td>");
                tr.append("<td>" + data[i].destinations + "</td>");
                tr.append("<td style='text-align: right'>" + data[i].price + "</td>");
                tr.append("<td>" + data[i].departure + "</td>");
                tr.append("<td>" + data[i].arrival + "</td>");
                tr.append("<td>" + data[i].duration + "</td>");

                $('#flightresulttable').append(tr);
            }
        },
        error: function (err) {
            alert(err.responseText);
        }
    });

}
function AuthorizeToken() {
    var loginData = {
        grant_type: 'password',
        username: "rudresh",
        password: "123"
    };

    $.ajax({
        type: 'POST',
        crossDomain: true,
        crossOrigin: true,
        contentType: "application/json",
        url: 'http://localhost:11159/token',
        data: loginData
    }).done(function (data) {
        sessionStorage.setItem("Token", data.access_token);
    }).fail("Error");
}
