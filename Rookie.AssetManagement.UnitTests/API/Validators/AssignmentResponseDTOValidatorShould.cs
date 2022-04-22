using Rookie.AssetManagement.Contracts.Dtos.AssignmentDtos;
using Rookie.AssetManagement.DataAccessor.Enums;
using Rookie.AssetManagement.Tests.Validations;
using Rookie.AssetManagement.UnitTests.API.Validators.TestData;
using Rookie.AssetManagement.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Rookie.AssetManagement.UnitTests.API.Validators
{
    public class AssignmentResponseDTOValidatorShould : BaseValidatorShould
    {
        private readonly ValidationTestRunner<AssignmentResponseDTOValidator, AssignmentResponseDTO> _testRunner;
        public AssignmentResponseDTOValidatorShould()
        {
            _testRunner = ValidationTestRunner
               .Create<AssignmentResponseDTOValidator, AssignmentResponseDTO>(new AssignmentResponseDTOValidator());
        }

        [Theory]
        [MemberData(nameof(AssignmentTestData.ValidAssignmentResponseDTO), MemberType = typeof(AssignmentTestData))]
        public void HaveNoErrorWhenDTOIsValid(int assignmentId, AssignmentResponseEnum res)
        {
            _testRunner
                .For(m => m.AssignmentID = assignmentId)
                .ShouldNotHaveErrorsFor(m => m.AssignmentID);
            _testRunner
                .For(m => m.Response = res)
                .ShouldNotHaveErrorsFor(m => m.Response);

        }

        [Theory]
        [MemberData(nameof(AssignmentTestData.InvalidAssignmentID), MemberType = typeof(AssignmentTestData))]
        public void HaveErrorWhenAssignmentIDIsInvalid(int assignmentId,string msg) =>
        
            _testRunner
               .For(m => m.AssignmentID = assignmentId)
               .ShouldHaveErrorsFor(m => m.AssignmentID, msg);

        [Theory]
        [MemberData(nameof(AssignmentTestData.ValidResponse), MemberType = typeof(AssignmentTestData))]
        public void HaveNoErrorWhenResponseIsValid(AssignmentResponseEnum res) =>

           _testRunner
              .For(m => m.Response = res)
              .ShouldNotHaveErrorsFor(m => m.Response);


    }
}
