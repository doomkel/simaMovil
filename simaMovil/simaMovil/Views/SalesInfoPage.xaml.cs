using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using simaMovil.Models;
using simaMovil.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using DevExpress.XamarinForms;
using DevExpress.XamarinForms.DataGrid;



namespace simaMovil.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SalesInfoPage : ContentPage
    {
        public SalesInfoPage()
        {
            InitializeComponent();
            BindingContext = ActivatorUtilities.CreateInstance<SalesInfoViewModel>(Startup.ServiceProvider);
        }


        decimal vtasact;
        decimal vtasap;
        decimal meta;
        private void dgSales_CalculateCustomSummary(object sender, CustomSummaryEventArgs e)
        {
            if (e.FieldName.ToString() == "VentaAct")
            {
                if (e.IsTotalSummary)
                {
                    if (e.SummaryProcess == CustomSummaryProcess.Start)
                    {
                        vtasact = 0;
                    }
                    if (e.SummaryProcess == CustomSummaryProcess.Calculate)
                    {
                        vtasact += decimal.Parse(e.FieldValue.ToString());
                        e.TotalValue = vtasact;
                    }
                }
            }

            if (e.FieldName.ToString() == "VentaAP")
            {
                if (e.IsTotalSummary)
                {
                    if (e.SummaryProcess == CustomSummaryProcess.Start)
                    {
                        vtasap = 0;
                    }
                    if (e.SummaryProcess == CustomSummaryProcess.Calculate)
                    {
                        vtasap += decimal.Parse(e.FieldValue.ToString());
                        e.TotalValue = vtasap;
                    }
                }
            }

            if (e.FieldName.ToString() == "Meta")
            {
                if (e.IsTotalSummary)
                {
                    if (e.SummaryProcess == CustomSummaryProcess.Start)
                    {
                        meta = 0;
                    }
                    if (e.SummaryProcess == CustomSummaryProcess.Calculate)
                    {
                        meta += decimal.Parse(e.FieldValue.ToString());
                        e.TotalValue = meta;
                    }
                }
            }


            if (e.FieldName.ToString() == "Ptje")
            {
                if (e.IsTotalSummary)
                {
                    if (e.SummaryProcess == CustomSummaryProcess.Finalize)
                    {
                        e.TotalValue = (vtasact - vtasap) / vtasap;
                    }
                }
            }

            if (e.FieldName.ToString() == "PtjeMeta")
            {
                if (e.IsTotalSummary)
                {
                    if (e.SummaryProcess == CustomSummaryProcess.Finalize)
                    {
                        e.TotalValue = (vtasact - meta) / meta;
                    }
                }
            }
        }

        private void dgSales_CustomCellStyle(object sender, CustomCellStyleEventArgs e)
        {
            if (e.RowHandle % 2 == 0)
            {
                e.BackgroundColor = Color.FromHex("#F7F7F7");
            }

            if (e.FieldName == "Ptje" || e.FieldName == "PtjeMeta")
            {
                decimal value = (decimal)dgSales.GetCellValue(e.RowHandle, e.FieldName);

                if (value > 0)
                {
                    e.BackgroundColor = Color.LightGreen;
                }
                else
                {
                    e.BackgroundColor = Color.LightCoral;
                }

            }
        }
    }
}