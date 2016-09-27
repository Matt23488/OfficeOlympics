using OfficeOlympicsLib.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace OfficeOlympicsWeb.ViewModels
{
    public class CompetitorViewModel
    {
        public int CompetitorId { get; set; }
        
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [DisplayName("Name")]
        public string Name => $"{FirstName} {LastName}";

        public static CompetitorViewModel Build(Competitor competitor)
        {
            var viewModel = new CompetitorViewModel();

            viewModel.CompetitorId = competitor.Id;
            viewModel.FirstName = competitor.FirstName;
            viewModel.LastName = competitor.LastName;

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
            competitor.FirstName = FirstName;
            competitor.LastName = LastName;

            return competitor;
        }
    }
}