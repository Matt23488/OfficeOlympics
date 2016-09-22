﻿using OfficeOlympicsLib.Models;
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

        [DisplayName("Record Holder")]
        public string RecordHolder { get; set; }

        [DisplayName("Event")]
        public string Event { get; set; }

        [DisplayName("Record (in seconds/reps)")]
        public ScoreViewModel Score { get; set; }

        [DisplayName("Date Achieved")]
        public DateTime DateAchieved { get; set; }

        [DisplayName("Witnesses")]
        public List<string> Witnesses { get; set; }

        public RecordViewModel()
        {
            Score = new ScoreViewModel();
            Witnesses = new List<string>()
            {
                string.Empty,
                string.Empty
            };
        }

        public static RecordViewModel Build(Record record)
        {
            var viewModel = new RecordViewModel();

            viewModel.RecordId = record.Id;
            viewModel.RecordHolder = record.RecordHolder;
            viewModel.Event = record.OlympicEvent.EventName;
            viewModel.Score = ScoreViewModel.Build(record.Score, record.OlympicEvent.EventTypeId);
            viewModel.DateAchieved = record.DateAchieved;
            viewModel.Witnesses = new List<string>()
            {
                record.Witness1,
                record.Witness2
            };

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