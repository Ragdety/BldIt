using BldIt.Api.Form;
using BldIt.Models;
using AutoMapper;
using BldIt.Models.DataModels;

namespace BldIt.Api.Profiles
{
    public class JobProfile : Profile
    {
        public JobProfile()
        {
            CreateMap<JobCreationForm, Job>();
        }
    }
}