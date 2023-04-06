using SimpleWebAPI.Infrastructure.Converters.JsonConverters;

namespace SimpleWebAPI.Extensions
{
    public static class MvcBuilderExtensions
    {
        public static IMvcBuilder ConfigureJson(this IMvcBuilder mvcBuilder)
        {
            mvcBuilder
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.Converters.Add(new DateOnlyJsonConverter());
                });

            return mvcBuilder;
        }
    }
}
