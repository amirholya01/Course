// data that has been got from popup opener
let popupData = {};
let closeHandler = undefined;
let localstorageData = JSON.parse(localStorage.getItem('customPopupWindow'));

if (localstorageData.popupData !== null && localstorageData.popupData !== undefined) {
    popupData = localstorageData.popupData;
}

if (localstorageData.handler !== '' && localstorageData.handler !== null && localstorageData.handler !== undefined) {
    closeHandler = localstorageData.handler;
}

console.log('your close handler is: ', closeHandler);
console.log('your data is: ', popupData);