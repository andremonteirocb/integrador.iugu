using System.Collections.Generic;

namespace Integrador.Iugu.Entity
{

    public class PlanModelsList
    {
        public int TotalItems { get; set; }
        public PlanModel[] Items { get; set; }
    }
    
    public class PlanModel
    {
        public string id { get; set; }
        public string name { get; set; }
        public string identifier { get; set; }
        public int interval { get; set; }
        public string interval_type { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
        public List<PlanPrice> prices { get; set; }
        public List<PlanFeature> features { get; set; }
    }

    
    public class PlanPrice
    {
        public string created_at { get; set; }
        public string currency { get; set; }
        public string id { get; set; }
        public string plan_id { get; set; }
        public string updated_at { get; set; }
        public int value_cents { get; set; }
    }

    
    public class PlanFeature
    {
        public string created_at { get; set; }
        public string id { get; set; }
        public string identifier { get; set; }
        public object important { get; set; }
        public string name { get; set; }
        public string plan_id { get; set; }
        public int position { get; set; }
        public string updated_at { get; set; }
        public int value { get; set; }
    }
}
