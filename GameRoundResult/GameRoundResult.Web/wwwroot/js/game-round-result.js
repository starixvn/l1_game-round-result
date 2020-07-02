var gameRoundResult = (function ($) {
    var culture = $("#culture").val();
    var flatPickrLocale = culture.split("-")[1].toLowerCase();
    var $gameType = $("#GameType");
    var $roundId = $("#RoundId");
    var $date = $("#Date");
    var $userTimeZone = $("#UserTimeZone");
    var $currentTable;
    var tableOptions = {
        pageSize: 50
    };

    var flatPickr;

    return {
        onGetRoundResultSuccess: function () {
            if ($currentTable) {
                $currentTable.DataTable().clear().destroy();
            }

            $currentTable = $('#round-result table');
            $currentTable.DataTable({
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
                        date: flatPickr.formatDate(flatPickr.selectedDates[0], "Y-m-d"),
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
            flatPickr = $date.flatpickr({
                dateFormat: "d/m/Y",
                defaultDate: new Date(),
                locale: flatPickrLocale,
                disableMobile: true
            });

            $roundId.on("change", function (event) {
                var value = event.target.value;

                if (value) {
                    $date.prop("disabled", true);
                } else {
                    $date.prop("disabled", false);
                }
            }).on("keyup", function (event) {
                if (event.keyCode == 13) {
                    event.target.blur();
                }
            });
        }
    }
}(jQuery));

$(document).ready(function () {
    gameRoundResult.init();
});