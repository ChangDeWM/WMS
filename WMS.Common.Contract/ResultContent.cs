using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 
namespace WMS.Common.Contract
{
    public interface IResultContent { }
    /// <summary>
    /// 返回内容
    /// </summary> 
    public class ResultContent : IResultContent
    {
        public Boolean Succeed { get; set; }
        public String Msg { get; set; }
    }
    /// <summary>
    /// 返回内容
    /// </summary>
    public class ResultContent<TSource> : IResultContent
    {
        public Boolean Succeed { get; set; }
        public String Msg { get; set; }
        public TSource Data
        {
            get;
            set;
        }
    }

    public class ResultContent<TSource1, TSource2> : IResultContent
    {
        public TSource1 T1 { get; set; }
        public TSource2 T2 { get; set; }
    }
    public class ResultContent<TSource1, TSource2, TSource3> : IResultContent
    {
        public TSource1 T1 { get; set; }
        public TSource2 T2 { get; set; }
        public TSource3 T3 { get; set; }
    }
    public class ResultContent<TSource1, TSource2, TSource3, TSource4> : IResultContent
    {
        public TSource1 T1 { get; set; }
        public TSource2 T2 { get; set; }
        public TSource3 T3 { get; set; }
        public TSource4 T4 { get; set; }
    }
    public class ResultContent<TSource1, TSource2, TSource3, TSource4, TSource5> : IResultContent
    {
        public TSource1 T1 { get; set; }
        public TSource2 T2 { get; set; }
        public TSource3 T3 { get; set; }
        public TSource4 T4 { get; set; }
        public TSource5 T5 { get; set; }
    }
    public class ResultContent<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6> : IResultContent
    {
        public TSource1 T1 { get; set; }
        public TSource2 T2 { get; set; }
        public TSource3 T3 { get; set; }
        public TSource4 T4 { get; set; }
        public TSource5 T5 { get; set; }
        public TSource6 T6 { get; set; }
    }
    public class ResultContent<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TSource7> : IResultContent
    {
        public TSource1 T1 { get; set; }
        public TSource2 T2 { get; set; }
        public TSource3 T3 { get; set; }
        public TSource4 T4 { get; set; }
        public TSource5 T5 { get; set; }
        public TSource6 T6 { get; set; }
        public TSource7 T7 { get; set; }
    }
    public class ResultContent<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TSource7, TSource8> : IResultContent
    {
        public TSource1 T1 { get; set; }
        public TSource2 T2 { get; set; }
        public TSource3 T3 { get; set; }
        public TSource4 T4 { get; set; }
        public TSource5 T5 { get; set; }
        public TSource6 T6 { get; set; }
        public TSource7 T7 { get; set; }
        public TSource8 T8 { get; set; }
    }
    public class ResultContent<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TSource7, TSource8, TSource9> : IResultContent
    {
        public TSource1 T1 { get; set; }
        public TSource2 T2 { get; set; }
        public TSource3 T3 { get; set; }
        public TSource4 T4 { get; set; }
        public TSource5 T5 { get; set; }
        public TSource6 T6 { get; set; }
        public TSource7 T7 { get; set; }
        public TSource8 T8 { get; set; }
        public TSource9 T9 { get; set; }
    }
    public class ResultContent<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TSource7, TSource8, TSource9, TSource10> : IResultContent
    {
        public TSource1 T1 { get; set; }
        public TSource2 T2 { get; set; }
        public TSource3 T3 { get; set; }
        public TSource4 T4 { get; set; }
        public TSource5 T5 { get; set; }
        public TSource6 T6 { get; set; }
        public TSource7 T7 { get; set; }
        public TSource8 T8 { get; set; }
        public TSource9 T9 { get; set; }
        public TSource10 T10 { get; set; }
    }
    public class ResultContent<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TSource7, TSource8, TSource9, TSource10, TSource11> : IResultContent
    {
        public TSource1 T1 { get; set; }
        public TSource2 T2 { get; set; }
        public TSource3 T3 { get; set; }
        public TSource4 T4 { get; set; }
        public TSource5 T5 { get; set; }
        public TSource6 T6 { get; set; }
        public TSource7 T7 { get; set; }
        public TSource8 T8 { get; set; }
        public TSource9 T9 { get; set; }
        public TSource10 T10 { get; set; }
        public TSource11 T11 { get; set; }
    }
    public class ResultContent<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TSource7, TSource8, TSource9, TSource10, TSource11, TSource12> : IResultContent
    {
        public TSource1 T1 { get; set; }
        public TSource2 T2 { get; set; }
        public TSource3 T3 { get; set; }
        public TSource4 T4 { get; set; }
        public TSource5 T5 { get; set; }
        public TSource6 T6 { get; set; }
        public TSource7 T7 { get; set; }
        public TSource8 T8 { get; set; }
        public TSource9 T9 { get; set; }
        public TSource10 T10 { get; set; }
        public TSource11 T11 { get; set; }
        public TSource12 T12 { get; set; }
    }
    public class ResultContent<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TSource7, TSource8, TSource9, TSource10, TSource11, TSource12, TSource13> : IResultContent
    {
        public TSource1 T1 { get; set; }
        public TSource2 T2 { get; set; }
        public TSource3 T3 { get; set; }
        public TSource4 T4 { get; set; }
        public TSource5 T5 { get; set; }
        public TSource6 T6 { get; set; }
        public TSource7 T7 { get; set; }
        public TSource8 T8 { get; set; }
        public TSource9 T9 { get; set; }
        public TSource10 T10 { get; set; }
        public TSource11 T11 { get; set; }
        public TSource12 T12 { get; set; }
        public TSource13 T13 { get; set; }
    }
    public class ResultContent<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TSource7, TSource8, TSource9, TSource10, TSource11, TSource12, TSource13, TSource14> : IResultContent
    {
        public TSource1 T1 { get; set; }
        public TSource2 T2 { get; set; }
        public TSource3 T3 { get; set; }
        public TSource4 T4 { get; set; }
        public TSource5 T5 { get; set; }
        public TSource6 T6 { get; set; }
        public TSource7 T7 { get; set; }
        public TSource8 T8 { get; set; }
        public TSource9 T9 { get; set; }
        public TSource10 T10 { get; set; }
        public TSource11 T11 { get; set; }
        public TSource12 T12 { get; set; }
        public TSource13 T13 { get; set; }
        public TSource14 T14 { get; set; }
    }
    public class ResultContent<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TSource7, TSource8, TSource9, TSource10, TSource11, TSource12, TSource13, TSource14, TSource15> : IResultContent
    {
        public TSource1 T1 { get; set; }
        public TSource2 T2 { get; set; }
        public TSource3 T3 { get; set; }
        public TSource4 T4 { get; set; }
        public TSource5 T5 { get; set; }
        public TSource6 T6 { get; set; }
        public TSource7 T7 { get; set; }
        public TSource8 T8 { get; set; }
        public TSource9 T9 { get; set; }
        public TSource10 T10 { get; set; }
        public TSource11 T11 { get; set; }
        public TSource12 T12 { get; set; }
        public TSource13 T13 { get; set; }
        public TSource14 T14 { get; set; }
        public TSource15 T15 { get; set; }
    }
    public class ResultContent<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TSource7, TSource8, TSource9, TSource10, TSource11, TSource12, TSource13, TSource14, TSource15, TSource16> : IResultContent
    {
        public TSource1 T1 { get; set; }
        public TSource2 T2 { get; set; }
        public TSource3 T3 { get; set; }
        public TSource4 T4 { get; set; }
        public TSource5 T5 { get; set; }
        public TSource6 T6 { get; set; }
        public TSource7 T7 { get; set; }
        public TSource8 T8 { get; set; }
        public TSource9 T9 { get; set; }
        public TSource10 T10 { get; set; }
        public TSource11 T11 { get; set; }
        public TSource12 T12 { get; set; }
        public TSource13 T13 { get; set; }
        public TSource14 T14 { get; set; }
        public TSource15 T15 { get; set; }
        public TSource16 T16 { get; set; }
    }
    public class ResultContent<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TSource7, TSource8, TSource9, TSource10, TSource11, TSource12, TSource13, TSource14, TSource15, TSource16, TSource17> : IResultContent
    {
        public TSource1 T1 { get; set; }
        public TSource2 T2 { get; set; }
        public TSource3 T3 { get; set; }
        public TSource4 T4 { get; set; }
        public TSource5 T5 { get; set; }
        public TSource6 T6 { get; set; }
        public TSource7 T7 { get; set; }
        public TSource8 T8 { get; set; }
        public TSource9 T9 { get; set; }
        public TSource10 T10 { get; set; }
        public TSource11 T11 { get; set; }
        public TSource12 T12 { get; set; }
        public TSource13 T13 { get; set; }
        public TSource14 T14 { get; set; }
        public TSource15 T15 { get; set; }
        public TSource16 T16 { get; set; }
        public TSource17 T17 { get; set; }
    }
    public class ResultContent<TSource1, TSource2, TSource3, TSource4, TSource5, TSource6, TSource7, TSource8, TSource9, TSource10, TSource11, TSource12, TSource13, TSource14, TSource15, TSource16, TSource17, TSource18> : IResultContent
    {
        public TSource1 T1 { get; set; }
        public TSource2 T2 { get; set; }
        public TSource3 T3 { get; set; }
        public TSource4 T4 { get; set; }
        public TSource5 T5 { get; set; }
        public TSource6 T6 { get; set; }
        public TSource7 T7 { get; set; }
        public TSource8 T8 { get; set; }
        public TSource9 T9 { get; set; }
        public TSource10 T10 { get; set; }
        public TSource11 T11 { get; set; }
        public TSource12 T12 { get; set; }
        public TSource13 T13 { get; set; }
        public TSource14 T14 { get; set; }
        public TSource15 T15 { get; set; }
        public TSource16 T16 { get; set; }
        public TSource17 T17 { get; set; }
        public TSource18 T18 { get; set; }
    }



