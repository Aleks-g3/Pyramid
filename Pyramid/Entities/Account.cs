using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyramid.Entities
{
    public class Account
    {
        public Member Member { get; private set; }
        public long Amount { get; private set; }

        public Account(Member member)
        {
            this.Member = member;
            this.Amount = 0;
        }
    }
}
