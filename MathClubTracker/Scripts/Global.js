function UpdateStatus(statusField, message) {
    $(statusField).html(message);
    $(statusField).show();
}

function SuccessfulServiceResult(serviceResult) {
    if (serviceResult.result.Errors.length > 0) {
        return false;
    }
    return true;
}


function Errors(serviceResult) {
    var temp = "";
    for (var i = 0; i < serviceResult.result.Errors.length; i++) {
        if (temp != '') {
            temp += "<br/>";
        }
        temp += serviceResult.result.Errors[i];
    }
    return temp;
}


function ProcessServiceResult(serviceResult, statusField, successFunction, errorFunction) {
    if (SuccessfulServiceResult(serviceResult)) {
        if (successFunction != null) {
            successFunction();
        }
    } else {
        UpdateStatus(statusField, Errors(serviceResult));
        if (errorFunction != null) {
            errorFunction();
        }
    }
}