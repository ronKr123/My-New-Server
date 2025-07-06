using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class LendingAndReturnsBooks: BaseEntity
    {
        private Users userCode;
        private Books bookCode;
        private DateTime dateOfLending;
        private DateTime dateOfReturn;

        public Users UserCode { get => userCode; set => userCode = value; }
        public Books BookCode { get => bookCode; set => bookCode = value; }
        public DateTime DateOfLending { get => dateOfLending; set => dateOfLending = value; }
        public DateTime DateOfReturn { get => dateOfReturn; set => dateOfReturn = value; }


    }
}
