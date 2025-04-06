using BlazorBootstrap;
using MalenkijMelo.Services.IHttpClientServices;
using MalenkijMelo.Services;
using MalenkijMelo.Share.Models.Responses;
using MalenkijMelo.Share.Models;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace MalenkijMelo.Web.Components.PageComponents
{
    public partial class ApplicantsCard
    {
        [CascadingParameter(Name = "User")]
        public User? User { get; set; }

        private Modal? modal;

        private string modalTitle = $"Értékelés";

        private int ratingValue = 0;
        private string ratingText = "";
        private bool alreadyRated = false;
        private Rating rating = new();

        private async Task OnShowModalClick()
        {
            IRatingHttpClientService ratingHttpClientService = new RatingHttpClientService(new());
            rating = await ratingHttpClientService.GetRatingByRaterAndRatedId(CurrentUser!.Id, User!.Id);
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

        private async Task RateEmployee()
        {
            try
            {
                IRatingHttpClientService ratingHttpClientService = new RatingHttpClientService(new());

                Rating rating = new Rating
                {
                    RatedID = User!.Id,
                    RaterID = CurrentUser!.Id,
                    RatingText = ratingText,
                    Value = ratingValue
                };
                ControllerResponse res = await ratingHttpClientService.PostAsync(rating);
                if (res.HasError)
                {
                    Snackbar.Add("Hiba történt az értékelés közben", Severity.Error);
                }
                else
                {
                    Snackbar.Add("Sikeresen értékelted a munkavállalót", Severity.Success);
                    alreadyRated = true;
                    await modal!.HideAsync();
                }
            }
            catch (Exception)
            {
                Snackbar.Add("Hiba történt az értékelés közben", Severity.Error);
            }
        }

        private async Task UpdateEmployeeRating()
        {
            try
            {
                IRatingHttpClientService ratingHttpClientService = new RatingHttpClientService(new());

                ControllerResponse res = await ratingHttpClientService.PutAsync(rating);
                if (res.HasError)
                {
                    Snackbar.Add("Hiba történt az értékelés módosítása közben" + res.Error, Severity.Error);
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
