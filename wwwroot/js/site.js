// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

let dataArray = [];

function saveWorkInfo(button) {
    event.preventDefault();
    const row = button.parentElement.parentElement;
    const tableBody = row.parentElement;
    const index = Array.from(tableBody.children).indexOf(row);

    const inputs2 = row.querySelectorAll('input');
    const tableLength = tableBody.childElementCount;
    const values2 = Array.from(inputs2).map(input2 => input2.value);
    dataArray.push(values2);
    console.log(dataArray);
    addWorkInfo();
    console.log("add");
}





function deleteWorkInfo(button) {
    event.preventDefault();
    const row = button.parentElement.parentElement;
    const tableBody = row.parentElement;
    const tableRows = Array.from(tableBody.children);
    const index = tableRows.length - tableRows.indexOf(row) - 1;
    console.log(index);
    console.log("silmeden önce : " + dataArray);
    var id = document.querySelector("#hiddenInput");
    var idVal = id.value;
    var submitCount = document.querySelector("#submitCount");
    if (submitCount.value == "1") {
        dataArray.splice(index, 1);
        const inputs2 = row.querySelectorAll('input');
        const tableLength = tableBody.childElementCount;
        const values2 = Array.from(inputs2).map(input2 => input2.value);
        console.log("values2 : ", values2);
        DeleteFromWorkHistory(...values2);
        if (index !== -1) {
            tableBody.removeChild(row);
        }
        return;
    }
    dataArray.splice(index, 1);

    if (index !== -1) {
        tableBody.removeChild(row);
    }
    console.log("silmeden sonra " + dataArray);
}






function addWorkInfo() {
    event.preventDefault();


    const tableBody = document.querySelectorAll('tbody')[2];
    const newRow = document.createElement('tr');
    newRow.innerHTML = `
        <td><input placeholder="name" type="text"></td>
        <td><input placeholder="address" type="text"></td>
        <td><input placeholder="name" type="text"></td>
        <td><input placeholder="Departmant Name" type="text"></td>
        <td><input placeholder="start date" type="date"></td>
        <td><input placeholder="end date" type="date"></td>
        <td>
                                <button onclick="saveWorkInfo(this)">Save</button>  
        </td>
    `; //   <button onclick="saveWorkInfo(this)">Bilgileri kaydet.</button>

    // Check if there are any existing rows in the table body
    const existingRows = tableBody.getElementsByTagName("tr");

    // If there are rows, insert the new row before the first row; otherwise, simply append the new row.
    if (existingRows.length > 0) {
        tableBody.insertBefore(newRow, existingRows[0]);
    } else {
        tableBody.appendChild(newRow);
    }
    changeAddButtonToDelete(tableBody);


}


function changeAddButtonToDelete(tableBody) {
    event.preventDefault();
    var row = tableBody.rows[1];
    var deletionCell = row.cells[row.cells.length - 1];
    row.removeChild(deletionCell);
    var newDeleteButton = document.createElement("td");
    newDeleteButton.innerHTML = '<button onclick="deleteWorkInfo(this)">Delete</button>';
    row.appendChild(newDeleteButton);

    
}

function connectWorkDatabase(str1, str2, str3, str4, str5, str6) {
    console.log("bagland,");
    console.log(str1);
    console.log(str2);
    console.log(str3);
    console.log(str4);
    console.log(str5);
    console.log(str6);
    var id = document.querySelector("#hiddenInput");
    var idVal = id.value;
    console.log("the value is : ", idVal);
    var int1Value = idVal; // Replace '1' with the actual value you want to send for 'int1'
    var str1Value = str1; // Replace "Value1" with the actual value you want to send for 'str1'
    var str2Value = str2; // Replace "Value2" with the actual value you want to send for 'str2'
    var str3Value = str3; // Replace "Value3" with the actual value you want to send for 'str3'
    var str4Value = str4; // Replace "Value4" with the actual value you want to send for 'str4'
    var str5Value = str5; // Replace "Value5" with the actual value you want to send for 'str5'
    var str6Value = str6; // Replace "Value6" with the actual value you want to send for 'str6'
    $.ajax({
        url: '/Home/Work',
        type: 'POST',
        data: {
            int1: int1Value,
            str1: str1Value,
            str2: str2Value,
            str3: str3Value,
            str4: str4Value,
            str5: str5Value,
            str6: str6Value
        },
        success: function (response) {
            // Handle the response from the server if needed

        },
        error: function () {
            // Handle any errors that occur during the AJAX call
            alert('Error calling AddToWorkHistory action.');
        }
    });
}




