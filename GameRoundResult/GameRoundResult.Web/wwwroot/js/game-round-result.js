var gameRoundResult = (function ($) {
    var culture = $("#culture").val();

    return {
        onGetRoundResultSuccess: function () {
            $('#round-result table').DataTable({
                "ordering": false,
                "lengthMenu": [10, 25, 50],
                "pageLength": 50,
                "language": {
                    "url": `/lib/data-tables/i18n/${culture}.json`
                },
                "serverSide": true,
                "ajax": {
                    "url": `/${culture}/GameRoundResult/GetData`,
                    "data": {
                        gameType: $("#GameType").val(),
                        roundId: $("#RoundId").val(),
                        date: $("#Date").val(),
                        userTimeZone: $("#UserTimeZone").val()
                    }
                },
                "searching": false
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