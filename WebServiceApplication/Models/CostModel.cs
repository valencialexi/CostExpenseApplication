using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace WebServiceApplication.Models
{
    /// <summary>
    /// Class representation of the request
    /// </summary>
    public class CostModel
    {
        #region Constants
        private const double NZ_GST = .85;

        private const string UNKNOWN = "UNKNOWN";
        #endregion
        #region Declarations
        #endregion

        #region Properties
        public double TotalGSTAmount { get; set; }
        public double TotalAmountWithoutGST { get; set; }
        public string CostCenter { get; set; }

        #endregion

        #region Methods
        public static CostModel CalculateExtractedResult(XElement xmlElement)
        {
            CostModel model = new CostModel();
            model.TotalGSTAmount = Double.Parse(xmlElement.Element("total").Value);
            model.TotalAmountWithoutGST = model.TotalGSTAmount * NZ_GST;
            model.CostCenter = xmlElement.Element("cost_centre") != null ? xmlElement.Element("cost_centre").Value : UNKNOWN;
            return model;

        }
        #endregion
    }
}