using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Store.Common.Constant.OrderState
{
    public enum OrderState
    {
        [Display(Name = "در انتظار پرداخت")]
        WatingPay = 0,
        [Display(Name = "درحال پردازش")]
        Processing = 1,
        [Display(Name = "تحویل شده")]
        Delivered = 2,
        [Display(Name = "لغو شده")]
        Canceled = 3,
    }
}
