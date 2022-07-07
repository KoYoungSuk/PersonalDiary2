using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalDiary2
{
    internal class MemberDTO
    {
        string id;
        String password;
        public MemberDTO()
        {

        }
        public string Id { get => id; set => id = value; }
        public string Password { get => password; set => password = value; }
    }
}
