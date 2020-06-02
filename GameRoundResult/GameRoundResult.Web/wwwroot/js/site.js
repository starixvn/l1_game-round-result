$(document).ready(function () {
    tippy("#language", {
        interactive: true,
        trigger: 'click',
        allowHTML: true,
        content: document.getElementById('language-options'),
        theme: "light-border"
    });
});