using System;
using System.Collections.Generic;
using System.Text;

namespace Weable.TMS.Infrastructure.Model
{
    public class PagingModel
    {
        public PagingModel()
        {
        }
        public PagingModel(int page, int pageSize)
        {
            CurrentPage = page;
            PageSize = pageSize;
        }
        public static PagingModel createPaging(Paging paging) {
            var model = new PagingModel()
            {
                CurrentPage = paging.CurrentPage,
                PageCount = paging.PageCount,
                PageSize = paging.PageSize,
                RowCount = paging.RowCount,
                FirstRowOnPage = paging.FirstRowOnPage,
                LastRowOnPage = paging.LastRowOnPage
            };
            return model;
        }
        public int CurrentPage { get; set; }
        public int PageCount { get; set; }
        public int PageSize { get; set; }
        public int RowCount { get; set; }
        public int FirstRowOnPage { get; set; }
        public int LastRowOnPage { get; set; }
    }
}
