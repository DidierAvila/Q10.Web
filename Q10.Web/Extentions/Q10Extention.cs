using Q10.Application.Students.Commands;
using Q10.Application.SubjectRegistrations.Commands;
using Q10.Application.SubjectRegistrations.Queries;
using Q10.Application.Subjects.Commands;
using Q10.Application.Subjects.Queries;
using Q10.Domain.Entities;
using Q10.Infrastructure.Repositories;

namespace Q10.Web.Extentions
{
    public static class Q10Extention
    {
        public static IServiceCollection AddQ10Extention(this IServiceCollection services)
        {
            services.AddScoped<IStudentHandler, StudentHandler>();
            services.AddScoped<IRepositoryBase<Student>, RepositoryBase<Student>>();
            services.AddScoped<IRepositoryBase<Subject>, RepositoryBase<Subject>>();
            services.AddScoped<ISubjectRegistrationRepository, SubjectRegistrationRepository>();
            // Corrected the MediatR registration to use the proper overload  
            services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(GetSubjectQuery).Assembly));
            services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(GetSubjectsQuery).Assembly));
            services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(CreateSubjectCommand).Assembly));
            services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(DeleteSubjectCommand).Assembly));
            services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(UpdateSubjectCommand).Assembly));
            services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(CreateSubjectRegistrationCommand).Assembly));
            services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(GetSubjectRegistrationsByStudentIdQuery).Assembly));
            
            return services;
        }
    }
}
