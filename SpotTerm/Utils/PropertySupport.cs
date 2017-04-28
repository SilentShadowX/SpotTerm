using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SpotTerm.Utils
{
    public static class PropertySupport
    {
        public static string ExtractPropertyName<T>(Expression<Func<T>> propertyExpression)
        {
            if (propertyExpression == null)
                throw new ArgumentNullException(nameof(propertyExpression));

            return ExtractPropertyNameFromLambda(propertyExpression);
        }

        internal static string ExtractPropertyNameFromLambda(LambdaExpression expression)
        {
            if (expression == null)
                throw new ArgumentNullException(nameof(expression));

            var memberExpression = expression.Body as MemberExpression;
            if (memberExpression == null)
                throw new ArgumentException(nameof(expression));

            var property = memberExpression.Member as PropertyInfo;
            if (property == null)
                throw new ArgumentException(nameof(expression));

            var getMethod = property.GetMethod;
            if (getMethod.IsStatic)
                throw new ArgumentException(nameof(expression));

            return memberExpression.Member.Name;
        }
    }
}