    public static class ResultContentExpand
    {
        public static IQueryable<ResultContent<TResult1, TResult2>> ToResult<TSource, TResult1, TResult2>(this IQueryable<TSource> source, Func<TSource, TResult1> selector1, Func<TSource, TResult2> selector2)
        {
            if (source == null) throw new Exception("source is null");
            if (selector1 == null) throw new Exception("selector1 is null");
            if (selector2 == null) throw new Exception("selector2 is null");
            return source.Select(x => new ResultContent<TResult1, TResult2> { T1 = selector1(x), T2 = selector2(x) });
        }
        public static IQueryable<ResultContent<TResult1, TResult2, TResult3>> ToResult<TSource, TResult1, TResult2, TResult3>(this IQueryable<TSource> source, Func<TSource, TResult1> selector1, Func<TSource, TResult2> selector2, Func<TSource, TResult3> selector3)
        {
            if (source == null) throw new Exception("source is null");
            if (selector1 == null) throw new Exception("selector1 is null");
            if (selector3 == null) throw new Exception("selector3 is null");
            if (selector3 == null) throw new Exception("selector3 is null");
            return source.Select(x => new ResultContent<TResult1, TResult2, TResult3> { T1 = selector1(x), T2 = selector2(x), T3 = selector3(x) });
        }
        public static IQueryable<ResultContent<TResult1, TResult2, TResult3, TResult4>> ToResult<TSource, TResult1, TResult2, TResult3, TResult4>(this IQueryable<TSource> source, Func<TSource, TResult1> selector1, Func<TSource, TResult2> selector2, Func<TSource, TResult3> selector3, Func<TSource, TResult4> selector4)
        {
            if (source == null) throw new Exception("source is null");
            if (selector1 == null) throw new Exception("selector1 is null");
            if (selector4 == null) throw new Exception("selector4 is null");
            if (selector4 == null) throw new Exception("selector4 is null");
            if (selector4 == null) throw new Exception("selector4 is null");
            return source.Select(x => new ResultContent<TResult1, TResult2, TResult3, TResult4> { T1 = selector1(x), T2 = selector2(x), T3 = selector3(x), T4 = selector4(x) });
        }
        public static IQueryable<ResultContent<TResult1, TResult2, TResult3, TResult4, TResult5>> ToResult<TSource, TResult1, TResult2, TResult3, TResult4, TResult5>(this IQueryable<TSource> source, Func<TSource, TResult1> selector1, Func<TSource, TResult2> selector2, Func<TSource, TResult3> selector3, Func<TSource, TResult4> selector4, Func<TSource, TResult5> selector5)
        {
            if (source == null) throw new Exception("source is null");
            if (selector1 == null) throw new Exception("selector1 is null");
            if (selector5 == null) throw new Exception("selector5 is null");
            if (selector5 == null) throw new Exception("selector5 is null");
            if (selector5 == null) throw new Exception("selector5 is null");
            if (selector5 == null) throw new Exception("selector5 is null");
            return source.Select(x => new ResultContent<TResult1, TResult2, TResult3, TResult4, TResult5> { T1 = selector1(x), T2 = selector2(x), T3 = selector3(x), T4 = selector4(x), T5 = selector5(x) });
        }
        public static IQueryable<ResultContent<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6>> ToResult<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6>(this IQueryable<TSource> source, Func<TSource, TResult1> selector1, Func<TSource, TResult2> selector2, Func<TSource, TResult3> selector3, Func<TSource, TResult4> selector4, Func<TSource, TResult5> selector5, Func<TSource, TResult6> selector6)
        {
            if (source == null) throw new Exception("source is null");
            if (selector1 == null) throw new Exception("selector1 is null");
            if (selector6 == null) throw new Exception("selector6 is null");
            if (selector6 == null) throw new Exception("selector6 is null");
            if (selector6 == null) throw new Exception("selector6 is null");
            if (selector6 == null) throw new Exception("selector6 is null");
            if (selector6 == null) throw new Exception("selector6 is null");
            return source.Select(x => new ResultContent<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6> { T1 = selector1(x), T2 = selector2(x), T3 = selector3(x), T4 = selector4(x), T5 = selector5(x), T6 = selector6(x) });
        }
        public static IQueryable<ResultContent<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7>> ToResult<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7>(this IQueryable<TSource> source, Func<TSource, TResult1> selector1, Func<TSource, TResult2> selector2, Func<TSource, TResult3> selector3, Func<TSource, TResult4> selector4, Func<TSource, TResult5> selector5, Func<TSource, TResult6> selector6, Func<TSource, TResult7> selector7)
        {
            if (source == null) throw new Exception("source is null");
            if (selector1 == null) throw new Exception("selector1 is null");
            if (selector7 == null) throw new Exception("selector7 is null");
            if (selector7 == null) throw new Exception("selector7 is null");
            if (selector7 == null) throw new Exception("selector7 is null");
            if (selector7 == null) throw new Exception("selector7 is null");
            if (selector7 == null) throw new Exception("selector7 is null");
            if (selector7 == null) throw new Exception("selector7 is null");
            return source.Select(x => new ResultContent<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7> { T1 = selector1(x), T2 = selector2(x), T3 = selector3(x), T4 = selector4(x), T5 = selector5(x), T6 = selector6(x), T7 = selector7(x) });
        }
        public static IQueryable<ResultContent<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8>> ToResult<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8>(this IQueryable<TSource> source, Func<TSource, TResult1> selector1, Func<TSource, TResult2> selector2, Func<TSource, TResult3> selector3, Func<TSource, TResult4> selector4, Func<TSource, TResult5> selector5, Func<TSource, TResult6> selector6, Func<TSource, TResult7> selector7, Func<TSource, TResult8> selector8)
        {
            if (source == null) throw new Exception("source is null");
            if (selector1 == null) throw new Exception("selector1 is null");
            if (selector8 == null) throw new Exception("selector8 is null");
            if (selector8 == null) throw new Exception("selector8 is null");
            if (selector8 == null) throw new Exception("selector8 is null");
            if (selector8 == null) throw new Exception("selector8 is null");
            if (selector8 == null) throw new Exception("selector8 is null");
            if (selector8 == null) throw new Exception("selector8 is null");
            if (selector8 == null) throw new Exception("selector8 is null");
            return source.Select(x => new ResultContent<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8> { T1 = selector1(x), T2 = selector2(x), T3 = selector3(x), T4 = selector4(x), T5 = selector5(x), T6 = selector6(x), T7 = selector7(x), T8 = selector8(x) });
        }
        public static IQueryable<ResultContent<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9>> ToResult<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9>(this IQueryable<TSource> source, Func<TSource, TResult1> selector1, Func<TSource, TResult2> selector2, Func<TSource, TResult3> selector3, Func<TSource, TResult4> selector4, Func<TSource, TResult5> selector5, Func<TSource, TResult6> selector6, Func<TSource, TResult7> selector7, Func<TSource, TResult8> selector8, Func<TSource, TResult9> selector9)
        {
            if (source == null) throw new Exception("source is null");
            if (selector1 == null) throw new Exception("selector1 is null");
            if (selector9 == null) throw new Exception("selector9 is null");
            if (selector9 == null) throw new Exception("selector9 is null");
            if (selector9 == null) throw new Exception("selector9 is null");
            if (selector9 == null) throw new Exception("selector9 is null");
            if (selector9 == null) throw new Exception("selector9 is null");
            if (selector9 == null) throw new Exception("selector9 is null");
            if (selector9 == null) throw new Exception("selector9 is null");
            if (selector9 == null) throw new Exception("selector9 is null");
            return source.Select(x => new ResultContent<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9> { T1 = selector1(x), T2 = selector2(x), T3 = selector3(x), T4 = selector4(x), T5 = selector5(x), T6 = selector6(x), T7 = selector7(x), T8 = selector8(x), T9 = selector9(x) });
        }
        public static IQueryable<ResultContent<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10>> ToResult<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10>(this IQueryable<TSource> source, Func<TSource, TResult1> selector1, Func<TSource, TResult2> selector2, Func<TSource, TResult3> selector3, Func<TSource, TResult4> selector4, Func<TSource, TResult5> selector5, Func<TSource, TResult6> selector6, Func<TSource, TResult7> selector7, Func<TSource, TResult8> selector8, Func<TSource, TResult9> selector9, Func<TSource, TResult10> selector10)
        {
            if (source == null) throw new Exception("source is null");
            if (selector1 == null) throw new Exception("selector1 is null");
            if (selector10 == null) throw new Exception("selector10 is null");
            if (selector10 == null) throw new Exception("selector10 is null");
            if (selector10 == null) throw new Exception("selector10 is null");
            if (selector10 == null) throw new Exception("selector10 is null");
            if (selector10 == null) throw new Exception("selector10 is null");
            if (selector10 == null) throw new Exception("selector10 is null");
            if (selector10 == null) throw new Exception("selector10 is null");
            if (selector10 == null) throw new Exception("selector10 is null");
            if (selector10 == null) throw new Exception("selector10 is null");
            return source.Select(x => new ResultContent<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10> { T1 = selector1(x), T2 = selector2(x), T3 = selector3(x), T4 = selector4(x), T5 = selector5(x), T6 = selector6(x), T7 = selector7(x), T8 = selector8(x), T9 = selector9(x), T10 = selector10(x) });
        }
        public static IQueryable<ResultContent<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11>> ToResult<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11>(this IQueryable<TSource> source, Func<TSource, TResult1> selector1, Func<TSource, TResult2> selector2, Func<TSource, TResult3> selector3, Func<TSource, TResult4> selector4, Func<TSource, TResult5> selector5, Func<TSource, TResult6> selector6, Func<TSource, TResult7> selector7, Func<TSource, TResult8> selector8, Func<TSource, TResult9> selector9, Func<TSource, TResult10> selector10, Func<TSource, TResult11> selector11)
        {
            if (source == null) throw new Exception("source is null");
            if (selector1 == null) throw new Exception("selector1 is null");
            if (selector11 == null) throw new Exception("selector11 is null");
            if (selector11 == null) throw new Exception("selector11 is null");
            if (selector11 == null) throw new Exception("selector11 is null");
            if (selector11 == null) throw new Exception("selector11 is null");
            if (selector11 == null) throw new Exception("selector11 is null");
            if (selector11 == null) throw new Exception("selector11 is null");
            if (selector11 == null) throw new Exception("selector11 is null");
            if (selector11 == null) throw new Exception("selector11 is null");
            if (selector11 == null) throw new Exception("selector11 is null");
            if (selector11 == null) throw new Exception("selector11 is null");
            return source.Select(x => new ResultContent<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11> { T1 = selector1(x), T2 = selector2(x), T3 = selector3(x), T4 = selector4(x), T5 = selector5(x), T6 = selector6(x), T7 = selector7(x), T8 = selector8(x), T9 = selector9(x), T10 = selector10(x), T11 = selector11(x) });
        }
        public static IQueryable<ResultContent<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12>> ToResult<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12>(this IQueryable<TSource> source, Func<TSource, TResult1> selector1, Func<TSource, TResult2> selector2, Func<TSource, TResult3> selector3, Func<TSource, TResult4> selector4, Func<TSource, TResult5> selector5, Func<TSource, TResult6> selector6, Func<TSource, TResult7> selector7, Func<TSource, TResult8> selector8, Func<TSource, TResult9> selector9, Func<TSource, TResult10> selector10, Func<TSource, TResult11> selector11, Func<TSource, TResult12> selector12)
        {
            if (source == null) throw new Exception("source is null");
            if (selector1 == null) throw new Exception("selector1 is null");
            if (selector12 == null) throw new Exception("selector12 is null");
            if (selector12 == null) throw new Exception("selector12 is null");
            if (selector12 == null) throw new Exception("selector12 is null");
            if (selector12 == null) throw new Exception("selector12 is null");
            if (selector12 == null) throw new Exception("selector12 is null");
            if (selector12 == null) throw new Exception("selector12 is null");
            if (selector12 == null) throw new Exception("selector12 is null");
            if (selector12 == null) throw new Exception("selector12 is null");
            if (selector12 == null) throw new Exception("selector12 is null");
            if (selector12 == null) throw new Exception("selector12 is null");
            if (selector12 == null) throw new Exception("selector12 is null");
            return source.Select(x => new ResultContent<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12> { T1 = selector1(x), T2 = selector2(x), T3 = selector3(x), T4 = selector4(x), T5 = selector5(x), T6 = selector6(x), T7 = selector7(x), T8 = selector8(x), T9 = selector9(x), T10 = selector10(x), T11 = selector11(x), T12 = selector12(x) });
        }
        public static IQueryable<ResultContent<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13>> ToResult<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13>(this IQueryable<TSource> source, Func<TSource, TResult1> selector1, Func<TSource, TResult2> selector2, Func<TSource, TResult3> selector3, Func<TSource, TResult4> selector4, Func<TSource, TResult5> selector5, Func<TSource, TResult6> selector6, Func<TSource, TResult7> selector7, Func<TSource, TResult8> selector8, Func<TSource, TResult9> selector9, Func<TSource, TResult10> selector10, Func<TSource, TResult11> selector11, Func<TSource, TResult12> selector12, Func<TSource, TResult13> selector13)
        {
            if (source == null) throw new Exception("source is null");
            if (selector1 == null) throw new Exception("selector1 is null");
            if (selector13 == null) throw new Exception("selector13 is null");
            if (selector13 == null) throw new Exception("selector13 is null");
            if (selector13 == null) throw new Exception("selector13 is null");
            if (selector13 == null) throw new Exception("selector13 is null");
            if (selector13 == null) throw new Exception("selector13 is null");
            if (selector13 == null) throw new Exception("selector13 is null");
            if (selector13 == null) throw new Exception("selector13 is null");
            if (selector13 == null) throw new Exception("selector13 is null");
            if (selector13 == null) throw new Exception("selector13 is null");
            if (selector13 == null) throw new Exception("selector13 is null");
            if (selector13 == null) throw new Exception("selector13 is null");
            if (selector13 == null) throw new Exception("selector13 is null");
            return source.Select(x => new ResultContent<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13> { T1 = selector1(x), T2 = selector2(x), T3 = selector3(x), T4 = selector4(x), T5 = selector5(x), T6 = selector6(x), T7 = selector7(x), T8 = selector8(x), T9 = selector9(x), T10 = selector10(x), T11 = selector11(x), T12 = selector12(x), T13 = selector13(x) });
        }
        public static IQueryable<ResultContent<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13, TResult14>> ToResult<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13, TResult14>(this IQueryable<TSource> source, Func<TSource, TResult1> selector1, Func<TSource, TResult2> selector2, Func<TSource, TResult3> selector3, Func<TSource, TResult4> selector4, Func<TSource, TResult5> selector5, Func<TSource, TResult6> selector6, Func<TSource, TResult7> selector7, Func<TSource, TResult8> selector8, Func<TSource, TResult9> selector9, Func<TSource, TResult10> selector10, Func<TSource, TResult11> selector11, Func<TSource, TResult12> selector12, Func<TSource, TResult13> selector13, Func<TSource, TResult14> selector14)
        {
            if (source == null) throw new Exception("source is null");
            if (selector1 == null) throw new Exception("selector1 is null");
            if (selector14 == null) throw new Exception("selector14 is null");
            if (selector14 == null) throw new Exception("selector14 is null");
            if (selector14 == null) throw new Exception("selector14 is null");
            if (selector14 == null) throw new Exception("selector14 is null");
            if (selector14 == null) throw new Exception("selector14 is null");
            if (selector14 == null) throw new Exception("selector14 is null");
            if (selector14 == null) throw new Exception("selector14 is null");
            if (selector14 == null) throw new Exception("selector14 is null");
            if (selector14 == null) throw new Exception("selector14 is null");
            if (selector14 == null) throw new Exception("selector14 is null");
            if (selector14 == null) throw new Exception("selector14 is null");
            if (selector14 == null) throw new Exception("selector14 is null");
            if (selector14 == null) throw new Exception("selector14 is null");
            return source.Select(x => new ResultContent<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13, TResult14> { T1 = selector1(x), T2 = selector2(x), T3 = selector3(x), T4 = selector4(x), T5 = selector5(x), T6 = selector6(x), T7 = selector7(x), T8 = selector8(x), T9 = selector9(x), T10 = selector10(x), T11 = selector11(x), T12 = selector12(x), T13 = selector13(x), T14 = selector14(x) });
        }
        public static IQueryable<ResultContent<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13, TResult14, TResult15>> ToResult<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13, TResult14, TResult15>(this IQueryable<TSource> source, Func<TSource, TResult1> selector1, Func<TSource, TResult2> selector2, Func<TSource, TResult3> selector3, Func<TSource, TResult4> selector4, Func<TSource, TResult5> selector5, Func<TSource, TResult6> selector6, Func<TSource, TResult7> selector7, Func<TSource, TResult8> selector8, Func<TSource, TResult9> selector9, Func<TSource, TResult10> selector10, Func<TSource, TResult11> selector11, Func<TSource, TResult12> selector12, Func<TSource, TResult13> selector13, Func<TSource, TResult14> selector14, Func<TSource, TResult15> selector15)
        {
            if (source == null) throw new Exception("source is null");
            if (selector1 == null) throw new Exception("selector1 is null");
            if (selector15 == null) throw new Exception("selector15 is null");
            if (selector15 == null) throw new Exception("selector15 is null");
            if (selector15 == null) throw new Exception("selector15 is null");
            if (selector15 == null) throw new Exception("selector15 is null");
            if (selector15 == null) throw new Exception("selector15 is null");
            if (selector15 == null) throw new Exception("selector15 is null");
            if (selector15 == null) throw new Exception("selector15 is null");
            if (selector15 == null) throw new Exception("selector15 is null");
            if (selector15 == null) throw new Exception("selector15 is null");
            if (selector15 == null) throw new Exception("selector15 is null");
            if (selector15 == null) throw new Exception("selector15 is null");
            if (selector15 == null) throw new Exception("selector15 is null");
            if (selector15 == null) throw new Exception("selector15 is null");
            if (selector15 == null) throw new Exception("selector15 is null");
            return source.Select(x => new ResultContent<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13, TResult14, TResult15> { T1 = selector1(x), T2 = selector2(x), T3 = selector3(x), T4 = selector4(x), T5 = selector5(x), T6 = selector6(x), T7 = selector7(x), T8 = selector8(x), T9 = selector9(x), T10 = selector10(x), T11 = selector11(x), T12 = selector12(x), T13 = selector13(x), T14 = selector14(x), T15 = selector15(x) });
        }
        public static IQueryable<ResultContent<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13, TResult14, TResult15, TResult16>> ToResult<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13, TResult14, TResult15, TResult16>(this IQueryable<TSource> source, Func<TSource, TResult1> selector1, Func<TSource, TResult2> selector2, Func<TSource, TResult3> selector3, Func<TSource, TResult4> selector4, Func<TSource, TResult5> selector5, Func<TSource, TResult6> selector6, Func<TSource, TResult7> selector7, Func<TSource, TResult8> selector8, Func<TSource, TResult9> selector9, Func<TSource, TResult10> selector10, Func<TSource, TResult11> selector11, Func<TSource, TResult12> selector12, Func<TSource, TResult13> selector13, Func<TSource, TResult14> selector14, Func<TSource, TResult15> selector15, Func<TSource, TResult16> selector16)
        {
            if (source == null) throw new Exception("source is null");
            if (selector1 == null) throw new Exception("selector1 is null");
            if (selector16 == null) throw new Exception("selector16 is null");
            if (selector16 == null) throw new Exception("selector16 is null");
            if (selector16 == null) throw new Exception("selector16 is null");
            if (selector16 == null) throw new Exception("selector16 is null");
            if (selector16 == null) throw new Exception("selector16 is null");
            if (selector16 == null) throw new Exception("selector16 is null");
            if (selector16 == null) throw new Exception("selector16 is null");
            if (selector16 == null) throw new Exception("selector16 is null");
            if (selector16 == null) throw new Exception("selector16 is null");
            if (selector16 == null) throw new Exception("selector16 is null");
            if (selector16 == null) throw new Exception("selector16 is null");
            if (selector16 == null) throw new Exception("selector16 is null");
            if (selector16 == null) throw new Exception("selector16 is null");
            if (selector16 == null) throw new Exception("selector16 is null");
            if (selector16 == null) throw new Exception("selector16 is null");
            return source.Select(x => new ResultContent<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13, TResult14, TResult15, TResult16> { T1 = selector1(x), T2 = selector2(x), T3 = selector3(x), T4 = selector4(x), T5 = selector5(x), T6 = selector6(x), T7 = selector7(x), T8 = selector8(x), T9 = selector9(x), T10 = selector10(x), T11 = selector11(x), T12 = selector12(x), T13 = selector13(x), T14 = selector14(x), T15 = selector15(x), T16 = selector16(x) });
        }
        public static IEnumerable<ResultContent<TResult1, TResult2>> ToResult<TSource, TResult1, TResult2>(this IEnumerable<TSource> source, Func<TSource, TResult1> selector1, Func<TSource, TResult2> selector2)
        {
            if (source == null) throw new Exception("source is null");
            if (selector1 == null) throw new Exception("selector1 is null");
            if (selector2 == null) throw new Exception("selector2 is null");
            foreach (var local in source)
            {
                yield return new ResultContent<TResult1, TResult2>
                {
                    T1 = selector1(local),
                    T2 = selector2(local)
                };
            }
        }
        public static IEnumerable<ResultContent<TResult1, TResult2, TResult3>> ToResult<TSource, TResult1, TResult2, TResult3>(this IEnumerable<TSource> source, Func<TSource, TResult1> selector1, Func<TSource, TResult2> selector2, Func<TSource, TResult3> selector3)
        {
            if (source == null) throw new Exception("source is null");
            if (selector1 == null) throw new Exception("selector1 is null");
            if (selector3 == null) throw new Exception("selector3 is null");
            if (selector3 == null) throw new Exception("selector3 is null");
            foreach (var local in source)
            {
                yield return new ResultContent<TResult1, TResult2, TResult3>
                {
                    T1 = selector1(local),
                    T2 = selector2(local),
                    T3 = selector3(local)
                };
            }
        }
        public static IEnumerable<ResultContent<TResult1, TResult2, TResult3, TResult4>> ToResult<TSource, TResult1, TResult2, TResult3, TResult4>(this IEnumerable<TSource> source, Func<TSource, TResult1> selector1, Func<TSource, TResult2> selector2, Func<TSource, TResult3> selector3, Func<TSource, TResult4> selector4)
        {
            if (source == null) throw new Exception("source is null");
            if (selector1 == null) throw new Exception("selector1 is null");
            if (selector4 == null) throw new Exception("selector4 is null");
            if (selector4 == null) throw new Exception("selector4 is null");
            if (selector4 == null) throw new Exception("selector4 is null");
            foreach (var local in source)
            {
                yield return new ResultContent<TResult1, TResult2, TResult3, TResult4>
                {
                    T1 = selector1(local),
                    T2 = selector2(local),
                    T3 = selector3(local),
                    T4 = selector4(local)
                };
            }
        }
        public static IEnumerable<ResultContent<TResult1, TResult2, TResult3, TResult4, TResult5>> ToResult<TSource, TResult1, TResult2, TResult3, TResult4, TResult5>(this IEnumerable<TSource> source, Func<TSource, TResult1> selector1, Func<TSource, TResult2> selector2, Func<TSource, TResult3> selector3, Func<TSource, TResult4> selector4, Func<TSource, TResult5> selector5)
        {
            if (source == null) throw new Exception("source is null");
            if (selector1 == null) throw new Exception("selector1 is null");
            if (selector5 == null) throw new Exception("selector5 is null");
            if (selector5 == null) throw new Exception("selector5 is null");
            if (selector5 == null) throw new Exception("selector5 is null");
            if (selector5 == null) throw new Exception("selector5 is null");
            foreach (var local in source)
            {
                yield return new ResultContent<TResult1, TResult2, TResult3, TResult4, TResult5>
                {
                    T1 = selector1(local),
                    T2 = selector2(local),
                    T3 = selector3(local),
                    T4 = selector4(local),
                    T5 = selector5(local)
                };
            }
        }
        public static IEnumerable<ResultContent<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6>> ToResult<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6>(this IEnumerable<TSource> source, Func<TSource, TResult1> selector1, Func<TSource, TResult2> selector2, Func<TSource, TResult3> selector3, Func<TSource, TResult4> selector4, Func<TSource, TResult5> selector5, Func<TSource, TResult6> selector6)
        {
            if (source == null) throw new Exception("source is null");
            if (selector1 == null) throw new Exception("selector1 is null");
            if (selector6 == null) throw new Exception("selector6 is null");
            if (selector6 == null) throw new Exception("selector6 is null");
            if (selector6 == null) throw new Exception("selector6 is null");
            if (selector6 == null) throw new Exception("selector6 is null");
            if (selector6 == null) throw new Exception("selector6 is null");
            foreach (var local in source)
            {
                yield return new ResultContent<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6>
                {
                    T1 = selector1(local),
                    T2 = selector2(local),
                    T3 = selector3(local),
                    T4 = selector4(local),
                    T5 = selector5(local),
                    T6 = selector6(local)
                };
            }
        }
        public static IEnumerable<ResultContent<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7>> ToResult<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7>(this IEnumerable<TSource> source, Func<TSource, TResult1> selector1, Func<TSource, TResult2> selector2, Func<TSource, TResult3> selector3, Func<TSource, TResult4> selector4, Func<TSource, TResult5> selector5, Func<TSource, TResult6> selector6, Func<TSource, TResult7> selector7)
        {
            if (source == null) throw new Exception("source is null");
            if (selector1 == null) throw new Exception("selector1 is null");
            if (selector7 == null) throw new Exception("selector7 is null");
            if (selector7 == null) throw new Exception("selector7 is null");
            if (selector7 == null) throw new Exception("selector7 is null");
            if (selector7 == null) throw new Exception("selector7 is null");
            if (selector7 == null) throw new Exception("selector7 is null");
            if (selector7 == null) throw new Exception("selector7 is null");
            foreach (var local in source)
            {
                yield return new ResultContent<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7>
                {
                    T1 = selector1(local),
                    T2 = selector2(local),
                    T3 = selector3(local),
                    T4 = selector4(local),
                    T5 = selector5(local),
                    T6 = selector6(local),
                    T7 = selector7(local)
                };
            }
        }
        public static IEnumerable<ResultContent<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8>> ToResult<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8>(this IEnumerable<TSource> source, Func<TSource, TResult1> selector1, Func<TSource, TResult2> selector2, Func<TSource, TResult3> selector3, Func<TSource, TResult4> selector4, Func<TSource, TResult5> selector5, Func<TSource, TResult6> selector6, Func<TSource, TResult7> selector7, Func<TSource, TResult8> selector8)
        {
            if (source == null) throw new Exception("source is null");
            if (selector1 == null) throw new Exception("selector1 is null");
            if (selector8 == null) throw new Exception("selector8 is null");
            if (selector8 == null) throw new Exception("selector8 is null");
            if (selector8 == null) throw new Exception("selector8 is null");
            if (selector8 == null) throw new Exception("selector8 is null");
            if (selector8 == null) throw new Exception("selector8 is null");
            if (selector8 == null) throw new Exception("selector8 is null");
            if (selector8 == null) throw new Exception("selector8 is null");
            foreach (var local in source)
            {
                yield return new ResultContent<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8>
                {
                    T1 = selector1(local),
                    T2 = selector2(local),
                    T3 = selector3(local),
                    T4 = selector4(local),
                    T5 = selector5(local),
                    T6 = selector6(local),
                    T7 = selector7(local),
                    T8 = selector8(local)
                };
            }
        }
        public static IEnumerable<ResultContent<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9>> ToResult<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9>(this IEnumerable<TSource> source, Func<TSource, TResult1> selector1, Func<TSource, TResult2> selector2, Func<TSource, TResult3> selector3, Func<TSource, TResult4> selector4, Func<TSource, TResult5> selector5, Func<TSource, TResult6> selector6, Func<TSource, TResult7> selector7, Func<TSource, TResult8> selector8, Func<TSource, TResult9> selector9)
        {
            if (source == null) throw new Exception("source is null");
            if (selector1 == null) throw new Exception("selector1 is null");
            if (selector9 == null) throw new Exception("selector9 is null");
            if (selector9 == null) throw new Exception("selector9 is null");
            if (selector9 == null) throw new Exception("selector9 is null");
            if (selector9 == null) throw new Exception("selector9 is null");
            if (selector9 == null) throw new Exception("selector9 is null");
            if (selector9 == null) throw new Exception("selector9 is null");
            if (selector9 == null) throw new Exception("selector9 is null");
            if (selector9 == null) throw new Exception("selector9 is null");
            foreach (var local in source)
            {
                yield return new ResultContent<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9>
                {
                    T1 = selector1(local),
                    T2 = selector2(local),
                    T3 = selector3(local),
                    T4 = selector4(local),
                    T5 = selector5(local),
                    T6 = selector6(local),
                    T7 = selector7(local),
                    T8 = selector8(local),
                    T9 = selector9(local)
                };
            }
        }
        public static IEnumerable<ResultContent<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10>> ToResult<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10>(this IEnumerable<TSource> source, Func<TSource, TResult1> selector1, Func<TSource, TResult2> selector2, Func<TSource, TResult3> selector3, Func<TSource, TResult4> selector4, Func<TSource, TResult5> selector5, Func<TSource, TResult6> selector6, Func<TSource, TResult7> selector7, Func<TSource, TResult8> selector8, Func<TSource, TResult9> selector9, Func<TSource, TResult10> selector10)
        {
            if (source == null) throw new Exception("source is null");
            if (selector1 == null) throw new Exception("selector1 is null");
            if (selector10 == null) throw new Exception("selector10 is null");
            if (selector10 == null) throw new Exception("selector10 is null");
            if (selector10 == null) throw new Exception("selector10 is null");
            if (selector10 == null) throw new Exception("selector10 is null");
            if (selector10 == null) throw new Exception("selector10 is null");
            if (selector10 == null) throw new Exception("selector10 is null");
            if (selector10 == null) throw new Exception("selector10 is null");
            if (selector10 == null) throw new Exception("selector10 is null");
            if (selector10 == null) throw new Exception("selector10 is null");
            foreach (var local in source)
            {
                yield return new ResultContent<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10>
                {
                    T1 = selector1(local),
                    T2 = selector2(local),
                    T3 = selector3(local),
                    T4 = selector4(local),
                    T5 = selector5(local),
                    T6 = selector6(local),
                    T7 = selector7(local),
                    T8 = selector8(local),
                    T9 = selector9(local),
                    T10 = selector10(local)
                };
            }
        }
        public static IEnumerable<ResultContent<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11>> ToResult<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11>(this IEnumerable<TSource> source, Func<TSource, TResult1> selector1, Func<TSource, TResult2> selector2, Func<TSource, TResult3> selector3, Func<TSource, TResult4> selector4, Func<TSource, TResult5> selector5, Func<TSource, TResult6> selector6, Func<TSource, TResult7> selector7, Func<TSource, TResult8> selector8, Func<TSource, TResult9> selector9, Func<TSource, TResult10> selector10, Func<TSource, TResult11> selector11)
        {
            if (source == null) throw new Exception("source is null");
            if (selector1 == null) throw new Exception("selector1 is null");
            if (selector11 == null) throw new Exception("selector11 is null");
            if (selector11 == null) throw new Exception("selector11 is null");
            if (selector11 == null) throw new Exception("selector11 is null");
            if (selector11 == null) throw new Exception("selector11 is null");
            if (selector11 == null) throw new Exception("selector11 is null");
            if (selector11 == null) throw new Exception("selector11 is null");
            if (selector11 == null) throw new Exception("selector11 is null");
            if (selector11 == null) throw new Exception("selector11 is null");
            if (selector11 == null) throw new Exception("selector11 is null");
            if (selector11 == null) throw new Exception("selector11 is null");
            foreach (var local in source)
            {
                yield return new ResultContent<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11>
                {
                    T1 = selector1(local),
                    T2 = selector2(local),
                    T3 = selector3(local),
                    T4 = selector4(local),
                    T5 = selector5(local),
                    T6 = selector6(local),
                    T7 = selector7(local),
                    T8 = selector8(local),
                    T9 = selector9(local),
                    T10 = selector10(local),
                    T11 = selector11(local)
                };
            }
        }
        public static IEnumerable<ResultContent<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12>> ToResult<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12>(this IEnumerable<TSource> source, Func<TSource, TResult1> selector1, Func<TSource, TResult2> selector2, Func<TSource, TResult3> selector3, Func<TSource, TResult4> selector4, Func<TSource, TResult5> selector5, Func<TSource, TResult6> selector6, Func<TSource, TResult7> selector7, Func<TSource, TResult8> selector8, Func<TSource, TResult9> selector9, Func<TSource, TResult10> selector10, Func<TSource, TResult11> selector11, Func<TSource, TResult12> selector12)
        {
            if (source == null) throw new Exception("source is null");
            if (selector1 == null) throw new Exception("selector1 is null");
            if (selector12 == null) throw new Exception("selector12 is null");
            if (selector12 == null) throw new Exception("selector12 is null");
            if (selector12 == null) throw new Exception("selector12 is null");
            if (selector12 == null) throw new Exception("selector12 is null");
            if (selector12 == null) throw new Exception("selector12 is null");
            if (selector12 == null) throw new Exception("selector12 is null");
            if (selector12 == null) throw new Exception("selector12 is null");
            if (selector12 == null) throw new Exception("selector12 is null");
            if (selector12 == null) throw new Exception("selector12 is null");
            if (selector12 == null) throw new Exception("selector12 is null");
            if (selector12 == null) throw new Exception("selector12 is null");
            foreach (var local in source)
            {
                yield return new ResultContent<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12>
                {
                    T1 = selector1(local),
                    T2 = selector2(local),
                    T3 = selector3(local),
                    T4 = selector4(local),
                    T5 = selector5(local),
                    T6 = selector6(local),
                    T7 = selector7(local),
                    T8 = selector8(local),
                    T9 = selector9(local),
                    T10 = selector10(local),
                    T11 = selector11(local),
                    T12 = selector12(local)
                };
            }
        }
        public static IEnumerable<ResultContent<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13>> ToResult<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13>(this IEnumerable<TSource> source, Func<TSource, TResult1> selector1, Func<TSource, TResult2> selector2, Func<TSource, TResult3> selector3, Func<TSource, TResult4> selector4, Func<TSource, TResult5> selector5, Func<TSource, TResult6> selector6, Func<TSource, TResult7> selector7, Func<TSource, TResult8> selector8, Func<TSource, TResult9> selector9, Func<TSource, TResult10> selector10, Func<TSource, TResult11> selector11, Func<TSource, TResult12> selector12, Func<TSource, TResult13> selector13)
        {
            if (source == null) throw new Exception("source is null");
            if (selector1 == null) throw new Exception("selector1 is null");
            if (selector13 == null) throw new Exception("selector13 is null");
            if (selector13 == null) throw new Exception("selector13 is null");
            if (selector13 == null) throw new Exception("selector13 is null");
            if (selector13 == null) throw new Exception("selector13 is null");
            if (selector13 == null) throw new Exception("selector13 is null");
            if (selector13 == null) throw new Exception("selector13 is null");
            if (selector13 == null) throw new Exception("selector13 is null");
            if (selector13 == null) throw new Exception("selector13 is null");
            if (selector13 == null) throw new Exception("selector13 is null");
            if (selector13 == null) throw new Exception("selector13 is null");
            if (selector13 == null) throw new Exception("selector13 is null");
            if (selector13 == null) throw new Exception("selector13 is null");
            foreach (var local in source)
            {
                yield return new ResultContent<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13>
                {
                    T1 = selector1(local),
                    T2 = selector2(local),
                    T3 = selector3(local),
                    T4 = selector4(local),
                    T5 = selector5(local),
                    T6 = selector6(local),
                    T7 = selector7(local),
                    T8 = selector8(local),
                    T9 = selector9(local),
                    T10 = selector10(local),
                    T11 = selector11(local),
                    T12 = selector12(local),
                    T13 = selector13(local)
                };
            }
        }
        public static IEnumerable<ResultContent<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13, TResult14>> ToResult<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13, TResult14>(this IEnumerable<TSource> source, Func<TSource, TResult1> selector1, Func<TSource, TResult2> selector2, Func<TSource, TResult3> selector3, Func<TSource, TResult4> selector4, Func<TSource, TResult5> selector5, Func<TSource, TResult6> selector6, Func<TSource, TResult7> selector7, Func<TSource, TResult8> selector8, Func<TSource, TResult9> selector9, Func<TSource, TResult10> selector10, Func<TSource, TResult11> selector11, Func<TSource, TResult12> selector12, Func<TSource, TResult13> selector13, Func<TSource, TResult14> selector14)
        {
            if (source == null) throw new Exception("source is null");
            if (selector1 == null) throw new Exception("selector1 is null");
            if (selector14 == null) throw new Exception("selector14 is null");
            if (selector14 == null) throw new Exception("selector14 is null");
            if (selector14 == null) throw new Exception("selector14 is null");
            if (selector14 == null) throw new Exception("selector14 is null");
            if (selector14 == null) throw new Exception("selector14 is null");
            if (selector14 == null) throw new Exception("selector14 is null");
            if (selector14 == null) throw new Exception("selector14 is null");
            if (selector14 == null) throw new Exception("selector14 is null");
            if (selector14 == null) throw new Exception("selector14 is null");
            if (selector14 == null) throw new Exception("selector14 is null");
            if (selector14 == null) throw new Exception("selector14 is null");
            if (selector14 == null) throw new Exception("selector14 is null");
            if (selector14 == null) throw new Exception("selector14 is null");
            foreach (var local in source)
            {
                yield return new ResultContent<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13, TResult14>
                {
                    T1 = selector1(local),
                    T2 = selector2(local),
                    T3 = selector3(local),
                    T4 = selector4(local),
                    T5 = selector5(local),
                    T6 = selector6(local),
                    T7 = selector7(local),
                    T8 = selector8(local),
                    T9 = selector9(local),
                    T10 = selector10(local),
                    T11 = selector11(local),
                    T12 = selector12(local),
                    T13 = selector13(local),
                    T14 = selector14(local)
                };
            }
        }
        public static IEnumerable<ResultContent<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13, TResult14, TResult15>> ToResult<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13, TResult14, TResult15>(this IEnumerable<TSource> source, Func<TSource, TResult1> selector1, Func<TSource, TResult2> selector2, Func<TSource, TResult3> selector3, Func<TSource, TResult4> selector4, Func<TSource, TResult5> selector5, Func<TSource, TResult6> selector6, Func<TSource, TResult7> selector7, Func<TSource, TResult8> selector8, Func<TSource, TResult9> selector9, Func<TSource, TResult10> selector10, Func<TSource, TResult11> selector11, Func<TSource, TResult12> selector12, Func<TSource, TResult13> selector13, Func<TSource, TResult14> selector14, Func<TSource, TResult15> selector15)
        {
            if (source == null) throw new Exception("source is null");
            if (selector1 == null) throw new Exception("selector1 is null");
            if (selector15 == null) throw new Exception("selector15 is null");
            if (selector15 == null) throw new Exception("selector15 is null");
            if (selector15 == null) throw new Exception("selector15 is null");
            if (selector15 == null) throw new Exception("selector15 is null");
            if (selector15 == null) throw new Exception("selector15 is null");
            if (selector15 == null) throw new Exception("selector15 is null");
            if (selector15 == null) throw new Exception("selector15 is null");
            if (selector15 == null) throw new Exception("selector15 is null");
            if (selector15 == null) throw new Exception("selector15 is null");
            if (selector15 == null) throw new Exception("selector15 is null");
            if (selector15 == null) throw new Exception("selector15 is null");
            if (selector15 == null) throw new Exception("selector15 is null");
            if (selector15 == null) throw new Exception("selector15 is null");
            if (selector15 == null) throw new Exception("selector15 is null");
            foreach (var local in source)
            {
                yield return new ResultContent<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13, TResult14, TResult15>
                {
                    T1 = selector1(local),
                    T2 = selector2(local),
                    T3 = selector3(local),
                    T4 = selector4(local),
                    T5 = selector5(local),
                    T6 = selector6(local),
                    T7 = selector7(local),
                    T8 = selector8(local),
                    T9 = selector9(local),
                    T10 = selector10(local),
                    T11 = selector11(local),
                    T12 = selector12(local),
                    T13 = selector13(local),
                    T14 = selector14(local),
                    T15 = selector15(local)
                };
            }
        }
        public static IEnumerable<ResultContent<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13, TResult14, TResult15, TResult16>> ToResult<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13, TResult14, TResult15, TResult16>(this IEnumerable<TSource> source, Func<TSource, TResult1> selector1, Func<TSource, TResult2> selector2, Func<TSource, TResult3> selector3, Func<TSource, TResult4> selector4, Func<TSource, TResult5> selector5, Func<TSource, TResult6> selector6, Func<TSource, TResult7> selector7, Func<TSource, TResult8> selector8, Func<TSource, TResult9> selector9, Func<TSource, TResult10> selector10, Func<TSource, TResult11> selector11, Func<TSource, TResult12> selector12, Func<TSource, TResult13> selector13, Func<TSource, TResult14> selector14, Func<TSource, TResult15> selector15, Func<TSource, TResult16> selector16)
        {
            if (source == null) throw new Exception("source is null");
            if (selector1 == null) throw new Exception("selector1 is null");
            if (selector16 == null) throw new Exception("selector16 is null");
            if (selector16 == null) throw new Exception("selector16 is null");
            if (selector16 == null) throw new Exception("selector16 is null");
            if (selector16 == null) throw new Exception("selector16 is null");
            if (selector16 == null) throw new Exception("selector16 is null");
            if (selector16 == null) throw new Exception("selector16 is null");
            if (selector16 == null) throw new Exception("selector16 is null");
            if (selector16 == null) throw new Exception("selector16 is null");
            if (selector16 == null) throw new Exception("selector16 is null");
            if (selector16 == null) throw new Exception("selector16 is null");
            if (selector16 == null) throw new Exception("selector16 is null");
            if (selector16 == null) throw new Exception("selector16 is null");
            if (selector16 == null) throw new Exception("selector16 is null");
            if (selector16 == null) throw new Exception("selector16 is null");
            if (selector16 == null) throw new Exception("selector16 is null");
            foreach (var local in source)
            {
                yield return new ResultContent<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13, TResult14, TResult15, TResult16>
                {
                    T1 = selector1(local),
                    T2 = selector2(local),
                    T3 = selector3(local),
                    T4 = selector4(local),
                    T5 = selector5(local),
                    T6 = selector6(local),
                    T7 = selector7(local),
                    T8 = selector8(local),
                    T9 = selector9(local),
                    T10 = selector10(local),
                    T11 = selector11(local),
                    T12 = selector12(local),
                    T13 = selector13(local),
                    T14 = selector14(local),
                    T15 = selector15(local),
                    T16 = selector16(local)
                };
            }
        }
    }
}
