using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InoCar.Api.Model
{
 
        public class ApiResponse<TItem>
        {
            public ApiResponse(IEnumerable<TItem> items)
            {
                Items = items;
               
            }

            public IEnumerable<TItem> Items { get; set; }
           
        }

}
