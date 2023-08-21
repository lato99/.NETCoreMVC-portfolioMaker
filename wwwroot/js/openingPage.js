
//alert("hello");


//function openUser() {
//    event.preventDefault(); // Prevent form submission (prevents page reload)


//    $.ajax({
//        url: '/OpeningPage/OpenUserPage', // The URL for the AddToDiller action in the DillerController
//        type: 'POST',               // The HTTP method to use, in this case, POST
//        data: {
//            int1: 1

//        },
//        success: function (response) {
//            alert("going");
//        },
//        error: function () {
//            // Handle any errors that occur during the AJAX call
//            alert('Error calling DeleteFromDiller action.');
//        }
//    });

//}


function goToUser() {

    event.preventDefault();
    console.log("Hello");
    $.ajax({
        url: '/Home/goToUserPage',
        type: 'POST',
        success: function (response) {
            // Handle the response from the server if needed
            console.log("console : result : ", response);
            $("body").html(response);
        },
        error: function () {
            // Handle any errors that occur during the AJAX call
            alert('Error calling AddToWorkHistory action.');
        }
    });
}


function goToAdmin() {

    event.preventDefault();
    console.log("Hello");
    $.ajax({
        url: '/Home/goToAdminPage',
        type: 'POST',
        success: function (response) {
            // Handle the response from the server if needed
            console.log("console : result : ", response);
            $("body").html(response);
        },
        error: function () {
            // Handle any errors that occur during the AJAX call
            alert('Error calling AddToWorkHistory action.');
        }
    });
}
