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
                $('#links .empty').fadeOut(0);
                linkTemplate.tmpl(data).prependTo('#links tbody').fadeIn(1500);
            }
        });

        return false;
    });

    $('#links .cmd-remove').live('click', function (ev) {

        var target = $(ev.target).closest('tr');
        var shortenedUrl = target.find('td').eq(0).text();

        $.ajax({
            type: 'POST',
            url: '/Links/Delete',
            data: { 'ShortenedUrl': shortenedUrl },
            success: function (data) {
                target.fadeOut(1500).remove();
                $('#links .empty').fadeIn(1500);
            }
        });

        return false;
    });
});