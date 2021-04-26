//Common Names - Input
var btnSubmit = "#btnSubmit";

//Layout Page
function ActivateSearch() {
    $("#inputSearchSite").focus();
    $("#inputSearchSite").fadeIn(1000, function () {
        this.placeholder = "Search...";
    });
}

//Product Page
function selectShoeSize(sizeId) {
    if ($("#" + sizeId).hasClass("soldOut")) {
        return;
    }

    //remove selected class from any other child divs
    var listSizes = $("#sizeInfo > div");

    for (var i = 0; i < listSizes.length; i++) {
        var childElement = $("#" + listSizes[i].id);

        if (sizeId.toString() === childElement.attr("id")) {
            continue;
        }

        if (childElement.hasClass("sizeInfoDetailsSelected")) {
            childElement.removeClass("sizeInfoDetailsSelected");
            childElement.addClass("sizeInfoDetails");
        }
    } 

    //set current element classes
    if ($("#" + sizeId).hasClass("sizeInfoDetails")) {
        $("#" + sizeId).removeClass("sizeInfoDetails");
    } else {
        $("#" + sizeId).addClass("sizeInfoDetails");
    }

    if ($("#" + sizeId).hasClass("sizeInfoDetailsSelected")) {
        $("#" + sizeId).removeClass("sizeInfoDetailsSelected");
        $("#" + sizeId).addClass("sizeInfoDetails");
        $("#hiddenIsSelected_" + sizeId).val(false);

        $(btnSubmit).prop('disabled', true);
        $(btnSubmit).addClass("disabledButton");
        $(btnSubmit).removeClass("btnSubmit purpleBlueGrad");
    } else {
        $("#" + sizeId).addClass("sizeInfoDetailsSelected");
        $("#hiddenIsSelected_" + sizeId).val(true);
        $("#hiddenSizeId").val(sizeId);

        $(btnSubmit).prop('disabled', false);
        $(btnSubmit).removeClass("disabledButton");
        $(btnSubmit).addClass("btnSubmit purpleBlueGrad");
    }
}

//Cart page
function CartRemoveItem() {
    return confirm('Are you sure you want to remove this item?');
}

//Checkout page
function setupCheckout() {
    $("#billingForm").hide();
    $("#billingShippingInfo").hide();
    $("#cardForm").hide();
};

function confirmShippingForm() {
    $("#shippingForm").slideUp();
    $("#billingHeader").removeClass("inactiveForm");
    $("#billingHeader").addClass("purpleBlueGrad");
    $("#billingForm").slideDown();
}

function confirmBillingForm() {
    var result = true;

    if ($("#BillingIsShippingAddress").prop("checked") === false) {
        result = billingFormInputsHaveValues();
    }

    if (result) {
        $("#billingDetails").slideUp();
        $("#cardForm").slideDown();
    }
}

function checkShippingForm() { 
    var inputsWithValueCount = validateInputs(true);

    if (inputsWithValueCount) {
        $("#btnShipping").removeClass("disabledButton");
        $("#btnShipping").addClass("btnSubmit purpleBlueGrad"); 
    }
}

function checkBillingForm() {
    console.log("checkBillingForm hit");

    if ($("#BillingIsShippingAddress").prop("checked") === false) {
        var inputsWithValueCount = validateInputs(false);

        if (inputsWithValueCount) {
            $("#btnBilling").removeClass("disabledButton");
            $("#btnBilling").addClass("btnSubmit purpleBlueGrad");
        } else {
            $("#btnBilling").removeClass("btnSubmit purpleBlueGrad");
            $("#btnBilling").addClass("disabledButton");
        }
    }
}

function checkCardForm() {
    var inputs = $("div.cardRequired input");
    var inputsHaveValue = false;

    for (var i = 0; i < inputs.length; i++) {
        inputsHaveValue = inputs[i].val().length > 0;

        if (!inputsHaveValue) {
            break;
        }
    }

    if (inputsHaveValue) {
        $("#btnPlaceOrder").prop('disabled', false);
        $("#btnPlaceOrder").removeClass("disabledButton");
        $("#btnPlaceOrder").addClass("btnSubmit purpleBlueGrad");
    } else {
        $("#btnPlaceOrder").prop('disabled', true);
        $("#btnPlaceOrder").removeClass("btnSubmit purpleBlueGrad");
        $("#btnPlaceOrder").addClass("disabledButton");
    }
}

