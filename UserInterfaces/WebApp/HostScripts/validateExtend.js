$.extend($.fn.validatebox.defaults.rules, {
    //下拉框必选项
    requiredSelect: {
        validator: function (value, param) {
            return value && value !== '请选择';
        },
        message: "该输入项是必选项！"
    },
    //整数
    Integer: {
        validator: function (value, param) {
            return /^\-?\d+$/.test(value);
        },
        message: "请输入正确的整数！"
    },
    //正整数
    PositiveInteger:{
        validator: function (value, param) {
            return (/^(\+|-)?\d+$/.test(value)) && value > 0;
        },
        message: "请输入正整数！"
    },
    //非负 整数
    PositiveInt: {
        validator: function (value, param) {
            return (/^(\+|-)?\d+$/.test(value)) && value >= 0;
        },
        message: "请输入不小于0的整数！"
    },
    //数字
    Numerical: {
        validator: function (value, param) {
            return /^\d+(\.\d+)?$/.test(value);
        },
        message: "请输入正确的数值！"
    },
    // 价格
    Price: {
        validator: function (value, param) {
            return /^(\d{1,10})(\.\d{1,2})?$/.test(value);
        },
        message: "请输入数字,小数点后最多2位！"
    },
    // 价格（小数点前面无长度限制）
    Price2: {
        validator: function (value, param) {
            return /^(\d)(\.\d{1,2})?$/.test(value);
        },
        message: "请输入数字,小数点后最多2位！"
    },
    // 利率
    Rate: {
        validator: function (value) {
            return /^(-?)(\d+)(\.?)(\d*)$/.test(value);
        },
        message: "请输入正确的利率。"
    },
    // 比例
    Ratio: {
        validator: function (value) {
            return /^(-?)(\d+)(\.?)(\d*)$/.test(value);
        },
        message: "请输入正确的比例值。"
    },
    // 日期
    Date: {
        validator: function (value) {
            return /^(?:(?!0000)[0-9]{4}([-]?)(?:(?:0?[1-9]|1[0-2])\1(?:0?[1-9]|1[0-9]|2[0-8])|(?:0?[13-9]|1[0-2])\1(?:29|30)|(?:0?[13578]|1[02])\1(?:31))|(?:[0-9]{2}(?:0[48]|[2468][048]|[13579][26])|(?:0[48]|[2468][048]|[13579][26])00)([-]?)0?2\2(?:29))$/i.test(value);
        },
        message: "请输入正确的日期！(如:2000-01-01)"
    },
    // 日期时间
    DateTime: {
        validator: function (value) {
            return /^(\d{1,4})(-|\/)(\d{1,2})\2(\d{1,2}) (\d{1,2}):(\d{1,2}):(\d{1,2})$/.test(value);
        },
        message: "请输入正确的时间！(如:2000-01-01 00:00:00)"
    },
    // 年月
    YearMonth: {
        validator: function (value) {
            return /^\d{4}-\d{2}$/i.test(value);
        },
        message: "请输入正确的日期！(如:2000-01)"
    },
    // 年
    Year: {
        validator: function (value) {
            return /^\d{4}$/i.test(value);
        },
        message: "请输入正确的日期！(如:2000)"
    },
    //手机
    Mobile: {
        validator: function (value) {
            ////return /^[1](3|4|5|7|8)\d{9}$/.test(value);
            return /^[1]\d{10}$/.test(value);
        },
        message: "请输入正确的手机号码！(如:13800000000)"
    },
    // 电话号码
    Phone: {
        validator: function (value) {
            var score = /^((\(\d{2,3}\))|(\d{3}\-))?(\(0\d{2,3}\)|0\d{2,3}-)?[1-9]\d{6,7}(\-\d{1,4})?$/i;
            return score.test(value);
        },
        message: "请填入电话号码,如010-8888888"
    },
    // 邮箱
    Email: {
        validator: function (value) {
            return /^[a-z0-9]+([._\\-]*[a-z0-9])*@([a-z0-9]+[-a-z0-9]*[a-z0-9]+.){1,63}[a-z0-9]+$/.test(value);
        },
        message: "请输入正确的邮箱地址！"
    },
    // 身份证
    Identity: {
        validator: function (value) {
            return /^(^[1-9]\d{7}((0\d)|(1[0-2]))(([0|1|2]\d)|3[0-1])\d{3}$)|(^[1-9]\d{5}[1-9]\d{3}((0\d)|(1[0-2]))(([0|1|2]\d)|3[0-1])((\d{4})|\d{3}[Xx])$)$/.test(value);
        },
        message: "请输入正确的身份证号！"
    },
    // 邮编
    PostCode: {
        validator: function (value) {
            return /^\d{6}$/.test(value);
        },
        message: "请输入6位纯数字邮政编码！"
    },
    // 车牌号
    PlateNo: {
        validator: function (value) {
            return /^[\u4e00-\u9fa5]{1}[a-zA-Z]{1}[\da-zA-Z]{5}$/.test(value);
        },
        message: "请输入正确的车牌号！"
    },
    // 车架号
    FrameNo: {
        validator: function (value) {
            return /^[a-zA-Z0-9]{17}$/.test(value);
        },
        message: "字符要17位！"
    },
    // 组织机构代码证
    OrganizationCode: {
        validator: function (value) {
            return /^[\da-zA-Z]{8}\-[\da-zA-Z]$/.test(value);
        },
        message: "请输入有效的组织机构代码证！(如：00000000-0)"
    },
    // 验证手机或电话
    PhoneOrMobile: {
        validator: function (value) {
            return /^[1](3|4|5|7|8)\d{9}$/.test(value) || /^((\(\d{2,3}\))|(\d{3}\-))?(\(0\d{2,3}\)|0\d{2,3}-)?[1-9]\d{6,7}(\-\d{1,4})?$/i.test(value);
        },
        message: '请填入手机或电话号码,如13800000000或010-8888888'
    },
    // 帐号
    checkUsernameFormat: {
        validator: function (value) {
            return /^[a-z\_]{1}\w{1,18}$/i.test(value);
        },
        message: "请输入正确的用户名，由字母、数字和下划线组成。不可以数字开头,长度在2-18位之间!"
    },
    // 帐号重复验证 [否决的]
    checkUsernameRepeat: {
        validator: function (value, param) {
            var result = false;

            $.ajax({
                async: false,
                data: { username: value },
                type: "GET",
                url: "../api/User/CheckUsername",
                statusCode: {
                    200: function (data) {
                        result = true;
                    }
                }
            });

            return result;
        },
        message: '用户名已使用!'
    },
    
    ScaleRange: {
        validator: function (value, param) {
            if (param === undefined) {
                return value <= 100 && value >= 0;
            }
            else {
                return value <= param[1] && value >= param[0];
            }
        },
        message: '比例区间超出边界！'
    },
});