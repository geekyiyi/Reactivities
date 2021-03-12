using AutoMapper;
using Domain;

namespace Application.Core
{
    public class MappingProfiles : Profile
    {
        // create a map from one object to another
        public MappingProfiles()
        {

            // mapping from Activity to Activity
            // for edit handler will map from the activity to the activity
            CreateMap<Activity, Activity>();
        }
    }
}