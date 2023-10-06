using Microsoft.Extensions.Primitives;
using System.Collections.Specialized;

namespace MiddlewareTest.Middleware
{

    public class MyMiddleware
    {
        public MyMiddleware(RequestDelegate next)
        {
            Next = next;
        }
        public RequestDelegate Next { get; }

        public async Task InvokeAsync(HttpContext context)
        {
            context = Tooman2Rial(context);
            await Next(context);
        }
        private HttpContext Tooman2Rial(HttpContext context)
        {
            if (!context.Request.HasFormContentType)
                return context;
            var formDictionary = new Dictionary<string, StringValues>();
            var form = context.Request.Form;

            foreach (var key in form.Keys)
            {
                form.TryGetValue(key, out StringValues formValues);
                if (key == "CurrentMoney" || key == "IncreaseMoney")
                    formValues = (double.Parse(formValues) * 10).ToString();
                formDictionary.Add(key, formValues);
            }
            FormCollection formCollection = new FormCollection(formDictionary);
            context.Request.Form = formCollection;
            return context;
        }
    }
}