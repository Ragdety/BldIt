using BldIt.Models;
using AutoMapper;
using BldIt.Models.DataModels;
using BldIt.Models.Forms;

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