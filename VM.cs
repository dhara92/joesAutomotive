using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Joe_Automotive 
{
    class VM : INotifyPropertyChanged
    {
        public const decimal OIL_CHARGES = 26;
        public const decimal LUBE_CHARGES = 18;
        public const decimal RADIATOR_CHARGES = 30;
        public const decimal TRANSMISSION_CHARGES = 80;
        public const decimal INSPECTION_CHARGES = 15;
        public const decimal MUFFLER_CHARGES = 100;
        public const decimal TIRE_CHARGES = 20;
        public const decimal LABOR_CHARGES = 20;
        public const decimal TAX_RATE = 0.06m;


        public bool oilChange;
        bool lubeChange;
        bool radiator;
        bool inspection;
        bool transmission;
        bool tireRotation;
        bool mufflerChange;

        string oilLubeTotal;
        string flushTotal;
        string miscTotal;
        string otherTotal;
        string taxTotal;
        string finalTotal;

        int hours;
        decimal partCharges;
        public bool OilChange
        {
            get { return oilChange; }
            set { oilChange = value; onChange(); }
        }

        public bool LubeJob
        {
            get { return lubeChange; }
            set { lubeChange = value; onChange(); }
        }

        public bool RadiatorFlush
        {
            get { return radiator; }
            set { radiator = value; onChange(); }
        }

        public bool Inspection
        {
            get { return inspection; }
            set { inspection = value; onChange(); }
        }

        public bool Transmission
        {
            get { return transmission; }
            set { transmission = value;onChange(); }
        }

        public bool MufflerChange
        {
            get { return mufflerChange; }
            set { mufflerChange = value;onChange(); }
        }

        public bool TireRotation
        {
            get { return tireRotation; }
            set { tireRotation = value; onChange(); }
        }

        public string OilLubeTotal
        {
            get { return oilLubeTotal; }
            set { oilLubeTotal = value; onChange(); }
        }
        public string FlushTotal
        {
            get { return flushTotal; }
            set { flushTotal = value; onChange(); }
        }
        public string MiscTotal
        {
            get { return miscTotal; }
            set { miscTotal = value; onChange(); }
        }
        public string OtherTotal
        {
            get { return otherTotal; }
            set { otherTotal = value; onChange(); }
        }

        public string TaxTotal 
        {
            get { return taxTotal; }
            set { taxTotal = value; onChange(); }
        }
        public string FinalTotal
        {
            get { return finalTotal; }
            set { finalTotal = value; onChange(); }
        }

        public int Hours
        {
            get { return hours; }
            set { hours = value; onChange(); }
        }
        public decimal PartCharges
        {
            get { return partCharges; }
            set { partCharges = value; onChange(); }
        }
        public decimal OilLubeCharges()
        {
            decimal total = 0;
            if (OilChange)
                total += OIL_CHARGES;
            if (LubeJob)
                total += LUBE_CHARGES;
            return total;
        }
        public decimal FlushCharges()
        {
            decimal total = 0;
            if (RadiatorFlush)
                total += RADIATOR_CHARGES;
            if (Transmission)
                total += TRANSMISSION_CHARGES;
            return total;
        }
        public decimal MiscCharges()
        {
            decimal total = 0;
            if (Inspection)
                total += INSPECTION_CHARGES;
            if (MufflerChange)
                total += MUFFLER_CHARGES;
            if (TireRotation)
                total += TIRE_CHARGES;
            return total;
        }

        public decimal OtherCharges()
        {
            decimal total = 0;
            try
            {
                if (Hours > 0)
                 total = ((LABOR_CHARGES) * Hours);

                if (PartCharges > 0)
                    total += PartCharges + TaxCharges();
            }
            catch
            {
                MessageBox.Show("Please Enter valid Value");
            }
          
            return total;
        }
        public decimal TaxCharges()
        {
            decimal taxes = 0;
            if (PartCharges > 0)
                taxes = PartCharges * TAX_RATE;
            return taxes;
        }
        public decimal TotalCharges()
        {
            decimal total = OilLubeCharges() + FlushCharges() + MiscCharges() + OtherCharges();
            return total;
        }
        public void ClearOilLube()
        {
            OilChange = false;
            LubeJob = false;
        }
        public void ClearFlushes()
        {
            RadiatorFlush = false;
            Transmission = false;
        }
        public void ClearMisc()
        {
            Inspection = false;
            MufflerChange = false;
            TireRotation = false;
        }
        public void ClearOther()
        {
            PartCharges = 0;
            Hours = 0;
        }
        public void FinalTotalView()
        {

            PartCharges = 0;
            OilLubeTotal = "";
            FlushTotal = "";
            MiscTotal = "";
            OtherTotal = "";
            TaxTotal = "";
            FinalTotal = "";

        }
        public void Calculate()
        {
            OilLubeTotal = Math.Round(OilLubeCharges(), 2).ToString("C");
            FlushTotal = Math.Round(FlushCharges(), 2).ToString("C");
            MiscTotal = Math.Round(MiscCharges(), 2).ToString("C");
            OtherTotal = Math.Round(OtherCharges(), 2).ToString("C");
            TaxTotal = Math.Round(TaxCharges(), 2).ToString("C");
            FinalTotal = Math.Round(TotalCharges(), 2).ToString("C");
          /*  PartChargesVal = Math.Round(PartCharges, 2).ToString("C") + " + " + TaxChargesVal;
            PartTotalVal = Math.Round((PartCharges + TaxCharges()), 2).ToString("C");
            GridResultVis = true;
            GridSelectVis = false;
            TitleHeight = SINGLE_HEIGHT;
            TitleWidth = SINGLE_WIDTH;*/
        }

        public void ClearAll()
        {
            ClearOilLube();
            ClearFlushes();
            ClearMisc();
            ClearOther();
            FinalTotalView();
           
        }


        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void onChange([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
