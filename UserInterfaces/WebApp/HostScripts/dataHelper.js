// Json序列化
$.fn.serializeJson = function () {
    var obj = {};
    var array = this.serializeArray();

    var selector = this.selector;

    if (!!window.ActiveXObject || "ActiveXObject" in window) {
        array = $(this).parents("form").serializeArray();

        array = $.map(array, function (val) {
            if ($("[name=" + val.name + "]").parents(selector).length)
                return val;
        });
    }

    $.each(array, function (i, e) {
        if (obj[e.name] !== undefined) {
            if (!obj[e.name].push) {
                obj[e.name] = [obj[e.name]];
            }
            obj[e.name].push(e.value || '');
        } else {
            obj[e.name] = e.value || '';
        }
    });

    return obj;
};

// 对象数据克隆
function ObjClone(obj) {
    if (obj === null) {
        return null;
    }

    let jsonStr = JSON.stringify(obj);

    return JSON.parse(jsonStr);
}

/**
 * 日期转换：时间戳->本地时间      
 * @param {Date} nS 时间戳
 * @returns {Date} 本地时间
 */
function GetLocalTime(nS) {

    //时间戳为10位需*1000，时间戳为13位的话不需乘1000
    if (nS.length === 10) {
        nS = nS * 1000;
    }

    let date = new Date(nS);
    if (date.toString() === "Invalid Date") {
        return '无效日期';
    }
    let Y = date.getFullYear() + '-',
        M = (date.getMonth() + 1 < 10 ? '0' + (date.getMonth() + 1) : date.getMonth() + 1) + '-',
        D = date.getDate() + ' ',
        h = date.getHours() + ':',
        m = date.getMinutes() + ':',
        s = date.getSeconds();

    return Y + M + D + h + m + s;
}

/**
 * 格式化数字：千分位
 * @param {any} value 待格式化值
 * @param {number} point 保留小数（默认2位）
 * @returns {number} 格式化值
 */
function Format2Thousand(value, point = 2) {
    value = value + '';

    if (value === null || value.length === 0) {
        value = 0;
    }

    if (typeof value === 'string') {
        value = value.replace(/,/g, '');
    }

    value = parseFloat(value) || 0;

    return (value.toFixed(point) + '').replace(/\d{1,3}(?=(\d{3})+(\.\d*)?$)/g, '$&,');
}

// js格式化时间 "yyyy-MM-dd hh:mm:ss"  
Date.prototype.Format = function (fmt) {
    var o = {
        "M+": this.getMonth() + 1, //月份  
        "d+": this.getDate(), //日  
        "h+": this.getHours(), //小时  
        "m+": this.getMinutes(), //分  
        "s+": this.getSeconds(), //秒  
        "q+": Math.floor((this.getMonth() + 3) / 3), //季度  
        "S": this.getMilliseconds() //毫秒  
    };
    if (/(y+)/.test(fmt))
        fmt = fmt.replace(RegExp.$1, (this.getFullYear() + "").substr(4 - RegExp.$1.length));
    for (var k in o)
        if (new RegExp("(" + k + ")").test(fmt))
            fmt = fmt.replace(RegExp.$1, (RegExp.$1.length === 1) ? (o[k]) : (("00" + o[k]).substr(("" + o[k]).length)));
    return fmt;
}
Date.prototype.addDays = function (d) {
    this.setDate(this.getDate() + d);

    return this;
};
Date.prototype.addWeeks = function (w) {
    this.addDays(w * 7);
};
Date.prototype.addMonths = function (m) {
    var d = this.getDate();
    this.setMonth(this.getMonth() + m);
    if (this.getDate() < d) {
        this.setDate(0);
    }

    return this;
};
Date.prototype.addYears = function (y) {
    var m = this.getMonth();
    this.setFullYear(this.getFullYear() + y);
    if (m < this.getMonth()) {
        this.setDate(0);
    }
};

String.prototype.endWith = function (str) {
    if (str === null || str === "" || this.length === 0 || str.length > this.length) {
        return false;
    }

    return this.substring(this.length - str.length) === str;
};

String.prototype.startWith = function (str) {
    if (str === null || str === "" || this.length === 0 || str.length > this.length) {
        return false;
    }

    return this.substr(0, str.length) === str;
};