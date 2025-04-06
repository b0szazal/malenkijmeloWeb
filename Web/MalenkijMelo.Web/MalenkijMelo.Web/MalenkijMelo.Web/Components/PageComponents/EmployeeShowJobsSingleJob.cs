using BlazorBootstrap;
using MalenkijMelo.Services;
using MalenkijMelo.Services.IHttpClientServices;
using MalenkijMelo.Share.Assemblers;
using MalenkijMelo.Share.Dtos;
using MalenkijMelo.Share.Models;
using MalenkijMelo.Share.Models.Responses;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using MudBlazor;
using System.Threading.Tasks;

namespace MalenkijMelo.Web.Components.PageComponents
{
    public partial class EmployeeShowJobsSingleJob
    {
        [CascadingParameter(Name = "Job")]
        public JobDto? Job { get; set; }

        [Inject]
        public IUserJobActionHttpClientService? HttpService { get; set; }

        private IUserHttpClientService? _httpClientService;
        private IWorkplaceHttpClientService? _workplaceHttpClientService;
        private IRatingHttpClientService? _ratingHttpClientService;

        public User? Publisher { get; set; }

        public int Applicants { get; set; } = 0;

        public string? OuterCardStyle { get; set; } = "width: 450px; height: 325px;";

        public string JobTitle
        {
            get
            {
                if (Publisher != null)
                {
                    return Publisher.Name + ": " + Job!.JobName;
                }
                return "munkaadó nem található" + ": " + Job!.JobName;
            }
        }

        public string ShortJobDescription
        {
            get
            {
                if (Job!.JobDescription.Length > 75)
                {
                    return Job!.JobDescription.Substring(0, 75) + "...";
                }
                return Job!.JobDescription;
            }
        }

        public string JobWorkplace { get; set; } = "";
        private double _ratingAvg;
        

        protected override async void OnInitialized()
        {
            HttpService = new UserJobActionHttpClientService(new UserJobActionAssembler());
            _httpClientService = new UserHttpClientService(new());
            _workplaceHttpClientService = new WorkplaceHttpClientService(new());
            _ratingHttpClientService = new RatingHttpClientService(new());
            await Task.Run(() =>
            {
                Applicants = HttpService!.GetNumberOfApplicants(Job!.JobId).Result;
                UserJobActionDto usj = HttpService!.GetPublisher(Job!.JobId).Result;
                Publisher = _httpClientService.GetByIdAsync(usj.UserId).Result;
                JobWorkplace = _workplaceHttpClientService.GetByIdAsync(Job!.WorkplaceId).Result.PlaceName;
                _ratingAvg = _ratingHttpClientService.GetUserRatingAvg(CurrentUser!.Id).Result;
            });
            if (_ratingAvg == 0 || _ratingAvg==-1)
            {
                OuterCardStyle += "background-color: grey;";
            }
            else if(_ratingAvg <= 3)
            {
                OuterCardStyle += "background-color: black;";
            }
            else if (Applicants >= 100)
            {
                OuterCardStyle += "background-color: crimson;";
            }
            else if(Applicants >= 10)
            {
                OuterCardStyle += "background-color: orange;";
            }
            else if (Job!.IsPaymentMoney == false)
            {
                OuterCardStyle += "background-color: yellow;";
            }
            else
            {
                OuterCardStyle += "background-color: green;";
            }
        }

        private Modal? modal;

        private async Task OnShowModalClick()
        {
            await modal!.ShowAsync();
        }

        private async Task OnHideModalClick()
        {
            await modal!.HideAsync();
        }

        private async Task ApplyForJobClick()
        {
            if (!await CheckIfAlreadyApplied())
            {
                ControllerResponse response =
                await HttpService!.PostAsync(new UserJobAction()
                {
                    JobId = Job!.JobId,
                    UserId = CurrentUser!.Id,
                    DateOfApplication = System.DateTime.UtcNow,
                    Id = Guid.CreateVersion7().ToString()
                });
                if (response.HasError)
                {
                    Snackbar.Add(response.Error, Severity.Error);
                }
                else
                {
                    Applicants++;
                    Snackbar.Add("Sikeres jelentkezés", Severity.Success);
                }
            }
            else
            {
                Snackbar.Add("Erre a munkára már jelentkezett", Severity.Warning);
            }
            await modal!.HideAsync();
        }

        private async Task<bool> CheckIfAlreadyApplied()
        {
            UserJobActionDto usj = await HttpService!.GetUserJobActionByBothJobAndUserIds(Job!.JobId , CurrentUser!.Id);
            if(usj.UserId == CurrentUser.Id && usj.JobId == Job.JobId)
            {
                return true;
            }
            return false;
        }
    }
}
