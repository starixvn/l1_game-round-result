var demo = (function ($) {
    const formDemo = '#form-demo';
    const getRequestParamUrl = "/Demo/GetRequestParam";

    function openRoundResultPage() {
        var data = {
            auth: {
                clientId: "Demo",
                clientKey: "123demoqweaaa"
            }
        };
        postRequest("/GameRoundResult/GetAccessUrl", JSON.stringify(data), {
            contentType: "application/json; charset=utf-8",
            dataType: "json"
        }, (content) => {
            openNewTab(content?.redirectUrl);
        })
    }

    function getBetDetails() {
        postRequest(getRequestParamUrl, $(formDemo).serialize(), {}, (request) => {
            if (request) {
                requestBetDetails(request);
            }
        })
    }

    function getEndRoundInfo() {
        postRequest(getRequestParamUrl, $(formDemo).serialize(), {}, (request) => {
            if (request) {
                requestEndRoundInfo(request);
            }
        })
    }

    function getRoundHistory() {
        postRequest(getRequestParamUrl, $(formDemo).serialize(), {}, (request) => {
            if (request) {
                requestRoundHistory(request);
            }
        })
    }

    function requestEndRoundInfo(data) {
        postRequest("/EndRoundInfo", data, {
            contentType: "application/json; charset=utf-8",
            headers: {
                "Access-Key": "test"
            },
            dataType: "json"
        }, (content) => {
            $('#retrieve-end-round-result').text(JSON.stringify(content, null, 2));
            $('.retrieve-end-round-result-field').removeClass('d-none');
        });
    }

    function requestBetDetails(data) {
        postRequest("/BetHistory/GetAccessUrl", data, {
            contentType: "application/json; charset=utf-8",
            dataType: "json"
        }, (content) => {
            openNewTab(content?.redirectUrl);
        });
    }

    function requestRoundHistory(data) {
        postRequest("/RoundHistory/GetAccessUrl", data, {
            contentType: "application/json; charset=utf-8",
            dataType: "text"
        }, (content) => {
            openNewTab(content);
        });
    }

    function postRequest(url, data, options, onDone) {
        $.ajax({
            ...options,
            method: "POST",
            url,
            data,
        }).done(onDone);
    }

    function openNewTab(url) {
        if (url) {
            window.open(url);
        }
    }

    return {
        init: function () {
            $('#form-demo').submit((e) => {
                e.preventDefault();
            });
        },
        getBetDetails,
        openRoundResultPage,
        getEndRoundInfo,
        getRoundHistory
    }
}(jQuery));

$(document).ready(function () {
    demo.init();
});