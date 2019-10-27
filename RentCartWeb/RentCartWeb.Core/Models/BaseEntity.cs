using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentCartWeb.Core.Models
{
    public abstract class BaseEntity
    {
        int _number;
        public int Id
        {
            get
            {
                return this._number;
            }
            set
            {
                this._number = value;
            }
        }

    public DateTimeOffset CreatedAt { get; set; }

        public BaseEntity()
            {
           
            this.CreatedAt =DateTime.Now;
            }
    }
}
