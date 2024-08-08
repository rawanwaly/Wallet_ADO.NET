using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Entities
{
    public class EntityBase { }
    public class Wallet : EntityBase
    {
        public int WallId { get; set; }
        public string? Holder { get; set; }
        public decimal Balance { get; set; }
        public override string ToString()
        {
            return $"Wallet Data: {WallId} : {Holder} : {Balance}";
        }
    }
}
