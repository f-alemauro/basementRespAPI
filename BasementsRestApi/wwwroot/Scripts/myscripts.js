$('.deleteAction').click(function (e) {
    e.preventDefault();
    var id = $(this).attr("itemID");
        if (confirm("Confirm delete?")) {
            $.ajax({
                type: "DELETE",
                url: 'api/items/'+id,
             
                contentType: "application/json; charset=utf-8",
                success: function (response) {
                    $('table#itemList tr#itemRow'+id).remove();
                },
                error: function (response) {
                    alert("Error in deleting item");
                }
            });
        }
})

$("#newItemButton").click(function () {
    $("#newItemForm").toggle();
});


$("#saveItemButton").click(function () {

    var newItem ={};
    newItem.Quantity = $('#Quantity').val();
    newItem.AddedOn = $('#AddedOn').val();
    newItem.ExpireOn = $('#ExpireOn').val();
    newItem.ItemDefinitionID = $('#itemDefs').val();
    newItem.UserID = 1;
    var data = JSON.stringify(newItem);
   

    $.ajax({
        url: 'api/items',
        type: 'POST',
        contentType: 'application/json',
        success: function (response) {
            alert(response.message);
        },
        fail: function (response) {
            alert(response.message);
        },
        data: data

    });
})  

$(document).ready(function () {
    $.get("api/itemDefinitions", function (response) {
        if (response.success) {
            for (var i = 0; i <= response.data.length; i++) {
                $('#itemDefs').append('<option value="' + response.data[i].itemDefinitionID + '">' + response.data[i].description + '-' + response.data[i].volume + ' ' + response.data[i].unitOfMeasurement + '</option>');
            }
        }
        
    });

    

});