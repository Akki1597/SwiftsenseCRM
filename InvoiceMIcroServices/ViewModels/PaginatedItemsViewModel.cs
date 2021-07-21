using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceMIcroServices.ViewModels
{
    public class PaginatedItemsViewModel<TEntity> where TEntity:class
    {
        public PaginatedItemsViewModel(int pageSize, int pageIndex, int count, IEnumerable<TEntity> data)
        {
            this.pageSize = pageSize;
            this.pageIndex = pageIndex;
            this.count = count;
            this.data = data;
        }

        public int pageSize { get; private set; }
        public int pageIndex { get; private set; }
        public int count { get; set; }
        public IEnumerable<TEntity> data { get; set; }

        
    }
}
