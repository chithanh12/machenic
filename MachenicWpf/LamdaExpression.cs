using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace MachenicWpf {
    public static class LamdaExtension {
        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> exp1, Expression<Func<T, bool>> exp2) where T : class {
            var result = Expression.Lambda<Func<T, bool>>(Expression.AndAlso(new SwapVisitor(exp1.Parameters[0], exp2.Parameters[0]).Visit(exp1.Body), exp2.Body), exp2.Parameters);
            return result;
        }
        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> exp1, Expression<Func<T, bool>> exp2) where T : class {
            var result = Expression.Lambda<Func<T, bool>>(Expression.OrElse(new SwapVisitor(exp1.Parameters[0], exp2.Parameters[0]).Visit(exp1.Body), exp2.Body), exp2.Parameters);
            return result;
        }
        public static void ForEach<T>(this IEnumerable<T> items, Action<T> action) {
            foreach (T item in items) {
                action(item);
            }
        }
    }
    public class SwapVisitor : ExpressionVisitor {
        private readonly Expression m_from, m_to;
        public SwapVisitor(Expression from, Expression to) {
            this.m_from = from;
            this.m_to = to;
        }
        public override Expression Visit(Expression node) {
            return node == m_from ? m_to : base.Visit(node);
        }
    }
}
