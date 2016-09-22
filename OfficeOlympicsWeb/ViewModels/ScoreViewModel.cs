using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OfficeOlympicsWeb.ViewModels
{
    public class ScoreViewModel
    {
        public int Score { get; set; }
        public int EventType { get; set; }

        public static ScoreViewModel Build(int score, int eventType)
        {
            var viewModel = new ScoreViewModel();

            viewModel.Score = score;
            viewModel.EventType = eventType;

            return viewModel;
        }
    }
}