using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Data;
using CS2010.ArcSys.Business;

namespace CS2010.ArcSys.Business
{

    public class modTranshipmentReport
    {

        private Boolean _IsBooking;
        public Boolean IsBooking
        {
            get
            {
                return _IsBooking;
            }
            set
            {
                _IsBooking = value;
            }
        }

        public Boolean IsBol
        {
            get
            {
                return !_IsBooking;
            }
        }

        private DateTime? _sailDateFrom;
        public DateTime? sailDateFrom
        {
            get
            {
                return _sailDateFrom;
            }
            set
            {
                _sailDateFrom = value;
            }
        }

        private DateTime? _sailDateTo;
        public DateTime? sailDateTo
        {
            get
            {
                return _sailDateTo;
            }
            set
            {
                _sailDateTo = value;
            }
        }

        public string voyage { get; set; }

        private string _vessels;
        public string vessels
        {
            get
            {
                return _vessels;
            }
            set
            {
                _vessels = value;
            }
        }

        private string _booking;
        public string booking
        {
            get
            {
                return _booking;
            }
            set
            {
                _booking = value;
            }
        }

        private string _bol;
        public string bol
        {
            get
            {
                return _bol;
            }
            set
            {
                _bol = value;
            }
        }

        public string ErrorMsg { get; set; }

    }

}
