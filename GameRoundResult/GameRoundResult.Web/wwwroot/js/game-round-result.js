var gameRoundResult = (function ($) {
    var culture = $("#culture").val();

    return {
        onGetRoundResultSuccess: function () {
            $('#round-result table').DataTable({
                "ordering": false,
                "lengthMenu": [10, 25, 50],
                "language": {
                    "url": `/lib/data-tables/i18n/${culture}.json`
                }
            });
        },
        init: function () {
            $("#UserTimeZone").val(Intl.DateTimeFormat().resolvedOptions().timeZone);
        }
    }
}(jQuery));

$(document).ready(function () {
    gameRoundResult.init();
});