using OfficeOlympicsLib.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace OfficeOlympicsWeb.ViewModels
{
    public class CompetitorListViewModel
    {
        public List<CompetitorViewModel> Competitors { get; set; }

        [DisplayName("Active")]
        public IEnumerable<CompetitorViewModel> ActiveCompetitors => Competitors.Where(obj => obj.IsActive);

        [DisplayName("Inactive")]
        public IEnumerable<CompetitorViewModel> InactiveCompetitors => Competitors.Where(obj => !obj.IsActive);

        public static CompetitorListViewModel Build(IEnumerable<Competitor> competitors)
        {
            var viewModel = new CompetitorListViewModel();

            viewModel.Competitors = CompetitorViewModel.BuildList(competitors);

            return viewModel;
        }
    }
}