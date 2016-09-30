using OfficeOlympicsLib.Models;
using OfficeOlympicsWeb.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OfficeOlympicsWeb.ViewModels
{
    public class CompetitorViewModel
    {
        [Required]
        public int CompetitorId { get; set; }
        
        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [Required]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [DisplayName("Active")]
        public bool IsActive { get; set; }

        [DisplayName("Full Name")]
        public string FullName => $"{FirstName} {LastName}";

        [DisplayName("Name")]
        public string FormattedName => $"{LastName}, {FirstName}";

        [DisplayName("Initials")]
        public string Initials => $"{FirstName[0]}{LastName[0]}";

        public CompetitorViewModel()
        {
            CompetitorId = 0;
            FirstName = string.Empty;
            LastName = string.Empty;
            IsActive = true;
        }

        public static CompetitorViewModel Build(Competitor competitor)
        {
            var viewModel = new CompetitorViewModel();

            viewModel.CompetitorId = competitor.Id;
            viewModel.FirstName = competitor.FirstName;
            viewModel.LastName = competitor.LastName;
            viewModel.IsActive = competitor.IsActive;

            return viewModel;
        }

        public static List<CompetitorViewModel> BuildList(IEnumerable<Competitor> competitors)
        {
            var viewModelList = new List<CompetitorViewModel>();

            foreach(var competitor in competitors)
            {
                viewModelList.Add(Build(competitor));
            }

            return viewModelList;
        }

        public Competitor Map()
        {
            var competitor = new Competitor();

            competitor.Id = CompetitorId;
            competitor.FirstName = FirstName.AsProperNoun();
            competitor.LastName = LastName.AsProperNoun();
            competitor.IsActive = IsActive;

            return competitor;
        }
    }
}