$(document).ready(function () {

    var linkTemplate = $('#linkTemplate'),
        createLinkForm = $('#dashboard-add-link');

    createLinkForm.find('button').click(function (ev) {
        var originalUrl = createLinkForm.find('input').val(),
            action = createLinkForm.attr('action'),
            method = createLinkForm.attr('method');

        $.ajax({
            type: method,
            url: action,
            data: { 'OriginalUrl': originalUrl },
            success: function (data) {
                linkTemplate.tmpl(data).prependTo('#links tbody').fadeIn(1500);
            }
        });

        return false;
    });
});