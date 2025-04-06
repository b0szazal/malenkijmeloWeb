using MalenkijMelo.Share.Dtos;
using MalenkijMelo.Share.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalenkijMelo.Share.Converters
{
    public static class AdminActionConverter
    {
        public static AdminActionDto ConvertToAdminActionDto(this AdminAction adminAction)
        {
            return new AdminActionDto()
            {
                Id = adminAction.Id,
                ActionDate = adminAction.ActionDate,
                ActionDescription = adminAction.ActionDescription,
                ActionType = adminAction.ActionType,
                AdminId = adminAction.AdminId,
                AffectedId = adminAction.AffectedId,
            };
        }

        public static AdminAction ConvertToAdminAction(this AdminActionDto adminActionDto)
        {
            return new AdminAction()
            {
                Id= adminActionDto.Id,
                ActionDate = adminActionDto.ActionDate,
                ActionDescription = adminActionDto.ActionDescription,
                ActionType = adminActionDto.ActionType,
                AdminId = adminActionDto.AdminId,
                AffectedId = adminActionDto.AffectedId,
            };
        }

        public static List<AdminActionDto> ConvertListToAdminActionDtos(this List<AdminAction> adminActions)
        {
            return adminActions.Select(ConvertToAdminActionDto).ToList();
        }

        public static List<AdminAction> ConvertListToAdminActions(this List<AdminActionDto> adminActionDtos)
        {
            return adminActionDtos.Select(ConvertToAdminAction).ToList();
        }
    }
}
