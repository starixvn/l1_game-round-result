var gameRoundResult = (function ($) {
    var culture = $("#culture").val();
    var $gameType = $("#GameType");
    var $roundId = $("#RoundId");
    var $date = $("#Date");
    var $userTimeZone = $("#UserTimeZone");

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
                        gameType: $gameType.val(),
                        roundId: $roundId.val(),
                        date: $date.val(),
                        userTimeZone: $userTimeZone.val()
                    }
                },
                "searching": false
            });
        },
        init: function () {
            $userTimeZone.val(Intl.DateTimeFormat().resolvedOptions().timeZone);
        }
    }
}(jQuery));

$(document).ready(function () {
    gameRoundResult.init();

    $("body").on("click", ".view-keno-result", function () {
        var $kenoResultModal = $("#keno-result-modal");
        $kenoResultModal.empty();

        var $this = $(this);
        var result = $this.data("result").split(",");

        
        $kenoResultModal.append("<div id='numbers'></div>");
        var listNumbers = $("#numbers");
        listNumbers.addClass("numbers");

        for (var i = 0; i < result.length; i++) {
            var $span = $("<span>");
            $span.addClass("circle");
            $span.text(result[i]);
            listNumbers.append($span);
        }

        $kenoResultModal.modal();
    });
});