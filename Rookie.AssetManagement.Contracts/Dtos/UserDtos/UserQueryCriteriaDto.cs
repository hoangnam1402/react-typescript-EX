using System.Collections.Generic;

namespace Rookie.AssetManagement.Contracts.Dtos.UserDtos
{
    public class UserQueryCriteriaDto : BaseQueryCriteria
    {
        public int[] Types { get; set; }
        public int Id { get; set; }
    }
}
