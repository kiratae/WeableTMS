/*
 * App JavaScript v1
 */
$.ajaxSetup({
    // Disable caching of AJAX responses
    cache: false
    //async: false
});

//moment.locale('th');

var __WE_MASK_NUMBER = new Mask("#,##0.00", "number");
var __WE_MASK_NUM = new Mask('#,###.##', "number");
var __WE_MASK_INT = new Mask('#,###', "number");
var __WE_MASK_STR_DIGIT_3 = new Mask('###');
var __WE_MASK_STR_DIGIT_5 = new Mask('#####');
var __WE_MASK_STR_DIGIT_7 = new Mask('#######');
var __WE_MASK_STR_DIGIT_8 = new Mask('########');
var __WE_MASK_STR_DIGIT_13 = new Mask('#############');
var __WE_MASK_STR_DIGIT_14 = new Mask('##############');
var __WE_MASK_STR_DIGIT_16 = new Mask('################');

var __suspend_edit_inline_click = false;

$(document).ready(function () {
    $('.datepicker').wePikaday();
    $('input.number').weMask({ maskObj: __WE_MASK_NUMBER });
    $('input.num').weMask({ maskObj: __WE_MASK_NUM });
    $('input.int').weMask({ maskObj: __WE_MASK_INT });
    $('input.str-digit-3').weMask({ maskObj: __WE_MASK_STR_DIGIT_3 });
    $('input.str-digit-5').weMask({ maskObj: __WE_MASK_STR_DIGIT_5 });
    $('input.str-digit-7').weMask({ maskObj: __WE_MASK_STR_DIGIT_7 });
    $('input.str-digit-8').weMask({ maskObj: __WE_MASK_STR_DIGIT_8 });
    $('input.str-digit-13').weMask({ maskObj: __WE_MASK_STR_DIGIT_13 });
    $('input.str-digit-14').weMask({ maskObj: __WE_MASK_STR_DIGIT_14 });
    $('input.str-digit-16').weMask({ maskObj: __WE_MASK_STR_DIGIT_16 });
    //$('select.we-select2').select2();
    $('body').bind('DOMNodeInserted', function (e) {
        var element = e.target;
        $(element).find('input.number').weMask({ maskObj: __WE_MASK_NUMBER });
        $(element).find('input.num').weMask({ maskObj: __WE_MASK_NUM });
        $(element).find('input.int').weMask({ maskObj: __WE_MASK_INT });
        $(element).find('input.str-digit-3').weMask({ maskObj: __WE_MASK_STR_DIGIT_3 });
        $(element).find('input.str-digit-5').weMask({ maskObj: __WE_MASK_STR_DIGIT_5 });
        $(element).find('input.str-digit-7').weMask({ maskObj: __WE_MASK_STR_DIGIT_7 });
        $(element).find('input.str-digit-8').weMask({ maskObj: __WE_MASK_STR_DIGIT_8 });
        $(element).find('input.str-digit-13').weMask({ maskObj: __WE_MASK_STR_DIGIT_13 });
        $(element).find('input.str-digit-14').weMask({ maskObj: __WE_MASK_STR_DIGIT_14 });
        $(element).find('input.str-digit-16').weMask({ maskObj: __WE_MASK_STR_DIGIT_16 });
        $(element).find('.datepicker').wePikaday();
    });

    $('.navbar .dropdown').hover(function () {
        $(this).find('.dropdown-menu').first().stop(true, true).delay(50).slideDown();
        $(this).addClass('open');
    }, function () {
        $(this).find('.dropdown-menu').first().stop(true, true).delay(50).slideUp();
        $(this).removeClass('open');
    });

    $('.btn-clear').attr('title', 'clear');
    $('body').on('click', '.btn-clear', function () {
        var cntrId = $(this).attr('for');
        $('#' + cntrId).val('');
        $('#' + cntrId).change();
    });

    $('.btn-reset').attr('title', 'reset');
    $('body').on('click', '.btn-reset', function () {
        var cntrId = $(this).attr('for');
        $('#' + cntrId).val($('#' + cntrId).prop('defaultValue'));
        $('#' + cntrId).change();
    });
    //
    //    $(document).on('change', ':file', function () {
    //        var input = $(this),
    //                numFiles = input.get(0).files ? input.get(0).files.length : 1,
    //                label = input.val().replace(/\\/g, '/').replace(/.*\//, '');
    //        input.trigger('fileselect', [numFiles, label]);
    //    });
    //    $(':file').on('fileselect', function (event, numFiles, label) {
    //
    //        var input = $(this).parents('.input-group').find(':text'),
    //                log = numFiles > 1 ? numFiles + ' files selected' : label;
    //
    //        if (input.length) {
    //            input.val(log);
    //        } else {
    //            if (log)
    //                alert(log);
    //        }
    //
    //    });
});

