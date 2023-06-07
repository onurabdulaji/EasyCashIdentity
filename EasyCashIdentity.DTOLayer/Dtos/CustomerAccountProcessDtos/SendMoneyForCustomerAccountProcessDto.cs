﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCashIdentity.DTOLayer.Dtos.CustomerAccountProcessDtos
{
    public class SendMoneyForCustomerAccountProcessDto
    {
        public string ProcessType { get; set; }
        public decimal Amount { get; set; }
        public DateTime ProcessDate { get; set; }
        public int SenderID { get; set; }
        public int RecieverID { get; set; }
        public string ReceiverAccountNumber { get; set; }

    }
}
