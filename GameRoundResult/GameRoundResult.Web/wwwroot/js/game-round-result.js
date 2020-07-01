var gameRoundResult = (function ($) {
    var culture = $("#culture").val();
    var $gameType = $("#GameType");
    var $roundId = $("#RoundId");
    var $date = $("#Date");
    var $userTimeZone = $("#UserTimeZone");

    var tableOptions = {
        pageSize: 50
    };

    return {
        onGetRoundResultSuccess: function () {
            $('#round-result table').DataTable({
                "ordering": false,
                "lengthMenu": [10, 25, 50],
                "pageLength": tableOptions.pageSize,
                "language": {
                    "url": `/lib/data-tables/i18n/${culture}.json`
                },
                "serverSide": true,
                "ajax": {
                    "url": `/${culture}/GameRoundResult/GetData`,
                    "data": {
                        gameType: $gameType.val(),
                        roundId: $roundId.val(),
                        date: $date.val(),
                        userTimeZone: $userTimeZone.val()
                    }
                },
                "searching": false
            }).on('length.dt', function (e, settings, len) {
                tableOptions.pageSize =  len;
            });;
        },
        init: function () {
            $userTimeZone.val(Intl.DateTimeFormat().resolvedOptions().timeZone);
        }
    }
}(jQuery));

$(document).ready(function () {
    gameRoundResult.init();
});