String.prototype.format = function () {
    var content = this;
    for (var i = 0; i < arguments.length; i++) {
        var replacement = '{' + i + '}';
        content = content.replace(replacement, arguments[i]);
    }
    return content;
};
function weIsStrEmpty(str) {
    var isEmpty = (str = null || str == 'undefined' || str == '');
    return isEmpty;
}
$.fn.checkAll = function (selector, scopeSelector, excludeSelector) {
    if (!selector)
        selector = '.checkboxtable';
    if (!scopeSelector)
        scopeSelector = 'table';
    if (!excludeSelector)
        excludeSelector = '.checkbox-all';
    selector = selector + ':not(' + excludeSelector + ')';

    var self = this;
    $(selector).click(function (e) {
        var checkedItems = $(selector + ':checked');
        var items = $(selector);

        if (checkedItems && checkedItems.length && items && items.length && (checkedItems.length == items.length)) {
            $(self).prop('checked', true);
        } else {
            $(self).prop('checked', false);
        }
    });

    $(this).click(function (e) {
        if ($(this).prop('checked')) {
            $(this).closest(scopeSelector).find(selector).prop('checked', true);
        } else {
            $(this).closest(scopeSelector).find(selector).prop('checked', false);
        }
        $(this).change();
    });
};

$.fn.validateData = function (options) {
    var settings = {
        'title': '',
        'btnok': 'OK',
        'isreq': true,
        'reqprefix': 'Please input ',
        'beforecallback': null,
        'aftercallback': null
    };
    $.extend(settings, options);

    var scope = $(this);

    var internalCallback = function () {
        var errors = [];
        if (settings.beforecallback != null) {
            var errs = settings.beforecallback();
            if (errs != null && errs != 'undefined' && errs.length > 0) {
                for (i = 0; i < errs.length; i++) {
                    errors.push(errs[i]);
                }
            }
        }
        if (settings.isreq) {
            var errs = ClientValidateRequire(scope, settings.reqprefix);
            if (errs != null && errs != 'undefined' && errs.length > 0) {
                for (i = 0; i < errs.length; i++) {
                    errors.push(errs[i]);
                }
            }
        }
        if (settings.aftercallback != null) {
            var errs = settings.aftercallback();
            if (errs != null && errs != 'undefined' && errs.length > 0) {
                for (i = 0; i < errs.length; i++) {
                    errors.push(errs[i]);
                }
            }
        }
        return errors;
    }
    return ClientValidate(internalCallback, settings.title, settings.btnok);
}
$.fn.clearData = function (options) {
    try {
        $(this).find('input[type=text]').val('');
        $(this).find('input[type=checkbox]').prop('checked', false);
        $(this).find('textarea').val('');
        $(this).find('select').prop('selectedIndex', 0);
    } catch (ex) {
    }
}

