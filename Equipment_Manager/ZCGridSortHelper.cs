using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Equipment_Manager
{
    public class ZCGridSortHelper
    {
        public ZCGridColumnSortButton btn;
        public ZCGridViewSortType SortType = ZCGridViewSortType.SortNone;
        public ZCGridViewKeyFilterType FirstKeyFilterType = ZCGridViewKeyFilterType.FilterNone;
        public ZCGridViewKeyFilterType SecondKeyFilterType = ZCGridViewKeyFilterType.FilterNone;
        public ZCGridViewKeyLinkType KeyLinkType = ZCGridViewKeyLinkType.None;

        public string FirstKey = "";
        public string SecondKey = "";

        public List<string> ListFilterKeys = new List<string>();
        public bool UseListFilter = false;
        public bool HasNullListKey;
        public bool ListFilterSelectAll=true;
        public bool ListFilterSelectNull;

        internal void Clear()
        {
            this.SortType = ZCGridViewSortType.SortNone;
            this.FirstKey = "";
            this.FirstKeyFilterType = ZCGridViewKeyFilterType.FilterNone;
            this.SecondKey = "";
            this.SecondKeyFilterType = ZCGridViewKeyFilterType.FilterNone;
            this.KeyLinkType = ZCGridViewKeyLinkType.None;
            this.UseListFilter = false;
            this.ListFilterKeys.Clear();
        }
    }
    public enum ZCGridViewSortType
    {
        SortAZ,
        SortZA,
        SortNone
    }
    public enum ZCGridViewKeyFilterType{
        Equal,
        GreateThan,
        SmallThan,
        NotEqual,
        BeginWith,
        EndWidt,
        Include,
        NotInclude,
        FilterNone
    }
    public enum ZCGridViewKeyLinkType{
        And,
        Or,
        None

    }
}
