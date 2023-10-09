function readURL(input, priviewImg) {

    if (input.files && input.files[0]) {
        var reader = new FileReader();

        reader.onload = function (e) {
            $(priviewImg).attr('src', e.target.result);
        }

        reader.readAsDataURL(input.files[0]);
    }
}

$("[ImageInput]").change(function () {
    var x = $(this).attr("ImageInput");
    if (this.files && this.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            $("[ImageFile=" + x + "]").attr('src', e.target.result);
        };
        reader.readAsDataURL(this.files[0]);
    }
});

$(document).ready(function () {
    // set ckeditor for textareas where they have ckeditor attribute
    var editors = $("[ckeditor]");
    if (editors.length > 0) {
        $.getScript("/assets/js/editors/ckeditor/ckeditor.js?v=123",
            function (script, textStatus, jqXHR) {
                $(editors).each(function (index, value) {
                    var id = $(value).attr('ckeditor');
                    ClassicEditor.create(document.querySelector('[ckeditor="' + id + '"]'),
                        {
                            toolbar: {
                                items: [
                                    'heading',
                                    '|',
                                    'bold',
                                    'italic',
                                    'link',
                                    '|',
                                    'fontSize',
                                    'fontColor',
                                    '|',
                                    'imageUpload',
                                    'blockQuote',
                                    'insertTable',
                                    'undo',
                                    'redo',
                                    'codeBlock'
                                ]
                            },
                            language: 'en',
                            table: {
                                contentToolbar: [
                                    'tableColumn',
                                    'tableRow',
                                    'mergeTableCells'
                                ]
                            },
                            licenseKey: '',
                            simpleUpload: {
                                // The URL that the images are uploaded to.
                                uploadUrl: '/Uploader/UploadImage'
                            }

                        }).then(editor => {
                        window.editor = editor;
                    }).catch(error => {
                        console.error(error);
                    });
                });
            });
    }
});

function fillPage(id) {
    $("#Page").val(id);
    $("#filter-form").submit();
}

// submit form with filter-search id on change radio buttons
$('#filter-form input[type=radio]').change(function () {
    $("#pageId").val(1);
    $("#filter-search").submit();
});


function reloadPageAfterSeconds(seconds) {
    setTimeout(function () {
        location.reload();
    }, seconds);
}

function AddOwlCarousel(selector, config) {
    $(selector).owlCarousel(config);
}

var cursorPointerElements = $('[cusror-pointer]');
if (cursorPointerElements.length > 0) {
    $.each(cursorPointerElements,
        function (index, value) {
            $(value).css('cursor', 'pointer');
        });
}