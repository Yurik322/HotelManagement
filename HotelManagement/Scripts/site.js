$(".changeAccommodationType").click(function() {
    var accommodationTypeID = $(this).attr("data-id");

    $("accommodationTypesRow").hide();
    $("div.accommodationTypesRow[data-id=" + accommodationTypeID + "]").show();
})