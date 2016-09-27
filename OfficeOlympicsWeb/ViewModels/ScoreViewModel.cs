using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OfficeOlympicsWeb.ViewModels
{
    public class ScoreViewModel
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int? Score { get; set; }
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