function DeleteFromWorkHistory(str1, str2, str3, str4, str5, str6) {
    console.log("diger islem");
    console.log(str1);
    console.log(str2);
    console.log(str3);
    console.log(str4);
    console.log(str5);
    console.log(str6);
    var id = document.querySelector("#hiddenInput");
    var idVal = id.value;
    console.log("the value is : ", idVal);
    var int1Value = idVal; // Replace '1' with the actual value you want to send for 'int1'
    var str1Value = str1; // Replace "Value1" with the actual value you want to send for 'str1'
    var str2Value = str2; // Replace "Value2" with the actual value you want to send for 'str2'
    var str3Value = str3; // Replace "Value3" with the actual value you want to send for 'str3'
    var str4Value = str4; // Replace "Value4" with the actual value you want to send for 'str4'
    var str5Value = str5; // Replace "Value5" with the actual value you want to send for 'str5'
    var str6Value = str6; // Replace "Value6" with the actual value you want to send for 'str6'

    $.ajax({
        url: '/Home/DeleteFromWorkHistory',
        type: 'POST',
        data: {
            int1: int1Value,
            str1: str1Value,
            str2: str2Value,
            str3: str3Value,
            str4: str4Value,
            str5: str5Value,
            str6: str6Value
        },
        success: function (response) {
            // Handle the response from the server if needed

        },
        error: function () {
            // Handle any errors that occur during the AJAX call
            alert('Error calling DeleteFromWorkHistory action.');
        }
    });
}


function addAllWorkHist(dArray) {
    for (let i = 0; i < dataArray.length; i++) {
        connectWorkDatabase(...dArray[i]);
    }
    dArray.length = 0;
}























let dataArray2 = [];


function addAllEduInfo(dArray) {
    for (let i = 0; i < dArray.length; i++) {
        connectEduDatabase(...dArray[i]);
    }
    dArray.length = 0;
}





function saveEduInfo(button) {
    event.preventDefault();
    const row = button.parentElement.parentElement;
    const tableBody = row.parentElement;
    const inputs = row.querySelectorAll('input');
    const values = Array.from(inputs).map(input => input.value);
    row.classList.add('uneditable');

    // Set all inputs as readonly
    inputs.forEach(input => {
        input.readOnly = true;
    });

    
    const tableLength = tableBody.childElementCount;

    dataArray2.push(values);
    console.log("save edu sonrası dataArray" + dataArray2);
    addEduRow();
}

function deleteEduInfo(button) {
    event.preventDefault();
    const row = button.parentElement.parentElement;
    const tableBody = row.parentElement;

    const tableRows = Array.from(tableBody.children);
    const index2 = tableRows.length - tableRows.indexOf(row) - 1;
    const index = Array.from(tableBody.children).indexOf(row);

    const row2 = button.parentElement.parentElement;
    const inputs2 = row.querySelectorAll('input');
    const values2 = Array.from(inputs2).map(input2 => input2.value);
    var id = document.querySelector("#hiddenInput");
    var idVal = id.value;
    var submitCount = document.querySelector("#submitCount");
    if (submitCount.value == "1") {
        dataArray2.splice(index2, 1);
        const tableLength = tableBody.childElementCount;
        connectDatabaseToDeleteSchool(...values2);
        if (index !== -1) {
            tableBody.removeChild(row);
        }
        return;
    }
    dataArray2.splice(index2, 1);
    //connectDatabaseToDeleteSchool(...values2);
    if (index !== -1) {
        tableBody.removeChild(row2);
       

    }
 
}










function addEduRow() {
    event.preventDefault();
    const tableBody = document.querySelectorAll('tbody')[3];
    const newRow = document.createElement('tr');
    newRow.innerHTML = `
                <td><input type="text"></td>
                <td><input type="text"></td>
                <td><input type="text"></td>
                <td><input type="text"></td>
                <td><input type="date"></td>
                <td><input type="date"></td>
                <td><button onclick="saveEduInfo(this)">Save</button>

            `;
    // Check if there are any existing rows in the table body
    const existingRows = tableBody.getElementsByTagName("tr");

    // If there are rows, insert the new row before the first row; otherwise, simply append the new row.
    if (existingRows.length > 0) {
        tableBody.insertBefore(newRow, existingRows[0]);
    } else {
        tableBody.appendChild(newRow);
    }
    changeAddButtonToDelete(tableBody);
}



function connectEduDatabase(str1, str2, str3, str4, str5, str6) {
    var id = document.querySelector("#hiddenInput");
    var idVal = id.value;


    $.ajax({
        url: '/Home/AddToOkullar',
        type: 'POST',
        data: {
            int1: idVal,
            str1: str1,
            str2: str2,
            str3: str3,
            str4: str4,
            str5: str5,
            str6: str6
        },
        success: function (response) {
            // Handle the response from the server if needed

        },
        error: function () {
            // Handle any errors that occur during the AJAX call
            alert('Error calling AddToOkullar action.');
        }
    });
}


