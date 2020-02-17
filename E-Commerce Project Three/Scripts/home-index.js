/// <reference path="jquery-1.10.2.js" />
$(".j-add").on('click', function (event) {
    $this = $(this)
    $.ajax({
        url: '/Cart/Add/' + $this.data("desktopWallpaperId"),
        method: 'post',
        dataType: 'json'
    }).done(function (data, textStatus, jqXHR) {
        alert(data)
        $("#shopping-cart-container").addClass("not-empty")
    }).fail(function (jqXHR, textStatus, errorThrown) {
        var status = jqXHR.status;
        switch(status)
        {
            case 400:
                alert("You have already added or try to add something doesn't exsit within our database.")
                break
            case 500:
                alert("System error.")
                break
            default:
                alert("Network might be taking some problems. Please have a try later.")
                break
        }
    })
})