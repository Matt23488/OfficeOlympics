using OfficeOlympicsLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OfficeOlympicsWeb.ViewModels
{
    public class QuoteViewModel
    {
        public string Text { get; set; }
        public string Quoter { get; set; }

        public static QuoteViewModel Build(Quote quote)
        {
            var viewModel = new QuoteViewModel();

            viewModel.Text = quote.QuoteText;
            viewModel.Quoter = quote.Quoter;

            return viewModel;
        }
    }
}