function connectDatabaseToDeleteSchool(str1, str2, str3, str4, str5, str6) {
    var id = document.querySelector("#hiddenInput");
    var idVal = id.value;
    var int1Value = idVal; // Replace '1' with the actual value you want to send for 'int1'
    var str1Value = str1; // Replace "Value1" with the actual value you want to send for 'str1'
    var str2Value = str2; // Replace "Value2" with the actual value you want to send for 'str2'
    var str3Value = str3; // Replace "Value3" with the actual value you want to send for 'str3'
    var str4Value = str4; // Replace "Value4" with the actual value you want to send for 'str4'
    var str5Value = str5; // Replace "Value5" with the actual value you want to send for 'str5'
    var str6Value = str6; // Replace "Value6" with the actual value you want to send for 'str6'

    $.ajax({
        url: '/Home/DeleteFromOkullar', // The URL for the AddToDiller action in the DillerController
        type: 'POST',               // The HTTP method to use, in this case, POST
        data: {
            int1: int1Value,
            str1: str1Value,
            str2: str2Value,
            str3: str3Value,
            str4: str4Value,
            str5: str5Value,
            str6: str6Value
        },
        success: function (response) {
            // Handle the response from the server if needed

        },
        error: function () {
            // Handle any errors that occur during the AJAX call
            alert('Error calling DeleteFromDiller action.');
        }
    });
}
























function addAllLangInfo(dArray) {
    for (let i = 0; i < dArray.length; i++) {
        connectLangDatabase(...dArray[i]);
    }
    dArray.length = 0
}






let dataArray3 = [];

function saveLangInfo(button) {
    event.preventDefault();
    const row = button.parentElement.parentElement;
    const textInputs = row.querySelectorAll('input[type="text"]');
    const selectInputs = row.querySelectorAll('select');

    const textValues = Array.from(textInputs).map(input => input.value);
    const selectValues = Array.from(selectInputs).map(select => select.value);

    const values = [...textValues, ...selectValues];
    console.log(values);

    //connectLangDatabase(1, values[0], values[1], values[2], values[3], values[4], values[5]);
    row.classList.add('uneditable');

    // Set all inputs as readonly
    textInputs.forEach(input => {
        input.readOnly = true;
    });

    selectInputs.forEach(select => {
        select.disabled = true;
    });
    var id = document.querySelector("#hiddenInput");
    var idVal = id.value;

    const newArray = [idVal, values[0], values[1], values[2], values[3], values[4], values[5]];
    dataArray3.push(newArray);
    console.log("after new line ", dataArray3);
    addLangInfo();
}


function deleteLangInfo(button) {
    event.preventDefault();

    var row = button.parentElement.parentElement;
    var textInputs = row.querySelectorAll('input[type="text"]');
    var selectInputs = row.querySelectorAll('select');

    var textValues = Array.from(textInputs).map(input => input.value);
    var selectValues = Array.from(selectInputs).map(select => select.value);

    var values = [...textValues, ...selectValues];
    var id = document.querySelector("#hiddenInput");
    const tableBody = row.parentElement;
    const tableRows = Array.from(tableBody.children);
    var idVal = id.value;
    const index = Array.from(tableBody.children).indexOf(row);
    var submitCount = document.querySelector("#submitCount");
    const index2 = tableRows.length - tableRows.indexOf(row) - 1;
    if (submitCount.value == "1") {

        const inputs2 = row.querySelectorAll('input');
        const tableLength = tableBody.childElementCount;
        const values2 = Array.from(inputs2).map(input2 => input2.value);
        connectDatabaseToDeleteLanguage(idVal, values[0], values[1], values[2], values[3], values[4], values[5]);
        dataArray3.splice(index2, 1);
        if (index !== -1) {
            tableBody.removeChild(row);
        }
        return;
    }
   


    row = button.parentElement.parentElement;


   
    
    dataArray3.splice(index2, 1);
    console.log("after deletion");
    if (index !== -1) {
        tableBody.removeChild(row);

    }
}


