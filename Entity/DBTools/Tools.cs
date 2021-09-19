using System.Collections.Generic;

namespace Entity.Tools
{
    public enum Permision
    {
        none = 0,
        x = 1,
        w = 10,
        r = 100,
        wx = 11,
        rx = 101,
        rw = 110,
        rwx = 111
    }
    public static class ValidationTools
    {
        public const string RequiredField_Msg = "ورود این فیلد ضروری ست.";

        public const string Tell_Regx = ".*";
        public const string Tell_Msg = "شماره همراه مجاز وارد نمایید.";

        public const string Pass_Regx = ".*";
        public const string Pass_Msg = "گذرواژه بایستی حداقل 8 حرف شامل حروف ،عدد و نماد ها باشد.";

        public const string Mail_Regx = ".*";
        public const string Mail_Msg = "یک ایمیل صحیح وارد نمایید.";

        public const string OnlyNumber_Regx = ".*";
        public const string OnlyNumber_Msg = "تنها مجاز به وروود اعدا هستید";

        public const string WithOutSymbol_Regx = ".*";
        public const string WithOutSymbol_Msg = "مجاز به ورود تمام حروف بجز نماد ها هستید.";

        public const string StandardName_Regx = ".*";
        public const string StandardName_Msg = "یک نام صحیح فارسی یاانگلیسی(بدون نماد و اعداد)وارد نمایید.";

        public const string StandardEngName_Regx = ".*";
        public const string StandardEngName_Msg = "یک نام صحیح انگلیسی(بدون نماد و اعداد)وارد نمایید.";

        public const string StandardFaName_Regx = ".*";
        public const string StandardFaName_Msg = "یک نام صحیح فارسی(بدون نماد و اعداد)وارد نمایید.";

        public const string EngStr_Regx = ".*";
        public const string EngStr_Msg = "مجاز به ورود حروف هستید.";

        public const string FaStr_Regx = ".*";
        public const string FaStr_Msg = "مجاز به ورود حروف فارسی هستید.";

        public const string Url_Regx = ".*";
        public const string Url_Msg = "آدرس اینترنتی صحیح وارد نمایید.";
        public static string MinLengthMsg(int x) => "حداقل طول رشته ورودی بایستی " + x.ToString() + "نویسه باشد";






        public const string ValdationError = "اطلاعات ورودی غیر مجاز است";

    }
}