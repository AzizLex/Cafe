var urlInput;

$(document).ready(function () {
    $.ajax({
        type: "GET",
        url: "/Home/AjaxAddress",
        contentType: false,
        processData: false,
        data: "",
        success: function (cred) {
            if (cred.address) document.styleSheets[1].addRule('.address:before', 'content: "' + cred.address + '";');
            if (cred.phone)  document.styleSheets[1].addRule('.phone:before', 'content: "' + cred.phone + '";');
            if (cred.email) document.styleSheets[1].addRule('.email:before', 'content: "' + cred.email + '";');
            if (cred.opening1) document.styleSheets[1].addRule('.opening1:before', 'content: "' + cred.opening1 + '";');
            if (cred.opening2) document.styleSheets[1].addRule('.opening2:before', 'content: "' + cred.opening2 + '";');
        },
        error: function () {
            alert("No data about address!");
        }
    });

    $("textarea").each(function () { $(this).css('height', this.scrollHeight + 2); });
    $("textarea").keypress(function () {
        $(this).css('height', 0);
        $(this).css('height', this.scrollHeight + 3);
    })
    $("textarea").on('input', function () {
        $(this).css('height', 0);
        $(this).css('height', this.scrollHeight + 3);
    });
});