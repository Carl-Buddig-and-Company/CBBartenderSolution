$(".lnkSave").live("click", function () {
    $("#divHolder").attr('disabled', true);
    $("#divWait").css({ 'display': 'block' });
});