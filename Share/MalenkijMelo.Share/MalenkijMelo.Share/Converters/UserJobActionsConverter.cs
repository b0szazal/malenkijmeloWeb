using MalenkijMelo.Share.Dtos;
using MalenkijMelo.Share.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalenkijMelo.Share.Converters
{
    public static class UserJobActionsConverter
    {
        public static UserJobActionDto ConvertToUserJobActionDto(this UserJobAction application)
        {
            return new UserJobActionDto()
            {
                UserId = application.UserId,
                JobId = application.JobId,
                DateOfApplication = application.DateOfApplication,
                Id = application.Id,
            };
        }

        public static UserJobAction ConvertToUserJobAction(this UserJobActionDto application) 
        {
            return new UserJobAction()
            {
                UserId = application.UserId,
                JobId = application.JobId,
                DateOfApplication = application.DateOfApplication,
                Id = application.Id,
            };
        }

        public static List<UserJobActionDto> ConvertListToApplicationDtos(this List<UserJobAction> applications)
        {
            return applications.Select(ConvertToUserJobActionDto).ToList();
        }

        public static List<UserJobAction> ConvertListToApplications(this List<UserJobActionDto> applicationDtos)
        {
            return applicationDtos.Select(ConvertToUserJobAction).ToList();
        }
    }
}