function billingFormInputsHaveValues() {
    var inputsWithValueCount = validateInputs(false);

    return inputsWithValueCount;
}

function validateInputs(isShippingForm) {
    var prefix = isShippingForm ? "shipping" : "billing";
    
    var inputs = $("div." + prefix + "Required input");
    var inputsHaveValue = false;

    for (var i = 0; i < inputs.length; i++) {
        inputsHaveValue = inputs[i].value.length > 0;

        if (!inputsHaveValue) {
            break;
        }
    }

    return inputsHaveValue;
}

function returnToShipping() {
    $("#billingForm").slideUp();
    $("#billingHeader").removeClass("purpleBlueGrad");
    $("#billingHeader").addClass("inactiveForm");
    $("#shippingForm").slideDown();
}

function returnToBilling() {
    $("#cartForm").slideUp();
    $("#cardHeader").removeClass("purpleBlueGrad");
    $("#cardHeader").addClass("inactiveForm");
    $("#billingForm").slideDown();
}

function cardNumberFormat(e) {
    var input = this;
    var count = 0;
    var cardNumber = input.val();

    for (var i = 0; i < input.val().length; i++) {
        count++;

        if (count % 4 === 0) {
            input.val() = cardNumber + "-";
        }
    }
}

function showShippingDetails() {
    if ($("#BillingIsShippingAddress").prop("checked") === true) {
        getShippingInformation();
        $("#billingFormContainer").hide();
        $("#billingShippingInfo").show();

        $("#btnBilling").removeClass("disabledButton");
        $("#btnBilling").addClass("btnSubmit purpleBlueGrad");
    }
    else {
        checkBillingForm();
        $("#billingShippingInfo").hide();
        $("#billingFormContainer").show();
    }
}

function getShippingInformation() {
    $("#billingShippingFirstName").text($("#ShippingFirstName").val());
    $("#billingShippingLastName").text($("#ShippingLastName").val());
    $("#billingShippingAddress1").text($("#ShippingAddress1").val());
    $("#billingShippingAddress2").text($("#ShippingAddress2").val());
    $("#billingShippingCityTown").text($("#ShippingCityTown").val());
    $("#billingShippingPostalCode").text($("#ShippingPostalCode").val());
    $("#billingShippingCountry").text($("#ShippingCountry").val());
    $("#billingShippingPhone").text($("#ShippingPhone").val());
    $("#billingShippingEmail").text($("#ShippingEmail").val());
}

//Login page
function checkLoginForm() {
    console.log("checkLoginForm");
    var emailLength = $("#txtEmail").val().length;
    var passwordLength = $("#txtPassword").val().length;

    console.log("txtEmail" + emailLength);
    console.log("txtPassword" + passwordLength);

    if (emailLength < 3) {
        disableLoginButton();
        return;
    }

    if (passwordLength < 8) {
        disableLoginButton();
        return;
    }

    $(btnSubmit).prop('disabled', false);
    $(btnSubmit).removeClass("disabledButton");
    $(btnSubmit).addClass("btnSubmit tealLightBlueGrad");
}

function disableLoginButton() {
    $().prop('disabled', true);
    $(btnSubmit).removeClass("btnSubmit tealLightBlueGrad");
    $(btnSubmit).addClass("disabledButton");
}

//Register page
function checkRegisterForm() {
    var allowRegister = false;

    //get all controls that are required
    var inputs = $(':input[required]:visible');

    for (var i = 0; i < inputs.length; i++) {
        if (inputs[i].value.length >= 2) {
            allowRegister = true;
        } else {
            allowRegister = false;
            break;
        }
    }

    if (allowRegister) {
        $(btnSubmit).prop('disabled', false);
        $(btnSubmit).removeClass("disabledButton");
        $(btnSubmit).addClass("btnSubmit tealLightBlueGrad");
    } else {
        $(btnSubmit).prop('disabled', true);
        $(btnSubmit).removeClass("btnSubmit tealLightBlueGrad");
        $(btnSubmit).addClass("disabledButton");
    }
}

function moveToMonth() {
    if ($("#dobDay").val().length >= 2) {
        $("#dobMonth").focus();
    }
    debugger;
}

function moveToYear() {
    if ($("#dobMonth").val().length >= 2) {
        $("#dobYear").focus();
    }
    debugger;
}