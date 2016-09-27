using OfficeOlympicsLib.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace OfficeOlympicsWeb.ViewModels
{
    public class RecordViewModel
    {
        public int RecordId { get; set; }

        [DisplayName("Competitor")]
        public CompetitorViewModel Competitor { get; set; }

        [DisplayName("Event")]
        public string Event { get; set; }

        [DisplayName("Record (in seconds/reps)")]
        public ScoreViewModel Score { get; set; }

        [DisplayName("Date Achieved")]
        public DateTime DateAchieved { get; set; }

        [DisplayName("Witness 1")]
        public CompetitorViewModel Witness1 { get; set; }

        [DisplayName("Witness 2")]
        public CompetitorViewModel Witness2 { get; set; }

        public RecordViewModel()
        {
            Competitor = new CompetitorViewModel();
            Score = new ScoreViewModel();
            Witness1 = new CompetitorViewModel();
            Witness2 = new CompetitorViewModel();
        }

        public static RecordViewModel Build(Record record)
        {
            var viewModel = new RecordViewModel();

            var witnessList = record.Witnesses.Select(obj => obj.Competitor).ToList();

            viewModel.RecordId = record.Id;
            viewModel.Competitor = CompetitorViewModel.Build(record.Competitor);
            viewModel.Event = record.OlympicEvent.EventName;
            viewModel.Score = ScoreViewModel.Build(record.Score, record.OlympicEvent.EventTypeId);
            viewModel.DateAchieved = record.DateAchieved;
            viewModel.Witness1 = CompetitorViewModel.Build(witnessList[0]);
            viewModel.Witness2 = CompetitorViewModel.Build(witnessList[1]);

            return viewModel;
        }

        public static List<RecordViewModel> BuildList(IEnumerable<Record> records)
        {
            var viewModelList = new List<RecordViewModel>();

            foreach (var record in records)
            {
                viewModelList.Add(Build(record));
            }

            return viewModelList;
        }
    }
}