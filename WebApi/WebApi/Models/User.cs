using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class User
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string Status { get; set; }
    }

    public class RebatePromotionHistory
    {
        public int Id { get; set; }
        public int rebate_campaign_seq { get; set; }
        public string active_date { get; set; }
        public string inactive_date { get; set; }
        public string cut_off_date { get; set; }
        public int TotalRecords { get; set; }
        public string PromoName { get; set; }
        public string Status { get; set; }
        public string Comments { get; set; }
        public string Date { get; set; }
        public string UpdatedBy { get; set; }
        public List<Promotion> PromotionList { get; set; }
    }

    public class Promotion
    {
        public Int64 rebate_campaign_seq { get; set; }       
        public string active_flag { get; set; }       
        public string Comments { get; set; }
        public string Date { get; set; }
        public string UpdatedBy { get; set; }
    }

    public class Model {
        public Int64 rebate_product_seq { get; set; }
        public string product_code { get; set; }
        public string product_name { get; set; }
        public string brand_name { get; set; }
        public string BaseUnit { get; set; }
        public string SalesUnit { get; set; }
        public string Product_Color { get; set; }
        public string SizeOption1 { get; set; }
        public string SizeOption2 { get; set; }
        public string SizeOption3 { get; set; }
        public string SizeOption4 { get; set; }
        public string SizeOption5 { get; set; }
        public string SizeOption6 { get; set; }
        public string SizeOption7 { get; set; }
    }

}