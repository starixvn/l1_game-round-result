var gameRoundResult = (function ($) {
    return {
        onGetRoundResultSuccess: function () {
            debugger;
            $('#round-result table').DataTable({
                "ordering": false,
                "lengthMenu": [10, 25, 50]
            });
        }
    }
}(jQuery));