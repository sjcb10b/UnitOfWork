$(document).ready(function () {
   
    console.log("working 100 %");

    $('#finalpayment').click(function () {

        console.log("on click check the values ");
        var filter = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
        var error_fname = '';
        var error_lname = '';
        var error_email = '';
        var error_phone = '';
        var error_street = '';
        var error_city = '';
        var error_state = '';
        var error_zip = '';
        // Card Verification
        var error_ccc_name = '';
        var error_ccc_number = '';
        var error_expiration = '';
        var error_cvv = '';

        




        if ($.trim($('#FirstName').val()).length == 0) {
            error_first_name = 'First Name is required';
            $('#error_fname').text(error_first_name);
            $('#FirstName').addClass('has-error');
        }
        else
        {
            error_first_name = '';
            $('#error_fname').text(error_fname);
            $('#FirstName').removeClass('has-error');
        }
        if ($.trim($('#LastName').val()).length == 0) {
            error_lname = 'Last Name is required';
            $('#error_lname').text(error_lname);
            $('#LastName').addClass('has-error');
        }
        else
        {
            error_lname = '';
            $('#error_lname').text(error_lname);
            $('#LastName').removeClass('has-error');
        }

        //if ($.trim($('#email').val()).length == 0) {
        //    error_email = 'Email is required';
        //    $('#error_email').text(error_email);
        //    $('#email').addClass('has-error');
        //}
        //else
        //{
        //    if (!filter.test($('#email').val())) {
        //        error_email = 'Invalid Email';
        //        $('#error_email').text(error_email);
        //        $('#email').addClass('has-error');
        //    }
        //    else {
        //        error_email = '';
        //        $('#error_email').text(error_email);
        //        $('#email').removeClass('has-error');
        //    }
        //}
        //// Phone verification 
        if ($.trim($('#Phone').val()).length == 0) {
            error_phone = 'Phone is required';
            $('#error_phone').text(error_phone);
            $('#Phone').addClass('has-error');
        }
        else
        {
            error_phone = '';
            $('#error_phone').text(error_phone);
            $('#Phone').removeClass('has-error');
        }

        //// address
        if ($.trim($('#Street').val()).length == 0) {
            error_street = 'Street is required';
            $('#error_street').text(error_street);
            $('#Street').addClass('has-error');
        }
        else
        {
            error_street = '';
            $('#error_street').text(error_street);
            $('#Street').removeClass('has-error');
        }

        //// City
        if ($.trim($('#City').val()).length == 0) {
            error_city = 'City is required';
            $('#error_city').text(error_city);
            $('#City').addClass('has-error');
        }
        else {
            error_city = '';
            $('#error_city').text(error_city);
            $('#City').removeClass('has-error');
        }

        // State
        if ($.trim($('#State').val()).length == 0) {
            error_state = 'State is required';
            $('#error_state').text(error_state);
            $('#State').addClass('has-error');
        }
        else {
            error_state = '';
            $('#error_state').text(error_state);
            $('#State').removeClass('has-error');
        }

        //// Zip
        if ($.trim($('#ZipCode').val()).length == 0) {
            error_zip = 'Zip is required';
            $('#error_zip').text(error_zip);
            $('#ZipCode').addClass('has-error');
        }
        else {
            error_zip = '';
            $('#error_zip').text(error_zip);
            $('#ZipCode').removeClass('has-error');
        }

        //// ccc_name
        if ($.trim($('#ccc_name').val()).length == 0) {
            error_ccc_name = 'Name on Card is required';
            $('#error_ccc_name').text(error_ccc_name);
            $('#ccc_name').addClass('has-error');
        }
        else {
            error_ccc_name = '';
            $('#error_ccc_name').text(error_ccc_name);
            $('#ccc_name').removeClass('has-error');
        }
        //// ccc_number
        if ($.trim($('#ccc_number').val()).length == 0) {
            error_ccc_number = 'Credit Card Number is required';
            $('#error_ccc_number').text(error_ccc_number);
            $('#ccc_number').addClass('has-error');
        }
        else {
            error_ccc_number = '';
            $('#error_ccc_number').text(error_ccc_number);
            $('#ccc_number').removeClass('has-error');
        }
        //// expiration
        if ($.trim($('#expiration').val()).length == 0) {
            error_expiration = 'Expiration is required';
            $('#error_expiration').text(error_expiration);
            $('#expiration').addClass('has-error');
        }
        else
        {
            error_expiration = '';
            $('#error_expiration').text(error_expiration);
            $('#expiration').removeClass('has-error');
        }
        //// expiration
        if ($.trim($('#cvv').val()).length == 0) {
            error_cvv = 'CVV is required';
            $('#error_cvv').text(error_cvv);
            $('#cvv').addClass('has-error');
        }
        else {
            error_cvv = '';
            $('#error_cvv').text(error_cvv);
            $('#cvv').removeClass('has-error');
        }











        if (error_first_name != '' || error_lname != '' || error_phone != '' || error_street != '' || error_city != '' || error_state != '' || error_zip != '' || error_ccc_name != '' || error_ccc_number != '' || error_expiration != '' || error_cvv != '') {
            return false;
        } else {
            //return true;
            //alert("submit");
             console.log("Final Submit ")
            $('#myform').submit();
           
        }
        
        //   ||   || error_expiration != '' || error_cvv != ''

    });

});



