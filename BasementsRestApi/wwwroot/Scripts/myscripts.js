var timeoudID = -1;

$('.deleteAction').click(function (e) {
    e.preventDefault();
    var id = $(this).attr("itemID");
        if (confirm("Confirm delete?")) {
            $.ajax({
                type: "DELETE",
                url: '/api/items/'+id,
             
                contentType: "application/json; charset=utf-8",
                success: function (response) {
                    if (response.success)
                    {
                        $('div.alert').fadeIn(500).addClass(response.cssClassName).html('<strong>' + response.title + '</strong> ' + response.message).delay(3000).fadeOut(500);
                        $('table#itemList tr#itemRow' + id).remove();
                    }
                    else
                    {
                        $('div.alert').fadeIn(500).addClass(response.cssClassName).html('<strong>' + response.title + '</strong> ' + response.message).delay(3000).fadeOut(500);
                    }
                }
            });
        }
})

$(document).on("change", "#item_Quantity",
    function ()
    {
        if (timeoudID!=-1)
        {
            window.clearTimeout(timeoudID);
        }
        var quantity = parseInt($(this).val(), 10);
        var itemID = $(this).attr("itemID");
        timeoudID = window.setTimeout(function () {
            //var quantity = parseInt($(this).val(), 10);
            if (quantity) {
                //var itemID = $(this).attr("itemID");
                $.post(
                    "/api/items/" + itemID + "/" + quantity
                )
                    .done(
                        function (response, textStatus, jqXHR) {
                            $('div.alert').fadeIn(500).addClass(response.cssClassName).html('<strong>' + response.title + '</strong> ' + response.message).delay(3000).fadeOut(500);
                        }
                    )
                    .fail(
                        function (jqXHR, textStatus, errorThrown) {
                            alert("error:" + jqXHR.responseJSON.message);
                        })
            }
            timeoudID = -1;
        }, 3000);
    
    }
);

$("#newItemButton").click(function () {
    $("#newItemForm").toggle();
});

$("#newItemDefButton").click(function () {
    $("#itemDefsForm").toggle();
});

$("#newUserForm").click(function () {
    $("#userForm").toggle();
});


$("#saveItemButton").click(function () {

    var newItem ={};
    newItem.Quantity = $('#Quantity').val();
    newItem.AddedOn = $('#AddedOn').val();
    newItem.ExpireOn = $('#ExpireOn').val();
    newItem.ItemDefinitionID = $('#itemDefs').val();
    newItem.UserID = $('#usersDef').val();
    var data = JSON.stringify(newItem);
    
    $.ajax({
        url: '/api/items',
        type: 'POST',
        contentType: 'application/json',
        success: function (response) {
            if (response.success) {
                var addedOnDT = response.data.addedOn.substring(0, 10);
                var expireOnDT = response.data.expireOn.substring(0, 10);
                $('div.alert').fadeIn(500).addClass(response.cssClassName).html('<strong>' + response.title + '</strong> ' + response.message).delay(3000).fadeOut(500);

                $('#itemList').append('<tr id="' + response.data.itemID + '">' +
                    '<td>' + response.data.itemDefinition.description + ',' + response.data.itemDefinition.volume +
                    response.data.itemDefinition.unitOfMeasurement + '</td>' +
                    '<td><input class="form-control text-box single-line" id="item_Quantity" itemID="' +
                    response.data.itemID + '" min="1" name="item.Quantity" type="number" value="' + response.data.quantity + '" /></td>' +
                    '<td>' + addedOnDT + '</td>' +
                    '<td>' + expireOnDT + '</td>' +
                    '<td>' + response.data.user.name + '</td>' +
                    '<td><a href="/Items/Edit?itemID=' + response.data.itemID + '">Edit</a> |' +
                    '<a class="deleteAction" href="" itemID="' + response.data.itemID + '">Delete</a> </td></tr >');
            }
            else {
                $('div.alert').fadeIn(500).addClass(response.cssClassName).html('<strong>' + response.title + '</strong> ' + response.message).delay(3000).fadeOut(500);
            }
        },
        fail: function (response) {
           
        },
        data: data,
        complete: function () {
            $('html, body').animate({ scrollTop: 0 }, 'fast');
            $("#newItemForm").toggle();
           
        }
    });
    
})



$("#addItemDef").click(function () {

    var newItemDef = {};
    newItemDef.BarCode = $('#Barcode').val();
    newItemDef.Type = $('#itemDefType').val();
    newItemDef.Description = $('#Description').val();
    newItemDef.Volume = $('#Volume').val();
    newItemDef.UnitOfMeasurement = $('#itemDefUOM').val();
    var data = JSON.stringify(newItemDef);

    $.ajax({
        url: '/api/itemDefinitions',
        type: 'POST',
        contentType: 'application/json',
        success: function (response) {
            if (response.success) {
                $('div.alert').fadeIn(500).addClass(response.cssClassName).html('<strong>' + response.title + '</strong> ' + response.message).delay(3000).fadeOut(500);

                $('#itemDefs').append('<option value="' + response.data.itemDefinitionID + '" selected>' + response.data.description + '-' + response.data.volume + ' ' + response.data.unitOfMeasurement + '</option>');
            }
            else {
                $('div.alert').fadeIn(500).addClass(response.cssClassName).html('<strong>' + response.title + '</strong> ' + response.message).delay(3000).fadeOut(500);
            }
        },
        fail: function (response) {

        },
        data: data,
        complete: function () {
            $("#itemDefsForm").toggle();
        }
    });

})



$("#addUserButton").click(function () {

    var newUser = {};
    newUser.Name = $('#Name').val();
    newUser.LastActivityTimestamp = '1900-01-01 00:00:00';
    var data = JSON.stringify(newUser);

    $.ajax({
        url: '/api/users',
        type: 'POST',
        contentType: 'application/json',
        success: function (response) {
            if (response.success) {
                $('div.alert').fadeIn(500).addClass(response.cssClassName).html('<strong>' + response.title + '</strong> ' + response.message).delay(3000).fadeOut(500);
                $('#usersDef').append('<option value="' + response.data.userID + '" selected>' + response.data.name+'</option>');
            }
            else {
                $('div.alert').fadeIn(500).addClass(response.cssClassName).html('<strong>' + response.title + '</strong> ' + response.message).delay(3000).fadeOut(500);
            }
        },
        fail: function (response) {

        },
        data: data,
        complete: function () {
            $("#userForm").toggle();
        }
    });

})