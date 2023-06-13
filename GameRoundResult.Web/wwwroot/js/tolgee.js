const tolgee = (function ($) {
    return {
        init: function () {
            const language = $("#tolgee_language")[0]?.value;
            const ns = $("#tolgee_namespace")[0]?.value;

            if (!language || !ns) {
                return;
            }

            const { Tolgee, InContextTools, FormatSimple, BackendFetch } =
                window['@tolgee/web'];
            const tolgee = Tolgee()
                .use(InContextTools())
                .use(FormatSimple())
                .use(BackendFetch())
                .init({
                    projectId: 6,
                    apiKey: 'tgpak_gzpwe2ttgnzwqzlkoztwk4jqnbzhc3lehbqwo2lsozttk',
                    apiUrl: 'https://tolgee.sgamesuat.com',
                    defaultLanguage: language,
                    observerType: 'text',
                    observerOptions: { inputPrefix: '{{', inputSuffix: '}}' },
                    ns: ns.split(',')
                });

            tolgee.run();
        }
    }
}(jQuery));

$(document).ready(function () {
    tolgee.init();
});