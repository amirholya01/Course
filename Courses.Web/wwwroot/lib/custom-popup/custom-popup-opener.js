/*
every link should have custom-popup-page attribute to handle custom popup
these attrs can be set to open new popup
custom-popup-page-url: this is the url of the page that you want to open (required)
custom-popup-page-width: set the width of the popup page
custom-popup-page-height: set the height of the popup page
custom-popup-page-data: send data to popup page (you should set global variable in the page and send its name in this attribute)
custom-popup-page-handler: handler method to execute after popup closed. you should send function name to it
custom-popup-page-target: this is the target of the page to open
custom-popup-page-layout: this is for choosing layout should be empty or not. default is empty. choices are: empty, admin

you can access to sent data with popupData name
you can access to sent handler with closeHandler name
*/

let customWindow;

function generateCustomPopupOpenerHandler() {
    $('[custom-popup-page]').on('click', function () {
        // url of the page you want to open in popup
        let pageUrl = $(this).attr('custom-popup-page-url');
        let layout = $(this).attr('custom-popup-page-layout');
        if (layout === null || layout === undefined) {
            layout = 'empty';
        }

        if (layout === 'empty') {
            if (pageUrl.toString().indexOf('?') > -1) {
                pageUrl += '&popup-page=True';
            } else {
                pageUrl += '?popup-page=True';
            }
        }
        // get window page size
        let pageWidth = $(this).attr('custom-popup-page-width');
        let pageHeight = $(this).attr('custom-popup-page-height');
        // default width and height
        let width = '1000';
        let height = '700';
        // set width and height
        if (pageWidth !== '' && pageWidth !== null && pageWidth !== undefined) width = pageWidth;
        if (pageHeight !== '' && pageHeight !== null && pageHeight !== undefined) height = pageHeight;

        let y = window.top.outerHeight / 2 + window.top.screenY - (parseInt(height) / 2);
        let x = window.top.outerWidth / 2 + window.top.screenX - (parseInt(width) / 2);

        // set target for popup to open in
        let popupTarget = $(this).attr('custom-popup-page-target');
        if (popupTarget === null || popupTarget === undefined) popupTarget = 'custom-popup';

        // popup window parameters
        let params = `scrollbars=no,resizable=no,status=no,location=no,toolbar=no,menubar=no,width=${width},height=${height},left=${x},top=${y}`;

        // check page url has been set
        if (pageUrl === '' || pageUrl === undefined || pageUrl === null) {
            return;
        }

        // popup handler
        let handler = $(this).attr('custom-popup-page-handler');
        // handle data that has been sent to popup window
        let pageDataKeyName = $(this).attr('custom-popup-page-data');
        let pageData = {};
        if (pageDataKeyName !== '' && pageDataKeyName !== null && pageDataKeyName !== undefined) {
            if (window[pageDataKeyName.toString()] !== null && window[pageDataKeyName.toString()] !== undefined) {
                pageData = window[pageDataKeyName.toString()];
            }
        }

        // open popup
        customWindow = window.open(pageUrl, popupTarget, params);
        if (window.focus) {
            customWindow.focus();
            localStorage.removeItem('customPopupWindow');
            localStorage.setItem('customPopupWindow', JSON.stringify({
                popupData: pageData,
                handler: handler
            }));
        }
    });
}

generateCustomPopupOpenerHandler();