$.fn.wePikaday = function (options) {
    var settings = {
        'onDraw': null
    };
    $.extend(settings, options);

    var yearOffset = 543;

    var cntr = $(this);
    var isBirthDate = $(cntr).hasClass('birth-date');
    var currDate = $(cntr).val();
    var initDate = new Date();
    if (currDate !== null && currDate !== '' && currDate !== undefined) {
        var dt1 = currDate.substring(0, 2);
        var mon1 = currDate.substring(3, 5);
        var yr1 = currDate.substring(6, 10);
        temp1 = mon1 + "/" + dt1 + "/" + (Number(yr1) - yearOffset);
        initDate = new Date(Date.parse(temp1));
    }

    var todayYear = moment().year();

    $(this).pikaday({
        yearRange: isBirthDate ? [todayYear - 100, todayYear] : null,
        format: 'DD/MM/YYYY',
        i18n: {
            months: moment.localeData()._months,
            weekdays: moment.localeData()._weekdays,
            weekdaysShort: moment.localeData()._weekdaysMin
        },
        toString: function (date, format) {
            // you should do formatting based on the passed format,
            // but we will just return 'D/M/YYYY' for simplicity
            var day = date.getDate();
            var month = date.getMonth() + 1;
            var year = date.getFullYear() + yearOffset;
            //return `${day}/${month}/${year}`;
            return String("00" + day).slice(-2) + '/' + String("00" + month).slice(-2) + '/' + year;
        },
        parse: function (dateString, format) {
            // dateString is the result of `toString` method
            var parts = dateString.split('/');
            var day = parseInt(parts[0], 10);
            var month = parseInt(parts[1], 10) - 1;
            var year = parseInt(parts[2], 10) - yearOffset;
            return new Date(year, month, day);
        },
        onOpen: function () {
            //var split = $(this.getField()).val().split("/");
            //var year = Number(split[2]) - yearOffset;
            //var month = Number(split[1]) - 1;
            //var day = Number(split[0]);
            //var date = new Date(year, month, day)
            //var d = moment(date);
            //this.setDate(d.toDate());
            __suspend_edit_inline_click = true;
        },
        onDraw: function () {
            $('.pika-select-year option').each(function () {
                var beYear = Number($(this).val()) + yearOffset;
                $(this).text(beYear);
            });
            $('.pika-select-year').each(function () {
                var beYear = Number($(this).val()) + yearOffset;
                $(this).closest('.pika-lendar').find('.label-year').html(beYear);
            });

            if (settings.onDraw !== null) {
                settings.onDraw(this);
            }
        },
        onSelect: function (date) {
            //var d = this.getMoment();
            //var d = moment(date);
            //$(this.getField()).val(d.format('DD') + '/' + d.format('MM') + '/' + (Number(d.year()) + yearOffset));
            if (settings.onSelect)
                settings.onSelect(date);
        },
        onClose: function () {
            __suspend_edit_inline_click = false;
        },
        defaultDate: initDate //moment().toDate()
    });
};

$.fn.weSelect = function (options) {
    var settings = {
        placeholder: '- ทั้งหมด -',
        captionFormat: '{0} รายการ',
        captionFormatAllSelected: '{0} รายการ (ทั้งหมด)',
        okCancelInMulti: true,
        isClickAwayOk: true,
        selectAll: true,
        search: true,
        searchText: '- ค้นหา -',
        noMatch: 'ไม่พบข้อมูลจากคำค้น - "{0}"',
        locale: ['ตกลง', 'ยกเลิก', 'เลือกทั้งหมด']
    };
    $.extend(settings, options);
    $(this).SumoSelect({
        placeholder: settings.placeholder,
        captionFormat: settings.captionFormat,
        captionFormatAllSelected: settings.captionFormatAllSelected,
        okCancelInMulti: settings.okCancelInMulti,
        isClickAwayOk: settings.isClickAwayOk,
        selectAll: settings.selectAll,
        search: settings.search,
        searchText: settings.searchText,
        noMatch: settings.noMatch,
        locale: settings.locale
    });
    $(this).val(settings.value);
    $(this)[0].sumo.reload();
};

$.fn.weMask = function (options) {
    var settings = {
        maskObj: __WE_MASK_NUMBER
    };
    $.extend(settings, options);

    $(this).each(function () {
        settings.maskObj.attach($(this)[0]);
    });
    $(this).blur();
}

function GetElementArray(selector, attr) {
    var arr = [];
    $(selector).each(function (index, elem) {
        var val = $(elem).attr(attr);
        arr.push(val);
    });
    return arr;
}
function getErrorMessage(errors) {
    if (errors === null || errors.length <= 0)
        return "";
    var msg = "<ul>";
    for (var i = 0; i < errors.length; i++)
        msg += "<li>" + errors[i] + "</li>";
    msg += "</ul>";
    return msg;
}

