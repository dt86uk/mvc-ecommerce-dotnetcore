//Add Product Page
var jsonSizeCount = 0;
function canEnableAddSizeButton() {
    var sizeNameEl = $("#sizes" + jsonSizeCount + "_SizeName");
    var quantityEl = $("#sizes" + jsonSizeCount + "_Quantity");

    if (sizeNameEl.val().length >= 1 && quantityEl.val().length >= 1) {
        if ($(".sizeCtrl").val()) {
            $("#btnAddSize").attr("disabled", false);
        }
    }
}

var initCall = true;
function addNewSize() {
    jsonSizeCount++;
    var addSizeHtml = "<div id='divIdHere' class='addSizeContainer paddingTopBot5'>Size Name: <input id='sizeIdHere' type='text' class='inlineBlock' value='' /> Quantity: <input id='quantityIdHere' type='text' class='inlineBlock width40px' value='' />" + 
        "<input id='removeButtonId' type='image' class='vertAlignMid' alt='Delete' src='../../img/icon-pack/png/190-trash.png' width='25' onclick='removeSize(countId);' /></div>";

    var editedHtml = addSizeHtml
        .replace("divIdHere", "divSize" + jsonSizeCount)
        .replace("sizeIdHere", "sizes" + jsonSizeCount + "_SizeName")
        .replace("quantityIdHere", "sizes" + jsonSizeCount + "_Quantity")
        .replace("countId", jsonSizeCount.toString())
        .replace("removeButtonId", "sizes" + jsonSizeCount + "_Remove");

    $("#divSizesJson").append(editedHtml);
}

function editNewSize(sizeCount) {
    sizeCount++;
    var addSizeHtml = "<div id='divIdHere' class='addSizeContainer paddingTopBot5'>Size Name: <input id='sizeIdHere' type='text' class='inlineBlock' value='' /> Quantity: <input id='quantityIdHere' type='text' class='inlineBlock width40px' value='' />&nbsp;" +
        "<input id='removeButtonId' type='image' class='vertAlignMid' alt='Delete' src='/img/icon-pack/png/190-trash.png' width='25' onclick='removeSize(countId);' /></div>";

    var editedHtml = addSizeHtml
        .replace("divIdHere", "divSize" + sizeCount)
        .replace("sizeIdHere", "sizes" + sizeCount + "_SizeName")
        .replace("quantityIdHere", "sizes" + sizeCount + "_Quantity")
        .replace("countId", sizeCount.toString())
        .replace("removeButtonId", "sizes" + sizeCount + "_Remove");

    $("#divSizesJson").append(editedHtml);
}

function removeSize(id) {
    var parentElement = $("#divSize" + id);
    parentElement.remove();

    jsonSizeCount--; 
    if ($(".addSizeContainer").legnth === 1) {
        if ($(".sizeCtrl").val()) {
            $("#btnAddSize").attr("disabled", false);
        }
        else {
            $("#btnAddSize").attr("disabled", true);
        }
    }
}

function serializeSizes() {
    debugger;
    //get all size containers
    var sizeCollcetionParent = document.getElementsByClassName("addSizeContainer");

    //open json string
    var sizesJson = '[';

    //get ctrls & val from inputs
    for (var i = 0; i < sizeCollcetionParent.length; i++) {
        var sizeNameCtrl = "#sizes" + i.toString() + "_SizeName";
        var sizeNameVal = $(sizeNameCtrl).val();

        var quantityCtrl = "#sizes" + i.toString() + "_Quantity";
        var quantityVal = $(quantityCtrl).val();

        var itemJson = '{ "sizeName": "' + sizeNameVal + '", "Quantity": ' + quantityVal + ' }';

        if (i !== (sizeCollcetionParent.length - 1)) {
            itemJson += ',';
        }

        sizesJson += itemJson;
        count = 0;
    }

    //close json string
    sizesJson += ']';

    //set value in hidden control
    $("#SizesJson").val(sizesJson);
}

function setSizesCount(sizesCount) {
    debugger;
    console.log(count);
    count = (sizesCount - 1);

    if ($(".addSizeContainer").legnth === 1) {
        if ($(".sizeCtrl").val()) {
            $("#btnAddSize").attr("disabled", false);
        }
        else {
            $("#btnAddSize").attr("disabled", true);
        }
    }
}

function loadSizes(sizeCount) {
    jsonSizeCount = sizeCount;
}