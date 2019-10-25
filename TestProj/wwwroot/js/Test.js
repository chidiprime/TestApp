
$(document).ready(function () {
    $('#grant_type').val('password');
    $('#username').val('lolade.amunigun@fidesicng.com');
    $('#password').val('P@ssword01');
    $('#scope').val('openid profile identity-server-api');
    $('#clientid').val('pmsapi');
    $('#clientsecret').val('SolutionPms');
});
$('#save').click(function () {
    $('#result').text('');
    var grant_type = $('#grant_type').val();
    var username = $('#username').val();
    var password = $('#password').val();
    var scope = $('#scope').val();
    var clientid = $('#clientid').val();
    var clientsecret = $('#clientsecret').val();
    if (grant_type == "") {
        alert("Grant type is required");
        return;
    }
    if (username == "") {
        alert("Username is required");
        return;
    }
    if (password == "") {
        alert("Password is required");
        return;
    }
    if (scope == "") {
        alert("Scope is required");
        return;
    }
    if (clientid == "") {
        alert("Client Id is required");
        return;
    }
    if (clientsecret == "") {
        alert("Client Secret is required");
        return;
    }
    var sosObject =
    {
        grant_type: grant_type,
        username: username,
        password: password,
        scope: scope,
        client_id: clientid,
        client_secret: clientsecret
    }
    $("#LoadingImage").show();
    $.ajax({
        url: "/PostCredential",
        type: 'POST',
        contentType: "application/json",
        data: JSON.stringify(sosObject),
        success: function (data, textStatus, xhr) {
            $('#result').text(data);
            //$("#LoadingImage").hide();
        },
        error: function (xhr, textStatus, errorThrown) {
            $('#result').text(xhr.responseText);
        },
        complete: function () {
            //$("#LoadingImage").hide();
        }
    });
});