using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KKB.BLL.model
{
    class Account
    {
        public string AccountNumber { get; set; }
        private double Balance_;
        public double Balance {
            get
            {
                return Balance_;
            }
            set {
                if(value<0)
                    {
                    throw new Exception("Баланс не может быть отрицательным");
                    }
                else
                {
                    Balance_ = value;
                }
            } }
        public DateTime CreateDate { get; set; }
    }
}