function addLangInfo() {
    event.preventDefault();

    const tableBody = document.querySelectorAll('tbody')[4];
    const newRow = document.createElement('tr');
    newRow.innerHTML = `
                            <td><input type="text"></td>
                            <td>
                                <select>
                                    <option value="a1">a1</option>
                                    <option value="a2">a2</option>
                                    <option value="b1">b1</option>
                                    <option value="b2">b2</option>
                                    <option value="c1">c1</option>
                                    <option value="c2">c2</option>
                                </select>
                            </td>
                            <td>
                                <select>
                                    <option value="a1">a1</option>
                                    <option value="a2">a2</option>
                                    <option value="b1">b1</option>
                                    <option value="b2">b2</option>
                                    <option value="c1">c1</option>
                                    <option value="c2">c2</option>
                                </select>
                            </td>
                            <td>
                                <select>
                                    <option value="a1">a1</option>
                                    <option value="a2">a2</option>
                                    <option value="b1">b1</option>
                                    <option value="b2">b2</option>
                                    <option value="c1">c1</option>
                                    <option value="c2">c2</option>
                                </select>
                            </td>
                            <td>
                                <select>
                                    <option value="a1">a1</option>
                                    <option value="a2">a2</option>
                                    <option value="b1">b1</option>
                                    <option value="b2">b2</option>
                                    <option value="c1">c1</option>
                                    <option value="c2">c2</option>
                                </select>
                            </td>
                            <td>
                                <select>
                                    <option value="a1">a1</option>
                                    <option value="a2">a2</option>
                                    <option value="b1">b1</option>
                                    <option value="b2">b2</option>
                                    <option value="c1">c1</option>
                                    <option value="c2">c2</option>
                                </select>
                            </td>
                            <td>
                                <button onclick="saveLangInfo(this)">Save</button>
                            </td>
            `;
    // Check if there are any existing rows in the table body
    const existingRows = tableBody.getElementsByTagName("tr");

    // If there are rows, insert the new row before the first row; otherwise, simply append the new row.
    if (existingRows.length > 0) {
        tableBody.insertBefore(newRow, existingRows[0]);
    } else {
        tableBody.appendChild(newRow);
    }
    changeAddButtonToDelete(tableBody)
}



function connectLangDatabase(int1, str1, str2, str3, str4, str5, str6) {
    var int1Value = int1; // Replace '1' with the actual value you want to send for 'int1'
    var str1Value = str1; // Replace "Value1" with the actual value you want to send for 'str1'
    var str2Value = str2; // Replace "Value2" with the actual value you want to send for 'str2'
    var str3Value = str3; // Replace "Value3" with the actual value you want to send for 'str3'
    var str4Value = str4; // Replace "Value4" with the actual value you want to send for 'str4'
    var str5Value = str5; // Replace "Value5" with the actual value you want to send for 'str5'
    var str6Value = str6; // Replace "Value6" with the actual value you want to send for 'str6'

    var id = document.querySelector("#hiddenInput");
    var idVal = id.value;
    console.log("the value is : ", idVal);
    $.ajax({
        url: '/Home/AddToDiller', // The URL for the AddToDiller action in the DillerController
        type: 'POST',               // The HTTP method to use, in this case, POST
        data: {
            int1: idVal,
            str1: str1Value,
            str2: str2Value,
            str3: str3Value,
            str4: str4Value,
            str5: str5Value,
            str6: str6Value
        },
        success: function (response) {
            // Handle the response from the server if needed
            console.log(response);
        },
        error: function () {
            // Handle any errors that occur during the AJAX call
            alert('Error calling AddToDiller action.');
        }
    });
}








function connectDatabaseToDeleteLanguage(int1, str1, str2, str3, str4, str5, str6) {
    var id = document.querySelector("#hiddenInput");
    var idVal = id.value;
    var int1Value = idVal; // Replace '1' with the actual value you want to send for 'int1'
    var str1Value = str1; // Replace "Value1" with the actual value you want to send for 'str1'
    var str2Value = str2; // Replace "Value2" with the actual value you want to send for 'str2'
    var str3Value = str3; // Replace "Value3" with the actual value you want to send for 'str3'
    var str4Value = str4; // Replace "Value4" with the actual value you want to send for 'str4'
    var str5Value = str5; // Replace "Value5" with the actual value you want to send for 'str5'
    var str6Value = str6; // Replace "Value6" with the actual value you want to send for 'str6'

    $.ajax({
        url: '/Home/DeleteFromDiller', // The URL for the AddToDiller action in the DillerController
        type: 'POST',               // The HTTP method to use, in this case, POST
        data: {
            int1: int1Value,
            str1: str1Value,
            str2: str2Value,
            str3: str3Value,
            str4: str4Value,
            str5: str5Value,
            str6: str6Value
        },
        success: function (response) {
            // Handle the response from the server if needed
        },
        error: function () {
            // Handle any errors that occur during the AJAX call
            alert('Error calling DeleteFromDiller action.');
        }
    });
}