function weDeleteSingleRow(url) {
    Swal.fire({
        title: "ยืนยันการลบ",
        text: "โปรดยืนยันการลบข้อมูล",
        type: "warning",
        showCancelButton: true,
        confirmButtonClass: "btn btn-danger ml-1",
        confirmButtonText: "ลบ",
        cancelButtonText: "ยกเลิก",
        cancelButtonClass: "btn btn-secondary mr-1",
        buttonsStyling: false,
        reverseButtons: true
    }).then(function (result) {
        if (result.value) {
            $.post(url,
                null,
                function (data, textStatus, xhr) {
                    console.log(data);
                    if (data.statusCode === "0") {
                        Swal.fire({
                            title: "ลบข้อมูล",
                            text: "ลบข้อมูลเรียบร้อย",
                            type: "success",
                            confirmButtonClass: 'btn btn-primary',
                            confirmButtonText: "ตกลง",
                            buttonsStyling: false
                        }).then(function () {
                            location.reload();
                        });
                    } else {
                        var msg = getErrorMessage(data.errors);
                        if (msg === null || msg === "undefined")
                            msg = "";
                        Swal.fire({
                            title: "ลบข้อมูลไม่สำเร็จ",
                            html: msg,
                            type: "error",
                            confirmButtonClass: 'btn btn-primary',
                            confirmButtonText: "ตกลง",
                            buttonsStyling: false
                        });
                    }
                }, "json");
        }
    });
}
function weSaveForm(form, successCallback, errorCallback = null) {
    $.post($(form).attr("action"),
        $(form).serialize(),
        function (data, textStatus, xhr) {
            if (data.statusCode === "0") {
                Swal.fire({
                    title: "บันทึกข้อมูล",
                    text: "บันทึกข้อมูลเรียบร้อย",
                    type: "success",
                    confirmButtonText: 'ตกลง',
                    confirmButtonClass: 'btn btn-primary',
                    buttonsStyling: false
                }).then(function () {
                    if (successCallback !== null) {
                        successCallback();
                    }
                });
            } else {
                var msg = getErrorMessage(data.errors);
                if (msg === null || msg === "undefined")
                    msg = "";
                Swal.fire({
                    title: "บันทึกไม่สำเร็จ",
                    html: msg,
                    type: "error",
                    confirmButtonText: 'ตกลง',
                    confirmButtonClass: 'btn btn-primary',
                    buttonsStyling: false
                }).then(function () {
                    if (errorCallback instanceof Function) {
                        errorCallback();
                    }
                });
            }
        }, "json"
    );
}

function weWrapRowLink(rowSelector, urlDataSelector, tdExcludedSelector) {
    if (!urlDataSelector)
        urlDataSelector = 'x-url';
    if (!tdExcludedSelector)
        tdExcludedSelector = 'td:not(.tool)';
    $(rowSelector).each(function () {
        var url = $(this).data(urlDataSelector);
        $(this).find(tdExcludedSelector).each(function () {
            var content = $(this).html();
            if (!content)
                content = content + '&nbsp;';
            var dom = '<a href="' + url + '" style="display:inline-block;width:100%;color:inherit;">' + content + '</a>';
            $(this).html(dom);
        });
    });
}


// Ployfill
// 
// Object.assign
if (typeof Object.assign !== 'function') {
    // Must be writable: true, enumerable: false, configurable: true
    Object.defineProperty(Object, "assign", {
        value: function assign(target, varArgs) { // .length of function is 2
            'use strict';
            if (target === null || target === undefined) {
                throw new TypeError('Cannot convert undefined or null to object');
            }

            var to = Object(target);

            for (var index = 1; index < arguments.length; index++) {
                var nextSource = arguments[index];

                if (nextSource !== null && nextSource !== undefined) {
                    for (var nextKey in nextSource) {
                        // Avoid bugs when hasOwnProperty is shadowed
                        if (Object.prototype.hasOwnProperty.call(nextSource, nextKey)) {
                            to[nextKey] = nextSource[nextKey];
                        }
                    }
                }
            }
            return to;
        },
        writable: true,
        configurable: true
    });
}