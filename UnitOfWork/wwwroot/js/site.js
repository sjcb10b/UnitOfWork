//$(document).ready(function () {
//    $('#myTable').DataTable({

//        "scrollCollapse": true,
//        "paging": true
//    });
//});

$(document).ready(function () {
    $('#myTable').DataTable({

        "scrollCollapse": true,
        "paging": true
    });
});
// Write your JavaScript code.

$(function () {
    $("#loaderbody").addClass('hide');

    $(document).bind('ajaxStart', function () {
        $("#loaderbody").removeClass('hide');
    }).bind('ajaxStop', function () {
        $("#loaderbody").addClass('hide');
    });
});

showInPopup = (url, title) => {
    console.log("I am in");
    $.ajax({
        type: 'GET',
        url: url,
        success: function (res) {
            $('#form-modal .modal-body').html(res);
            $('#form-modal .modal-title').html(title);
            $('#form-modal').modal('show');
            // to make popup draggable
            $('.modal-dialog').draggable({
                handle: ".modal-header"
            });
        }
    })
}

jQueryAjaxPost = form => {
    try {
        $.ajax({
            type: 'POST',
            url: form.action,
            data: new FormData(form),
            contentType: false,
            processData: false,
            success: function (res) {
                if (res.isValid) {
                    $('#view-all').html(res.html)
                    $('#form-modal .modal-body').html('');
                    $('#form-modal .modal-title').html('');
                    $('#form-modal').modal('hide');
                }
                else
                    $('#form-modal .modal-body').html(res.html);
            },
            error: function (err) {
                console.log(err)
            }
        })
        //to prevent default form submit event
        return false;
    } catch (ex) {
        console.log(ex)
    }
}

jQueryAjaxDelete = form => {
    if (confirm('Are you sure to delete this record ?')) {
        try {
            $.ajax({
                type: 'POST',
                url: form.action,
                data: new FormData(form),
                contentType: false,
                processData: false,
                success: function (res) {
                    $('#view-all').html(res.html);
                },
                error: function (err) {
                    console.log(err)
                }
            })
        } catch (ex) {
            console.log(ex)
        }
    }

    //prevent default form submit event
    return false;
}






function FillCities(lstCountryCtrl, lstCityId) {
    var lstCities = $("#" + lstCityId);
    lstCities.empty();

    lstCities.append($('<option/>',
        {
            value: null,
            text: "Select City"
        }));

    var selectedCountry = lstCountryCtrl.options[lstCountryCtrl.selectedIndex].value;

    if (selectedCountry != null && selectedCountry != '') {
        $.getJSON('/customer/getcitiesbycountry', { countryId: selectedCountry }, function (cities) {
            if (cities != null && !jQuery.isEmptyObject(cities)) {
                $.each(cities, function (index, city) {
                    lstCities.append($('<option/>',
                        {
                            value: city.value,
                            text: city.text
                        }));
                });
            };
        });
    }
    return;
}


$(".custom-file-input").on("change", function () {

    var fileName = $(this).val().split("\\").pop();

    document.getElementById('PreviewPhoto').src = window.URL.createObjectURL(this.files[0]);

    document.getElementById('PhotoUrl').value = fileName;

});