function submitImage2(userId) {
    var formData = new FormData();
    formData.append("userImage", $("#userImg")[0].files[0]);
    console.log('user ID : ' + userId);
    formData.append("userId", userId);
    $.ajax({
        url: "/Home/UploadImage", // Replace 'ControllerName' with your actual controller name
        type: "POST",
        data: formData,
        processData: false,
        contentType: false,
        success: function () {
            console.log("Image uploaded successfully");
            // Perform any actions you want after a successful upload
        },
        error: function () {
            console.log("Image upload failed");
            // Handle error or display a message to the user
        }
    });
}




function submitImage3() {
    const imgElement = document.getElementById("preview");
    const imageURL = imgElement.src;

    if (!imageURL || imageURL === "#") {
        console.error("Image source not provided.");
        return;
    }

    const link = document.createElement("a");
    link.href = imageURL;
    link.download = "image.jpg"; // You can change the filename here
    document.body.appendChild(link);
    link.click();
    document.body.removeChild(link);
}









// Function to handle form submission
function submitImage() {

        const imageElement = document.getElementById('preview');
        const imageSource = imageElement.src;

        if (imageSource && imageSource !== '#' && imageSource !== 'about:blank') {
            const link = document.createElement('a');
            link.href = imageSource;
            link.download = 'downloaded_image.jpg';
            link.target = '_blank';
            link.click();
        } else {
            alert('Image source not valid.');
        }
    
}





// Function to handle form submission
function submitForm() {
    event.preventDefault(); // Prevent form submission (prevents page reload)
    // Get all input elements inside the "kisisel_bilgiler" div
    const inputs = document.querySelectorAll('.kisisel_bilgiler input');
    const data = {}; // Object to store the form data
    var id = document.querySelector("#hiddenInput");
    var idVal = id.value;
    // Loop through each input element and store their values in the data object
    inputs.forEach(input => {
        const name = input.id;
        const value = input.value;
        data[name] = value;
    });

    // Now, you have all the form data stored in the 'data' object
    // You can use this object to perform any actions you want, such as sending it to the server, etc.

    var firstName = data["adInput"];
    var lastName = data["soyadInput"];

    var age = data["ageInput"];

    var birthdate = new Date(data["ageInput"]); // Convert the input date to a Date object
    var currentDate = new Date(); // Get the current date
    var timeDiff = currentDate - birthdate; // Calculate the time difference in milliseconds

    age = new Date(timeDiff); // Convert the time difference to a Date object
    age = age.getUTCFullYear() - 1970; // Extract the year difference

    var address = data["addressInput"];
    var bekar = data["Evli"];
    var evli = data["Bekar"];
    const selectedRadioButton = document.querySelector('input[name="medenihalInput"]:checked');
    var martialStatus = selectedRadioButton.value
    var telephone = data["telInput"];
    var email = data["emailInput"];


    //submitPortfolio(firstName, lastName,address,telNo,email)

    $.ajax({
        url: '/Home/AddUserToUsersDB', // The URL for the AddToDiller action in the DillerController
        type: 'POST',               // The HTTP method to use, in this case, POST
        data: {

            str1: firstName,
            str2: lastName,
            str3: age,
            str4: address,
            str5: martialStatus,
            str6: telephone,
            str7: email,
            str8: idVal
        },
        success: function (response) {
            alert("Submit edildi.");
            // Handle the response from the server if needed
            $("#hiddenInput").val(response);
            console.log(response);
            
            var submitCount = document.querySelector("#submitCount");
            submitCount.value = "1";
            addAllWorkHist(dataArray);

            addAllEduInfo(dataArray2);
            addAllLangInfo(dataArray3);

            var id = document.querySelector("#hiddenInput");
            var idVal = id.value;

            submitImage2(idVal);
            
        },
        error: function () {
            // Handle any errors that occur during the AJAX call
            alert('Error calling DeleteFromDiller action.');
        }
    });



}







function submitSearch() {
    event.preventDefault();
    var fname = document.getElementById("fname").value;
    var sname = document.getElementById("sname").value;
    var minAge = document.getElementById("minAge").value;
    var maxAge = document.getElementById("maxAge").value;
    var city = document.getElementById("city").value;
    var mstatus = document.getElementById("mstatus").value;

    var data = {
        fname: fname,
        sname: sname,
        minAge: minAge,
        maxAge: maxAge,
        city: city,
        mstatus: mstatus
    };

    $.ajax({
        type: "POST",
        url: "/Home/FilterUsers",
        data: data,
        success: function (result) {
           
            console.log("console : result : ", result);
            $("body").html(result);
        },
        error: function (error) {
            console.log(error);
        }
    });
}




