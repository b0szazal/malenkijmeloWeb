using BlazorBootstrap;
using MalenkijMelo.Services.IHttpClientServices;
using MalenkijMelo.Services;
using MalenkijMelo.Share.Assemblers;
using MalenkijMelo.Share.Dtos;
using MalenkijMelo.Share.Models;
using Microsoft.AspNetCore.Components;
using MalenkijMelo.Share.Converters;
using MudBlazor;
using System.Threading.Tasks;
using MalenkijMelo.Share.Models.Responses;

namespace MalenkijMelo.Web.Components.PageComponents
{
    public partial class EmployeeShowAppliedJobsSingleJob
    {
        [CascadingParameter(Name = "Application")]
        public UserJobActionDto? ApplicationDto { get; set; }

        private IUserJobActionHttpClientService? _userJobActionHttpService; 
        private IUserHttpClientService? _userHttpClientService;
        private IWorkplaceHttpClientService? _workplaceHttpClientService;
        private IJobHttpClientService? _jobHttpClientService;

        public User? Publisher { get; set; }
        private JobDto JobDto { get; set; } = new JobDto();

        public int Applicants { get; set; } = 0;

        private string CardStyle = "";
        public string JobTitle
        {
            get
            {
                if (Publisher != null)
                {
                    return Publisher.Name + ": " + JobDto!.JobName;
                }
                return "munkaadó nem található" + ": " + JobDto!.JobName;
            }
        }

        public string ShortJobDescription
        {
            get
            {
                if (JobDto!.JobDescription.Length > 75)
                {
                    return JobDto!.JobDescription.Substring(0, 75) + "...";
                }
                return JobDto!.JobDescription;
            }
        }

        public string JobWorkplace { get; set; } = "";


        protected override async void OnInitialized()
        {
            _userJobActionHttpService = new UserJobActionHttpClientService(new());
            _userHttpClientService = new UserHttpClientService(new());
            _workplaceHttpClientService = new WorkplaceHttpClientService(new());
            _jobHttpClientService = new JobHttpClientService(new());
            await Task.Run(() =>
            {
                JobDto = _jobHttpClientService!.GetByIdAsync(ApplicationDto!.JobId).Result.ConvertToJobDto();
                Applicants = _userJobActionHttpService!.GetNumberOfApplicants(JobDto!.JobId).Result;
                UserJobActionDto usj = _userJobActionHttpService!.GetPublisher(JobDto!.JobId).Result;
                Publisher = _userHttpClientService.GetByIdAsync(usj.UserId).Result;
                JobWorkplace = _workplaceHttpClientService.GetByIdAsync(JobDto!.WorkplaceId).Result.PlaceName;
            });
            modalTitle= Publisher!.Name + " értékelése";
        }

        private async Task RemoveApplication()
        {
            try
            {
                await _userJobActionHttpService!.DeleteAsync(ApplicationDto!.Id);
                Applicants--;
                Snackbar.Add("Sikeresen törölte a jelentkezését", Severity.Success);
            }
            catch (Exception)
            {
                Snackbar.Add("Hiba történt a jelentkezés törlése közben", Severity.Error);
            }
            CardStyle = "display: none;";
        }

        private Modal? modal;
        private bool alreadyRated = false;
        private string modalTitle = "Értékelés";
        private string ratingText = "";
        private int ratingValue = 0;
        private Rating rating = new Rating();

        private async Task OnShowModalClick()
        {
            IRatingHttpClientService ratingHttpClientService = new RatingHttpClientService(new());
            rating = await ratingHttpClientService.GetRatingByRaterAndRatedId(CurrentUser!.Id, Publisher!.Id);
            if (rating.Value > 0)
            {
                alreadyRated = true;
                ratingValue = (int)rating.Value;
                ratingText = rating.RatingText;
            }
            await modal!.ShowAsync();
        }

        private async Task OnHideModalClick()
        {
            await modal!.HideAsync();
        }

        private async Task RateEmployer()
        {
            try
            {
                IRatingHttpClientService ratingHttpClientService = new RatingHttpClientService(new());

                Rating rating = new Rating
                {
                    RatedID = Publisher!.Id,
                    RaterID = CurrentUser!.Id,
                    RatingText = ratingText,
                    Value = ratingValue
                };
                ControllerResponse res= await ratingHttpClientService.PostAsync(rating);
                if (res.HasError)
                {
                    Snackbar.Add("Hiba történt az értékelés közben", Severity.Error);
                }
                else
                {
                    Snackbar.Add("Sikeresen értékelted a munkaadót", Severity.Success);
                    alreadyRated = true;
                    await modal!.HideAsync();
                }
            }
            catch (Exception)
            {
                Snackbar.Add("Hiba történt az értékelés közben", Severity.Error);
            }
        }

        private async Task UpdateEmployerRating()
        {
            try
            {
                IRatingHttpClientService ratingHttpClientService = new RatingHttpClientService(new());

                ControllerResponse res= await ratingHttpClientService.PutAsync(rating);
                if(res.HasError)
                {
                    Snackbar.Add("Hiba történt az értékelés módosítása közben"+ res.Error, Severity.Error);
                }
                else
                {
                    Snackbar.Add("Sikeresen módosítottad az értékelést", Severity.Success);
                    await modal!.HideAsync();
                }
            }
            catch (Exception)
            {
                Snackbar.Add("Hiba történt az értékelés módosítása közben", Severity.Error);
            }
        }
    }
}
