// 获取Url参数
function GetQueryString(name) {
    let reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)");

    let r = window.location.search.substr(1).match(reg);

    return r === null ? null : decodeURI(r[2]);
}
/**
 * 获取URL参数
 * @returns {Object} 参数
 */
function GetRequest() {
    let url = decodeURI(location.search);//获取url中"?"符后的字串
    if (!url) {
        return {};
    }
    let theRequest = new Object();
    if (url.indexOf("?") !== -1) {
        let str = url.substr(1);
        strs = str.split("&");
        for (let i = 0; i < strs.length; i++) {
            theRequest[strs[i].split("=")[0]] = unescape(strs[i].split("=")[1]);
        }
    }

    return theRequest;
}   

// 是否为IE内核
function IsIE() {
    return !!window.ActiveXObject || "ActiveXObject" in window;
}

/**
 * Js版Ajax多请求并行，并统一返回结果
 * @param {any} ajaxOptions Ajax请求设置集合
 * @returns {Promise} Promise
 */
function RunAllTaskForAjax(ajaxOptions) {
    if (Object.prototype.toString.call(ajaxOptions) !== "[object Array]") {
        return null;
    }

    let tasks = [];

    for (let i = 0; i < ajaxOptions.length; i++) {
        let ajaxOption = ajaxOptions[i];

        if (!ajaxOption) {
            tasks.push(Promise.resolve(null));

            break;
        }

        let promise = new Promise(function (resolve, reject) {
            $.ajax(ajaxOption).done(function (data) {
                resolve(data);
            }).fail(function (data) {
                resolve(data);
            });
        });

        tasks.push(promise);
    }

    return Promise.all(tasks);
}
