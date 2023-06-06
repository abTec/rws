using AutoMapper;

namespace TranslationManagement.Api
{
    public static class AutoMapperConfiguration
    {
        public static MapperConfiguration ConfigureMapping()
        => new(mc =>
        {
            mc.AddMaps(new[] {
                "Application"
            });
        });
    }
}
