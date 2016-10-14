using OfficeOlympicsLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OfficeOlympicsWeb.ViewModels
{
    public class EventBoardRecordViewModel
    {
        public CompetitorViewModel Competitor { get; set; }
        public ScoreViewModel Score { get; set; }

        public static EventBoardRecordViewModel Build(Record record)
        {
            var viewModel = new EventBoardRecordViewModel();

            viewModel.Competitor = CompetitorViewModel.Build(record.Competitor);
            viewModel.Score = ScoreViewModel.Build(record.Score, record.OlympicEvent.EventTypeId);

            return viewModel;
        }

        public static List<EventBoardRecordViewModel> BuildList(IEnumerable<Record> records)
        {
            var viewModelList = new List<EventBoardRecordViewModel>();

            foreach (var record in records)
            {
                viewModelList.Add(Build(record));
            }

            return viewModelList;
        }
    }
}