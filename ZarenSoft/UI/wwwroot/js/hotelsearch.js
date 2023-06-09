$(function () {
    $("#searchBox").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: '/Hotel/AutoComplete/',
                headers: {
                    "RequestVerificationToken":
                        $('input[name="__RequestVerificationToken"]').val()
                },
                data: { "term": request.term },
                type: "POST",
                dataType: "json",
                success: function (data) {
                    $("#searchBox").val(data[0]);
                    response($.map(data, function (item) {
                        return item;
                    }))
                },
                error: function (xhr, textStatus, error) {
                    alert(xhr.statusText);
                },
                failure: function (response) {
                    alert("failure " + response.responseText);
                }
            });

        },
        select: function (e, i) {
            $("#searchBox").val(i.item.val);
            /* When selected starts search ---  I will add this later----
            $.ajax({
                type: 'GET',
                url: '/Search/Hotels?SearchString='+i.item.val,
                contentType: 'json',
                success: function (result) {
                    console.log('Data received: ');
                    console.log(result);
                }
            });*/
        },
        minLength: 3
    });
});
